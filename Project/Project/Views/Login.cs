using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Project
{
    public partial class Login : Form
    {
        ConnectDatabaseDataContext managerHotel;
        public Login()
        {
            InitializeComponent();
            managerHotel = new ConnectDatabaseDataContext();
            //InterfaceDefault();
        }
        //giao diện mặc định
        private void InterfaceDefault()
        {

            errorEmail.Text = "";
            errorPass.Text = "";
            inputEmail.Text = "";
            inputPass.Text = "";
        }
        //phương thức đăng nhập
        //kiểm tra tính hợp lệ của email
        private bool CheckFormatEmail()
        {
            string email = inputEmail.Text;
            string regex = "\\A(?:[a-z0-9!#$%&'*+=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z";
            Regex re = new Regex(regex, RegexOptions.IgnoreCase);
            if (re.IsMatch(email))
            {
                errorEmail.Text = "Đã đúng định dạng !";
                errorEmail.ForeColor = ColorTranslator.FromHtml("#0a9b1b");
                return true;
            }
            else
            {
                errorEmail.Text = "Email không đúng định dạng !";
                return false;
            }

        }
        //kiểm tra trống trong input
        private void CheckNull()
        {
            string email = Regex.Replace(inputEmail.Text, @"[\s+]", ""); ;
            string pass = Regex.Replace(inputPass.Text, @"[\s+]", ""); ;
            if (email == "")
            {
                errorEmail.Text = "Email không được để trống !";
            }
            else
            {
                errorEmail.Text = "";
            }
            if (pass == "")
            {
                errorPass.Text = "Mật khẩu không được để trống !";
            }
            else
            {
                errorPass.Text = "";
            }
        }
        //xác minh email và pass
        private void LoginAcc()
        {
            CheckNull();
            if (CheckFormatEmail())
            {
                string email = inputEmail.Text;
                string pass = inputPass.Text;
                try
                {
                    Employee em = managerHotel.Employees.FirstOrDefault(e => e.email == email);

                    if (em.pass == pass)
                    {
                        managerHotel MH = new managerHotel(em,this);
                        MH.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("mật khẩu sai, xin vui lòng kiểm tra lại !");

                    }
                }
                catch (Exception e)
                {

                    MessageBox.Show("Tài khoản không tồn tại, xin vui lòng kiểm tra lại !");
                }
            }
        }

        private void inputEmail_KeyDown(object sender, KeyEventArgs e)
        {
            CheckFormatEmail();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginAcc();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
