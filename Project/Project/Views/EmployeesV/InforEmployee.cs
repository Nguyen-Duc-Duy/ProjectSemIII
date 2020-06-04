using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
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
            InterfaceDefault();

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
            InterfaceDefault();

            CreateEm.Visible = false;
            ShowDataEmToUpdate();
        }
        //giao diện mạc định
        private void InterfaceDefault()
        {
            labelErrorEmail.Text = "";
            labelErrorPhone.Text = "";
        }
        private void InforCustomer_Load(object sender, EventArgs e)
        {

        }
        //kiển tra định dạng
        private bool CheckForm()
        {
            string phone = SDTEm.Text;
            string email = EmailEm.Text;

            Regex regexPhone = new Regex("^((02)|(09)|(03)|(08))\\w{8}$");
            bool checkPhone = regexPhone.IsMatch(phone);

            Regex regexEmail = new Regex("[a-z0-9!#$%&'*+=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            bool checkEmail = regexEmail.IsMatch(email);
            if (NameEm.Text != "")
            {
                label5.Text = "Chính sác !";
                label5.ForeColor = Color.Red;
                if (checkEmail)
                {
                    labelErrorEmail.Text = "Chính sác !";
                    labelErrorEmail.ForeColor = Color.Green;
                    if (checkPhone)
                    {
                        labelErrorPhone.Text = "Chính sác !";
                        labelErrorPhone.ForeColor = Color.Green;
                        if (PassEm.Text != "")
                        {
                            label3.Text = "Chính sác !";
                            label3.ForeColor = Color.Green;
                            return true;
                        }
                        else
                        {
                            label3.Text = "Mật khẩu không được để trống !";
                            label3.ForeColor = Color.Red;
                            return false;
                        }
                        
                    }
                    else
                    {
                        labelErrorPhone.Text = "Số điện thoại sai định dạng !";
                        labelErrorPhone.ForeColor = Color.Red;
                        return false;
                    }

                }
                else
                {
                    labelErrorEmail.Text = "Email sai định dạng !";
                    labelErrorEmail.ForeColor = Color.Red;
                    return false;
                }

            }
            else
            {
                label5.Text = "Tên không được để trống !";
                label5.ForeColor = Color.Red;
                return false;
            }
        }
        DateTime dateTimeNow = DateTime.Now;
        //chức năng thêm mới nhân viên
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckForm())
            {
                Employee employee = new Employee();
                employee.name = NameEm.Text;
                employee.email = EmailEm.Text;
                employee.phone = SDTEm.Text;
                employee.pass = PassEm.Text;
                employee.decript = DescriptEm.Text;
                employee.avt = "avt-man.png";
                employee.stt = 1;
                employee.date_created = dateTimeNow;

                managerHotel.Employees.InsertOnSubmit(employee);
                managerHotel.SubmitChanges();

                MessageBox.Show("Thêm mới thành công !");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }


        //chức năng cập nhật nhân viên
        //hiển thị thông tin nhân viên cần cập nhật
        private void ShowDataEmToUpdate()
        {
            if (employeeToUpdate != null)
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
            if (CheckForm())
            {
                var employee = managerHotel.Employees.FirstOrDefault(x => x.id == employeeToUpdate.id);
                employee.name = NameEm.Text;
                employee.email = EmailEm.Text;
                employee.phone = SDTEm.Text;
                employee.decript = DescriptEm.Text;
                employee.pass = PassEm.Text;
                employee.avt = "avt-man.png";
                employee.stt = SttEm.Checked == true ? 1 : 0;
                employee.date_update = dateTimeNow;

                managerHotel.SubmitChanges();

                MessageBox.Show("Cập nhật thành công !");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
