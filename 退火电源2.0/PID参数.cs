using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace 退火电源2._0
{
    public partial class PID参数 : Form
    {
        Form1 form1 = new Form1();
        public PID参数(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }
        private void PID参数_Load(object sender, EventArgs e)
        {
            textBox9.Text = form1.InitKp;
            textBox10.Text = form1.InitKi;
            textBox11.Text = form1.InitKd;

            label3.Text = "读取值： " + (form1.Kp / 10).ToString();
            label4.Text = "读取值： " + (form1.Ki / 10).ToString();
            label5.Text = "读取值： " + (form1.Kd / 10).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户名！");
                return;
            }
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户密码！");
                return;
            }
            groupBox3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Trim() == "")
            {
                MessageBox.Show("请输入P！");
                return;
            }
            if (textBox10.Text.Trim() == "")
            {
                MessageBox.Show("请输入I！");
                return;
            }
            if (textBox11.Text.Trim() == "")
            {
                MessageBox.Show("请输入D！");
                return;
            }

            try
            {
                float p = float.Parse(textBox9.Text.Trim());
                float i = float.Parse(textBox10.Text.Trim());
                float d = float.Parse(textBox11.Text.Trim());

                int kp = (int)p * 10;
                int ki = (int)i * 10;
                int kd = (int)d * 10;

                byte kpHi = Convert.ToByte(kp / 256);
                byte kpLow = Convert.ToByte(kp % 256);

                byte kiHi = Convert.ToByte(ki / 256);
                byte kiLow = Convert.ToByte(ki % 256);

                byte kdHi = Convert.ToByte(kd / 256);
                byte kdLow = Convert.ToByte(kd % 256);

                byte[] data = new byte[6]{kpHi,kpLow,kiHi,kiLow,kdHi,kdLow};

                byte[] buffer = CModbus.F16(0x02, 0x03, 0x00,0x03, 0x06, data);
                form1.SerialSendData(buffer);

                CXMLHelper.MyUpdataNode("初始化参数//PID//KP", textBox9.Text.Trim());
                CXMLHelper.MyUpdataNode("初始化参数//PID//KI", textBox10.Text.Trim());
                CXMLHelper.MyUpdataNode("初始化参数//PID//KD", textBox11.Text.Trim());

                form1.InitKp = textBox9.Text;
                form1.InitKi = textBox10.Text;
                form1.InitKd = textBox11.Text;

                Thread.Sleep(300);
                label3.Text = "读取值： " + (form1.Kp / 10).ToString();
                label4.Text = "读取值： " + (form1.Ki / 10).ToString();
                label5.Text = "读取值： " + (form1.Kd / 10).ToString();
            }
            catch
            { }
        }

    }
}
