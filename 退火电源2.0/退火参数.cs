using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 退火电源2._0
{
    public partial class 退火参数 : Form
    {
        Form1 form1 = new Form1();
        public 退火参数(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }
        private void 退火参数_Load(object sender, EventArgs e)
        {
            if (form1.PinLv.Count <= 0)
            {
                if (form1.InitListBoxItems != null && form1.InitListBoxItems.Count >= 0)
                {
                    listBox1.Items.Clear();
                    for (int i = 0; i < form1.InitListBoxItems.Count; i++)
                    {
                        listBox1.Items.Add(form1.InitListBoxItems[i]);
                    }
                }
            }
            else
            {
                listBox1.Items.Clear();
                for (int i = 0; i < form1.PinLv.Count; i++)
                {
                    //11kHz 10mA 20% 10s
                    string str = (form1.PinLv[i]).ToString() + "Hz "; 
                    str = str + (form1.DianLiu[i] / 10.0).ToString() + "mA ";
                    str = str  + (form1.ZhanKongBi[i] / 10.0).ToString() + "% ";
                    str = str + form1.ShiJian[i].ToString() +"s";
                    listBox1.Items.Add(str);
                }
            }
        }
        //添加
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入频率！");
                return;
            }
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("请输入电流！");
                return;
            }
            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("请输入占空比！");
                return;
            }
            if (textBox4.Text.Trim() == "")
            {
                MessageBox.Show("请输入时间！");
                return;
            }
            try
            {
                int i = int.Parse(textBox1.Text);
                if (i > 256 * 256)
                {
                    MessageBox.Show("频率值过大，不能大于65000！");
                    return;
                }
                int pinLv = int.Parse(textBox1.Text.Trim());
                float dianLiu = float.Parse(textBox2.Text.Trim());
                float zhanKongBi= float.Parse(textBox3.Text.Trim());
                float shiJian = float.Parse(textBox4.Text.Trim());

                string item = textBox1.Text.Trim() + "Hz " + textBox2.Text.Trim() + "mA " + textBox3.Text.Trim() + "% " + textBox4.Text.Trim() + "s";
                listBox1.Items.Add(item);
            }
            catch
            { }
        }
        //删除
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
        //清空
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        //确定
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count <= 0)
            {
                MessageBox.Show("请输入数据！");
                return;
            }

            form1.PinLv.Clear();
            form1.DianLiu.Clear();
            form1.ZhanKongBi.Clear();
            form1.ShiJian.Clear();

            for (int i = 0; i < listBox1.Items.Count;i++ )
            {
                string strItem = listBox1.Items[i].ToString();
                string[] itemStr = strItem.Split(' ');
                //10mA 20% 10Hz 5s
                string str1 = itemStr[0];
                string str2 = itemStr[1];
                string str3 = itemStr[2];
                string str4 = itemStr[3];

                str1 = str1.Substring(0, str1.Length - 2);
                str2 = str2.Substring(0, str2.Length - 2);
                str3 = str3.Substring(0, str3.Length - 1);
                str4 = str4.Substring(0, str4.Length - 1);

                int pinLvC = int.Parse(str1);
                float dianLiuC = float.Parse(str2);
                float zhanKongBiC = float.Parse(str3);
                int rTimeC = int.Parse(str4);

                form1.PinLv.Add((int)pinLvC);
                form1.DianLiu.Add((int)dianLiuC * 10);
                form1.ZhanKongBi.Add((int)zhanKongBiC * 10);
                form1.ShiJian.Add(rTimeC);
            }
            int nodeCount = CXMLHelper.MyGetNodeChildCount("初始化参数//TuiHuo");
            if (listBox1.Items.Count <= nodeCount)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    string path = "初始化参数//TuiHuo//"+"step" + (i+1).ToString();
                    CXMLHelper.MyUpdataNode(path, listBox1.Items[i].ToString());
                }
                for (int i = 0; i < nodeCount; i++)
                {
                    if (i < listBox1.Items.Count)
                    {
                        string path = "初始化参数//TuiHuo//" + "step" + (i + 1).ToString();
                        CXMLHelper.MyUpdataNode(path, listBox1.Items[i].ToString());
                    }
                    else
                    {
                        string path = "初始化参数//TuiHuo//" + "step" + (i + 1).ToString();
                        CXMLHelper.MyUpdataNode(path, "");
                    }
                }
            }
            else
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (i <= nodeCount)
                    {
                        string path = "step" + (i + 1).ToString();
                        CXMLHelper.MyUpdataNode(path, listBox1.Items.ToString());
                    }
                    else
                    {
                        string path = "step" + (i + 1).ToString();
                        CXMLHelper.MyInertNode("初始化参数//TuiHuo", path, listBox1.Items[i].ToString());
                    }
                }
            }
            this.Close();
        }
        //取消
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
