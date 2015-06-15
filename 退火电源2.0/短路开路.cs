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
    public partial class 短路开路 : Form
    {
        Form1 form1 = new Form1();
        public 短路开路(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox12.Text.Trim() == "")
            {
                MessageBox.Show("请输入短路值！");
                return;
            }
            if (textBox13.Text.Trim() == "")
            {
                MessageBox.Show("请输入开路值！");
                return;
            }

            try
            {
                float k = float.Parse(textBox12.Text.Trim());
                float d = float.Parse(textBox13.Text.Trim());

                int kk = (int)k * 10;
                int kd = (int)d * 10;

                byte kHi = Convert.ToByte(kk / 256);
                byte kLow = Convert.ToByte(kk % 256);

                byte dHi = Convert.ToByte(kd / 256);
                byte dLow = Convert.ToByte(kd % 256);

                byte[] data = new byte[4] { kHi, kLow,dHi, dLow};

                byte[] buffer = CModbus.F16(0x02, 0x06, 0x00, 0x02, 0x04, data);

                form1.SerialSendData(buffer);

                CXMLHelper.MyUpdataNode("初始化参数//KaiLuDuanLu//KaiLu", textBox12.Text);
                CXMLHelper.MyUpdataNode("初始化参数//KaiLuDuanLu//DuanLu", textBox13.Text);
                form1.InitKaiLu = textBox12.Text;
                form1.InitDuanLu = textBox13.Text;

                Thread.Sleep(300);
                label1.Text = "读取值： " + (form1.KaiLu/10).ToString();
                label2.Text = "读取值： " + (form1.DuanLu/10).ToString();
            }
            catch
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 短路开路_Load(object sender, EventArgs e)
        {
            textBox12.Text = form1.InitKaiLu;
            textBox13.Text = form1.InitDuanLu;

            label1.Text = "读取值： " + (form1.KaiLu / 10).ToString();
            label2.Text = "读取值： " + (form1.DuanLu / 10).ToString();
        }
    }
}
