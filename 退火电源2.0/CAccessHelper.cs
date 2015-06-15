using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Data;

namespace 退火电源2._0
{
    class CAccessHelper
    {
        public static string ConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\123.accdb;Persist Security Info=False;";
        //public static string ConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\123.laccdb;";
        //public static string ConnStr = MyData.Properties.Settings.Default.my_soft_oledbConn;
        //打开数据库链接
        public static OleDbConnection Open_Conn(string ConnStr)
        {
            OleDbConnection Conn = new OleDbConnection(ConnStr);
            Conn.Open();
            return Conn;
        }
        //关闭数据库链接
        public static void Close_Conn(OleDbConnection Conn)
        {
            if (Conn != null)
            {
                Conn.Close();
                Conn.Dispose();
            }
            GC.Collect();
        }
        //运行OleDb语句
        public static int Run_SQL(string SQL, string ConnStr)
        {
            OleDbConnection Conn = Open_Conn(ConnStr);
            OleDbCommand Cmd = Create_Cmd(SQL, Conn);
            try
            {
                int result_count = Cmd.ExecuteNonQuery();
                Close_Conn(Conn);
                return result_count;
            }
            catch
            {
                Close_Conn(Conn);
                return 0;
            }
        }
        // 生成Command对象 
        public static OleDbCommand Create_Cmd(string SQL, OleDbConnection Conn)
        {
            OleDbCommand Cmd = new OleDbCommand(SQL, Conn);
            return Cmd;
        }
        // 运行OleDb语句返回 DataTable
        public static DataTable Get_DataTable(string SQL, string ConnStr, string Table_name)
        {
            OleDbDataAdapter Da = Get_Adapter(SQL, ConnStr);
            DataTable dt = new DataTable(Table_name);
            Da.Fill(dt);
            return dt;
        }
        // 运行OleDb语句返回 OleDbDataReader对象
        public static OleDbDataReader Get_Reader(string SQL, string ConnStr)
        {
            OleDbConnection Conn = Open_Conn(ConnStr);
            OleDbCommand Cmd = Create_Cmd(SQL, Conn);
            OleDbDataReader Dr;
            try
            {
                Dr = Cmd.ExecuteReader(CommandBehavior.Default);
            }
            catch
            {
                throw new Exception(SQL);
            }
            Close_Conn(Conn);
            return Dr;
        }
        // 运行OleDb语句返回 OleDbDataAdapter对象 
        public static OleDbDataAdapter Get_Adapter(string SQL, string ConnStr)
        {
            OleDbConnection Conn = Open_Conn(ConnStr);
            OleDbDataAdapter Da = new OleDbDataAdapter(SQL, Conn);
            return Da;
        }
        // 运行OleDb语句,返回DataSet对象
        public static DataSet Get_DataSet(string SQL, string ConnStr, DataSet Ds)
        {
            OleDbDataAdapter Da = Get_Adapter(SQL, ConnStr);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Err)
            {
                throw Err;
            }
            return Ds;
        }
        // 运行OleDb语句,返回DataSet对象
        public static DataSet Get_DataSet(string SQL, string ConnStr, DataSet Ds, string tablename)
        {
            OleDbDataAdapter Da = Get_Adapter(SQL, ConnStr);
            try
            {
                Da.Fill(Ds, tablename);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return Ds;
        }
        // 运行OleDb语句,返回DataSet对象，将数据进行了分页
        public static DataSet Get_DataSet(string SQL, string ConnStr, DataSet Ds, int StartIndex, int PageSize, string tablename)
        {
            OleDbConnection Conn = Open_Conn(ConnStr);
            OleDbDataAdapter Da = Get_Adapter(SQL, ConnStr);
            try
            {
                Da.Fill(Ds, StartIndex, PageSize, tablename);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            Close_Conn(Conn);
            return Ds;
        }

        public static int HasRecord(string strSQL,string strConn)
        {
            int i = 0;

            OleDbConnection conn = null;

            try
            {
                OleDbCommand cmd = null;

                conn = new OleDbConnection();
                conn.ConnectionString = strConn;

                conn.Open();

                cmd = new OleDbCommand(strSQL, conn);

                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    i = (int)dr[0];
                }
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

            return i;
        }
        public static DataTable GetDataTable(string strConn, string strSQL)
        {
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(strSQL, strConn);
            da.Fill(dt);
            return dt;
        }
    }
}
