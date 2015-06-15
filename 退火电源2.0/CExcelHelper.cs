using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Office.Interop.Excel;

namespace 退火电源2._0
{
    class CExcelHelper
    {
        /// <summary>
        /// 保存非晶丝数据到模板
        /// </summary>
        /// <param name="number">文件名</param>
        /// <param name="number">名称</param>
        /// <param name="lenth">长度</param>
        /// <param name="dianzu">电阻</param>
        /// <param name="zhijing">直径</param>
        /// <param name="list">电流</param>
        /// <param name="list">电压</param>
        public static void SaveDataToExcel(string fileName,string number, string lenth, string dianzu, string zhijing, List<string> sPinLv,List<string> sDianLiu,List<string> sZhanKongBi,List<string> dianLiu,List<string> dianYa,List<string> dianZu)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            app.UserControl = true;

            string str = System.IO.Directory.GetCurrentDirectory();
            //D:\\CSharpP\\ChartSample\\ChartSample\\bin\\Debug
            string fileName1 = str + "\\SavaData.xlsx";
            //string fileName1 = @"..\SavaData.xlsx";
            //打开一个WorkBook
            Workbook book = app.Workbooks.Open(fileName1,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            if (book == null)
                return;

            Worksheet worksheet = (Worksheet)book.Sheets.get_Item(1); //第一个工作薄。
            if (worksheet == null)
                return;  //工作薄中没有工作表.

            worksheet.Cells[5, 1] = number;
            worksheet.Cells[5, 2] = lenth;
            worksheet.Cells[5, 3] = dianzu;
            worksheet.Cells[5, 4] = zhijing;
            //写入数据，Excel索引从1开始。
            for (int i = 0; i < dianLiu.Count; i++)
            {
                worksheet.Cells[5 + i, 5] = sPinLv[i];
                worksheet.Cells[5 + i, 6] = sDianLiu[i];
                worksheet.Cells[5 + i, 7] = sZhanKongBi[i];
                worksheet.Cells[5 + i, 8] = dianLiu[i];
                worksheet.Cells[5 + i, 9] = dianYa[i];
                worksheet.Cells[5 + i, 10] = dianZu[i];
            }

            book.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            book.Close(null, null, null);
            app.Workbooks.Close();
            app.Quit();
        }
    }
}
