using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Views.OrdersRoom
{
    public partial class OrderService : Form
    {
        ConnectDatabaseDataContext managerHotel;
        public List<int> ReturnValue1 { get; set; }
        public OrderService()
        {
            managerHotel = new ConnectDatabaseDataContext();
            InitializeComponent();
            ShowDataService();
            
        }
        public OrderService(bool b)
        {

            managerHotel = new ConnectDatabaseDataContext();
            InitializeComponent();
            ShowDataService();
            MessageBox.Show("Vui lòng chọn lại dịch vụ !");
        }

        private void OrderService_Load(object sender, EventArgs e)
        {

        }
        //lấy dữ liệu dịch vụ
        private void ShowDataService()
        {
            var dataSer = from s in managerHotel.Servicers where s.stt == 1 select s;
            dataService.DataSource = dataSer;
        }
        List<int> listSer = new List<int>();
        //lấy giá trị được chọn
        private void GetDataSelected()
        {
            foreach (DataGridViewRow item in dataService.Rows)
            {
                DataGridViewCheckBoxCell checkboxRoom = (DataGridViewCheckBoxCell)item.Cells["check"];
                if (checkboxRoom.Value != checkboxRoom.TrueValue)
                {
                    listSer.Add(Convert.ToInt32(item.Cells["id"].Value));
                }
            }
            this.ReturnValue1 = listSer.Distinct().ToList();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetDataSelected();
        }
    }
}
