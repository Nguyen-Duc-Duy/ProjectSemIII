using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            StatusRoom.Checked = (room.stt == 1 ? true : false);
            comboTypeRoom.SelectedValue = room.id_type;
        }
        //cập nhật
        private void updateRoom_Click(object sender, EventArgs e)
        {

        }
        //tạo mới
        private void createRoom_Click(object sender, EventArgs e)
        {

        }
    }
}
