using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml;

namespace 退火电源2._0
{
    public partial class 测试 : Form
    {
        Form1 form1 = new Form1();
        public 测试(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            /*
            //增加节点
            CXMLHelper m_menu_keleyi_com2 = new CXMLHelper();
            Hashtable m_ht = new Hashtable();
            m_ht.Add("url", "http://keleyi.com/menu/csharp/");
            m_ht.Add("text", "C#");
            m_menu_keleyi_com2.InsertNode(@"D:\kel" + "eyimenu.xml", "csharp", true, "keleyimenu", m_ht, null);

            //获取节点
            string m_nodeName = "csharp";
            XmlNode m_menuNode_keleyi_com = m_menu_keleyi_com2.GetXmlNodeByXpath(@"D:\kel" + "eyimenu.xml", "//kele" + "yimenu//" + m_nodeName);
            string m_nodeText = m_menuNode_keleyi_com.Attributes["text"].Value;
            string m_nodeUrl = m_menuNode_keleyi_com.Attributes["url"].Value;
             */

            //CXMLHelper xmlhelper = new CXMLHelper();
            //xmlhelper.CreateXmlDocument(@"./ini.xml", "初始化参数", "utf-8");

            //serialPort1.PortName

            //CXMLHelper xmlhelper = new CXMLHelper();
            //Hashtable ht = new Hashtable();
            //ht.Add("portName","COM1");
            //xmlhelper.InsertNode(@"./ini.xml", "SerialPort", true, "初始化参数", ht, null);

            CXMLHelper xmlhelper = new CXMLHelper();
            Hashtable ht = new Hashtable();
            ht.Add("portName","COM4");
            xmlhelper.UpdateNode(@"./ini.xml", "初始化参数", ht, null);
        }

        //展示xml
        private void button7_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Books.xml");
            MessageBox.Show(xmlDoc.InnerXml);
        }
        //创建xml
        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = i++ + ++i;
                
            i = 5;
            int d = i++;
            int b = ++i;
            int c = d + b;    
            c.ToString();
            //xml文档
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration dec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(dec);

            //创建根节点 
            XmlElement root = xmlDoc.CreateElement("Books");
            xmlDoc.AppendChild(root);

            //节点及元素
            XmlNode book = xmlDoc.CreateElement("Book");
            XmlElement title = GetXmlElement(xmlDoc, "Title", "Window Form");
            XmlElement isbn = GetXmlElement(xmlDoc, "ISBN", "111111");
            XmlElement author = GetXmlElement(xmlDoc, "Author", "amandag");
            XmlElement price = GetXmlElement(xmlDoc, "Price", "128.00");
            price.SetAttribute("Unit", "￥");

            book.AppendChild(title);
            book.AppendChild(isbn);
            book.AppendChild(author);
            book.AppendChild(price);
            root.AppendChild(book);

            xmlDoc.Save("Books.xml");
            MessageBox.Show("数据已写入！");
        }
        //插入数据
        private void button3_Click(object sender, EventArgs e)
        {
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load("Books.xml");

            //XmlNode root = xmlDoc.SelectSingleNode("Books");

            //XmlElement book = xmlDoc.CreateElement("Book");
            //XmlElement title = GetXmlElement(xmlDoc, "Title", "ASP.NET");
            //XmlElement isbn = GetXmlElement(xmlDoc, "ISBN", "222222");
            //XmlElement author = GetXmlElement(xmlDoc, "Author", "moon");
            //XmlElement price = GetXmlElement(xmlDoc, "Price", "111.00");
            //price.SetAttribute("Unit", "{1}quot");

            //book.AppendChild(title);
            //book.AppendChild(isbn);
            //book.AppendChild(author);
            //book.AppendChild(price);
            //root.AppendChild(book);

            //xmlDoc.Save("Books.xml");
            //MessageBox.Show("数据已插入！");

            CXMLHelper.MyInertNode("初始化参数//TuiHuo", "step6", "aa");
        }
        //更新节点
        private void button4_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Books.xml");

            //方法1:获取Books//Book节点的第一个子节点 
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("Books//Book").ChildNodes;
            XmlElement xe = null;
            //遍历所有子节点 
            foreach (XmlNode xn in nodeList)
            {
                //将子节点类型转换为XmlElement类型 
                xe = (XmlElement)xn;
                if (xe.Name == "Author" && xe.InnerText == "amandag")
                {
                    xe.InnerText = "高歌";
                }

                if (xe.GetAttribute("Unit") == "￥")
                {
                   // xe.SetAttribute("Unit", "{1}quot;);
                    xe.SetAttribute("Unit","{1}quot");
                }
            }

            //方法2:
            XmlNode node = xmlDoc.SelectSingleNode("Books//Book[Author=\"moon\"]//Author");
            if(node != null)
            {
                node.InnerText = "宝贝";
                
            }
    
            xmlDoc.Save("Books.xml");
            MessageBox.Show("数据已更新！");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Books.xml");

            XmlNodeList nodeList = xmlDoc.SelectNodes("Books//Book//Price[@Unit=\"$\"]");

            //遍历所有子节点 
            foreach (XmlNode xn in nodeList)
            {
                XmlElement xe = (XmlElement)xn;
                xe.RemoveAttribute("Unit");
            }
            xmlDoc.Save("Books.xml");
            MessageBox.Show("数据已删除！");
        }

        private XmlElement GetXmlElement(XmlDocument doc, string elementName, string value)
        {
            XmlElement element = doc.CreateElement(elementName);
            element.InnerText = value;
            return element;
        }

        private void UpdataAttribute()
        {
            //方法1
            XmlDocument doc1 = new XmlDocument();
            doc1.LoadXml("<fsdlconfig userName=\"ss\" password=\"134\"/>");
            XmlAttribute att1 = (XmlAttribute)doc1.SelectSingleNode("/fsdlconfig/@userName");
            Console.WriteLine(att1.Value);
            att1.Value = "test";
            string str1 = doc1.OuterXml; 
            //方法2
            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml("<fsdlconfig userName=\"ss\" password=\"134\"/>");
            
            XmlElement att2 = (XmlElement)doc2.FirstChild;
            att2.SetAttribute("userName", "test");
            string str2 = doc2.OuterXml; 
        }
        //遍历属性
        private void BianLiAttribute()
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("Books.xml");

            XmlNode rootNode = xmldoc.SelectSingleNode("Books");

            XmlAttributeCollection xmlc = rootNode.Attributes;
            for (int i = 0; i < xmlc.Count; i++)
            {
 
            }
        }
        //遍历节点
        private void BianLiChildNode2()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("bookstore.xml");

            XmlNode xn = xmlDoc.SelectSingleNode("bookstore");

            XmlNodeList xnl = xn.ChildNodes;

            MessageBox.Show(xnl.Count.ToString());
        }
        //遍历节点
        private void BianLiChildNode()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("bookstore.xml"); 

            XmlNode xn = xmlDoc.SelectSingleNode("bookstore");

            XmlNodeList xnl = xn.ChildNodes;

            foreach (XmlNode xnf in xnl)
            {
                XmlElement xe = (XmlElement)xnf;
                Console.WriteLine(xe.GetAttribute("genre"));//显示属性值 
                Console.WriteLine(xe.GetAttribute("ISBN"));

                XmlNodeList xnf1 = xe.ChildNodes;
                foreach (XmlNode xn2 in xnf1)
                {
                    Console.WriteLine(xn2.InnerText);//显示子节点点文本 
                }
            } 
        }
    }
}
