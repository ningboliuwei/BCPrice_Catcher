namespace BCPrice_Catcher
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.btnStartStopStrategy = new System.Windows.Forms.Button();
			this.btnCancelAllOrders = new System.Windows.Forms.Button();
			this.lblM = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.nudParaMin = new System.Windows.Forms.NumericUpDown();
			this.btnSwitchMode = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.nudParaZ = new System.Windows.Forms.NumericUpDown();
			this.lblBtccPrice = new System.Windows.Forms.Label();
			this.lblHuobiAccount = new System.Windows.Forms.Label();
			this.lblHuobiPrice = new System.Windows.Forms.Label();
			this.lblDifferPrice = new System.Windows.Forms.Label();
			this.tckPecentage = new System.Windows.Forms.TrackBar();
			this.lblBtccAccount = new System.Windows.Forms.Label();
			this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
			this.lblTotalProfits = new System.Windows.Forms.Label();
			this.tableLayoutPanelOutSite = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelInSite = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.nudParaA = new System.Windows.Forms.NumericUpDown();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.nudParaB = new System.Windows.Forms.NumericUpDown();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.功能FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gdvBtccTrades = new System.Windows.Forms.DataGridView();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudParaMin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudParaZ)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tckPecentage)).BeginInit();
			this.tableLayoutPanelMain.SuspendLayout();
			this.panel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudParaA)).BeginInit();
			this.flowLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudParaB)).BeginInit();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gdvBtccTrades)).BeginInit();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Khaki;
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.btnCancelAllOrders, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnStartStopStrategy, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(612, 140);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(409, 70);
			this.tableLayoutPanel1.TabIndex = 11;
			// 
			// btnStartStopStrategy
			// 
			this.btnStartStopStrategy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.btnStartStopStrategy.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnStartStopStrategy.Location = new System.Drawing.Point(104, 2);
			this.btnStartStopStrategy.Margin = new System.Windows.Forms.Padding(2);
			this.btnStartStopStrategy.Name = "btnStartStopStrategy";
			this.btnStartStopStrategy.Size = new System.Drawing.Size(98, 46);
			this.btnStartStopStrategy.TabIndex = 8;
			this.btnStartStopStrategy.Text = "开始(&S)";
			this.btnStartStopStrategy.UseVisualStyleBackColor = false;
			this.btnStartStopStrategy.Click += new System.EventHandler(this.btnStartStopStrategy_Click);
			// 
			// btnCancelAllOrders
			// 
			this.btnCancelAllOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.btnCancelAllOrders.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnCancelAllOrders.Location = new System.Drawing.Point(308, 2);
			this.btnCancelAllOrders.Margin = new System.Windows.Forms.Padding(2);
			this.btnCancelAllOrders.Name = "btnCancelAllOrders";
			this.btnCancelAllOrders.Size = new System.Drawing.Size(99, 46);
			this.btnCancelAllOrders.TabIndex = 8;
			this.btnCancelAllOrders.Text = "全部撤单(&T)";
			this.btnCancelAllOrders.UseVisualStyleBackColor = false;
			this.btnCancelAllOrders.Click += new System.EventHandler(this.btnCancelAllOrders_Click);
			// 
			// lblM
			// 
			this.lblM.AutoSize = true;
			this.lblM.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblM.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblM.Location = new System.Drawing.Point(0, 0);
			this.lblM.Name = "lblM";
			this.lblM.Size = new System.Drawing.Size(38, 16);
			this.lblM.TabIndex = 9;
			this.lblM.Text = "label1";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.BackColor = System.Drawing.Color.Khaki;
			this.flowLayoutPanel1.Controls.Add(this.label2);
			this.flowLayoutPanel1.Controls.Add(this.nudParaMin);
			this.flowLayoutPanel1.Controls.Add(this.btnSwitchMode);
			this.flowLayoutPanel1.Controls.Add(this.label4);
			this.flowLayoutPanel1.Controls.Add(this.nudParaZ);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 140);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(408, 70);
			this.flowLayoutPanel1.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(2, 0);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 39);
			this.label2.TabIndex = 5;
			this.label2.Text = "最小交易量";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nudParaMin
			// 
			this.nudParaMin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nudParaMin.DecimalPlaces = 3;
			this.nudParaMin.Location = new System.Drawing.Point(85, 2);
			this.nudParaMin.Margin = new System.Windows.Forms.Padding(2);
			this.nudParaMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudParaMin.Name = "nudParaMin";
			this.nudParaMin.Size = new System.Drawing.Size(100, 26);
			this.nudParaMin.TabIndex = 6;
			this.nudParaMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			// 
			// btnSwitchMode
			// 
			this.btnSwitchMode.BackColor = System.Drawing.Color.LimeGreen;
			this.btnSwitchMode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnSwitchMode.Location = new System.Drawing.Point(189, 2);
			this.btnSwitchMode.Margin = new System.Windows.Forms.Padding(2);
			this.btnSwitchMode.Name = "btnSwitchMode";
			this.btnSwitchMode.Size = new System.Drawing.Size(200, 35);
			this.btnSwitchMode.TabIndex = 8;
			this.btnSwitchMode.Text = "启动真实模式(&R)";
			this.btnSwitchMode.UseVisualStyleBackColor = false;
			this.btnSwitchMode.Click += new System.EventHandler(this.btnSwitchMode_Click);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.Location = new System.Drawing.Point(2, 39);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(18, 20);
			this.label4.TabIndex = 5;
			this.label4.Text = "Z";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nudParaZ
			// 
			this.nudParaZ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nudParaZ.DecimalPlaces = 3;
			this.nudParaZ.Location = new System.Drawing.Point(24, 41);
			this.nudParaZ.Margin = new System.Windows.Forms.Padding(2);
			this.nudParaZ.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudParaZ.Name = "nudParaZ";
			this.nudParaZ.Size = new System.Drawing.Size(100, 26);
			this.nudParaZ.TabIndex = 6;
			// 
			// lblBtccPrice
			// 
			this.lblBtccPrice.AutoEllipsis = true;
			this.lblBtccPrice.AutoSize = true;
			this.lblBtccPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.lblBtccPrice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblBtccPrice.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblBtccPrice.Location = new System.Drawing.Point(0, 0);
			this.lblBtccPrice.Margin = new System.Windows.Forms.Padding(0);
			this.lblBtccPrice.Name = "lblBtccPrice";
			this.lblBtccPrice.Size = new System.Drawing.Size(408, 60);
			this.lblBtccPrice.TabIndex = 5;
			this.lblBtccPrice.Text = "Btcc价格\r\n";
			this.lblBtccPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblHuobiAccount
			// 
			this.lblHuobiAccount.AutoEllipsis = true;
			this.lblHuobiAccount.AutoSize = true;
			this.lblHuobiAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.lblHuobiAccount.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblHuobiAccount.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblHuobiAccount.Location = new System.Drawing.Point(612, 60);
			this.lblHuobiAccount.Margin = new System.Windows.Forms.Padding(0);
			this.lblHuobiAccount.Name = "lblHuobiAccount";
			this.lblHuobiAccount.Size = new System.Drawing.Size(409, 80);
			this.lblHuobiAccount.TabIndex = 5;
			this.lblHuobiAccount.Text = "Huobi比例";
			this.lblHuobiAccount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblHuobiPrice
			// 
			this.lblHuobiPrice.AutoEllipsis = true;
			this.lblHuobiPrice.AutoSize = true;
			this.lblHuobiPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.lblHuobiPrice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblHuobiPrice.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblHuobiPrice.Location = new System.Drawing.Point(612, 0);
			this.lblHuobiPrice.Margin = new System.Windows.Forms.Padding(0);
			this.lblHuobiPrice.Name = "lblHuobiPrice";
			this.lblHuobiPrice.Size = new System.Drawing.Size(409, 60);
			this.lblHuobiPrice.TabIndex = 5;
			this.lblHuobiPrice.Text = "Huobi价格";
			this.lblHuobiPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblDifferPrice
			// 
			this.lblDifferPrice.AutoEllipsis = true;
			this.lblDifferPrice.AutoSize = true;
			this.lblDifferPrice.BackColor = System.Drawing.Color.PaleTurquoise;
			this.lblDifferPrice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblDifferPrice.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblDifferPrice.Location = new System.Drawing.Point(408, 0);
			this.lblDifferPrice.Margin = new System.Windows.Forms.Padding(0);
			this.lblDifferPrice.Name = "lblDifferPrice";
			this.lblDifferPrice.Size = new System.Drawing.Size(204, 60);
			this.lblDifferPrice.TabIndex = 5;
			this.lblDifferPrice.Text = "差价";
			this.lblDifferPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tckPecentage
			// 
			this.tckPecentage.BackColor = System.Drawing.Color.Khaki;
			this.tckPecentage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tckPecentage.LargeChange = 10;
			this.tckPecentage.Location = new System.Drawing.Point(408, 140);
			this.tckPecentage.Margin = new System.Windows.Forms.Padding(0);
			this.tckPecentage.Maximum = 100;
			this.tckPecentage.Name = "tckPecentage";
			this.tckPecentage.Size = new System.Drawing.Size(204, 70);
			this.tckPecentage.TabIndex = 6;
			this.tckPecentage.TickFrequency = 5;
			this.tckPecentage.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tckPecentage.Value = 40;
			this.tckPecentage.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
			// 
			// lblBtccAccount
			// 
			this.lblBtccAccount.AutoEllipsis = true;
			this.lblBtccAccount.AutoSize = true;
			this.lblBtccAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.lblBtccAccount.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblBtccAccount.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblBtccAccount.Location = new System.Drawing.Point(0, 60);
			this.lblBtccAccount.Margin = new System.Windows.Forms.Padding(0);
			this.lblBtccAccount.Name = "lblBtccAccount";
			this.lblBtccAccount.Size = new System.Drawing.Size(408, 80);
			this.lblBtccAccount.TabIndex = 5;
			this.lblBtccAccount.Text = "Btcc比例";
			this.lblBtccAccount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tableLayoutPanelMain
			// 
			this.tableLayoutPanelMain.ColumnCount = 3;
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanelMain.Controls.Add(this.gdvBtccTrades, 0, 5);
			this.tableLayoutPanelMain.Controls.Add(this.lblHuobiPrice, 2, 0);
			this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel1, 2, 2);
			this.tableLayoutPanelMain.Controls.Add(this.lblHuobiAccount, 2, 1);
			this.tableLayoutPanelMain.Controls.Add(this.lblBtccPrice, 0, 0);
			this.tableLayoutPanelMain.Controls.Add(this.lblBtccAccount, 0, 1);
			this.tableLayoutPanelMain.Controls.Add(this.lblDifferPrice, 1, 0);
			this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanel1, 0, 2);
			this.tableLayoutPanelMain.Controls.Add(this.tckPecentage, 1, 2);
			this.tableLayoutPanelMain.Controls.Add(this.lblTotalProfits, 1, 1);
			this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelOutSite, 0, 4);
			this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelInSite, 2, 4);
			this.tableLayoutPanelMain.Controls.Add(this.panel1, 1, 4);
			this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanel2, 0, 3);
			this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanel3, 2, 3);
			this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelMain.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 25);
			this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
			this.tableLayoutPanelMain.RowCount = 6;
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tableLayoutPanelMain.Size = new System.Drawing.Size(1021, 637);
			this.tableLayoutPanelMain.TabIndex = 0;
			// 
			// lblTotalProfits
			// 
			this.lblTotalProfits.AutoEllipsis = true;
			this.lblTotalProfits.AutoSize = true;
			this.lblTotalProfits.BackColor = System.Drawing.Color.SkyBlue;
			this.lblTotalProfits.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTotalProfits.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblTotalProfits.Location = new System.Drawing.Point(408, 60);
			this.lblTotalProfits.Margin = new System.Windows.Forms.Padding(0);
			this.lblTotalProfits.Name = "lblTotalProfits";
			this.lblTotalProfits.Size = new System.Drawing.Size(204, 80);
			this.lblTotalProfits.TabIndex = 5;
			this.lblTotalProfits.Text = "总利润";
			this.lblTotalProfits.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tableLayoutPanelOutSite
			// 
			this.tableLayoutPanelOutSite.ColumnCount = 6;
			this.tableLayoutPanelOutSite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelOutSite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanelOutSite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanelOutSite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelOutSite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanelOutSite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanelOutSite.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelOutSite.Location = new System.Drawing.Point(0, 240);
			this.tableLayoutPanelOutSite.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanelOutSite.Name = "tableLayoutPanelOutSite";
			this.tableLayoutPanelOutSite.RowCount = 7;
			this.tableLayoutPanelOutSite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanelOutSite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelOutSite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelOutSite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelOutSite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelOutSite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelOutSite.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelOutSite.Size = new System.Drawing.Size(408, 200);
			this.tableLayoutPanelOutSite.TabIndex = 12;
			// 
			// tableLayoutPanelInSite
			// 
			this.tableLayoutPanelInSite.ColumnCount = 6;
			this.tableLayoutPanelInSite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelInSite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanelInSite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanelInSite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelInSite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanelInSite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanelInSite.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelInSite.Location = new System.Drawing.Point(612, 240);
			this.tableLayoutPanelInSite.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanelInSite.Name = "tableLayoutPanelInSite";
			this.tableLayoutPanelInSite.RowCount = 7;
			this.tableLayoutPanelInSite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanelInSite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelInSite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelInSite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelInSite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelInSite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanelInSite.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelInSite.Size = new System.Drawing.Size(409, 200);
			this.tableLayoutPanelInSite.TabIndex = 13;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.lblM);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(408, 240);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(204, 200);
			this.panel1.TabIndex = 14;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Controls.Add(this.label1);
			this.flowLayoutPanel2.Controls.Add(this.nudParaA);
			this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 210);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(408, 30);
			this.flowLayoutPanel2.TabIndex = 15;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(2, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(17, 20);
			this.label1.TabIndex = 5;
			this.label1.Text = "a";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nudParaA
			// 
			this.nudParaA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nudParaA.DecimalPlaces = 3;
			this.nudParaA.Location = new System.Drawing.Point(23, 2);
			this.nudParaA.Margin = new System.Windows.Forms.Padding(2);
			this.nudParaA.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudParaA.Name = "nudParaA";
			this.nudParaA.Size = new System.Drawing.Size(100, 26);
			this.nudParaA.TabIndex = 6;
			// 
			// flowLayoutPanel3
			// 
			this.flowLayoutPanel3.Controls.Add(this.label3);
			this.flowLayoutPanel3.Controls.Add(this.nudParaB);
			this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel3.Location = new System.Drawing.Point(612, 210);
			this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(409, 30);
			this.flowLayoutPanel3.TabIndex = 15;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(2, 0);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(18, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "b";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nudParaB
			// 
			this.nudParaB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nudParaB.DecimalPlaces = 3;
			this.nudParaB.Location = new System.Drawing.Point(24, 2);
			this.nudParaB.Margin = new System.Windows.Forms.Padding(2);
			this.nudParaB.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudParaB.Name = "nudParaB";
			this.nudParaB.Size = new System.Drawing.Size(100, 26);
			this.nudParaB.TabIndex = 6;
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.功能FToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1021, 25);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 功能FToolStripMenuItem
			// 
			this.功能FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem});
			this.功能FToolStripMenuItem.Name = "功能FToolStripMenuItem";
			this.功能FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
			this.功能FToolStripMenuItem.Text = "功能(&F)";
			// 
			// SettingsToolStripMenuItem
			// 
			this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
			this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.SettingsToolStripMenuItem.Text = "设置(&C)";
			this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
			// 
			// gdvBtccTrades
			// 
			this.gdvBtccTrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gdvBtccTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tableLayoutPanelMain.SetColumnSpan(this.gdvBtccTrades, 3);
			this.gdvBtccTrades.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gdvBtccTrades.Location = new System.Drawing.Point(2, 442);
			this.gdvBtccTrades.Margin = new System.Windows.Forms.Padding(2);
			this.gdvBtccTrades.Name = "gdvBtccTrades";
			this.gdvBtccTrades.RowTemplate.Height = 30;
			this.gdvBtccTrades.Size = new System.Drawing.Size(1017, 193);
			this.gdvBtccTrades.TabIndex = 19;
			// 
			// Form6
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1021, 662);
			this.Controls.Add(this.tableLayoutPanelMain);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form6";
			this.Text = "Form4";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Activated += new System.EventHandler(this.Form6_Activated);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form6_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4_FormClosed);
			this.Load += new System.EventHandler(this.Form6_Load);
			this.Shown += new System.EventHandler(this.Form6_Shown);
			this.ResizeBegin += new System.EventHandler(this.Form6_ResizeBegin);
			this.ResizeEnd += new System.EventHandler(this.Form6_ResizeEnd);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form6_Paint);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudParaMin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudParaZ)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tckPecentage)).EndInit();
			this.tableLayoutPanelMain.ResumeLayout(false);
			this.tableLayoutPanelMain.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudParaA)).EndInit();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudParaB)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gdvBtccTrades)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TrackBar tckPecentage;
        private System.Windows.Forms.Label lblHuobiPrice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnStartStopStrategy;
        private System.Windows.Forms.Button btnCancelAllOrders;
        private System.Windows.Forms.Label lblHuobiAccount;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudParaMin;
        private System.Windows.Forms.Label lblBtccPrice;
        private System.Windows.Forms.Label lblBtccAccount;
        private System.Windows.Forms.Label lblDifferPrice;
        private System.Windows.Forms.Label lblTotalProfits;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 功能FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.Button btnSwitchMode;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOutSite;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInSite;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblM;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nudParaZ;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown nudParaA;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown nudParaB;
		private System.Windows.Forms.DataGridView gdvBtccTrades;
	}
}