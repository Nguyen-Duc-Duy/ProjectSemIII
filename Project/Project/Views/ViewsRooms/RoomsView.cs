using Project.Views.OrdersRoom;
using Project.Views.Pays;
using Project.Views.ViewsRooms;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Project.Views
{
    public partial class RoomsView : System.Windows.Forms.Form
    {
        ConnectDatabaseDataContext managerHotel;
        Employee employee;
        public RoomsView(Employee e)
        {
            employee = e;
            InitializeComponent();
            managerHotel = new ConnectDatabaseDataContext();
            toolStrip1.ImageScalingSize = new Size(30, 30);
            ShowRooms();
            InterfaceDefault();


        }

        //Giao diện mặc định
        private void InterfaceDefault()
        {
            //ẩn các nút tương tác với  phòng
            updateRoom.Visible = false;
            pay.Visible = false;
            //set giá trị cho bộ lọc phòng
            comboFilter.Items.Add("--- Lọc Phòng Theo ---");
            comboFilter.Items.Add("Các phòng trống");
            comboFilter.Items.Add("Các phòng đang ở");
            comboFilter.Items.Add("Các phòng đã đặt trước");
            comboFilter.SelectedIndex = 0;
        }
        Room RoomSelected;
        private void RoomsView_Load(object sender, EventArgs e)
        {
        }
        //sự kiện ẩn hiện layout thông tin phòng 
        private void panel1_MouseClickPanelChild(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Panel ConverSender = (Panel)(sender as Panel);
            Room r = (Room)ConverSender.Tag;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                foreach (Control c in ConverSender.Controls)
                {
                    if (c.GetType() == typeof(Label))
                    {
                        c.Visible = false;
                    }
                    if (c.GetType() == typeof(FlowLayoutPanel))
                    {
                        c.Visible = true;
                    }
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                RoomSelected = r;
                updateRoom.Visible = true;
                if(r.stt == 1)
                {
                    pay.Visible = true;
                }
                else
                {
                    pay.Visible = false;
                }
            }
        }
        //sự kiện click ẩn hiện tên phòng
        private void panel1_ClickHidePanelParent(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                FlowLayoutPanel pn = (sender as FlowLayoutPanel);

                Panel p = pn.Tag as Panel;

                if (pn.Visible == true)
                {
                    pn.Visible = false;
                    foreach (Control c in p.Controls)
                    {
                        if (c.GetType() == typeof(Label))
                        {
                            c.Visible = true;
                        }
                    }

                }
                else
                {
                    pn.Visible = true;
                }
            }

        }
        //hiển thị dữ liệu rooms
        private void ShowRooms()
        {
            foreach (Control item in layoutRooms.Controls)
            {
                layoutRooms.Controls.Remove(item);
            }
            var listRooms = from r in managerHotel.Rooms select r;
            foreach (var item in listRooms)
            {
                    //khởi panel tạo phòng
                Panel p = new Panel();
                p.Width = 150;
                p.Height = 200;
                p.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Commons\images\Room.png"));
                var bm = new Bitmap(p.BackgroundImage, new Size(p.Width, p.Height));
                p.BackgroundImage = bm;
                p.Tag = item;
                //trạng thái phòng
                Label LStt = new Label();
                if (item.stt == 1)
                {
                    LStt.Text = "Đang sử dụng";
                    LStt.BackColor = Color.FromArgb(241, 183, 21);
                }
                else if (item.stt == 0)
                {
                    LStt.Text = "Trống";
                    LStt.BackColor = Color.FromArgb(105, 217, 105);
                }
                else
                {
                    LStt.Text = "Hỏng";
                    LStt.BackColor = Color.FromArgb(232, 83, 43);
                }
                LStt.AutoSize = false;
                LStt.Width = p.Width;
                LStt.Height = 27;
                LStt.TextAlign = ContentAlignment.MiddleCenter;
                LStt.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                LStt.Padding = new Padding(5, 5,5,5);
                LStt.ForeColor = Color.White;
                LStt.Location = new Point(0, -5);
                p.Controls.Add(LStt);

                ///khởi tạo tên phòng
                Label l = new Label();
                l.Visible = true;
                l.Enabled = true;
                l.Text = item.name;
                l.ForeColor = Color.White;
                l.Location = new Point(70, 26);
                l.AutoSize = true;
                l.Width = 20;
                l.Height = 10;
                l.BackColor = Color.Transparent;
                l.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
                l.TabIndex = 3;
                    //khởi tạo layout chứa thông tin phòng
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Width = 140;
                flp.Height = 190;
                flp.TabIndex = 2;
                flp.Tag = p;
                flp.Location = new Point(5,5);

                    //sự kiên ẩn hiện layout chứa thông tin phòng
                flp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_ClickHidePanelParent);
                //khởi tạo các label thông tin của phòng
                
                //Tên phòng
                Label LName = new Label();
                LName.Text = item.name;
                LName.AutoSize = false;
                LName.Width = p.Width;
                LName.Height = 20;
                LName.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                LName.Location = new Point(90, 90);
                
                //loại phòng
                Types_Room type = managerHotel.Types_Rooms.FirstOrDefault(t => t.id == item.id_type);
                Label LType = new Label();
                LType.Text = "- loại : "+type.name;
                LType.AutoSize = true;
                LType.MaximumSize = new System.Drawing.Size(p.Width, 100);
                LType.Height = 20;
                LType.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                LType.Location = new Point(p.Width, p.Height);
                LType.TextAlign = ContentAlignment.MiddleRight;
                //Giá
                Label LPriceRoom = new Label();
                LPriceRoom.Text = "- Giá : " + type.moneys;
                LPriceRoom.AutoSize = true;
                LPriceRoom.MaximumSize = new System.Drawing.Size(p.Width, 100);
                LPriceRoom.Height = 20;
                LPriceRoom.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                LPriceRoom.Location = new Point(p.Width, p.Height);
                LPriceRoom.TextAlign = ContentAlignment.MiddleRight;
                //số người tiêu chuẩn
                Label LStandar = new Label();
                LStandar.Text = "- Tiêu chuẩn : "+type.AdultStandar + "(A)" + type.ChildrentStandar + "(C)";
                LStandar.AutoSize = true;
                LStandar.MaximumSize = new System.Drawing.Size(p.Width, 100);
                LStandar.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                LStandar.Location = new Point(p.Width, p.Height);
                //số người tối đa
                Label LMax = new Label();
                LMax.Text = "- Tối đa : " + type.AdultMax+"(A)"+type.ChildrentMax + "(C)";
                LMax.AutoSize = true;
                LMax.MaximumSize = new System.Drawing.Size(p.Width, 100);
                LMax.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                LMax.Location = new Point(p.Width, p.Height);
                //thông tin phòng đang ở
                if (item.stt == 1)
                {
                    var bill = managerHotel.Details_Bills.Where(x => x.id_room == item.id)
                        .Select(x => new  { dateFrom = x.Bill.dateFrom, dateTo = x.Bill.dateTo, id_cus = x.Bill.id_cus }).FirstOrDefault();
                    var cus = managerHotel.Customers.Where(x => x.id == bill.id_cus).FirstOrDefault();
                    //tên khách hàng
                    Label LNameCus = new Label();
                    LNameCus.Text = "- Tên khách : " + cus.name;
                    LNameCus.AutoSize = true;
                    LNameCus.MaximumSize = new System.Drawing.Size(p.Width, 100);
                    LNameCus.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                    LNameCus.Location = new Point(p.Width, p.Height);
                    //ngày đến 
                    Label LDateForm = new Label();
                    LDateForm.Text = "- Ngày bắt đầu : " + bill.dateFrom;
                    LDateForm.AutoSize = true;
                    LDateForm.MaximumSize = new System.Drawing.Size(p.Width, 100);
                    LDateForm.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                    LDateForm.Location = new Point(p.Width, p.Height);
                    //ngày đi
                    Label LDateTo = new Label();
                    LDateTo.Text = "- Ngày kết thúc : " + bill.dateTo;
                    LDateTo.AutoSize = true;
                    LDateTo.MaximumSize = new System.Drawing.Size(p.Width, 100);
                    LDateTo.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                    LDateTo.Location = new Point(p.Width, p.Height);
                }
                //add các panel và label
                flp.Visible = false;
                flp.Controls.Add(LName);
                flp.Controls.Add(LType);
                flp.Controls.Add(LStandar);
                flp.Controls.Add(LMax);

                p.Controls.Add(flp);
                p.Controls.Add(l);
                layoutRooms.Controls.Add(p);
                p.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClickPanelChild);
            }
        }

        private void createRoom_Click(object sender, EventArgs e)
        {
            InformationsRoom i = new InformationsRoom();
            i.ShowDialog();
        }

        private void updateRoom_Click(object sender, EventArgs e)
        {
            InformationsRoom i = new InformationsRoom(RoomSelected);
            i.ShowDialog();
            if (i.DialogResult == DialogResult.OK) {
                ShowRooms();
            }
        }

        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexSelected = Convert.ToString(comboFilter.SelectedIndex);
        }

        private void sttRoom_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OrdersView o = new OrdersView(employee);
            o.Show();

        }

        private void pay_Click(object sender, EventArgs e)
        {
            var bill = managerHotel.Details_Bills.Where(x => x.id_room == RoomSelected.id)
                .Where(x => x.Bill.stt == 0).Select(x => x.Bill.id_cus)
                .FirstOrDefault();
            PaysView p = new PaysView(bill,employee);
            p.Show();
        }
    }
}
