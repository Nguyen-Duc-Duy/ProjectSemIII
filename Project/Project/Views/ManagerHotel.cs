using Project.Views;
using Project.Views.Customers;
using Project.Views.OrdersRoom;
using Project.Views.PaysView;
using Project.Views.Setups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class managerHotel : Form
    {
        Employee employee;
        public managerHotel(Employee em)
        {
            employee = em;
            InitializeComponent();
            InforUser();
            timer1.Start();
            HandleButton();
            RoomsView r = new RoomsView();
            ChangeLayout(r);
            

        }
        //sửa button
        private void HandleButton()
        {
            btnRooms.FlatAppearance.BorderSize = 0;
            btnBill.FlatAppearance.BorderSize = 0;
            btnOrder.FlatAppearance.BorderSize = 0;
            btnEmployee.FlatAppearance.BorderSize = 0;
            btnCustomer.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnSetup.FlatAppearance.BorderSize = 0;
        }

        //hiển thị thông tin người dùng
        private void InforUser()
        {
            userName.Text = employee.name;
            avtUser.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Commons\images\"+employee.avt));
        }
        //định dạng ngày tháng giờ
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLine.Text = DateTime.Now.ToString("HH:mm:ss");
            dateLine.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        //thay đổi layout
        private void ChangeLayout(Form f)
        {
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.Manual;
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = FormBorderStyle.None;
            if(this.ActiveMdiChild != null)
            {
                Form formCurent = this.ActiveMdiChild;
                if (formCurent.Name != f.Name)
                {
                    formCurent.Hide();
                    f.Show();
                }
            }
            else
            {
                f.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RoomsView r = new RoomsView();
            ChangeLayout(r);
        }

        private void btnRooms_Move(object sender, EventArgs e)
        {
            btnRooms.BackColor = Color.Red;
        }
        OrdersView o = new OrdersView();

        public static object Types_Room { get; internal set; }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            
            ChangeLayout(o);
        }

        private void managerHotel_Load(object sender, EventArgs e)
        {

        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            PaysView p = new PaysView();
            ChangeLayout(p);
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            SetupsView s = new SetupsView();
            ChangeLayout(s);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomersView c = new CustomersView();
            ChangeLayout(c);
        }
    }
}
