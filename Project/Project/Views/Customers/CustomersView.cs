using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Views.Customers
{
    public partial class CustomersView : Form
    {
        ConnectDatabaseDataContext managerHotel;
        public CustomersView()
        {
            managerHotel = new ConnectDatabaseDataContext();
            InitializeComponent();
            ShowDataCus();
        }

        private void CustomersView_Load(object sender, EventArgs e)
        {

        }
        //hiển thị danh sách nhân viên
        private void ShowDataCus()
        {
            var listCus = from c in managerHotel.Customers select c;
            DataCus.DataSource = listCus;
        }
        //giao diện mặc định]
        private void InterfaceDefault()
        {
            UpdateCus.Visible = false;
            SttCus.Visible = false;
            HistoryOrder.Visible = false;
        }

        private void DataCus_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // chọn khách hàng - thực hiện tương tác

    }
}
