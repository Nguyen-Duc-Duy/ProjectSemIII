using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crystal_Report
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            studentCrystal crystal = new studentCrystal();
            WinFormDataContext dataContext = new WinFormDataContext();
            var d = dataContext.students.Select(
                x => new modelStudents
                {
                    id = x.id,
                    name = x.name,
                    code = x.code,
                    avt = x.avt,
                    stt = x.stt != null ? true : false,
                    classStudent = x.@class.name
                }
                );
            crystal.SetDataSource(d);
            cpt.ReportSource = crystal;
            cpt.Show();
        }
    }
}
