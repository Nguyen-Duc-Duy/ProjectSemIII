using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Project.Views.Pays
{
    public partial class PaysView : System.Windows.Forms.Form
    {
        ConnectDatabaseDataContext managerHotel = new ConnectDatabaseDataContext();
        Employee employee;
        public PaysView(Employee e)
        {
            employee = e;
            managerHotel = new ConnectDatabaseDataContext();
            InitializeComponent();
            InterfaceDefault();
            button3.Visible = false;
        }

        int idCustomer = 0;
        public PaysView(int idCus, Employee e)
        {
            idCustomer = idCus;
            employee = e;
            managerHotel = new ConnectDatabaseDataContext();
            InitializeComponent();
            RoomsServices(idCustomer);
            HideDataCus();
            ShowInforCus();
        }
        //giao diện mặc định
        private void InterfaceDefault()
        {
            BoxInforCus.Visible = false;
            BoxRooms.Visible = false;
            panel1.Visible = false;
        }
        //giao diện khi hóa đơn đã thanh toán
        private void InterBilled(int idBill)
        {
            var bill = managerHotel.Bills.Where(x => x.id == idBill).FirstOrDefault();
            if (bill.stt == 1)
            {
                button3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
            }

        }
        private void Pays_Load(object sender, EventArgs e)
        {

        }
        //hiển thị thông tin khách hàng
        private void ShowInforCus()
        {
            BoxInforCus.Visible = true;

            panel1.Visible = true;
            var cus = managerHotel.Customers.Where(x => x.id == idCustomer).FirstOrDefault();
            labelNationCus.Text = cus.Country.CommonName;
            labelCusName.Text = cus.name;
            labelNameCus.Text = cus.name;
            labelPhoneCus.Text = cus.phone;
            labelCardCus.Text = cus.car_personal;
            labelChildren.Text = cus.childrens.ToString();
            labelAdult.Text = cus.adults.ToString();
        }
        System.Globalization.CultureInfo cull = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
        //hiển thị phòng và dịch vụ của khách đã dùng
        float total = 0;
        int valPrepay = 0;
        int idBill = 0;
        private void RoomsServices(int idCus)
        {
            button3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            total = 0;
            ShowInforCus();
            BoxRooms.Visible = true;
            foreach (Control item in BoxRooms.Controls)
            {
                BoxRooms.Controls.Remove(item);
            }

            var BillCus = managerHotel.Bills.Where(x => x.id_cus == idCus).FirstOrDefault();
            idBill = BillCus.id;
            labelDateFrom.Text = BillCus.dateFrom;
            labelDateTo.Text = BillCus.dateTo;
            labelPrepay.Text = double.Parse(BillCus.Prepay.ToString()).ToString("#,###", cull.NumberFormat);
            valPrepay = (int)BillCus.Prepay;
            InterBilled(BillCus.id);
            //lấy ngày bắt đầu và kết thúc để tính tiền 
            DateTime start = Convert.ToDateTime(BillCus.dateFrom);
            DateTime end = Convert.ToDateTime(BillCus.dateTo);
            TimeSpan rangeDate = end - start;

            var BillDetailRoom = managerHotel.Details_Bills.Where(x => x.id_bill == BillCus.id).Select(x => x.id_room);
            int number = 0;
            int tam = 0;
            foreach (int idR in BillDetailRoom)
            {
                if (tam != idR)
                {
                    tam = idR;
                    number++;
                    //Details_Bill id = (Details_Bill) idR;
                    var room = managerHotel.Rooms.Where(x => x.id == idR).FirstOrDefault();
                    GroupBox gb = new GroupBox();
                    gb = RoomBilling.Clone();
                    gb.Text = "Phòng " + room.name;
                    gb.Visible = true;
                    gb.Name = RoomBilling.Name + number;
                    BoxRooms.Controls.Add(gb);
                    gb.Height = 350;
                    RoomBilling.Visible = false;

                    Label l = new Label();
                    l.Text = "Danh sách Dịch Vụ";
                    l.ForeColor = Color.FromArgb(240, 171, 38);
                    l.Location = new Point(20, 50);
                    gb.Controls.Add(l);

                    DataGridView dataSer = new DataGridView();
                    dataSer.Size = new Size(569, 150);
                    dataSer.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                    dataSer.Location = new Point(20, 80);
                    dataSer.ColumnCount = 5;
                    dataSer.Columns[0].Name = "id";
                    dataSer.Columns[1].Name = "STT";
                    dataSer.Columns[2].Name = "Tên Dịch vụ";
                    dataSer.Columns[3].Name = "Giá";
                    dataSer.Columns[4].Name = "Khuyến Mại";

                    dataSer.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataSer.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataSer.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataSer.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataSer.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    dataSer.Columns[0].Visible = false;

                    var detaiBill = managerHotel.Details_Bills.Where(x => x.id_bill == BillCus.id && x.id_room == Convert.ToInt32(idR));
                    int num = 0;
                    float totalSer = 0;
                    foreach (var ser in detaiBill)
                    {
                        num++;
                        var service = managerHotel.Servicers.Where(x => x.id == ser.id_ser).FirstOrDefault();
                        string[] row = new string[] { service.id.ToString(), num.ToString(), service.name, service.price.ToString(), service.sale.ToString() };
                        dataSer.Rows.Add(row);

                        totalSer = totalSer + (float)(service.price - service.sale);


                    }

                    float totalRoom = (float)(totalSer + room.Types_Room.moneys);
                    total += totalRoom;
                    Label titleTotalSer = new Label();
                    titleTotalSer.Text = "Tổng tiền dịch vụ :";
                    titleTotalSer.ForeColor = Color.FromArgb(240, 171, 38);
                    titleTotalSer.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    titleTotalSer.Location = new Point(20, 260);
                    titleTotalSer.AutoSize = true;

                    var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
                    System.Globalization.CultureInfo cul = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");

                    Label TextTotalSer = new Label();
                    TextTotalSer.Text = totalSer.ToString("#,###", cul.NumberFormat) + "VND";
                    TextTotalSer.ForeColor = Color.FromArgb(145, 149, 153);
                    TextTotalSer.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    TextTotalSer.Location = new Point(210, 260);
                    TextTotalSer.AutoSize = true;

                    Label titlePriceRoom = new Label();
                    titlePriceRoom.Text = "Tiền phòng :";
                    titlePriceRoom.ForeColor = Color.FromArgb(240, 171, 38);
                    titlePriceRoom.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    titlePriceRoom.Location = new Point(20, 300);
                    titlePriceRoom.AutoSize = true;

                    Label textPriceRoom = new Label();
                    textPriceRoom.Text = room.Types_Room.moneys.ToString("#,###", cul.NumberFormat) + "VND";
                    textPriceRoom.ForeColor = Color.FromArgb(145, 149, 153);
                    textPriceRoom.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    textPriceRoom.Location = new Point(210, 300);
                    textPriceRoom.AutoSize = true;

                    Label titleTotalRoom = new Label();
                    titleTotalRoom.Text = "Tổng tiền Phòng :";
                    titleTotalRoom.ForeColor = Color.FromArgb(240, 171, 38);
                    titleTotalRoom.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    titleTotalRoom.Location = new Point(370, 300);
                    titleTotalRoom.AutoSize = true;

                    Label textTotalRoom = new Label();
                    textTotalRoom.Text = totalRoom.ToString("#,###", cul.NumberFormat) + "VND";
                    textTotalRoom.ForeColor = Color.FromArgb(145, 149, 153);
                    textTotalRoom.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    textTotalRoom.Location = new Point(520, 300);
                    textTotalRoom.AutoSize = true;

                    gb.Controls.Add(titleTotalSer);
                    gb.Controls.Add(titlePriceRoom);
                    gb.Controls.Add(titleTotalRoom);
                    gb.Controls.Add(textTotalRoom);
                    gb.Controls.Add(textPriceRoom);
                    gb.Controls.Add(TextTotalSer);

                    gb.Controls.Add(dataSer);
                }
            }
            total = total * rangeDate.Days;
            string outPay = (BillCus.Prepay - total).ToString();
            labelOutPay.Text = double.Parse(outPay.ToString()).ToString("#,###", cull.NumberFormat);


            labelTotal.Text = double.Parse(total.ToString()).ToString("#,###", cull.NumberFormat);
        }

        //chức năng thanh toán
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (outPay != "" | Convert.ToInt32(outPay) >= 0)
                {
                    float Pay = (float)Convert.ToDouble(textInPay.Text);
                    var bill = managerHotel.Bills.Where(x => x.id == idBill).FirstOrDefault();
                    bill.stt = 1;
                    bill.InputMoney = Pay;
                    managerHotel.SubmitChanges();
                    var billDetail = managerHotel.Details_Bills.Where(x => x.id_bill == bill.id).Select(x => x);
                    foreach (Details_Bill item in billDetail)
                    {
                        var room = managerHotel.Rooms.Where(x => x.id == item.id_room).FirstOrDefault();
                        room.stt = 0;
                        managerHotel.SubmitChanges();
                    }
                    MessageBox.Show("Thanh toán thành công !");
                }
                else
                {
                    MessageBox.Show("Thanh toán Thất bại !");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("lỗi hệ thống xin thử lại ! Thanh toán thất bại !" + ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            HideDataCus();
        }

        private void PaysView_Resize(object sender, EventArgs e)
        {
            foreach (Control item in BoxRooms.Controls)
            {
                item.Width = BoxRooms.Width;
            }

        }
        //ẩn danh sách khách hàng
        private void HideDataCus()
        {
            BoxResoultSearch.Visible = false;
            panel1.Location = new Point(5, 51);
            BoxInforCus.Location = new Point(5, 84);
            BoxRooms.Location = new Point(5, 157);
        }
        //hiện danh sách khách hàng
        private void ShowDataCus()
        {
            BoxResoultSearch.Visible = true;
            panel1.Location = new Point(5, 177);
            BoxInforCus.Location = new Point(5, 210);
            BoxRooms.Location = new Point(5, 283);
            string nameCus = NameSearch.Text;
            var dataCus = managerHotel.Customers.Where(x => x.name.Contains(nameCus)).Select(x => new
            {
                id = x.id,
                name = x.name,
                car_personal = x.car_personal,
                phone = x.phone,
                stt = x.stt == 1 ? "Đã thanh toán" : "Chưa thanh toán"
            });

            dataSearch.DataSource = dataCus;
        }

        //chức năng tìm khách hàng
        private void button1_Click(object sender, EventArgs e)
        {
            ShowDataCus();

        }

        private void PaysView_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells["STTSer"].Value = (e.RowIndex + 1).ToString();
        }

        private void dataSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataSearch_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dataSearch.Rows[e.RowIndex].Cells["STT"].Value = (e.RowIndex + 1).ToString();

        }

        private void dataSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //sự kiện nhập tiền nhận
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
            if (e.KeyChar == (char)13)
            {
                textInPay.Text = string.Format("{0:n0}", double.Parse(textInPay.Text));
            }
        }
        string outPay = "";
        private void textInPay_KeyUp(object sender, KeyEventArgs e)
        {

            if (textInPay.Text != "")
            {
                string Pay = string.Format("{0:#;minus #}", double.Parse(textInPay.Text));

                int inPay = Convert.ToInt32(Pay);
                outPay = (inPay - (total - Convert.ToInt32(valPrepay))).ToString();
                labelOutPay.Text = double.Parse(outPay.ToString()).ToString("#,###", cull.NumberFormat);
            }

        }
        //xuất hóa đơn
        //tạo file excel

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataSearch_SelectionChanged(object sender, EventArgs e)
        {
            BoxInforCus.Visible = true;
            BoxRooms.Visible = true;
            panel1.Visible = true;
            int idCusOfdataCus = (int)dataSearch.CurrentRow.Cells["id"].Value;
            idCustomer = idCusOfdataCus;
            RoomsServices(idCusOfdataCus);
        }
    }
}
