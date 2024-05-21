using ListViewTest;
namespace Upper0
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
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.frameType = new System.Windows.Forms.ComboBox();
            this.frameFormat = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.frameId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sendTimes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.stopButoon = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.sendInterval = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.openButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.canBaudRateButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.canBaudrateComBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button33 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.DataAccCheckBox = new System.Windows.Forms.CheckBox();
            this.IdAccCheckBox = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.canData8 = new System.Windows.Forms.TextBox();
            this.canData7 = new System.Windows.Forms.TextBox();
            this.canData6 = new System.Windows.Forms.TextBox();
            this.canData5 = new System.Windows.Forms.TextBox();
            this.canData4 = new System.Windows.Forms.TextBox();
            this.canData3 = new System.Windows.Forms.TextBox();
            this.canData2 = new System.Windows.Forms.TextBox();
            this.canData1 = new System.Windows.Forms.TextBox();
            this.CAN_richBox = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.buttonFresh = new System.Windows.Forms.Button();
            this.PlaceHolder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pctime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID_Format = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Data_length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DATA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LedList = new System.Windows.Forms.ImageList(this.components);
            this.comboBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.DataBit = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.StopBit = new System.Windows.Forms.ComboBox();
            this.CheckBit = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox_receive = new System.Windows.Forms.RichTextBox();
            this.TX_box = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.HEXDisplay = new System.Windows.Forms.CheckBox();
            this.HEXSend = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label37 = new System.Windows.Forms.Label();
            this.button21 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button29 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button32 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button34 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.button31 = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.button38 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "帧类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "帧格式";
            // 
            // frameType
            // 
            this.frameType.FormattingEnabled = true;
            this.frameType.Items.AddRange(new object[] {
            "数据帧",
            "远程帧"});
            this.frameType.Location = new System.Drawing.Point(53, 34);
            this.frameType.Name = "frameType";
            this.frameType.Size = new System.Drawing.Size(71, 20);
            this.frameType.TabIndex = 18;
            // 
            // frameFormat
            // 
            this.frameFormat.FormattingEnabled = true;
            this.frameFormat.Items.AddRange(new object[] {
            "标准帧",
            "扩展帧"});
            this.frameFormat.Location = new System.Drawing.Point(187, 35);
            this.frameFormat.Name = "frameFormat";
            this.frameFormat.Size = new System.Drawing.Size(71, 20);
            this.frameFormat.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 20;
            this.label5.Text = "帧ID(HEX)";
            // 
            // frameId
            // 
            this.frameId.Location = new System.Drawing.Point(16, 62);
            this.frameId.Name = "frameId";
            this.frameId.Size = new System.Drawing.Size(62, 23);
            this.frameId.TabIndex = 22;
            this.frameId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.frameId.TextChanged += new System.EventHandler(this.frameId_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 14);
            this.label6.TabIndex = 23;
            this.label6.Text = "发送数据(HEX)";
            // 
            // sendTimes
            // 
            this.sendTimes.Location = new System.Drawing.Point(395, 59);
            this.sendTimes.Name = "sendTimes";
            this.sendTimes.Size = new System.Drawing.Size(68, 23);
            this.sendTimes.TabIndex = 26;
            this.sendTimes.TextChanged += new System.EventHandler(this.sendTimes_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 25;
            this.label7.Text = "发送次数";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // sendButton
            // 
            this.sendButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sendButton.Font = new System.Drawing.Font("黑体", 10F);
            this.sendButton.Location = new System.Drawing.Point(259, 29);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(63, 28);
            this.sendButton.TabIndex = 27;
            this.sendButton.Text = "发送";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // stopButoon
            // 
            this.stopButoon.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.stopButoon.Font = new System.Drawing.Font("黑体", 10F);
            this.stopButoon.Location = new System.Drawing.Point(259, 62);
            this.stopButoon.Name = "stopButoon";
            this.stopButoon.Size = new System.Drawing.Size(63, 28);
            this.stopButoon.TabIndex = 28;
            this.stopButoon.Text = "停止";
            this.stopButoon.UseVisualStyleBackColor = true;
            this.stopButoon.Click += new System.EventHandler(this.stopButoon_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 29;
            this.label8.Text = "波特率";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(363, 491);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 31;
            this.label9.Text = "发送帧数：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(510, 491);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 32;
            this.label10.Text = "接收帧数：";
            // 
            // sendInterval
            // 
            this.sendInterval.Location = new System.Drawing.Point(534, 61);
            this.sendInterval.Name = "sendInterval";
            this.sendInterval.Size = new System.Drawing.Size(53, 23);
            this.sendInterval.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(469, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 14);
            this.label13.TabIndex = 36;
            this.label13.Text = "定时发送";
            // 
            // openButton
            // 
            this.openButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.openButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.openButton.Location = new System.Drawing.Point(41, 119);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(95, 32);
            this.openButton.TabIndex = 38;
            this.openButton.Text = "打开串口";
            this.openButton.UseVisualStyleBackColor = false;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 14);
            this.label1.TabIndex = 43;
            this.label1.Text = "D0 D1 D2 D3 D4 D5 D6 D7";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.frameFormat);
            this.groupBox1.Controls.Add(this.frameType);
            this.groupBox1.Location = new System.Drawing.Point(12, 237);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 61);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CAN 帧格式设置";
            // 
            // canBaudRateButton
            // 
            this.canBaudRateButton.Location = new System.Drawing.Point(184, 34);
            this.canBaudRateButton.Name = "canBaudRateButton";
            this.canBaudRateButton.Size = new System.Drawing.Size(53, 23);
            this.canBaudRateButton.TabIndex = 31;
            this.canBaudRateButton.Text = "设置";
            this.canBaudRateButton.UseVisualStyleBackColor = true;
            this.canBaudRateButton.Click += new System.EventHandler(this.canBaudRateButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.canBaudrateComBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.canBaudRateButton);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 63);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "波特率设置";
            // 
            // canBaudrateComBox
            // 
            this.canBaudrateComBox.FormattingEnabled = true;
            this.canBaudrateComBox.Items.AddRange(new object[] {
            "1000",
            "800",
            "666",
            "500",
            "400",
            "250",
            "200",
            "125",
            "100",
            "80",
            "50",
            "40",
            "20",
            "10",
            "5"});
            this.canBaudrateComBox.Location = new System.Drawing.Point(69, 35);
            this.canBaudrateComBox.Name = "canBaudrateComBox";
            this.canBaudrateComBox.Size = new System.Drawing.Size(71, 20);
            this.canBaudrateComBox.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "Kbps";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button33);
            this.groupBox3.Controls.Add(this.button24);
            this.groupBox3.Controls.Add(this.DataAccCheckBox);
            this.groupBox3.Controls.Add(this.IdAccCheckBox);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.canData8);
            this.groupBox3.Controls.Add(this.canData7);
            this.groupBox3.Controls.Add(this.canData6);
            this.groupBox3.Controls.Add(this.canData5);
            this.groupBox3.Controls.Add(this.canData4);
            this.groupBox3.Controls.Add(this.canData3);
            this.groupBox3.Controls.Add(this.canData2);
            this.groupBox3.Controls.Add(this.canData1);
            this.groupBox3.Controls.Add(this.sendButton);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.stopButoon);
            this.groupBox3.Controls.Add(this.frameId);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.sendTimes);
            this.groupBox3.Controls.Add(this.sendInterval);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 10F);
            this.groupBox3.Location = new System.Drawing.Point(273, 537);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(647, 109);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送";
            // 
            // button33
            // 
            this.button33.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button33.Font = new System.Drawing.Font("黑体", 10F);
            this.button33.Location = new System.Drawing.Point(502, 25);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(80, 28);
            this.button33.TabIndex = 54;
            this.button33.Text = "导出数据";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.button33_Click_2);
            // 
            // button24
            // 
            this.button24.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button24.Font = new System.Drawing.Font("黑体", 10F);
            this.button24.Location = new System.Drawing.Point(588, 26);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(53, 28);
            this.button24.TabIndex = 53;
            this.button24.Text = "清空";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click_1);
            // 
            // DataAccCheckBox
            // 
            this.DataAccCheckBox.AutoSize = true;
            this.DataAccCheckBox.Location = new System.Drawing.Point(403, 35);
            this.DataAccCheckBox.Name = "DataAccCheckBox";
            this.DataAccCheckBox.Size = new System.Drawing.Size(82, 18);
            this.DataAccCheckBox.TabIndex = 52;
            this.DataAccCheckBox.Text = "DATA递增";
            this.DataAccCheckBox.UseVisualStyleBackColor = true;
            // 
            // IdAccCheckBox
            // 
            this.IdAccCheckBox.AutoSize = true;
            this.IdAccCheckBox.Location = new System.Drawing.Point(337, 35);
            this.IdAccCheckBox.Name = "IdAccCheckBox";
            this.IdAccCheckBox.Size = new System.Drawing.Size(68, 18);
            this.IdAccCheckBox.TabIndex = 51;
            this.IdAccCheckBox.Text = "ID递增";
            this.IdAccCheckBox.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(591, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 14);
            this.label11.TabIndex = 50;
            this.label11.Text = "ms";
            // 
            // canData8
            // 
            this.canData8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.canData8.Location = new System.Drawing.Point(227, 64);
            this.canData8.MaxLength = 2;
            this.canData8.Name = "canData8";
            this.canData8.Size = new System.Drawing.Size(21, 21);
            this.canData8.TabIndex = 8;
            this.canData8.TextChanged += new System.EventHandler(this.canData_TextChanged);
            // 
            // canData7
            // 
            this.canData7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.canData7.Location = new System.Drawing.Point(207, 64);
            this.canData7.MaxLength = 2;
            this.canData7.Name = "canData7";
            this.canData7.Size = new System.Drawing.Size(21, 21);
            this.canData7.TabIndex = 7;
            this.canData7.TextChanged += new System.EventHandler(this.canData_TextChanged);
            // 
            // canData6
            // 
            this.canData6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.canData6.Location = new System.Drawing.Point(187, 64);
            this.canData6.MaxLength = 2;
            this.canData6.Name = "canData6";
            this.canData6.Size = new System.Drawing.Size(21, 21);
            this.canData6.TabIndex = 6;
            this.canData6.TextChanged += new System.EventHandler(this.canData_TextChanged);
            // 
            // canData5
            // 
            this.canData5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.canData5.Location = new System.Drawing.Point(167, 64);
            this.canData5.MaxLength = 2;
            this.canData5.Name = "canData5";
            this.canData5.Size = new System.Drawing.Size(21, 21);
            this.canData5.TabIndex = 5;
            this.canData5.TextChanged += new System.EventHandler(this.canData_TextChanged);
            // 
            // canData4
            // 
            this.canData4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.canData4.Location = new System.Drawing.Point(147, 64);
            this.canData4.MaxLength = 2;
            this.canData4.Name = "canData4";
            this.canData4.Size = new System.Drawing.Size(21, 21);
            this.canData4.TabIndex = 4;
            this.canData4.TextChanged += new System.EventHandler(this.canData_TextChanged);
            // 
            // canData3
            // 
            this.canData3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.canData3.Location = new System.Drawing.Point(127, 64);
            this.canData3.MaxLength = 2;
            this.canData3.Name = "canData3";
            this.canData3.Size = new System.Drawing.Size(21, 21);
            this.canData3.TabIndex = 3;
            this.canData3.TextChanged += new System.EventHandler(this.canData_TextChanged);
            // 
            // canData2
            // 
            this.canData2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.canData2.Location = new System.Drawing.Point(107, 64);
            this.canData2.MaxLength = 2;
            this.canData2.Name = "canData2";
            this.canData2.Size = new System.Drawing.Size(21, 21);
            this.canData2.TabIndex = 2;
            this.canData2.TextChanged += new System.EventHandler(this.canData_TextChanged);
            // 
            // canData1
            // 
            this.canData1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.canData1.Location = new System.Drawing.Point(87, 64);
            this.canData1.MaxLength = 2;
            this.canData1.Name = "canData1";
            this.canData1.Size = new System.Drawing.Size(21, 21);
            this.canData1.TabIndex = 1;
            this.canData1.TextChanged += new System.EventHandler(this.canData_TextChanged);
            // 
            // CAN_richBox
            // 
            this.CAN_richBox.HideSelection = false;
            this.CAN_richBox.Location = new System.Drawing.Point(273, 414);
            this.CAN_richBox.Name = "CAN_richBox";
            this.CAN_richBox.Size = new System.Drawing.Size(647, 120);
            this.CAN_richBox.TabIndex = 69;
            this.CAN_richBox.Text = "";
            this.CAN_richBox.TextChanged += new System.EventHandler(this.CAN_richBox_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 489);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(104, 489);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 55;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(198, 490);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 16);
            this.pictureBox3.TabIndex = 56;
            this.pictureBox3.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 58;
            this.label12.Text = "串口号：";
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(76, 27);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(60, 20);
            this.comboBoxPort.TabIndex = 59;
            // 
            // buttonFresh
            // 
            this.buttonFresh.Location = new System.Drawing.Point(176, 90);
            this.buttonFresh.Name = "buttonFresh";
            this.buttonFresh.Size = new System.Drawing.Size(96, 23);
            this.buttonFresh.TabIndex = 60;
            this.buttonFresh.Text = "刷新设备";
            this.buttonFresh.UseVisualStyleBackColor = true;
            this.buttonFresh.Click += new System.EventHandler(this.buttonFresh_Click);
            // 
            // PlaceHolder
            // 
            this.PlaceHolder.Width = 0;
            // 
            // Index
            // 
            this.Index.Text = "序号";
            this.Index.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Index.Width = 53;
            // 
            // pctime
            // 
            this.pctime.Text = "时间戳";
            this.pctime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pctime.Width = 120;
            // 
            // ID_Type
            // 
            this.ID_Type.Text = "帧类型";
            this.ID_Type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ID_Format
            // 
            this.ID_Format.Text = "帧格式";
            this.ID_Format.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // State
            // 
            this.State.Text = "状态";
            this.State.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Data_length
            // 
            this.Data_length.Text = "数据长度";
            this.Data_length.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DATA
            // 
            this.DATA.Text = " 数据(D0 - D7)";
            this.DATA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DATA.Width = 180;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LedList
            // 
            this.LedList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LedList.ImageStream")));
            this.LedList.TransparentColor = System.Drawing.Color.Transparent;
            this.LedList.Images.SetKeyName(0, "led_white16.png");
            this.LedList.Images.SetKeyName(1, "green.ico");
            this.LedList.Images.SetKeyName(2, "red.ico");
            // 
            // comboBoxBaudrate
            // 
            this.comboBoxBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudrate.FormattingEnabled = true;
            this.comboBoxBaudrate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200",
            "460800",
            "921600",
            "自定义输入"});
            this.comboBoxBaudrate.Location = new System.Drawing.Point(76, 57);
            this.comboBoxBaudrate.Name = "comboBoxBaudrate";
            this.comboBoxBaudrate.Size = new System.Drawing.Size(60, 20);
            this.comboBoxBaudrate.TabIndex = 64;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 63;
            this.label15.Text = "波特率：";
            // 
            // DataBit
            // 
            this.DataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataBit.FormattingEnabled = true;
            this.DataBit.Items.AddRange(new object[] {
            "8",
            "9"});
            this.DataBit.Location = new System.Drawing.Point(76, 87);
            this.DataBit.Name = "DataBit";
            this.DataBit.Size = new System.Drawing.Size(60, 20);
            this.DataBit.TabIndex = 66;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 90);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 65;
            this.label17.Text = "数据位：";
            // 
            // StopBit
            // 
            this.StopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StopBit.FormattingEnabled = true;
            this.StopBit.Items.AddRange(new object[] {
            "One",
            "Two"});
            this.StopBit.Location = new System.Drawing.Point(222, 57);
            this.StopBit.Name = "StopBit";
            this.StopBit.Size = new System.Drawing.Size(60, 20);
            this.StopBit.TabIndex = 69;
            // 
            // CheckBit
            // 
            this.CheckBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CheckBit.FormattingEnabled = true;
            this.CheckBit.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.CheckBit.Location = new System.Drawing.Point(222, 27);
            this.CheckBit.Name = "CheckBit";
            this.CheckBit.Size = new System.Drawing.Size(60, 20);
            this.CheckBit.TabIndex = 70;
            this.CheckBit.SelectedIndexChanged += new System.EventHandler(this.CheckBit_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(160, 60);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 12);
            this.label18.TabIndex = 67;
            this.label18.Text = "停止位：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(160, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 68;
            this.label19.Text = "校验位：";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "序号";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 53;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "时间戳";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "帧类型";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "帧格式";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "状态";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "数据长度";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = " 数据(D0 - D7)";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 180;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "ID";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_receive
            // 
            this.textBox_receive.HideSelection = false;
            this.textBox_receive.Location = new System.Drawing.Point(171, 8);
            this.textBox_receive.Name = "textBox_receive";
            this.textBox_receive.Size = new System.Drawing.Size(182, 97);
            this.textBox_receive.TabIndex = 0;
            this.textBox_receive.Text = "";
            // 
            // TX_box
            // 
            this.TX_box.Location = new System.Drawing.Point(12, 8);
            this.TX_box.Name = "TX_box";
            this.TX_box.Size = new System.Drawing.Size(153, 38);
            this.TX_box.TabIndex = 1;
            this.TX_box.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("黑体", 11F);
            this.button1.Location = new System.Drawing.Point(90, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // HEXDisplay
            // 
            this.HEXDisplay.AutoSize = true;
            this.HEXDisplay.Location = new System.Drawing.Point(18, 52);
            this.HEXDisplay.Name = "HEXDisplay";
            this.HEXDisplay.Size = new System.Drawing.Size(66, 16);
            this.HEXDisplay.TabIndex = 5;
            this.HEXDisplay.Text = "HEX显示";
            this.HEXDisplay.UseVisualStyleBackColor = true;
            // 
            // HEXSend
            // 
            this.HEXSend.AutoSize = true;
            this.HEXSend.Location = new System.Drawing.Point(18, 74);
            this.HEXSend.Name = "HEXSend";
            this.HEXSend.Size = new System.Drawing.Size(66, 16);
            this.HEXSend.TabIndex = 6;
            this.HEXSend.Text = "HEX发送";
            this.HEXSend.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(176, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 32);
            this.button2.TabIndex = 71;
            this.button2.Text = "关闭串口";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label37);
            this.panel5.Controls.Add(this.button21);
            this.panel5.Controls.Add(this.button20);
            this.panel5.Controls.Add(this.button19);
            this.panel5.Controls.Add(this.button14);
            this.panel5.Controls.Add(this.button16);
            this.panel5.Controls.Add(this.button15);
            this.panel5.Location = new System.Drawing.Point(12, 317);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(253, 218);
            this.panel5.TabIndex = 72;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.SystemColors.ControlText;
            this.label37.Font = new System.Drawing.Font("黑体", 16F);
            this.label37.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label37.Location = new System.Drawing.Point(59, 177);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(142, 22);
            this.label37.TabIndex = 32;
            this.label37.Text = "已初始化相机";
            this.label37.Visible = false;
            this.label37.Click += new System.EventHandler(this.label37_Click);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.Black;
            this.button21.Font = new System.Drawing.Font("黑体", 15F);
            this.button21.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button21.Location = new System.Drawing.Point(8, 169);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(230, 38);
            this.button21.TabIndex = 31;
            this.button21.Text = "相机初始化";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button20.Font = new System.Drawing.Font("黑体", 14F);
            this.button20.Location = new System.Drawing.Point(125, 126);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(113, 37);
            this.button20.TabIndex = 30;
            this.button20.Text = "手动控制";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button19.Font = new System.Drawing.Font("黑体", 14F);
            this.button19.Location = new System.Drawing.Point(8, 126);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(111, 37);
            this.button19.TabIndex = 29;
            this.button19.Text = "自动控制";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Red;
            this.button14.Enabled = false;
            this.button14.Font = new System.Drawing.Font("黑体", 18F);
            this.button14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button14.Location = new System.Drawing.Point(11, 8);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(232, 64);
            this.button14.TabIndex = 26;
            this.button14.Text = "急  停";
            this.button14.UseVisualStyleBackColor = false;
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button16.Font = new System.Drawing.Font("黑体", 14F);
            this.button16.Location = new System.Drawing.Point(127, 78);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(113, 37);
            this.button16.TabIndex = 28;
            this.button16.Text = "失能";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button15.Font = new System.Drawing.Font("黑体", 14F);
            this.button15.Location = new System.Drawing.Point(10, 78);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(111, 37);
            this.button15.TabIndex = 27;
            this.button15.Text = "使能";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 12F);
            this.label14.Location = new System.Drawing.Point(707, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 16);
            this.label14.TabIndex = 74;
            this.label14.Text = "手动控制按键";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button29);
            this.panel2.Controls.Add(this.button28);
            this.panel2.Controls.Add(this.button27);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button11);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Location = new System.Drawing.Point(614, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(314, 199);
            this.panel2.TabIndex = 73;
            // 
            // button29
            // 
            this.button29.Font = new System.Drawing.Font("黑体", 11F);
            this.button29.Location = new System.Drawing.Point(235, 80);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(64, 43);
            this.button29.TabIndex = 22;
            this.button29.Text = "归零";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // button28
            // 
            this.button28.Font = new System.Drawing.Font("黑体", 11F);
            this.button28.Location = new System.Drawing.Point(235, 141);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(64, 47);
            this.button28.TabIndex = 21;
            this.button28.Text = "右旋";
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.button28_Click);
            // 
            // button27
            // 
            this.button27.Font = new System.Drawing.Font("黑体", 11F);
            this.button27.Location = new System.Drawing.Point(235, 9);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(64, 59);
            this.button27.TabIndex = 20;
            this.button27.Text = "左旋";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("黑体", 11F);
            this.button3.Location = new System.Drawing.Point(91, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 58);
            this.button3.TabIndex = 10;
            this.button3.Text = "↑";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("黑体", 11F);
            this.button11.Location = new System.Drawing.Point(15, 139);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(72, 52);
            this.button11.TabIndex = 19;
            this.button11.Text = "SPEED DOWN";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("黑体", 11F);
            this.button4.Location = new System.Drawing.Point(91, 139);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 52);
            this.button4.TabIndex = 11;
            this.button4.Text = "↓";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("黑体", 11F);
            this.button10.Location = new System.Drawing.Point(15, 9);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(72, 58);
            this.button10.TabIndex = 18;
            this.button10.Text = "SPEED  UP";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("黑体", 11F);
            this.button5.Location = new System.Drawing.Point(15, 82);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(70, 42);
            this.button5.TabIndex = 12;
            this.button5.Text = "←";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("黑体", 11F);
            this.button9.Location = new System.Drawing.Point(157, 139);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(72, 52);
            this.button9.TabIndex = 17;
            this.button9.Text = "DOWN";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("黑体", 11F);
            this.button6.Location = new System.Drawing.Point(157, 82);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(72, 42);
            this.button6.TabIndex = 13;
            this.button6.Text = "→";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("黑体", 11F);
            this.button8.Location = new System.Drawing.Point(157, 9);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(72, 58);
            this.button8.TabIndex = 16;
            this.button8.Text = "UP";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("黑体", 11F);
            this.button7.Location = new System.Drawing.Point(91, 80);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(60, 44);
            this.button7.TabIndex = 15;
            this.button7.Text = "0";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 12F);
            this.label16.Location = new System.Drawing.Point(325, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(232, 16);
            this.label16.TabIndex = 76;
            this.label16.Text = "假的实时位置，点一下是角度值";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label35);
            this.panel3.Controls.Add(this.label34);
            this.panel3.Controls.Add(this.label33);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.label27);
            this.panel3.Controls.Add(this.label28);
            this.panel3.Location = new System.Drawing.Point(316, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(269, 199);
            this.panel3.TabIndex = 75;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label35.Font = new System.Drawing.Font("黑体", 18F);
            this.label35.Location = new System.Drawing.Point(111, 153);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(84, 26);
            this.label35.TabIndex = 22;
            this.label35.Text = "1.2354";
            this.label35.Click += new System.EventHandler(this.label35_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label34.Font = new System.Drawing.Font("黑体", 18F);
            this.label34.Location = new System.Drawing.Point(101, 108);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(96, 26);
            this.label34.TabIndex = 21;
            this.label34.Text = "470.826";
            this.label34.Click += new System.EventHandler(this.label34_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label33.Font = new System.Drawing.Font("黑体", 18F);
            this.label33.Location = new System.Drawing.Point(101, 64);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(96, 26);
            this.label33.TabIndex = 20;
            this.label33.Text = "048.320";
            this.label33.Click += new System.EventHandler(this.label33_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("黑体", 18F);
            this.label20.Location = new System.Drawing.Point(206, 154);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(46, 24);
            this.label20.TabIndex = 19;
            this.label20.Text = "rad";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("黑体", 18F);
            this.label21.Location = new System.Drawing.Point(206, 110);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(34, 24);
            this.label21.TabIndex = 18;
            this.label21.Text = "mm";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("黑体", 18F);
            this.label22.Location = new System.Drawing.Point(206, 64);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(34, 24);
            this.label22.TabIndex = 17;
            this.label22.Text = "mm";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("黑体", 18F);
            this.label23.Location = new System.Drawing.Point(206, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(34, 24);
            this.label23.TabIndex = 16;
            this.label23.Text = "mm";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("黑体", 18F);
            this.label24.Location = new System.Drawing.Point(22, 153);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(46, 24);
            this.label24.TabIndex = 15;
            this.label24.Text = "A轴";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label25.Font = new System.Drawing.Font("黑体", 18F);
            this.label25.Location = new System.Drawing.Point(99, 20);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(96, 26);
            this.label25.TabIndex = 14;
            this.label25.Text = "122.425";
            this.label25.Click += new System.EventHandler(this.label25_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("黑体", 18F);
            this.label26.Location = new System.Drawing.Point(22, 110);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(82, 24);
            this.label26.TabIndex = 13;
            this.label26.Text = "Z轴  -";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("黑体", 18F);
            this.label27.Location = new System.Drawing.Point(22, 64);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(46, 24);
            this.label27.TabIndex = 12;
            this.label27.Text = "Y轴";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("黑体", 18F);
            this.label28.Location = new System.Drawing.Point(22, 20);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(46, 24);
            this.label28.TabIndex = 11;
            this.label28.Text = "X轴";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button32);
            this.panel4.Controls.Add(this.button30);
            this.panel4.Controls.Add(this.button26);
            this.panel4.Controls.Add(this.button25);
            this.panel4.Controls.Add(this.button23);
            this.panel4.Controls.Add(this.button22);
            this.panel4.Controls.Add(this.button18);
            this.panel4.Controls.Add(this.button17);
            this.panel4.Controls.Add(this.button13);
            this.panel4.Controls.Add(this.button12);
            this.panel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel4.Location = new System.Drawing.Point(947, 33);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(209, 208);
            this.panel4.TabIndex = 78;
            // 
            // button32
            // 
            this.button32.Location = new System.Drawing.Point(88, 133);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(108, 31);
            this.button32.TabIndex = 10;
            this.button32.Text = "关闭相机";
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(87, 49);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(108, 36);
            this.button30.TabIndex = 8;
            this.button30.Text = "工作空间示意";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.button30_Click);
            // 
            // button26
            // 
            this.button26.Location = new System.Drawing.Point(88, 167);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(108, 31);
            this.button26.TabIndex = 7;
            this.button26.Text = "相机设置";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(87, 91);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(108, 36);
            this.button25.TabIndex = 6;
            this.button25.Text = "开启相机画面";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.button25_Click_1);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(11, 167);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(61, 31);
            this.button23.TabIndex = 5;
            this.button23.Text = "气阀通";
            this.button23.UseVisualStyleBackColor = true;
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(11, 133);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(61, 28);
            this.button22.TabIndex = 4;
            this.button22.Text = "气阀断";
            this.button22.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(88, 7);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(108, 36);
            this.button18.TabIndex = 3;
            this.button18.Text = "快速往复进动";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(11, 91);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(61, 36);
            this.button17.TabIndex = 2;
            this.button17.Text = "清空数据";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(11, 49);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(61, 36);
            this.button13.TabIndex = 1;
            this.button13.Text = "保存终点";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(11, 7);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(61, 36);
            this.button12.TabIndex = 0;
            this.button12.Text = "保存始点";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 12F);
            this.label29.Location = new System.Drawing.Point(1032, 8);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(56, 16);
            this.label29.TabIndex = 77;
            this.label29.Text = "演示用";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TX_box);
            this.panel1.Controls.Add(this.textBox_receive);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.HEXDisplay);
            this.panel1.Controls.Add(this.HEXSend);
            this.panel1.Location = new System.Drawing.Point(288, 262);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 115);
            this.panel1.TabIndex = 79;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 12F);
            this.label30.Location = new System.Drawing.Point(529, 395);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(112, 16);
            this.label30.TabIndex = 80;
            this.label30.Text = "CAN手动收发窗";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 12F);
            this.label31.Location = new System.Drawing.Point(415, 243);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(120, 16);
            this.label31.TabIndex = 81;
            this.label31.Text = "UART手动收发窗";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button34);
            this.panel6.Controls.Add(this.button37);
            this.panel6.Controls.Add(this.button35);
            this.panel6.Controls.Add(this.button36);
            this.panel6.Location = new System.Drawing.Point(12, 541);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(253, 100);
            this.panel6.TabIndex = 82;
            // 
            // button34
            // 
            this.button34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button34.Font = new System.Drawing.Font("黑体", 14F);
            this.button34.Location = new System.Drawing.Point(6, 3);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(113, 37);
            this.button34.TabIndex = 35;
            this.button34.Text = "A位";
            this.button34.UseVisualStyleBackColor = false;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // button37
            // 
            this.button37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button37.Font = new System.Drawing.Font("黑体", 14F);
            this.button37.Location = new System.Drawing.Point(127, 46);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(113, 37);
            this.button37.TabIndex = 87;
            this.button37.Text = "回位";
            this.button37.UseVisualStyleBackColor = false;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // button35
            // 
            this.button35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button35.Font = new System.Drawing.Font("黑体", 14F);
            this.button35.Location = new System.Drawing.Point(127, 3);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(113, 37);
            this.button35.TabIndex = 85;
            this.button35.Text = "B位";
            this.button35.UseVisualStyleBackColor = false;
            this.button35.Click += new System.EventHandler(this.button35_Click);
            // 
            // button36
            // 
            this.button36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button36.Font = new System.Drawing.Font("黑体", 14F);
            this.button36.Location = new System.Drawing.Point(6, 46);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(113, 37);
            this.button36.TabIndex = 86;
            this.button36.Text = "回零";
            this.button36.UseVisualStyleBackColor = false;
            this.button36.Click += new System.EventHandler(this.button36_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 12F);
            this.label32.Location = new System.Drawing.Point(1208, 9);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(72, 16);
            this.label32.TabIndex = 83;
            this.label32.Text = "状态信息";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(970, 414);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(376, 240);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 87;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("黑体", 13F);
            this.textBox1.Location = new System.Drawing.Point(1172, 33);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 356);
            this.textBox1.TabIndex = 88;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(989, 262);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(167, 128);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 89;
            this.pictureBox5.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.textBox6);
            this.panel7.Controls.Add(this.label42);
            this.panel7.Controls.Add(this.button31);
            this.panel7.Controls.Add(this.label41);
            this.panel7.Controls.Add(this.label40);
            this.panel7.Controls.Add(this.label39);
            this.panel7.Controls.Add(this.label38);
            this.panel7.Controls.Add(this.textBox5);
            this.panel7.Controls.Add(this.textBox4);
            this.panel7.Controls.Add(this.textBox3);
            this.panel7.Controls.Add(this.textBox2);
            this.panel7.Location = new System.Drawing.Point(668, 262);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(307, 127);
            this.panel7.TabIndex = 90;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(233, 52);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(62, 21);
            this.textBox6.TabIndex = 98;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("宋体", 12F);
            this.label42.Location = new System.Drawing.Point(161, 55);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(56, 16);
            this.label42.TabIndex = 97;
            this.label42.Text = "目标ID";
            // 
            // button31
            // 
            this.button31.Font = new System.Drawing.Font("黑体", 11F);
            this.button31.Location = new System.Drawing.Point(156, 81);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(139, 35);
            this.button31.TabIndex = 96;
            this.button31.Text = "参数写入/更新";
            this.button31.UseVisualStyleBackColor = true;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("宋体", 12F);
            this.label41.Location = new System.Drawing.Point(12, 13);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(56, 16);
            this.label41.TabIndex = 95;
            this.label41.Text = "速度Kp";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 12F);
            this.label40.Location = new System.Drawing.Point(161, 14);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(56, 16);
            this.label40.TabIndex = 94;
            this.label40.Text = "位置Ki";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("宋体", 12F);
            this.label39.Location = new System.Drawing.Point(12, 51);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(56, 16);
            this.label39.TabIndex = 93;
            this.label39.Text = "速度Ki";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("宋体", 12F);
            this.label38.Location = new System.Drawing.Point(12, 91);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(56, 16);
            this.label38.TabIndex = 92;
            this.label38.Text = "位置Kp";
            this.label38.Click += new System.EventHandler(this.label38_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(233, 12);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(62, 21);
            this.textBox5.TabIndex = 91;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(77, 92);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(62, 21);
            this.textBox4.TabIndex = 25;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(77, 52);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(62, 21);
            this.textBox3.TabIndex = 24;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(77, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(62, 21);
            this.textBox2.TabIndex = 23;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("宋体", 12F);
            this.label36.Location = new System.Drawing.Point(1120, 395);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(72, 16);
            this.label36.TabIndex = 86;
            this.label36.Text = "相机画面";
            this.label36.Click += new System.EventHandler(this.label36_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("宋体", 12F);
            this.label43.Location = new System.Drawing.Point(1023, 243);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(104, 16);
            this.label43.TabIndex = 91;
            this.label43.Text = "图像处理画面";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("宋体", 12F);
            this.label44.Location = new System.Drawing.Point(756, 243);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(104, 16);
            this.label44.TabIndex = 92;
            this.label44.Text = "电机参数调节";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label45.Font = new System.Drawing.Font("黑体", 18F);
            this.label45.Location = new System.Drawing.Point(1220, 323);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(60, 26);
            this.label45.TabIndex = 93;
            this.label45.Text = "NULL";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label46.Font = new System.Drawing.Font("黑体", 18F);
            this.label46.Location = new System.Drawing.Point(1220, 354);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(60, 26);
            this.label46.TabIndex = 94;
            this.label46.Text = "NULL";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("黑体", 18F);
            this.label47.Location = new System.Drawing.Point(1180, 324);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(34, 24);
            this.label47.TabIndex = 95;
            this.label47.Text = "CX";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("黑体", 18F);
            this.label48.Location = new System.Drawing.Point(1180, 356);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(34, 24);
            this.label48.TabIndex = 96;
            this.label48.Text = "CY";
            // 
            // button38
            // 
            this.button38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button38.Font = new System.Drawing.Font("黑体", 14F);
            this.button38.Location = new System.Drawing.Point(23, 630);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(229, 47);
            this.button38.TabIndex = 88;
            this.button38.Text = "稳定后存数";
            this.button38.UseVisualStyleBackColor = false;
            this.button38.Click += new System.EventHandler(this.button38_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1366, 677);
            this.Controls.Add(this.button38);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.CAN_richBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.StopBit);
            this.Controls.Add(this.CheckBit);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.DataBit);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.comboBoxBaudrate);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.buttonFresh);
            this.Controls.Add(this.comboBoxPort);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "USB2CAN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private NoFlashListView listView1;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox frameType;
        private System.Windows.Forms.ComboBox frameFormat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox frameId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox sendTimes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button stopButoon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox sendInterval;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader PlaceHolder;
        private System.Windows.Forms.ColumnHeader Index;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader ID_Type;
        private System.Windows.Forms.ColumnHeader ID_Format;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader Data_length;
        private System.Windows.Forms.ColumnHeader DATA;
        private System.Windows.Forms.Button canBaudRateButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox canData8;
        private System.Windows.Forms.TextBox canData7;
        private System.Windows.Forms.TextBox canData6;
        private System.Windows.Forms.TextBox canData5;
        private System.Windows.Forms.TextBox canData4;
        private System.Windows.Forms.TextBox canData3;
        private System.Windows.Forms.TextBox canData2;
        private System.Windows.Forms.TextBox canData1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;


        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;

        private System.Windows.Forms.ComboBox canBaudrateComBox;
        private System.Windows.Forms.CheckBox DataAccCheckBox;
        private System.Windows.Forms.CheckBox IdAccCheckBox;
        private System.Windows.Forms.ColumnHeader pctime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Button buttonFresh;
        private System.Windows.Forms.ImageList LedList;
        private System.Windows.Forms.ComboBox comboBoxBaudrate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox DataBit;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox StopBit;
        private System.Windows.Forms.ComboBox CheckBit;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.RichTextBox CAN_richBox;
        private System.Windows.Forms.CheckBox HEXSend;
        private System.Windows.Forms.CheckBox HEXDisplay;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox TX_box;
        private System.Windows.Forms.RichTextBox textBox_receive;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Button button38;
    }
}

