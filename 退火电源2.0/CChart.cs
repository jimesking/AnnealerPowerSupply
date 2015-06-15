using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms.DataVisualization.Charting;
using System.Data;

namespace 退火电源2._0
{
    class CChart
    {
        public static void QieHuan(float[] points,Chart chart1)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddY(points);
        }
        public static void AddPoint(float point, Chart chart1,int maxCount)
        {
            if (chart1.Series[0].Points.Count >= maxCount)
            {
                chart1.Series[0].Points.RemoveAt(0);
            }
            chart1.Series[0].Points.AddY(point);
        }

        public static void DataBindToChart(Chart chart1,DataTable dt)
        {
            chart1.DataSource = dt;
            chart1.Series[0].YValueMembers = "电流";
            chart1.DataBind();

            chart1.Series[0].IsValueShownAsLabel = true;
        }
    }
}
