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
    public partial class OrdersView : Form
    {
        public OrdersView()
        {
            InitializeComponent();
            InterfaceDefault();
            groupBox2.MaximumSize = new System.Drawing.Size(flowLayoutPanel2.Width, 200);

            VableRooms();
        }

        private void OrdersView_Load(object sender, EventArgs e)
        {

        }
        //giao diện mặc định
        private void InterfaceDefault()
        {
            
        }
        //thiết kết dữ liệu của phòng có thể đặt
        private void VableRooms()
        {
            int number = 20;
            label14.Visible = false;
            for (int i = 0; i < 3; i++)
            {
                Label l = new Label();
                l.AutoSize = true;
                l.Visible = true;
                l.BackColor = Color.Transparent;
                l.Padding = new Padding(60,10,0,0);
                l.Text = "Tên loại phòng " + number + " : số phòng";
                l.Location = new Point(20, number);
                number += 30;
                groupBox2.Controls.Add(l);
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CusName.Clear();
            InputCard.Clear();
            InputSDT.Clear();
            InputDescrips.Clear();
            numericAdult.Value = 0;
            numeriChildrent.Value = 0;
            numericPrepay.Value = 0;
        }
    }
}
