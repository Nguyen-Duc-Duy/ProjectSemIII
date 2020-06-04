using System;
using System.Linq;
using System.Windows.Forms;

namespace Project.Views.Setups
{
    public partial class InforService : Form
    {
        ConnectDatabaseDataContext managerHotel;
        //hàm khởi tạo
        public InforService()
        {
            managerHotel = new ConnectDatabaseDataContext();
            InitializeComponent();
            //ẩn trạng thái và nút lưu
            SttSer.Visible = false;
            UpdateSer.Visible = false;
        }
        Servicer service;
        public InforService(Servicer s)
        {
            managerHotel = new ConnectDatabaseDataContext();
            service = s;
            InitializeComponent();
            showServiceToUpdate();
        }
        private void InforService_Load(object sender, EventArgs e)
        {

        }
        DateTime dateTimeNow = Convert.ToDateTime(DateTime.Now.ToString());
        //tạo mới
        private void CreateSer_Click(object sender, EventArgs e)
        {

            Servicer s = new Servicer();
            s.name = NameSer.Text;
            s.price = Convert.ToDouble(PriceSer.Text);
            s.sale = (double)SaleSer.Value;
            s.descript = DescriptSer.Text;
            //s.date_created = Convert.ToDateTime(date.ToString(format));
            s.date_created = dateTimeNow;

            managerHotel.Servicers.InsertOnSubmit(s);
            managerHotel.SubmitChanges();

            MessageBox.Show("Thêm mới thành công !");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //cập nhật
        //set giá trị khi khi cập nhật
        private void showServiceToUpdate()
        {
            CreateSer.Visible = false;
            SttSer.Visible = true;
            NameSer.Text = service.name;
            PriceSer.Text = service.price.ToString();
            SaleSer.Value = Convert.ToInt32(service.sale);
            SttSer.Checked = service.stt == 1 ? true : false;
            DescriptSer.Text = service.descript;

        }
        private void UpdateSer_Click(object sender, EventArgs e)
        {
            var s = managerHotel.Servicers.FirstOrDefault(x => x.id == service.id);
            s.name = NameSer.Text;
            s.price = Convert.ToDouble(PriceSer.Text);
            s.sale = Convert.ToInt32(SaleSer.Value);
            s.stt = SttSer.Checked == true ? 1 : 0;
            s.descript = DescriptSer.Text;
            s.date_update = dateTimeNow;

            managerHotel.SubmitChanges();

            MessageBox.Show("Cập nhật thành công !");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PriceSer_Leave(object sender, EventArgs e)
        {
            //Double value;
            //if (Double.TryParse(PriceSer.Text, out value))
            //    PriceSer.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            //else
            //    PriceSer.Text = String.Empty;
        }
    }
}
