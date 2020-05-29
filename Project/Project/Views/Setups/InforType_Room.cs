using System;
using System.Linq;
using System.Windows.Forms;

namespace Project.Views.Setups
{
    public partial class InforType_Room : Form
    {
        ConnectDatabaseDataContext managerHotel;
        //hàm khởi tạo
        public InforType_Room()
        {
            managerHotel = new ConnectDatabaseDataContext();
            InitializeComponent();
            SttType_Room.Visible = false;
            UpdateType_Room.Visible = false;

        }

        Types_Room type;
        public InforType_Room(Types_Room t)
        {
            managerHotel = new ConnectDatabaseDataContext();
            type = t;
            InitializeComponent();
            CreateType_Room.Visible = false;
            ShowType_Room();
        }

        private void InforType_Room_Load(object sender, EventArgs e)
        {

        }
        //tạo mới loại phòng
        private void CreateType_Room_Click(object sender, EventArgs e)
        {
            Types_Room t = new Types_Room();
            t.name = NameType_Room.Text;
            t.moneys = Convert.ToDouble(PriceType_Room.Text);
            t.ChildrentStandar =(int) ChildrentStandar.Value;
            t.ChildrentMax = (int)ChildrentMax.Value;
            t.AdultStandar = (int)AdultStandar.Value;
            t.AdultMax = (int)AdultMax.Value;
            t.descript = DescriptType_Room.Text;
            managerHotel.Types_Rooms.InsertOnSubmit(t);
            managerHotel.SubmitChanges();
            MessageBox.Show("Thêm mới thành công !");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        //cập nhật loại phòng
        //hiển thị dữ liệu
        private void ShowType_Room()
        {
            NameType_Room.Text = type.name;
            PriceType_Room.Text = type.moneys.ToString();
            AdultStandar.Value =Convert.ToDecimal(type.AdultStandar);
            AdultMax.Value = Convert.ToDecimal(type.AdultMax);
            ChildrentStandar.Value = Convert.ToDecimal(type.ChildrentStandar);
            ChildrentMax.Value = Convert.ToDecimal(type.AdultStandar);
            SttType_Room.Checked = type.stt == 1 ? true : false;
            DescriptType_Room.Text = type.descript;
            

        }
        //cập nhật
        private void UpdateType_Room_Click(object sender, EventArgs e)
        {
            var t = managerHotel.Types_Rooms.FirstOrDefault(x => x.id == type.id);
            t.name = NameType_Room.Text;
            t.moneys = Convert.ToDouble(PriceType_Room.Text);
            t.ChildrentStandar = (int)ChildrentStandar.Value;
            t.ChildrentMax = (int)ChildrentMax.Value;
            t.AdultStandar = (int)AdultStandar.Value;
            t.AdultMax = (int)AdultMax.Value;
            t.descript = DescriptType_Room.Text;
            managerHotel.SubmitChanges();
            MessageBox.Show("Cập nhật thành công !");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
