using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project.Views.Dashboards
{
    public partial class DashboardView : Form
    {
        ConnectDatabaseDataContext db = new ConnectDatabaseDataContext();
        public DashboardView()
        {
            InitializeComponent();
            loadChartService();
            loadChartRoom();
        }

        private void DashboardView_Load(object sender, EventArgs e)
        {
            
        }

        private void loadChartService()
        {
            var dataChart = db.Servicers.Select(
                   x => new
                   {
                       name = x.name,
                       soluong = x.Details_Bills.Count()
                   }
                );
            chartService.DataSource = dataChart;
            chartService.Series["dashSer"].XValueMember = "name";
            chartService.Series["dashSer"].YValueMembers = "soluong";
            chartService.DataBind();
        }
        private void loadChartRoom()
        {
            DateTime dateTime = DateTime.Now;
            var dateStart = new DateTime(dateTime.Year, dateTime.Month, 1);
            var dateEnd = dateStart.AddMonths(1).AddDays(-1);
            var dataChart = db.billsOfMonth(dateStart.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"))
                .Select(x => new { date = x.dateFrom, number = x.num });

            chartBill.DataSource = dataChart;
            chartBill.Series["bill"].XValueMember = "date";
            chartBill.Series["bill"].YValueMembers = "number";
            chartBill.DataBind();

            //int dateE = (int)dateEnd.Day;
            //for (int i = 1; i <= dateE; i++)
            //{
            //    var d = new DateTime(dateTime.Year, dateTime.Month, i);
            //    var dataChart = db.billsOfMonthByDay(d.ToString("yyyy-MM-dd"))
            //   .Select(x => new { date = x.dateFrom, number = x.num });
            //    chartBill.DataSource = dataChart;
            //    chartBill.Series["bill"].XValueMember = "date";
            //    chartBill.Series["bill"].YValueMembers = "number";
            //}
            //chartBill.DataBind();
        }
    }
}
