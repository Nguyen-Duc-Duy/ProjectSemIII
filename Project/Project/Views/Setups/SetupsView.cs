using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Project.Views.Setups
{
    public partial class SetupsView : Form
    {
        ConnectDatabaseDataContext managerHotel;
        public SetupsView()
        {
            managerHotel = new ConnectDatabaseDataContext();
            InitializeComponent();
            ServicerView();
            Type_RoomsViews();
            InterfaceDefault();
        }

        private void SetupsView_Load(object sender, EventArgs e)
        {

        }

        //giao diện mặc định
        private void InterfaceDefault()
        {
            UpdateService.Visible = false;
            ChangeSttService.Visible = false;
            UpdateType_Room.Visible = false;
            ChangeSttType_Room.Visible = false;
        }

        //dịch vụ
        private void ServicerView()
        {
            ShowDataService();
        }
        //lấy dữ liệu dịch vụ
        private void ShowDataService()
        {
            managerHotel.Refresh(System.Data.Linq.RefreshMode.KeepChanges, managerHotel.Servicers);

            var listServices = managerHotel.Servicers.Select(x=> new {
                id = x.id,
                name = x.name,
                price = x.price,
                sale = x.sale,
                stt = x.stt == 0 ? "Đang tắt" : "Đang mở",
                descript = x.descript,
                date_created = x.date_created,
                date_update = x.date_update
            });
            dataServices.DataSource = listServices;
            //dataServices.Columns["id"].Visible = false;
        }
        //hiển thi tương tác dịch vụ

        //lấy dịch vụ trên bảng
        Servicer seviceSelected;
        private void dataServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataServices.CurrentRow != null)
            {
                int idService = Convert.ToInt32(dataServices.CurrentRow.Cells["IdSer"].Value.ToString());

                seviceSelected = managerHotel.Servicers.FirstOrDefault(x => x.id == idService);
                //hiển thị nút
                UpdateService.Visible = true;
                ChangeSttService.Visible = true;
                if (seviceSelected.stt == 1)
                {
                    ChangeSttService.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Commons\icons\icons8_eye_32.png"));
                    ChangeSttService.Text = "Dịch vụ có thể dùng";
                }
                else if (seviceSelected.stt == 0)
                {
                    ChangeSttService.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Commons\icons\icons8_invisible_32.png"));
                    ChangeSttService.Text = "Dịch vụ không thể dùng";
                }
            }
        }

        //thay đổi trạng thái dịch vụ
        private void ChangeSttService_Click(object sender, EventArgs e)
        {
            DialogResult confirm;
            var service = managerHotel.Servicers.FirstOrDefault(x => x.id == seviceSelected.id);
            if (seviceSelected.stt == 1)
            {
                confirm = MessageBox.Show("Bạn có chắc muốn ẩn Dịch vụ này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    service.stt = 0;
                    managerHotel.SubmitChanges();
                }
            }
            else if (seviceSelected.stt == 0)
            {
                confirm = MessageBox.Show("Bạn có chắc muốn hiện Dịch vụ này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    service.stt = 1;
                    managerHotel.SubmitChanges();
                }
            }
        }


        //hiển thị form tạo mới dịch vụ
        private void CreateService_Click(object sender, EventArgs e)
        {
            InforService i = new InforService();
            i.ShowDialog();
            if(i.DialogResult == DialogResult.OK)
            {
                ShowDataService();

            }
        }

        //hiển thị form cập nhật dịch vụ
        private void UpdateService_Click(object sender, EventArgs e)
        {
            InforService i = new InforService(seviceSelected);
            i.ShowDialog();
            if (i.DialogResult == DialogResult.Yes)
            {
                ShowDataService();
            }
        }
        //chức năng tìm kiếm dịch vụ
        private void button2_Click(object sender, EventArgs e)
        {
            string nameSearch = SearchServicer.Text;
            var listServices = managerHotel.Servicers.Where(x=>x.name.Contains(nameSearch)).Select(x => new {
                id = x.id,
                name = x.name,
                price = x.price,
                sale = x.sale,
                stt = x.stt == 0 ? "Đang tắt" : "Đang mở",
                descript = x.descript,
                date_created = x.date_created,
                date_update = x.date_update
            });
            dataServices.DataSource = listServices;
        }
        //chức năng làm mới
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ServicerView();
        }


        //loại phòng
        private void Type_RoomsViews()
        {
            ShowDataType_Rooms();
        }

        //lấy danh sách loại phòng
        private void ShowDataType_Rooms()
        {
            managerHotel.Refresh(System.Data.Linq.RefreshMode.KeepChanges, managerHotel.Types_Rooms);
            var listType_Rooms = from t in managerHotel.Types_Rooms select t;
            dataType_Rooms.DataSource = listType_Rooms;
            //dataType_Rooms.Columns["id"].Visible = false;
        }
       
        //lấy loại phòng trên bảng
        Types_Room TypeSelected;
        private void dataType_Rooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idType = Convert.ToInt32(dataType_Rooms.CurrentRow.Cells["idType"].Value.ToString());
            TypeSelected = managerHotel.Types_Rooms.FirstOrDefault(x => x.id == idType);
            UpdateType_Room.Visible = true;
            ChangeSttType_Room.Visible = true;
            if(TypeSelected.stt == 1)
            {
                ChangeSttType_Room.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Commons\icons\icons8_eye_32.png"));
                ChangeSttType_Room.Text = "Loại phòng có thể dùng";
            }else if (TypeSelected.stt == 0)
            {
                ChangeSttType_Room.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Commons\icons\icons8_invisible_32.png"));
                ChangeSttType_Room.Text = "Loại phòng không thể dùng";
            }

        }
        
        
        //thay đổi trạng thái loại phòng
        private void ChangeSttType_Room_Click(object sender, EventArgs e)
        {
            DialogResult confirm;
            var type = managerHotel.Types_Rooms.FirstOrDefault(x => x.id == TypeSelected.id);
            if(TypeSelected.stt == 1)
            {
                confirm = MessageBox.Show("Bạn có chắc muốn ẩn Loại Phòng này ?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    type.stt = 0;
                    managerHotel.SubmitChanges();
                }
            }
            else if(TypeSelected.stt == 0)
            {
                confirm = MessageBox.Show("Bạn có chắc muốn hiện Loại Phòng này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    type.stt = 1;
                    managerHotel.SubmitChanges();
                }
            }
        }

        //hiển thị form tạo mới loại phòng
        private void CreateType_Room_Click(object sender, EventArgs e)
        {
            InforType_Room i = new InforType_Room();
            i.ShowDialog();
            if (i.DialogResult == DialogResult.OK)
            {
                ShowDataType_Rooms();
            }
        }

        //hiển thị form cập nhật
        private void UpdateType_Room_Click(object sender, EventArgs e)
        {
            InforType_Room i = new InforType_Room(TypeSelected);
            i.ShowDialog();
            if (i.DialogResult == DialogResult.OK)
            {
                ShowDataType_Rooms();
            }
        }

        private void dataServices_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dataServices.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataType_Rooms_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataType_Rooms.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataServices_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dataType_Rooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        //chức năng làm mới loại phòng
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Type_RoomsViews();
        }
        //chức năng tìm kiếm loại phòng
        private void button1_Click(object sender, EventArgs e)
        {
            string nameType = SearchType.Text;
            var listType_Rooms = from t in managerHotel.Types_Rooms where t.name.Contains(nameType) select t;
            dataType_Rooms.DataSource = listType_Rooms;
        }
    }
}
