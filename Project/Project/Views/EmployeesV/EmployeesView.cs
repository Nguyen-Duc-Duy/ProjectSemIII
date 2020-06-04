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

namespace Project.Views.Employees
{
    public partial class EmployeesView : Form
    {
        ConnectDatabaseDataContext managerHotel;
        public EmployeesView()
        {
            managerHotel = new ConnectDatabaseDataContext();
            InitializeComponent();
            ShowDataEm();
            InterfaceDefault();
        }

        //giao diện mặc định
        private void InterfaceDefault()
        {
            UpdateEm.Visible = false;
            SttEm.Visible = false;
        }

        //hiển thị danh sách nhân viên
        private void ShowDataEm()
        {
            managerHotel.Refresh(System.Data.Linq.RefreshMode.KeepChanges, managerHotel.Employees);
            var listEm = from e in managerHotel.Employees where e.stt == 0 | e.stt == 1 select e;
            dataEm.DataSource = listEm;
        }

        //Chức năng tạo mới nhân viên
        //hiển thị form tạo mới
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            InforEmployee IE = new InforEmployee();
            IE.ShowDialog();
            if(IE.DialogResult == DialogResult.OK)
            {
                ShowDataEm();
            }
        }

        //chức năng cập nhật Thông tin nhân viên
        Employee EmSelected;
        //lấy nhân viên trên datatable
        private void dataEm_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowSelected = Convert.ToInt32(dataEm.CurrentRow.Cells["idEm"].Value.ToString());
            var Em = managerHotel.Employees.FirstOrDefault(x => x.id == rowSelected);

            EmSelected = Em;
            UpdateEm.Visible = true;
            SttEm.Visible = true;
            if (Em.stt == 1)
            {
                SttEm.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Commons\icons\icons8_eye_32.png"));
                SttEm.Text = "Đang làm";
            }
            else if (Em.stt == 0)
            {
                SttEm.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Commons\icons\icons8_invisible_32.png"));
                SttEm.Text = "Đã nghỉ làm";
            }
        }
        //hiển thị form cập nhật
        private void UpdateEm_Click(object sender, EventArgs e)
        {
            InforEmployee inforEmView = new InforEmployee(EmSelected);
            inforEmView.ShowDialog();
            if(inforEmView.DialogResult == DialogResult.OK)
            {
                ShowDataEm();
            }
        }

        private void SttEm_Click(object sender, EventArgs e)
        {
            DialogResult confirm;
            try
            {
                var em = managerHotel.Employees.FirstOrDefault(x => x.id == EmSelected.id);
                if (EmSelected.stt == 1)
                {
                    confirm = MessageBox.Show("Nhân viên này có chắc đang nghỉ làm ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        em.stt = 0;
                        managerHotel.SubmitChanges();
                    }
                }
                else if (EmSelected.stt == 0)
                {
                    confirm = MessageBox.Show("Nhân viên này có chắc đi làm lại ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        em.stt = 1;
                        managerHotel.SubmitChanges();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Vui lòng chọn nhân viên !");
            }
            
        }

        private void EmployeesView_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            ShowDataEm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchString = SearchEm.Text;
            var listEm = from em in managerHotel.Employees
                         where (em.stt == 0 | em.stt == 1) where em.name.Contains(searchString)
                         select em;
            dataEm.DataSource = listEm;
        }

        private void dataEm_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dataEm.Rows[e.RowIndex].Cells["STT"].Value = (e.RowIndex + 1).ToString();
        }
    }
}
