using Project.Views;
using Project.Views.Customers;
using Project.Views.Dashboards;
using Project.Views.Employees;
using Project.Views.OrdersRoom;
using Project.Views.Pays;
using Project.Views.Setups;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Project
{
    public partial class managerHotel : System.Windows.Forms.Form
    {
        public static managerHotel manager;

        Employee employee = new Employee();
        Login FormLogin;
        public managerHotel(Employee em,Login l)
        {
            FormLogin = l;
            employee = em;
            manager = this;
            InitializeComponent();
            InforUser();
            timer1.Start();
            HandleButton();
            RoomsView r = new RoomsView(employee);
            ChangeLayout(r);

        }
        public void label_load(string textPrograming, string iconPrograming, Color c)
        {
            StatusLabel.Text = textPrograming;
            StatusLabel.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Commons\icons\" + iconPrograming));
            StatusLabel.ForeColor = c;
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
            avtUser.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Commons\images\" + employee.avt));
        }
        //định dạng ngày tháng giờ
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLine.Text = DateTime.Now.ToString("HH:mm:ss");
            dateLine.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        //thay đổi layout
        private void ChangeLayout(System.Windows.Forms.Form f)
        {
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.Manual;
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = FormBorderStyle.None;
            if (this.ActiveMdiChild != null)
            {
                System.Windows.Forms.Form formCurent = this.ActiveMdiChild;
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
            RoomsView r = new RoomsView(employee);
            ChangeLayout(r);
        }

        private void btnRooms_Move(object sender, EventArgs e)
        {
            btnRooms.BackColor = Color.Red;
        }


        public static object Types_Room { get; internal set; }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrdersView o = new OrdersView(employee);
            ChangeLayout(o);
        }

        private void managerHotel_Load(object sender, EventArgs e)
        {

        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            PaysView p = new PaysView(employee);
            ChangeLayout(p);
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            SetupsView s = new SetupsView();
            ChangeLayout(s);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomersView c = new CustomersView(employee);
            ChangeLayout(c);
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            EmployeesView em = new EmployeesView();
            ChangeLayout(em);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            DashboardView d = new DashboardView();
            ChangeLayout(d);

        }

        private void avtUser_Click(object sender, EventArgs e)
        {

        }

        private void avtUser_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popupChangeCus.Show(avtUser,new Point(e.X,e.Y));
            }
        }

        private void ChangeInfor_Click(object sender, EventArgs e)
        {
            InforEmployee i = new InforEmployee(employee);
            i.Show();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin.Show();
        }
    }
}
