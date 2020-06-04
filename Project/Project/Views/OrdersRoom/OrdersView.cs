using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Project.Views.OrdersRoom
{
    public partial class OrdersView : Form
    {
        ConnectDatabaseDataContext db = new ConnectDatabaseDataContext();

        Employee employee;
        public OrdersView(Employee e)
        {
            employee = e;
            InitializeComponent();
            ShowDataCountry();

            InterfaceDefaultOrder();
        }
        //phương thức khởi tạo khi nhận phòng
        int idCusOld;
        public OrdersView(int idCus, Employee e)
        {
            idCusOld = idCus;
            employee = e;
            InitializeComponent();
            ShowDataCountry();

            InterfaceDefaultOrder();

        }
        ////dữ liệu quốc gia
        private void ShowDataCountry()
        {
            var country = db.Countries.Select(x => x);
            comboBoxCountry.DisplayMember = "CommonName";
            comboBoxCountry.ValueMember = "id";
            comboBoxCountry.DataSource = country;
        }
        //giao diện mặc định khi đặt phòng 
        private void InterfaceDefaultOrder()
        {
            // giá tri các form
            CusName.Clear();
            InputCard.Clear();
            InputSDT.Clear();
            InputDescripsBill.Clear();
            numericAdult.Value = 0;
            numeriChildrent.Value = 0;
            numericPrepay.Text = "0";
            DataRooms.Rows.Clear();
            comboBoxCountry.SelectedIndex = 0;
            // sự kiển hiển thị popup chọn dịch vụ
            popupRoom.ItemClicked += new ToolStripItemClickedEventHandler(click_popupItem);
        }

        private void OrdersView_Load(object sender, EventArgs e)
        {

        }
        //dữ liệu của phòng có thể đặt
        private void VableRooms()
        {
            DateTime dateNow = DateTime.Now;
            //giá trị ngày
            DateTime dateForm = dateTimeForm.Value;
            DateTime dateTo = dateTimeTo.Value;
            //giá trị người lớn, trẻ nhỏ
            int adult = (int)numericAdult.Value;
            int childrent = (int)numeriChildrent.Value;
            if (adult > 0 | childrent > 0)
            {
                if (dateForm >= dateNow | dateTo >= dateNow)
                {
                    if (Convert.ToDateTime(dateForm) < Convert.ToDateTime(dateTo))
                    {
                        //hiển thị dữ liệu phòng phù hợp
                        var RoomAble = db.RoomsAble(dateForm.ToString("yyyy-MM-dd"), dateTo.ToString("yyyy-MM-dd"), adult, childrent);
                        DataRooms.DataSource = RoomAble;
                        managerHotel.manager.label_load("", "icons8_checked_32.png", Color.FromArgb(0, 192, 0));
                    }
                    else
                    {
                        //thông báo lỗi
                        managerHotel.manager.label_load("Ngày bắt đầu và ngày kết thúc không thê trùng !", "icons8_high_priority_32.png", Color.FromArgb(255, 0, 0));
                    }
                }
                else
                {
                    //thông báo lỗi
                    managerHotel.manager.label_load("Không thể chọn ngày trong quá khứ !", "icons8_high_priority_32.png", Color.FromArgb(255, 0, 0));
                }

            }
            else
            {
                //thông báo lỗi
                managerHotel.manager.label_load("Số thành viên đặt phòng không dưới 1 !", "icons8_high_priority_32.png", Color.FromArgb(255, 0, 0));
            }
        }
        //
        private void button3_Click(object sender, EventArgs e)
        {
            InterfaceDefaultOrder();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            VableRooms();
        }
        int idRoomSelected;
        //hiển thị popupmenu
        private void DataRooms_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var positionRow = DataRooms.HitTest(e.X, e.Y).RowIndex;
                if (positionRow >= 0)
                {
                    idRoomSelected = (int)DataRooms.Rows[positionRow].Cells["id"].Value;
                }
                popupRoom.Show(DataRooms, new Point(e.X, e.Y));
            }
        }
        // danh sách dịch vụ đc đặt
        private void click_popupItem(Object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name.ToString() == "addService")
            {
                if (dictOrder.ContainsKey(idRoomSelected))
                {
                    OrderService o = new OrderService(true);
                    o.ShowDialog();
                    dictOrder[idRoomSelected] = o.ReturnValue1;
                }
                else
                {
                    List<int> listSer;
                    OrderService o = new OrderService();
                    o.ShowDialog();
                    listSer = o.ReturnValue1;
                    dictOrder.Add(idRoomSelected, listSer);
                }
            }
        }
        Dictionary<int, List<int>> dictOrder = new Dictionary<int, List<int>>();

        //lấy phòng đc đặt
        List<int> listRooms = new List<int>();
        Types_Room tr = new Types_Room();

        private void RoomBooking()
        {

            foreach (DataGridViewRow item in DataRooms.Rows)
            {
                DataGridViewCheckBoxCell checkboxRoom = (DataGridViewCheckBoxCell)item.Cells["check"];
                if (checkboxRoom.Value == "true")
                {
                    int idRoom = Convert.ToInt32(item.Cells["id"].Value.ToString());
                    listRooms.Add(idRoom);

                }
            }
            listRooms = listRooms.Distinct().ToList();
        }

        //lấy thông tin khách hàng và thêm mới
        DateTime dateTimeNow = Convert.ToDateTime(DateTime.Now.ToString());
        private void InforCus(int statusBill, int statusRoom = 2)
        {
            string name = CusName.Text;
            int sex = radioMale.Checked == true ? 1 : 0;
            string cmtnd = InputCard.Text;
            string phone = InputSDT.Text;
            string dateForm = dateTimeForm.Value.ToString("yyyy-MM-dd");
            string dateTo = dateTimeTo.Value.ToString("yyyy-MM-dd");
            int adult = (int)numericAdult.Value;
            int childrent = (int)numeriChildrent.Value;
            string descriptBill = InputDescripsBill.Text;
            string descriptCus = InputDescriptCus.Text;
            //định dạng card
            Regex regexCard = new Regex("^\\w{12}$");
            bool checkCard = regexCard.IsMatch(cmtnd);
            //định dạng phone
            Regex regexPhone = new Regex("^((02)|(09)|(03)|(08))\\w{8}$");
            bool checkPhone = regexPhone.IsMatch(phone);
            if (numericPrepay.Text != "")
            {
                if (radioFemale.Checked == true | radioMale.Checked == true)
                {
                    if (checkCard)
                    {
                        if (checkPhone)
                        {
                            //thêm thông tin khách hàng
                            Customer c = new Customer();
                            c.name = name;
                            c.sex = Convert.ToByte(sex);
                            c.car_personal = cmtnd;
                            c.adults = adult;
                            c.childrens = childrent;
                            c.id_nation = ((Country)comboBoxCountry.SelectedItem).Id;
                            c.phone = phone;
                            c.stt = 1;
                            c.decript = descriptCus;
                            c.date_created = dateTimeNow;

                            db.Customers.InsertOnSubmit(c);
                            db.SubmitChanges();

                            //thêm mới bill
                            Bill b = new Bill();
                            numericPrepay.Text = string.Format("{0:#;minus #}", double.Parse(numericPrepay.Text));
                            float prePay = (float)Convert.ToInt32(numericPrepay.Text);

                            b.id_em = employee.id;
                            b.id_cus = c.id;
                            b.dateFrom = dateForm;
                            b.dateTo = dateTo;

                            b.Prepay = prePay;
                            b.decript = descriptBill;
                            b.date_created = dateTimeNow;
                            b.stt = statusBill;

                            db.Bills.InsertOnSubmit(b);
                            db.SubmitChanges();
                            //thêm mới chi tiết bill
                            foreach (var r in listRooms)
                            {
                                foreach (var item in dictOrder)
                                {
                                    if (r == item.Key)
                                    {
                                        if (statusRoom == 1)
                                        {
                                            var changeSttRoom = db.Rooms.Where(x => x.id == r).FirstOrDefault();
                                            changeSttRoom.stt = 1;
                                            db.SubmitChanges();
                                        }

                                        foreach (var ser in item.Value)
                                        {
                                            Details_Bill DB = new Details_Bill();
                                            DB.id_bill = b.id;
                                            DB.id_room = r;
                                            DB.id_ser = ser;

                                            db.Details_Bills.InsertOnSubmit(DB);
                                            db.SubmitChanges();
                                        }

                                    }
                                }
                            }
                            managerHotel.manager.label_load("Định dạng hoàn hảo !", "icons8_checked_32.png", Color.FromArgb(0, 192, 0));
                            MessageBox.Show("Đặt phòng thành công");

                        }
                        else
                        {
                            managerHotel.manager.label_load("Sai định dạng số điện thoại !", "icons8_high_priority_32.png", Color.FromArgb(255, 0, 0));
                        }
                    }
                    else
                    {
                        managerHotel.manager.label_load("Sai định dạng số thẻ cá nhân !", "icons8_high_priority_32.png", Color.FromArgb(255, 0, 0));
                    }
                }
                else
                {
                    managerHotel.manager.label_load("Chưa chọn giới tính !", "icons8_high_priority_32.png", Color.FromArgb(255, 0, 0));
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhập tiền trả trước !");
            }
        }
        //thêm bill và detail_bill => đặt phòng
        private void buttonPay_Click(object sender, EventArgs e)
        {
            RoomBooking();
            InforCus(-1);
        }
        //tính tổng tiền tất cả dịch vụ
        private float totalSer()
        {
            float total = 0;
            foreach (var item in dictOrder)
            {
                foreach (var ser in item.Value)
                {
                    var moneySer = db.Servicers.FirstOrDefault(x => x.id == ser);
                    total += (float)(moneySer.price - moneySer.sale);
                }
            }
            return total;
        }
        //tính tổng tiền phòng
        float totalMoneys;
        private float totalRoom()
        {
            RoomBooking();

            float total = 0;
            foreach (var item in listRooms)
            {
                var moneyRoom = db.Types_Rooms.Join(db.Rooms,
                        type_room => type_room.id,
                        room => room.id_type,
                        (type_room, room) => new { money = type_room.moneys, idR = room.id }
                        ).Where(room => room.idR == item).FirstOrDefault();
                total += (float)moneyRoom.money;
            }

            return total;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime Start = Convert.ToDateTime(dateTimeForm.Value.ToString("yyyy-MM-dd"));
            DateTime End = Convert.ToDateTime(dateTimeTo.Value.ToString("yyyy-MM-dd"));
            TimeSpan rangeDate = End - Start;

            totalMoneys = (totalSer() + totalRoom()) * rangeDate.Days;

            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            System.Globalization.CultureInfo cul = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            labelTotalMoney.Text = double.Parse(totalMoneys.ToString()).ToString("#,###", cul.NumberFormat);
        }
        //sửa định dạng tiền khi nhập trả trước
        private void numericPrepay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
            if (e.KeyChar == (char)13)
            {
                numericPrepay.Text = string.Format("{0:n0}", double.Parse(numericPrepay.Text));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RoomBooking();
            InforCus(0, 1);
        }
    }
}
