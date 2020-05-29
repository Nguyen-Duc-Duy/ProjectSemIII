using Project.Views.ViewsRooms;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Project.Views
{
    public partial class RoomsView : Form
    {
        ConnectDatabaseDataContext managerHotel;
        public RoomsView()
        {
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
            sttRoom.Visible = false;
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
                sttRoom.Visible = true;
                if(r.stt == 1)
                {
                    sttRoom.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Commons\icons\icons8_visible_room_32.png"));
                    sttRoom.Text = "Phòng đang hoạt động";
                }
                else
                {
                    sttRoom.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Commons\icons\icons8_invisible_room_32.png"));
                    sttRoom.Text = "Phòng đang ngừng hoạt động";
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

            var listRooms = from r in managerHotel.Rooms select r;
            foreach (var item in listRooms)
            {
                    //khởi tạo phòng
                Panel p = new Panel();
                p.Width = 150;
                p.Height = 200;
                p.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Commons\images\Room.png"));
                var bm = new Bitmap(p.BackgroundImage, new Size(p.Width, p.Height));
                p.BackgroundImage = bm;
                p.Tag = item;

                    //khởi tạo trạng thái phòng
                    //Label sttRoom = new Label();
                //sttRoom.AutoSize = false;
                //sttRoom.Width = 20;
                //sttRoom.Height = 20;
                //sttRoom.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Commons\images\pngguru.png"));
                
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
                flp.Width = 150;
                flp.Height = 200;
                flp.TabIndex = 2;
                flp.Tag = p;
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
                LType.Location = new Point(p.Width - 20, p.Height - 90);
                LType.TextAlign = ContentAlignment.MiddleRight;
                //số người tiêu chuẩn
                Label LStandar = new Label();
                LStandar.Text = "- Tiêu chuẩn : "+type.AdultStandar+type.ChildrentStandar;
                LStandar.AutoSize = true;
                LStandar.MaximumSize = new System.Drawing.Size(p.Width, 100);
                LStandar.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                LStandar.Location = new Point(p.Width - 20, p.Height - 90);
                //số người tối đa
                Label LMax = new Label();
                LMax.Text = "Tối đa : " + type.AdultMax+type.ChildrentMax;
                LMax.AutoSize = true;
                LMax.MaximumSize = new System.Drawing.Size(p.Width, 100);
                LMax.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                LMax.Location = new Point(p.Width - 20, p.Height - 90);

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
        }

        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexSelected = Convert.ToString(comboFilter.SelectedIndex);
        }

        private void sttRoom_Click(object sender, EventArgs e)
        {

        }
    }
}
