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
using System.Collections;

namespace 退火电源2._0
{
    public partial class 串口设置 : Form
    {
        Form1 form1 = new Form1();
        public 串口设置(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }
        private void 串口设置_Load(object sender, EventArgs e)
        {
            comboBox1.Text = form1.InitPortName;
        }
        //打开串口
        private void button1_Click(object sender, EventArgs e)
        {           
            form1.PortName = comboBox1.Text;
            form1.OpenSeriaPort(comboBox1.Text.Trim(), 9600, 8, Parity.None, StopBits.One);

            CXMLHelper.MyUpdataAttribute("初始化参数//SerialPort", "portName", form1.PortName);
            form1.InitPortName = comboBox1.Text;
            this.Close();
        }
        //关闭串口
        private void button2_Click(object sender, EventArgs e)
        {
            form1.CloseSeriaPort();
            this.Close();
        }
    }
}
