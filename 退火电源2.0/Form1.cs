using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;
using System.Threading;

using System.Xml;
using System.Data.OleDb;

namespace 退火电源2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 字段
        private 测试 testForm;

        //流程工作
        private int d = 0;
        private int d2 = 0;                //报警闪烁间隔
        private int _currentStep = -1;      //当前工作步骤

        private bool onWorkStatus = false; //工作状态

        private int timeAdd = 0;           //计时器
        private int settingTime = 0;       //设置计时时间
        //启动命令是否完成
        private bool _startCommandRegIsOver = true; //数据是否发送成功
        private bool _startCommandCoilIsOver = true;//线圈强制是否成功

        //串口
        private string _portName;
        private int _rate;
        private int _dataBits;
        private Parity _parity;
        private StopBits _stopBits;
        private byte[] _sendData;
        private byte[] _receivedData;

        //PID
        private int _kp;
        private int _ki;
        private int _kd;

        //短路开路
        private int _duanLu;
        private int _kaiLu;

        //短路开路状态开关
        private bool _sDuanlu;
        private bool _sKaiLu;

        //非晶丝
        private string _feiJingSiSn;
        private float _feiJingSiLength;
        private float _feiJingSiZhiJing;
        private float _feiJingSiDianZu;

        //退火参数
        private List<int> _pinLv = new List<int>();
        private List<int> _dianLiu = new List<int>();
        private List<int> _zhanKongBi = new List<int>();
        private List<int> _shiJian = new List<int>();

        //当前电流，电压
        private float _currentDianLiu = 0;
        private float _currentDianYa = 0;
        private float _currentDianZu = 0;

        //init参数值
        private string _initPortName;

        private string _initKaiLu;
        private string _initDuanLu;

        private string _initKp;
        private string _initKi;
        private string _initKd;

        private List<string> _initListBoxItems = new List<string>();

        //曲线
        private List<float> _listDianLiu = new List<float>();
        private List<float> _listDianYa = new List<float>();

        private float[] arrayDianLiu = new float[100];
        private float[] arrayDianya = new float[100];
        private int arrayCount = 0;

        private int _pointsCount = 10;

        #endregion

        #region 属性

        #region 工作流程属性
        public bool StartCommandRegIsOver
        {
            get { return _startCommandRegIsOver; }
            set { _startCommandRegIsOver = value; }
        }

        public bool StartCommandCoilIsOver
        {
            get { return _startCommandCoilIsOver; }
            set { _startCommandCoilIsOver = value; }
        }

        public int CurrentStep
        {
            get { return _currentStep; }
            set { _currentStep = value; }
        }
        #endregion

        #region 串口属性
        public byte[] SendData
        {
            get { return _sendData; }
            set { _sendData = value; }
        }

        public byte[] ReceivedData
        {
            get { return _receivedData; }
            set { _receivedData = value; }
        }

        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        public int Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }

        public int DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        public Parity Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }

        public StopBits StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        } 
        #endregion

        #region PID属性
        public int Kp
        {
            get { return _kp; }
            set { _kp = value; }
        }

        public int Ki
        {
            get { return _ki; }
            set { _ki = value; }
        }

        public int Kd
        {
            get { return _kd; }
            set { _kd = value; }
        } 
        #endregion

        #region 短路开路属性
        public int DuanLu
        {
            get { return _duanLu; }
            set { _duanLu = value; }
        }

        public int KaiLu
        {
            get { return _kaiLu; }
            set { _kaiLu = value; }
        }

        public bool SDuanlu
        {
            get { return _sDuanlu; }
            set { _sDuanlu = value; }
        }

        public bool SKaiLu
        {
            get { return _sKaiLu; }
            set { _sKaiLu = value; }
        }
        #endregion

        #region 非晶丝属性
        public string FeiJingSiSn
        {
            get { return _feiJingSiSn; }
            set { _feiJingSiSn = value; }
        }

        public float FeiJingSiLength
        {
            get { return _feiJingSiLength; }
            set { _feiJingSiLength = value; }
        }

        public float FeiJingSiZhiJing
        {
            get { return _feiJingSiZhiJing; }
            set { _feiJingSiZhiJing = value; }
        }

        public float FeiJingSiDianZu
        {
            get { return _feiJingSiDianZu; }
            set { _feiJingSiDianZu = value; }
        } 
        #endregion

        #region 退火属性
        public List<int> PinLv
        {
            get { return _pinLv; }
            set { _pinLv = value; }
        }

        public List<int> DianLiu
        {
            get { return _dianLiu; }
            set { _dianLiu = value; }
        }

        public List<int> ZhanKongBi
        {
            get { return _zhanKongBi; }
            set { _zhanKongBi = value; }
        }

        public List<int> ShiJian
        {
            get { return _shiJian; }
            set { _shiJian = value; }
        } 
        #endregion

        #region 初始化参数
        public string InitPortName
        {
            get { return _initPortName; }
            set { _initPortName = value; }
        }

        public string InitKaiLu
        {
            get { return _initKaiLu; }
            set { _initKaiLu = value; }
        }

        public string InitDuanLu
        {
            get { return _initDuanLu; }
            set { _initDuanLu = value; }
        }

        public string InitKp
        {
            get { return _initKp; }
            set { _initKp = value; }
        }

        public string InitKi
        {
            get { return _initKi; }
            set { _initKi = value; }
        }

        public string InitKd
        {
            get { return _initKd; }
            set { _initKd = value; }
        }

        public List<string> InitListBoxItems
        {
            get { return _initListBoxItems; }
            set { _initListBoxItems = value; }
        }

        #endregion

        #region 曲线属性

        public List<float> ListDianLiu
        {
            get { return _listDianLiu; }
            set { _listDianLiu = value; }
        }

        public List<float> ListDianYa
        {
            get { return _listDianYa; }
            set { _listDianYa = value; }
        }


        public int PointsCount
        {
            get { return _pointsCount; }
            set { _pointsCount = value; }
        }

        #endregion

        #region 当前电流，电压，电阻
         public float CurrentDianLiu
        {
            get { return _currentDianLiu; }
            set { _currentDianLiu = value; }
        }

        public float CurrentDianYa
        {
            get { return _currentDianYa; }
            set { _currentDianYa = value; }
        }

        public float CurrentDianZu
        {
            get { return _currentDianZu; }
            set { _currentDianZu = value; }
        }
        #endregion

        #endregion

        #region 工具栏
        private void 串口参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            串口设置 sf = new 串口设置(this);
            sf.Show();
        }

        private void pID参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PID参数 pidf = new PID参数(this);
            pidf.Show();
        }

        private void 非晶丝ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            非晶丝 ff = new 非晶丝(this);
            ff.Show();
        }

        private void 短路开路ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            短路开路 df = new 短路开路(this);
            df.Show();
        }

        private void 退火参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            退火参数 tf = new 退火参数(this);
            tf.Show();
        }

        //电流
        private void 电流ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[0].LegendText = "电流";
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < ListDianLiu.Count; i++)
            {
                chart1.Series[0].Points.AddY(ListDianLiu[i]);
            }
        }
        //电压
        private void 电压ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[0].LegendText = "电压";
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < ListDianLiu.Count; i++)
            {
                chart1.Series[0].Points.AddY(ListDianYa[i]);
            }
        }
        //测试
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            测试 cf = new 测试(this);
            cf.Show();
            testForm = cf;
        }
        //启动
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (onWorkStatus == true)
            {
                MessageBox.Show("有工作正在运行！");
                return;
            }
            if (true == CheckSetting())
            {                
                onWorkStatus = true;              
                CWorkFlow.GoToStep(0,this);
                CurrentStep = 0;
                timer2.Enabled = false;
                timer1.Enabled = true;
                toolStripButton5.Enabled = false;
            }
        }
        //停止
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            onWorkStatus = false;
            CurrentStep = 0;
            timer1.Enabled = false;
            timer2.Enabled = true;
            toolStripButton5.Enabled = true;
        }
        #endregion

        #region 串口
        //发送数据
        public void SerialSendData(byte[] buffer)
        {
            serialPort1.Write(buffer, 0, buffer.Length);
            //等待命令反馈数据初始化
            SendData = buffer;
        }
        //串口数据接收事件
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                //接收数据
                Thread.Sleep(100);
                byte[] buffer = new byte[serialPort1.BytesToRead];
                CheckForIllegalCrossThreadCalls = false;
                serialPort1.Read(buffer, 0, buffer.Length);

                bool checkIsRight = false;
                if (buffer == CModbus.CRCCheck(buffer))
                {
                    checkIsRight = true;
                }
                else
                {
                    checkIsRight = false;
                }
                
                //如果接收数据正确
                if (checkIsRight)
                {
                    ReceivedData = buffer;

                    bool response = CModbus.ModbusDataHandle(SendData,buffer,this);

                    if (buffer[1] == 0x04 && buffer[2] == 0x06 && onWorkStatus == true)
                    {
                        //AddPointToChart();

                        //SavaRecentDataToArray();
                        //if (chart1.Series[0].LegendText == "电流")
                        //{
                        //    AddPointsToChart(arrayDianLiu);
                        //}
                        //if (chart1.Series[0].LegendText == "电压")
                        //{
                        //    AddPointsToChart(arrayDianya);
                        //}

                        //CChart.AddPoint(CurrentDianLiu, chart1, 10);
                    }

                    //if (testForm != null)
                    //{
                    //    ShowMessageOnTestForm(buffer);
                    //}
                }
                else
                {
                    return;
                }
            }
            catch
            {

            }
        }

        //打开串口
        public void OpenSeriaPort(string name,int rate,int dataBits,Parity parity,StopBits stopBits)
        {
            try
            {
                serialPort1.Close();
                serialPort1.PortName = name;
                serialPort1.BaudRate = rate;
                serialPort1.DataBits = dataBits;
                serialPort1.Parity = parity;
                serialPort1.StopBits = stopBits;
                serialPort1.Open();
            }
            catch
            {
 
            }
        }

        //关闭串口
        public void CloseSeriaPort()
        {
            serialPort1.Close();
        } 

        public bool Response(int f)
        {
            if (SendData != null && ReceivedData != null && SendData.Length > 0 && ReceivedData.Length > 0)
            {
                if (SendData[1] == f && ReceivedData[1] == f)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        //定时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            d = d + 1;
            if (d >= 2)
                d = 0;

            //显示状态
            string str = CWorkFlow.DisplayStuts(timeAdd, CurrentStep, PinLv.Count, CurrentDianLiu, CurrentDianYa, CurrentDianZu);
            toolStripLabel2.Text = str;
            //报警信息
            AlarmDisplay(d);

            //读取数据

            CWorkFlow.ReadDataOnTime(d,this);


            if (true == onWorkStatus && d ==1)
            {
                timeAdd = timeAdd + 1;   //0,0

                if (timeAdd >= ShiJian[CurrentStep])
                {
                    //判断工作是否完成
                    if (CurrentStep >= (PinLv.Count-1))
                    {
                        onWorkStatus = false;
                        timer1.Enabled = false;
                        timer2.Enabled = true;
                        CWorkFlow.FinishWork(this);
                        toolStripButton5.Enabled = true;
                        CurrentStep = -1;
                        timeAdd = 0;
                        chart1.Series[0].Points.Clear();
                    }
                    else
                    {
                        CWorkFlow.GoToStep(CurrentStep + 1, this);
                        CurrentStep = CurrentStep + 1;
                        timeAdd = 0;
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (onWorkStatus == true)
            {
                timer2.Enabled = false;
            }
            d2 = d2 + 1;
            if (d2 >= 2)
                d2 = 0;
            //显示状态
            string str = CWorkFlow.DisplayStuts(timeAdd, CurrentStep, PinLv.Count, CurrentDianLiu, CurrentDianYa, CurrentDianZu);
            toolStripLabel2.Text = str;
            //报警信息
            AlarmDisplay(d2);

            //读取数据
            if (serialPort1.IsOpen == true)
            {
                CWorkFlow.ReadDataOnTime(d2, this);
            }
        }
        //报警显示
        private void AlarmDisplay(int d)
        {
            if (SKaiLu == true || SDuanlu == true || serialPort1.IsOpen == false)
            {
                toolStripLabel1.ForeColor = Color.Red;
                if (d == 0)
                {
                    toolStripLabel1.Visible = false;
                }
                else
                {
                    toolStripLabel1.Visible = true;
                }
                if(SKaiLu == true && SDuanlu == false && serialPort1.IsOpen == true)
                {
                    toolStripLabel1.Text = "开路报警";
                }
                if (SKaiLu == false && SDuanlu == true && serialPort1.IsOpen == true)
                {
                    toolStripLabel1.Text = "短路报警";
                }
                if (SKaiLu == false && SDuanlu == false && serialPort1.IsOpen == false)
                {
                    toolStripLabel1.Text = "串口没有打开";
                }
            }
            else
            {
                toolStripLabel1.ForeColor = Color.Black;
                toolStripLabel1.Visible = true;
                toolStripLabel1.Text = "";
            }
        }
        //检查设置
        private bool CheckSetting()
        {
            if (PinLv == null)
            {
                MessageBox.Show("请设置好退火参数！");
                return false;
            }
            //退火工艺参数
            if (PinLv.Count <= 0)
            {
                MessageBox.Show("请设置好退火参数！");
                return false;
            }
            //串口参数
            if (serialPort1.IsOpen == false)
            {
                MessageBox.Show("请打开串口");
                return false;
            }

            //非晶丝参数
            if (FeiJingSiSn == "")
            {
                MessageBox.Show("请设置好非晶丝参数！");
                return false;
            }
            if (FeiJingSiLength >= -float.Epsilon && FeiJingSiLength <= float.Epsilon)
            {
                MessageBox.Show("请设置好非晶丝长度！");
                return false;
            }
            if (FeiJingSiDianZu >= -float.Epsilon && FeiJingSiDianZu <= float.Epsilon)
            {
                MessageBox.Show("请设置好非晶丝电阻！");
                return false;
            }
            if (_feiJingSiZhiJing >= -float.Epsilon && _feiJingSiZhiJing <= float.Epsilon)
            {
                MessageBox.Show("请设置好非晶丝直径！");
                return false;
            }

            ////短路开路
            //if (DuanLu == 0 || KaiLu == 0)
            //{
            //    MessageBox.Show("请设置好短路，开路参数！");
            //    return false;
            //}
            ////PID参数
            ////短路开路
            //if (Kp == 0 || Kd == 0 || Ki == 0)
            //{
            //    MessageBox.Show("请设置好PID参数！");
            //    return false;
            //}

            return true;
        }
        //初始化参数
        private void InitPara()
        {
            /*
             * <?xml version="1.0" encoding="utf-8"?>
                <初始化参数>
                  <SerialPort portName="COM1" />
                  <KaiLuDuanLu>
	                <KaiLu></KaiLu>
	                <DuanLu></DuanLu>
                  </KaiLuDuanLu>
                  <PID>
                    <KP></KP>
	                <KI></KI>
	                <KD></KD>
                  </PID>
                  <TuiHuo>
	                <step1 pinLv="11" dianLiu="12" zhanKongBi="13" shiJian="14"></step1>
	                <step2 pinLv="12" dianLiu="13" zhanKongBi="14" shiJian="15"></step2>
	                <step3 pinLv="13" dianLiu="14" zhanKongBi="15" shiJian="16"></step3>
	                <step4 pinLv="14" dianLiu="15" zhanKongBi="16" shiJian="17"></step4>
	                <step5 pinLv="15" dianLiu="16" zhanKongBi="17" shiJian="18"></step5>
                  </TuiHuo >
                </初始化参数>
            */
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(@"ini.xml");
            //串口名
            XmlAttribute att = (XmlAttribute)xmldoc.SelectSingleNode("初始化参数//SerialPort//@portName");
            InitPortName = att.Value;
            //开路短路
            XmlNode node = xmldoc.SelectSingleNode("初始化参数//KaiLuDuanLu//KaiLu");
            if (node.InnerText != "")
            {
                InitKaiLu = node.InnerText;
            }
            node = xmldoc.SelectSingleNode("初始化参数//KaiLuDuanLu//DuanLu");
            if (node.InnerText != "")
            {
                InitDuanLu = node.InnerText;
            }
            //PID
            node = xmldoc.SelectSingleNode("初始化参数//PID//KP");
            if (node.InnerText != "")
            {
                InitKp = node.InnerText;
            }
            node = xmldoc.SelectSingleNode("初始化参数//PID//KI");
            if (node.InnerText != "")
            {
                InitKi = node.InnerText;
            }
            node = xmldoc.SelectSingleNode("初始化参数//PID//KD");
            if (node.InnerText != "")
            {
                InitKd = node.InnerText;
            }
            //TuiHuo
            node = xmldoc.SelectSingleNode("初始化参数//TuiHuo");
            XmlNodeList nodelist = node.ChildNodes;
            if (nodelist != null && nodelist.Count > 0)
            {
                InitListBoxItems.Clear();
                foreach (XmlNode nodechild in nodelist)
                {
                    if (nodechild.InnerText.Length > 10)
                    {
                        InitListBoxItems.Add(nodechild.InnerText);
                    }
                }
            }
        }
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            InitPara();
            chart1.Series[0].LegendText = "电流";
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            timer2.Enabled = true;
        }

        private void InsertAccess()
        {
            OleDbConnection conn = null;

            try
            {
                OleDbCommand cmd = null;
                String strConnection, strSQL;

                strConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\123.accdb;Persist Security Info=False;";

                conn = new OleDbConnection();
                conn.ConnectionString = strConnection;

                conn.Open();

                //strNumber = "ab-2";
                //voltage = 0.1d;

               // strSQL = "INSERT INTO 表1 ( [No], voltage ) VALUES ('" + strNumber + "'," + voltage + ")";

                cmd = new OleDbCommand("", conn);

                cmd.ExecuteNonQuery();
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
        //数据发送反馈提示
        private void ResponseMessageBox(byte[] SendData,byte[] buffer)
        {
            bool b = true;
            for (int i = 0; i < 5; i++)
            {
                if (buffer[i] != SendData[i])
                {
                    b = false;
                }
            }
            if (b == true)
            {
                MessageBox.Show("设置成功！");
            }
        }

        private void SavaRecentDataToArray()
        {
            if (arrayCount <= 101)
            {
                arrayCount += 1;
            }

            if (arrayCount <= PointsCount)
            {
                arrayDianLiu[100 - arrayCount] = CurrentDianLiu;
                arrayDianya[100 - arrayCount] = CurrentDianYa;
            }
            else
            {
                float[] tempArray = new float[100];
                tempArray = arrayDianLiu;
                for (int i = 0; i < 99; i++)
                {
                    arrayDianLiu[i] = tempArray[i + 1];
                }
                arrayDianLiu[99] = CurrentDianLiu;

                tempArray = arrayDianya;
                for (int i = 0; i < 99; i++)
                {
                    arrayDianya[i] = tempArray[i + 1];
                }
                arrayDianya[99] = CurrentDianLiu;
            }
        }
        private void AddPointsToChart(float[] points)
        {
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < points.Length; i++)
            {
                chart1.Series[0].Points.AddY(points[i]);
            }
        }
        //在曲线中增加数据点
        private void AddPointToChart()
        {
            //电流
            if (ListDianLiu.Count > PointsCount)
            {
                ListDianLiu.RemoveAt(0);
            }
            ListDianLiu.Add(CurrentDianLiu);

            //电压
            if (ListDianYa.Count > PointsCount)
            {
                ListDianYa.RemoveAt(0);
            }
            ListDianYa.Add(CurrentDianYa);

            //曲线
            //电流
            lock(chart1)
            {
                if (chart1.Series[0].LegendText == "电流")
                {
                    if (chart1.Series[0].Points.Count > PointsCount)
                    {
                        chart1.Series[0].Points.RemoveAt(0);
                    }
                    chart1.Series[0].Points.AddY(CurrentDianLiu);
                }
            }
            //电压
            if (chart1.Series[0].LegendText == "电压")
            {
                if (chart1.Series[0].Points.Count > PointsCount)
                {
                    chart1.Series[0].Points.RemoveAt(0);
                }
                chart1.Series[0].Points.AddY(CurrentDianYa);
            }
        }

        private void ShowMessageOnTestForm(byte[] buffer)
        {
            string str = "";
            for (int i = 0; i < buffer.Length; i++)
            {
                string hexStr = String.Format("{0:X}", buffer[i]);
                str = str + hexStr + " ";
            }
            str = str + "\r\n";
            testForm.textBox1.Text = testForm.textBox1.Text + str;
            if (testForm.textBox1.Lines.Length >= 10)
            {
                testForm.textBox1.Text = "";
            }
        }

        //方法结束
    }
}
