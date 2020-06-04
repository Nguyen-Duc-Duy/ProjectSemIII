using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Project.Views.ViewsRooms
{
    public partial class InformationsRoom : Form
    {
        ConnectDatabaseDataContext managerHotel = new ConnectDatabaseDataContext();
        Room room;
        public InformationsRoom(Room r)
        {
            room = r;
            InitializeComponent();
            InterfaceDefault();
            createRoom.Visible = false;
            ShowInforToUpdate();
        }
        public InformationsRoom()
        {
            InitializeComponent();
            updateRoom.Visible = false;
            StatusRoom.Visible = false;
            InterfaceDefault();
        }
        private void InformationsRoom_Load(object sender, EventArgs e)
        {

        }
        List<Types_Room> listType_Room;
        //giao diện mặc định
        private void InterfaceDefault()
        {
            listType_Room = (from TR in managerHotel.Types_Rooms select TR).ToList();
            comboTypeRoom.DataSource = listType_Room;
            comboTypeRoom.DisplayMember = "name";
            comboTypeRoom.ValueMember = "id";
        }
        //hiển thị thông tin phòng được chọn
        private void ShowInforToUpdate()
        {
            NameRoom.Text = room.name;
            AddressRoom.Text = room.address_room;
            DescriptRoom.Text = room.descript;
            StatusRoom.Checked = (room.stt == 1 | room.stt == 0 ? true : false);
            comboTypeRoom.SelectedValue = room.id_type;
        }
        //lấy giá trị form
        private Room InforRoom(Room r)
        {
            r.name = NameRoom.Text;
            r.address_room = AddressRoom.Text;
            r.descript = DescriptRoom.Text;
            r.id_type = (int)comboTypeRoom.SelectedValue;
            return r;
        }
        DateTime dateTimeNow = DateTime.Now;
        //cập nhật
        private void updateRoom_Click(object sender, EventArgs e)
        {
            try
            {
                Room ro = managerHotel.Rooms.FirstOrDefault(r => r.id == room.id);
                ro = InforRoom(ro);
                ro.id = room.id;
                ro.stt = StatusRoom.Checked == true ? 0 : -1;
                ro.date_update = dateTimeNow;
                //kiểm tra tên
                if (checkNameRoom(ro.name))
                {
                    DialogResult confrim = MessageBox.Show("Tên bị trùng !", "Bạn vẫn muốn sử dụng tên này ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confrim == DialogResult.Yes)
                    {
                        managerHotel.SubmitChanges();
                        MessageBox.Show("Cập nhật thành công ! ");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    managerHotel.SubmitChanges();
                    MessageBox.Show("Cập nhật thành công ! ");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại ! " + ex.Message);
                this.Close();
            }
        }
        //tạo mới
        private void createRoom_Click(object sender, EventArgs e)
        {
            try
            {
                Room r = new Room();
                r = InforRoom(r);
                r.date_created = dateTimeNow;
                //kiểm tra tên
                if (checkNameRoom(r.name))
                {
                    DialogResult confrim = MessageBox.Show("Tên bị trùng ! Bạn vẫn muốn sử dụng tên này ?","Xác nhận" , MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confrim == DialogResult.Yes)
                    {
                        managerHotel.Rooms.InsertOnSubmit(r);
                        managerHotel.SubmitChanges();
                        MessageBox.Show("Thêm mới thành công ! ");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    managerHotel.Rooms.InsertOnSubmit(r);
                    managerHotel.SubmitChanges();
                    MessageBox.Show("Thêm mới thành công ! ");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm mới thất bại ! " + ex.Message);
                this.Close();
            }
        }
        //kiểm tra tên phòng
        private bool checkNameRoom(string name)
        {
            var room = managerHotel.Rooms.Where(x => x.name.Contains(name));
            if (room == null)
            {
                return false;
            }
            return true;
        }
    }
}
