using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project.Views.PaysView
{
    public partial class PaysView : Form
    {
        public PaysView()
        {
            InitializeComponent();
            ResoultSearching();
            RoomsServices();
        }
        
        //hiển trị kết quả tìm khách hàng
        private void ResoultSearching()
        {
            int number = 0;
            for (int i = 0; i < 8; i++)
            {
                Label l = new Label();
                l.AutoSize = true;
                l.Text = "Chào tất cả mọi người ! chúc mọi người ngày mới vui vẻ !";
                l.Font = new Font("Microsoft Sans Serif", 12);
                l.Location = new Point(10, number);
                number += 30;
                ResoultSearch.Controls.Add(l);

            }
        }
        private void Pays_Load(object sender, EventArgs e)
        {

        }
        //hiển thị phòng và dịch vụ tương úng
        private void RoomsServices()
        {
            int number = 0;

            for (int i = 0; i < 2; i++)
            {
                number += 1;
                GroupBox gb = new GroupBox();
                gb = RoomBilling.Clone();
                gb.Text = "Phòng " + number;
                gb.Visible = true;
                gb.Name = RoomBilling.Name + number;

                foreach (Control item in RoomBilling.Controls)
                {
                    if (item.GetType() == typeof(Label))
                    {
                        Label l = (Label)item;
                        Label c = new Label();
                        c = (Label)l.Clone();
                        c.Visible = true;
                        c.Name = l.Name + number;
                        gb.Controls.Add(c);
                    }
                    else
                    {
                        DataGridView b = new DataGridView();
                        b.Text = "Thử Control";
                        b.Location = new Point(item.Location.X, item.Location.Y);
                        b.Width = item.Width;
                        b.Height = item.Height;
                        b.Visible = true;
                        gb.Controls.Add(b);
                    }
                }
                BoxRooms.Controls.Add(gb);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
