namespace 退火电源2._0
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.串口参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pID参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.非晶丝ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.短路开路ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退火参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.电流ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.电压ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton5,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.toolStripDropDownButton1,
            this.toolStripSeparator3,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.toolStripSeparator4,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(805, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.串口参数ToolStripMenuItem,
            this.pID参数ToolStripMenuItem,
            this.非晶丝ToolStripMenuItem,
            this.短路开路ToolStripMenuItem,
            this.退火参数ToolStripMenuItem});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(85, 22);
            this.toolStripButton1.Text = "参数设置";
            // 
            // 串口参数ToolStripMenuItem
            // 
            this.串口参数ToolStripMenuItem.Name = "串口参数ToolStripMenuItem";
            this.串口参数ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.串口参数ToolStripMenuItem.Text = "串口参数";
            this.串口参数ToolStripMenuItem.Click += new System.EventHandler(this.串口参数ToolStripMenuItem_Click);
            // 
            // pID参数ToolStripMenuItem
            // 
            this.pID参数ToolStripMenuItem.Name = "pID参数ToolStripMenuItem";
            this.pID参数ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.pID参数ToolStripMenuItem.Text = "PID参数";
            this.pID参数ToolStripMenuItem.Click += new System.EventHandler(this.pID参数ToolStripMenuItem_Click);
            // 
            // 非晶丝ToolStripMenuItem
            // 
            this.非晶丝ToolStripMenuItem.Name = "非晶丝ToolStripMenuItem";
            this.非晶丝ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.非晶丝ToolStripMenuItem.Text = "非晶丝";
            this.非晶丝ToolStripMenuItem.Click += new System.EventHandler(this.非晶丝ToolStripMenuItem_Click);
            // 
            // 短路开路ToolStripMenuItem
            // 
            this.短路开路ToolStripMenuItem.Name = "短路开路ToolStripMenuItem";
            this.短路开路ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.短路开路ToolStripMenuItem.Text = "开路短路";
            this.短路开路ToolStripMenuItem.Click += new System.EventHandler(this.短路开路ToolStripMenuItem_Click);
            // 
            // 退火参数ToolStripMenuItem
            // 
            this.退火参数ToolStripMenuItem.Name = "退火参数ToolStripMenuItem";
            this.退火参数ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退火参数ToolStripMenuItem.Text = "退火参数";
            this.退火参数ToolStripMenuItem.Click += new System.EventHandler(this.退火参数ToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton5.Text = "启动";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton3.Text = "停止";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.电流ToolStripMenuItem,
            this.电压ToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(61, 22);
            this.toolStripDropDownButton1.Text = "曲线";
            // 
            // 电流ToolStripMenuItem
            // 
            this.电流ToolStripMenuItem.Name = "电流ToolStripMenuItem";
            this.电流ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.电流ToolStripMenuItem.Text = "电流";
            this.电流ToolStripMenuItem.Click += new System.EventHandler(this.电流ToolStripMenuItem_Click);
            // 
            // 电压ToolStripMenuItem
            // 
            this.电压ToolStripMenuItem.Name = "电压ToolStripMenuItem";
            this.电压ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.电压ToolStripMenuItem.Text = "电压";
            this.电压ToolStripMenuItem.Click += new System.EventHandler(this.电压ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton4.Text = "测试";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(285, 22);
            this.toolStripLabel2.Text = "步骤：0/5 0S,电流：0mA，电压：0mV，电阻：0Ω";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(104, 22);
            this.toolStripLabel1.Text = "报警信息：。。。";
            this.toolStripLabel1.Visible = false;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 25);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(805, 368);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 393);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "退火电源";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem 串口参数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pID参数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 非晶丝ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 短路开路ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退火参数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 电流ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 电压ToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Timer timer2;
    }
}

