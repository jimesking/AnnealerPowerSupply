using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;

namespace 退火电源2._0
{
    public partial class 非晶丝 : Form
    {
        Form1 form1 = new Form1();
        public 非晶丝(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }

        private void 非晶丝_Load(object sender, EventArgs e)
        {
            textBox5.Text = form1.FeiJingSiSn;
            textBox6.Text = form1.FeiJingSiLength.ToString();
            textBox7.Text = form1.FeiJingSiDianZu.ToString();
            textBox8.Text = form1.FeiJingSiZhiJing.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim() == "")
            {
                MessageBox.Show("请输入编号！");
                return;
            }
            if (textBox6.Text.Trim() == "")
            {
                MessageBox.Show("请输入长度！");
                return;
            }
            if (textBox7.Text.Trim() == "")
            {
                MessageBox.Show("请输入电阻！");
                return;
            }
            if (textBox8.Text.Trim() == "")
            {
                MessageBox.Show("请输入直径！");
                return;
            }

            try
            {
                form1.FeiJingSiSn = textBox5.Text.Trim();
                form1.FeiJingSiLength = float.Parse(textBox6.Text.Trim());
                form1.FeiJingSiDianZu = float.Parse(textBox7.Text.Trim());
                form1.FeiJingSiZhiJing = float.Parse(textBox8.Text.Trim());

                string strSql = "SELECT 非晶丝信息.[ID], 非晶丝信息.[编号], 非晶丝信息.[长度], 非晶丝信息.[电阻], 非晶丝信息.[直径] FROM 非晶丝信息 where 非晶丝信息.[编号] ='"+ textBox5.Text.Trim() +"'";
                string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\DataBase.accdb;Persist Security Info=False;";

                if (CAccessHelper.HasRecord(strSql, strConn) <= 0)
                {
                    strSql = "INSERT INTO 非晶丝信息 ( [编号], 长度,电阻,直径 ) VALUES ('" + textBox5.Text + "',";
                    strSql = strSql + form1.FeiJingSiLength +",";
                    strSql = strSql + form1.FeiJingSiDianZu +",";
                    strSql = strSql + form1.FeiJingSiZhiJing + ")";

                    CAccessHelper.Run_SQL(strSql, strConn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 插入数据到数据库
        /// </summary>
        private void InsertAccess()
        {
            OleDbConnection conn = null;

            try
            {
                OleDbCommand cmd = null;
                string strSql = "SELECT count(*) FROM 非晶丝信息 where 非晶丝信息.[编号] ='" + textBox5.Text.Trim() + "'";
                //string strSql = "INSERT INTO 非晶丝信息 ( [编号], 长度 ) VALUES ('12'," + 13 + ")";
                string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\DataBase.accdb;Persist Security Info=False;";

                conn = new OleDbConnection();
                conn.ConnectionString = strConn;

                conn.Open();

                //strNumber = "ab-2";
                //voltage = 0.1d;

                cmd = new OleDbCommand(strSql, conn);

                int i = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                //error process
            }
            finally
            {
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excle文件(*.xlsx)|.xlsx|xls files(*.xls)|*.xls|All files(*.*)|*.*";

            sfd.FilterIndex = 0;

            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径

                //获取文件路径，不带文件名 
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));

                //给文件名前加上时间 
                //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt;

                //在文件名里加字符 
                //saveFileDialog1.FileName.Insert(1,"dameng");

                //System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件

                ////fs输出带文字或图片的文件，就看需求了 

                string strSql = "SELECT * FROM 非晶丝信息 where 编号 ='" + textBox5.Text.Trim() + "'";
                string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\DataBase.accdb;Persist Security Info=False;";               

                DataTable dt = new DataTable();

                //dt = CAccessHelper.GetDataTable(strConn, strSql);

                dt = CAccessHelper.Get_DataTable(strSql, strConn, "aa");

                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("没有该非晶丝编号对应的数据记录！");
                    return;
                }

                string no = dt.Rows[0][1].ToString();
                string length = dt.Rows[0][2].ToString();
                string dianZu = dt.Rows[0][3].ToString();
                string zhiJin = dt.Rows[0][4].ToString();

                strSql = "SELECT * FROM 退火记录表 where 非晶丝编号 ='" + textBox5.Text.Trim() + "' order by ID";
                dt = CAccessHelper.Get_DataTable(strSql, strConn, "t0");

                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("没有该非晶丝编号对应的数据记录！");
                    return;
                }

                List<string> sPinLv = new List<string>();
                List<string> sDianLiu = new List<string>();
                List<string> sZhanKongBi = new List<string>();
                List<string> fLDianLiu = new List<string>();
                List<string> fLDianYa = new List<string>();
                List<string> fLDianZu = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sPinLv.Add(dt.Rows[i][2].ToString());
                    sDianLiu.Add(dt.Rows[i][3].ToString());
                    sZhanKongBi.Add(dt.Rows[i][4].ToString());
                    fLDianLiu.Add(dt.Rows[i][5].ToString());
                    fLDianYa.Add(dt.Rows[i][6].ToString());
                    fLDianZu.Add(dt.Rows[i][7].ToString());
                }

                CExcelHelper.SaveDataToExcel(localFilePath, no, length, dianZu, zhiJin, sPinLv, sDianLiu, sZhanKongBi, fLDianLiu, fLDianYa, fLDianZu);
            }

        }
//方法结束
    }
}
