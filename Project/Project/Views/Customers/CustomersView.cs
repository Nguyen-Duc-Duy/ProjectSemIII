using Project.Views.OrdersRoom;
using Project.Views.Pays;
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
    public partial class CustomersView : System.Windows.Forms.Form
    {
        ConnectDatabaseDataContext managerHotel;
        Employee employees;
        public CustomersView(Employee e)
        {
            employees = e;
            managerHotel = new ConnectDatabaseDataContext();
            InitializeComponent();
            ShowDataCus();
            InterfaceDefault();
        }

        private void CustomersView_Load(object sender, EventArgs e)
        {

        }
        //hiển thị danh sách nhân viên
        private void ShowDataCus()
        {
            var listCus = managerHotel.Customers.Join(
                managerHotel.Countries,
                 cus => cus.id_nation,
                countrys => countrys.Id,
                (cus, coutrys) => new { Customers = cus, Country = coutrys }
                
                ).Select(x => new {
                id = x.Customers.id,
                name = x.Customers.name,
                sex = x.Customers.sex == 1 ? "Nam" : "Nữ",
                card = x.Customers.car_personal,
                nation = x.Country.CommonName,
                adult = x.Customers.adults,
                childrent = x.Customers.childrens,
                date_created = x.Customers.date_created,
                date_updated = x.Customers.date_update
            });
            DataCus.DataSource = listCus;
        }
        //giao diện mặc định]
        private void InterfaceDefault()
        {
            SttCus.Visible = false;
            HistoryOrder.Visible = false;
            GoToRoom.Visible = false;
        }
        //lấy khách hàng đc chọn
        int idCusSelected;

        private void HistoryOrder_Click(object sender, EventArgs e)
        {
            PaysView p = new PaysView(idCusSelected,employees);
            p.ShowDialog();
        }

        private void DataCus_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataCus.Rows[e.RowIndex].Cells["STT"].Value = (e.RowIndex + 1).ToString();
        }

        private void UpdateCus_Click(object sender, EventArgs e)
        {

        }

        private void GoToRoom_Click(object sender, EventArgs e)
        {
            var Bill = managerHotel.Bills.Where(x => x.id_cus == idCusSelected)
                   .FirstOrDefault();
            Bill.stt = 0;
            var detailIdRoom = managerHotel.Details_Bills.Where(x => x.id_bill == Bill.id)
                .Select(x => x.id_room);
            foreach (var id in detailIdRoom)
            {
                Room room = managerHotel.Rooms.Where(x => x.id == id).FirstOrDefault();
                room.stt = 1;
                managerHotel.SubmitChanges();
            }
            managerHotel.SubmitChanges();
            MessageBox.Show("Nhận phòng thành công !");
        }

        private void DataCus_SelectionChanged(object sender, EventArgs e)
        {
            HistoryOrder.Visible = true;
            try
            {

                idCusSelected = (int)DataCus.CurrentRow.Cells["id"].Value;
                var sttBill = managerHotel.Bills.Where(x => x.id_cus == idCusSelected)
                    .Select(x => x.stt).FirstOrDefault();
                if (sttBill == -1)
                {
                    GoToRoom.Visible = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Giá trị không hợp lệ ! Vui lòng chọn lại !");
            }
        }

        private void SttCus_Click(object sender, EventArgs e)
        {

        }
    }
}
