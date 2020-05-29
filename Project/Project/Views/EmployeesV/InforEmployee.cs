using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Views.Employees
{
    public partial class InforEmployee : Form
    {

        //hàm khởi tạo không có tham số
        ConnectDatabaseDataContext managerHotel;
        public InforEmployee()
        {
            managerHotel = new ConnectDatabaseDataContext();
            InitializeComponent();
            UpdateEm.Visible = false;
            SttEm.Visible = false;
        }

        //hàm khởi tạo có tham số là nhân viên
        Employee employeeToUpdate;
        public InforEmployee(Employee e)
        {
            managerHotel = new ConnectDatabaseDataContext();
            employeeToUpdate = e;
            InitializeComponent();
            CreateEm.Visible = false;
            ShowDataEmToUpdate();
        }

        private void InforCustomer_Load(object sender, EventArgs e)
        {

        }

        //chức năng thêm mới nhân viên
        private void button1_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.name = NameEm.Text;
            employee.email = EmailEm.Text;
            employee.phone = SDTEm.Text;
            employee.pass = PassEm.Text;
            employee.decript = DescriptEm.Text;
            employee.avt = "avt-man.png";
            employee.stt = 1;
            managerHotel.Employees.InsertOnSubmit(employee);
            managerHotel.SubmitChanges();

            MessageBox.Show("Thêm mới thành công !");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        //chức năng cập nhật nhân viên
        //hiển thị thông tin nhân viên cần cập nhật
        private void ShowDataEmToUpdate()
        {
            if(employeeToUpdate != null)
            {
                NameEm.Text = employeeToUpdate.name;
                EmailEm.Text = employeeToUpdate.email;
                SDTEm.Text = employeeToUpdate.phone;
                PassEm.Text = employeeToUpdate.pass;
                DescriptEm.Text = employeeToUpdate.decript;
                SttEm.Checked = employeeToUpdate.stt == 1 ? true : false;
            }
            else
            {
                MessageBox.Show("Lỗi hệ thống vui lòng thử lại !");
            }
            
        }
        //cập nhật
        private void UpdateEm_Click(object sender, EventArgs e)
        {
            var employee = managerHotel.Employees.FirstOrDefault(x => x.id == employeeToUpdate.id);
            employee.name = NameEm.Text;
            employee.email = EmailEm.Text;
            employee.phone = SDTEm.Text;
            employee.decript = DescriptEm.Text;
            employee.pass = PassEm.Text;
            employee.avt = "avt-man.png";
            employee.stt = SttEm.Checked == true ? 1 : 0;
            managerHotel.SubmitChanges();

            MessageBox.Show("Cập nhật thành công !");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
