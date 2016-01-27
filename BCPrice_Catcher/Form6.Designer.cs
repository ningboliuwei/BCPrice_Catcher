﻿namespace BCPrice_Catcher
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
			this.btnCancelAllPendingPlacedOrders = new System.Windows.Forms.Button();
			this.btnStartStopStrategy = new System.Windows.Forms.Button();
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.btnShowPendingPlacedOrders = new System.Windows.Forms.Button();
			this.tableLayoutPanelOutSite = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.nudParaA = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.nudParaB = new System.Windows.Forms.NumericUpDown();
			this.btnPlaceOrder = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.nudAmount = new System.Windows.Forms.NumericUpDown();
			this.chkAutoTrade = new System.Windows.Forms.CheckBox();
			this.gdvTrades = new System.Windows.Forms.DataGridView();
			this.lblTotalProfits = new System.Windows.Forms.Label();
			this.tableLayoutPanelInSite = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.gdvOutSitePlacedOrders = new System.Windows.Forms.DataGridView();
			this.gdvInSitePlacedOrders = new System.Windows.Forms.DataGridView();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.lblStrategyValues = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.功能FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmbOutSite = new System.Windows.Forms.ComboBox();
			this.cmbInSite = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.nudParaMin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudParaZ)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tckPecentage)).BeginInit();
			this.tableLayoutPanelMain.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudParaA)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudParaB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gdvTrades)).BeginInit();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gdvOutSitePlacedOrders)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gdvInSitePlacedOrders)).BeginInit();
			this.tableLayoutPanel4.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// btnCancelAllPendingPlacedOrders
			// 
			this.btnCancelAllPendingPlacedOrders.BackColor = System.Drawing.Color.Salmon;
			this.btnCancelAllPendingPlacedOrders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCancelAllPendingPlacedOrders.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnCancelAllPendingPlacedOrders.Location = new System.Drawing.Point(350, 0);
			this.btnCancelAllPendingPlacedOrders.Margin = new System.Windows.Forms.Padding(0);
			this.btnCancelAllPendingPlacedOrders.Name = "btnCancelAllPendingPlacedOrders";
			this.btnCancelAllPendingPlacedOrders.Size = new System.Drawing.Size(125, 35);
			this.btnCancelAllPendingPlacedOrders.TabIndex = 8;
			this.btnCancelAllPendingPlacedOrders.Text = "全部撤单(&T)";
			this.btnCancelAllPendingPlacedOrders.UseVisualStyleBackColor = false;
			this.btnCancelAllPendingPlacedOrders.Click += new System.EventHandler(this.btnCancelAllPendingPlacedOrders_Click);
			// 
			// btnStartStopStrategy
			// 
			this.btnStartStopStrategy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.btnStartStopStrategy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnStartStopStrategy.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnStartStopStrategy.Location = new System.Drawing.Point(150, 0);
			this.btnStartStopStrategy.Margin = new System.Windows.Forms.Padding(0);
			this.btnStartStopStrategy.Name = "btnStartStopStrategy";
			this.btnStartStopStrategy.Size = new System.Drawing.Size(100, 35);
			this.btnStartStopStrategy.TabIndex = 8;
			this.btnStartStopStrategy.Text = "开始(&S)";
			this.btnStartStopStrategy.UseVisualStyleBackColor = false;
			this.btnStartStopStrategy.Click += new System.EventHandler(this.btnStartStopStrategy_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 35);
			this.label2.TabIndex = 5;
			this.label2.Text = "Min";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nudParaMin
			// 
			this.nudParaMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.nudParaMin.DecimalPlaces = 3;
			this.nudParaMin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.nudParaMin.Location = new System.Drawing.Point(32, 2);
			this.nudParaMin.Margin = new System.Windows.Forms.Padding(2);
			this.nudParaMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudParaMin.Name = "nudParaMin";
			this.nudParaMin.Size = new System.Drawing.Size(70, 23);
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
			this.btnSwitchMode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnSwitchMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnSwitchMode.Location = new System.Drawing.Point(0, 0);
			this.btnSwitchMode.Margin = new System.Windows.Forms.Padding(0);
			this.btnSwitchMode.Name = "btnSwitchMode";
			this.btnSwitchMode.Size = new System.Drawing.Size(150, 35);
			this.btnSwitchMode.TabIndex = 8;
			this.btnSwitchMode.Text = "启动真实模式(&R)";
			this.btnSwitchMode.UseVisualStyleBackColor = false;
			this.btnSwitchMode.Click += new System.EventHandler(this.btnSwitchMode_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.Location = new System.Drawing.Point(283, 0);
			this.label4.Margin = new System.Windows.Forms.Padding(0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(15, 35);
			this.label4.TabIndex = 5;
			this.label4.Text = "Z";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nudParaZ
			// 
			this.nudParaZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.nudParaZ.DecimalPlaces = 3;
			this.nudParaZ.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.nudParaZ.Location = new System.Drawing.Point(300, 2);
			this.nudParaZ.Margin = new System.Windows.Forms.Padding(2);
			this.nudParaZ.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudParaZ.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
			this.nudParaZ.Name = "nudParaZ";
			this.nudParaZ.Size = new System.Drawing.Size(70, 23);
			this.nudParaZ.TabIndex = 6;
			// 
			// lblBtccPrice
			// 
			this.lblBtccPrice.AutoEllipsis = true;
			this.lblBtccPrice.AutoSize = true;
			this.lblBtccPrice.BackColor = System.Drawing.Color.LightBlue;
			this.lblBtccPrice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblBtccPrice.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblBtccPrice.Location = new System.Drawing.Point(0, 25);
			this.lblBtccPrice.Margin = new System.Windows.Forms.Padding(0);
			this.lblBtccPrice.Name = "lblBtccPrice";
			this.lblBtccPrice.Size = new System.Drawing.Size(473, 40);
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
			this.lblHuobiAccount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblHuobiAccount.Location = new System.Drawing.Point(709, 65);
			this.lblHuobiAccount.Margin = new System.Windows.Forms.Padding(0);
			this.lblHuobiAccount.Name = "lblHuobiAccount";
			this.lblHuobiAccount.Size = new System.Drawing.Size(475, 60);
			this.lblHuobiAccount.TabIndex = 5;
			this.lblHuobiAccount.Text = "Huobi比例";
			this.lblHuobiAccount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblHuobiPrice
			// 
			this.lblHuobiPrice.AutoEllipsis = true;
			this.lblHuobiPrice.AutoSize = true;
			this.lblHuobiPrice.BackColor = System.Drawing.Color.Moccasin;
			this.lblHuobiPrice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblHuobiPrice.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblHuobiPrice.Location = new System.Drawing.Point(709, 25);
			this.lblHuobiPrice.Margin = new System.Windows.Forms.Padding(0);
			this.lblHuobiPrice.Name = "lblHuobiPrice";
			this.lblHuobiPrice.Size = new System.Drawing.Size(475, 40);
			this.lblHuobiPrice.TabIndex = 5;
			this.lblHuobiPrice.Text = "Huobi价格";
			this.lblHuobiPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblDifferPrice
			// 
			this.lblDifferPrice.AutoEllipsis = true;
			this.lblDifferPrice.AutoSize = true;
			this.lblDifferPrice.BackColor = System.Drawing.Color.PaleTurquoise;
			this.tableLayoutPanelMain.SetColumnSpan(this.lblDifferPrice, 2);
			this.lblDifferPrice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblDifferPrice.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblDifferPrice.Location = new System.Drawing.Point(473, 25);
			this.lblDifferPrice.Margin = new System.Windows.Forms.Padding(0);
			this.lblDifferPrice.Name = "lblDifferPrice";
			this.lblDifferPrice.Size = new System.Drawing.Size(236, 40);
			this.lblDifferPrice.TabIndex = 5;
			this.lblDifferPrice.Text = "差价";
			this.lblDifferPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tckPecentage
			// 
			this.tckPecentage.BackColor = System.Drawing.Color.Cornsilk;
			this.tableLayoutPanelMain.SetColumnSpan(this.tckPecentage, 2);
			this.tckPecentage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tckPecentage.LargeChange = 10;
			this.tckPecentage.Location = new System.Drawing.Point(473, 125);
			this.tckPecentage.Margin = new System.Windows.Forms.Padding(0);
			this.tckPecentage.Maximum = 100;
			this.tckPecentage.Name = "tckPecentage";
			this.tckPecentage.Size = new System.Drawing.Size(236, 70);
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
			this.lblBtccAccount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblBtccAccount.Location = new System.Drawing.Point(0, 65);
			this.lblBtccAccount.Margin = new System.Windows.Forms.Padding(0);
			this.lblBtccAccount.Name = "lblBtccAccount";
			this.lblBtccAccount.Size = new System.Drawing.Size(473, 60);
			this.lblBtccAccount.TabIndex = 5;
			this.lblBtccAccount.Text = "Btcc比例";
			this.lblBtccAccount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tableLayoutPanelMain
			// 
			this.tableLayoutPanelMain.ColumnCount = 4;
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanelMain.Controls.Add(this.lblHuobiPrice, 3, 1);
			this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel1, 3, 3);
			this.tableLayoutPanelMain.Controls.Add(this.lblHuobiAccount, 3, 2);
			this.tableLayoutPanelMain.Controls.Add(this.lblBtccPrice, 0, 1);
			this.tableLayoutPanelMain.Controls.Add(this.lblBtccAccount, 0, 2);
			this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelOutSite, 0, 4);
			this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel2, 0, 3);
			this.tableLayoutPanelMain.Controls.Add(this.gdvTrades, 0, 5);
			this.tableLayoutPanelMain.Controls.Add(this.tckPecentage, 1, 3);
			this.tableLayoutPanelMain.Controls.Add(this.lblTotalProfits, 1, 2);
			this.tableLayoutPanelMain.Controls.Add(this.lblDifferPrice, 1, 1);
			this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelInSite, 3, 4);
			this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel3, 1, 5);
			this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel4, 1, 4);
			this.tableLayoutPanelMain.Controls.Add(this.cmbOutSite, 0, 0);
			this.tableLayoutPanelMain.Controls.Add(this.cmbInSite, 3, 0);
			this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelMain.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 25);
			this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
			this.tableLayoutPanelMain.RowCount = 6;
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tableLayoutPanelMain.Size = new System.Drawing.Size(1184, 783);
			this.tableLayoutPanelMain.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightBlue;
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.btnSwitchMode, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnStartStopStrategy, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnShowPendingPlacedOrders, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnCancelAllPendingPlacedOrders, 3, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(709, 125);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(475, 70);
			this.tableLayoutPanel1.TabIndex = 11;
			// 
			// btnShowPendingPlacedOrders
			// 
			this.btnShowPendingPlacedOrders.BackColor = System.Drawing.Color.Gold;
			this.btnShowPendingPlacedOrders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnShowPendingPlacedOrders.Enabled = false;
			this.btnShowPendingPlacedOrders.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnShowPendingPlacedOrders.Location = new System.Drawing.Point(250, 0);
			this.btnShowPendingPlacedOrders.Margin = new System.Windows.Forms.Padding(0);
			this.btnShowPendingPlacedOrders.Name = "btnShowPendingPlacedOrders";
			this.btnShowPendingPlacedOrders.Size = new System.Drawing.Size(100, 35);
			this.btnShowPendingPlacedOrders.TabIndex = 8;
			this.btnShowPendingPlacedOrders.Text = "显示挂单(&D)";
			this.btnShowPendingPlacedOrders.UseVisualStyleBackColor = false;
			this.btnShowPendingPlacedOrders.Click += new System.EventHandler(this.btnShowPendingPlacedOrders_Click);
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
			this.tableLayoutPanelOutSite.Location = new System.Drawing.Point(0, 195);
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
			this.tableLayoutPanelOutSite.Size = new System.Drawing.Size(473, 200);
			this.tableLayoutPanelOutSite.TabIndex = 12;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.BackColor = System.Drawing.Color.Moccasin;
			this.tableLayoutPanel2.ColumnCount = 9;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.nudParaA, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.nudParaMin, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.label3, 4, 0);
			this.tableLayoutPanel2.Controls.Add(this.nudParaB, 5, 0);
			this.tableLayoutPanel2.Controls.Add(this.label4, 6, 0);
			this.tableLayoutPanel2.Controls.Add(this.nudParaZ, 7, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnPlaceOrder, 5, 1);
			this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.nudAmount, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.chkAutoTrade, 8, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 125);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(473, 70);
			this.tableLayoutPanel2.TabIndex = 20;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(104, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(15, 35);
			this.label1.TabIndex = 5;
			this.label1.Text = "a";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nudParaA
			// 
			this.nudParaA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.nudParaA.DecimalPlaces = 3;
			this.nudParaA.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.nudParaA.Location = new System.Drawing.Point(121, 2);
			this.nudParaA.Margin = new System.Windows.Forms.Padding(2);
			this.nudParaA.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudParaA.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
			this.nudParaA.Name = "nudParaA";
			this.nudParaA.Size = new System.Drawing.Size(70, 23);
			this.nudParaA.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(193, 0);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 35);
			this.label3.TabIndex = 5;
			this.label3.Text = "b";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nudParaB
			// 
			this.nudParaB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.nudParaB.DecimalPlaces = 3;
			this.nudParaB.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.nudParaB.Location = new System.Drawing.Point(211, 2);
			this.nudParaB.Margin = new System.Windows.Forms.Padding(2);
			this.nudParaB.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudParaB.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
			this.nudParaB.Name = "nudParaB";
			this.nudParaB.Size = new System.Drawing.Size(70, 23);
			this.nudParaB.TabIndex = 6;
			// 
			// btnPlaceOrder
			// 
			this.btnPlaceOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.tableLayoutPanel2.SetColumnSpan(this.btnPlaceOrder, 3);
			this.btnPlaceOrder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnPlaceOrder.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnPlaceOrder.Location = new System.Drawing.Point(209, 35);
			this.btnPlaceOrder.Margin = new System.Windows.Forms.Padding(0);
			this.btnPlaceOrder.Name = "btnPlaceOrder";
			this.btnPlaceOrder.Size = new System.Drawing.Size(163, 35);
			this.btnPlaceOrder.TabIndex = 8;
			this.btnPlaceOrder.Text = "手动下单(&B)";
			this.btnPlaceOrder.UseVisualStyleBackColor = false;
			this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(2, 35);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(26, 35);
			this.label5.TabIndex = 5;
			this.label5.Text = "m";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nudAmount
			// 
			this.nudAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nudAmount.DecimalPlaces = 3;
			this.nudAmount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.nudAmount.Location = new System.Drawing.Point(32, 37);
			this.nudAmount.Margin = new System.Windows.Forms.Padding(2);
			this.nudAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudAmount.Name = "nudAmount";
			this.nudAmount.Size = new System.Drawing.Size(70, 23);
			this.nudAmount.TabIndex = 6;
			// 
			// chkAutoTrade
			// 
			this.chkAutoTrade.AutoSize = true;
			this.chkAutoTrade.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chkAutoTrade.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.chkAutoTrade.Location = new System.Drawing.Point(372, 35);
			this.chkAutoTrade.Margin = new System.Windows.Forms.Padding(0);
			this.chkAutoTrade.Name = "chkAutoTrade";
			this.chkAutoTrade.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.chkAutoTrade.Size = new System.Drawing.Size(101, 35);
			this.chkAutoTrade.TabIndex = 7;
			this.chkAutoTrade.Text = "自动下单";
			this.chkAutoTrade.UseVisualStyleBackColor = true;
			this.chkAutoTrade.CheckedChanged += new System.EventHandler(this.chkAutoTrade_CheckedChanged);
			// 
			// gdvTrades
			// 
			this.gdvTrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gdvTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gdvTrades.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gdvTrades.Location = new System.Drawing.Point(2, 397);
			this.gdvTrades.Margin = new System.Windows.Forms.Padding(2);
			this.gdvTrades.Name = "gdvTrades";
			this.gdvTrades.RowTemplate.Height = 30;
			this.gdvTrades.Size = new System.Drawing.Size(469, 384);
			this.gdvTrades.TabIndex = 19;
			// 
			// lblTotalProfits
			// 
			this.lblTotalProfits.AutoEllipsis = true;
			this.lblTotalProfits.AutoSize = true;
			this.lblTotalProfits.BackColor = System.Drawing.Color.SkyBlue;
			this.tableLayoutPanelMain.SetColumnSpan(this.lblTotalProfits, 2);
			this.lblTotalProfits.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTotalProfits.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblTotalProfits.Location = new System.Drawing.Point(473, 65);
			this.lblTotalProfits.Margin = new System.Windows.Forms.Padding(0);
			this.lblTotalProfits.Name = "lblTotalProfits";
			this.lblTotalProfits.Size = new System.Drawing.Size(236, 60);
			this.lblTotalProfits.TabIndex = 5;
			this.lblTotalProfits.Text = "总利润";
			this.lblTotalProfits.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
			this.tableLayoutPanelInSite.Location = new System.Drawing.Point(709, 195);
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
			this.tableLayoutPanelInSite.Size = new System.Drawing.Size(475, 200);
			this.tableLayoutPanelInSite.TabIndex = 13;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanelMain.SetColumnSpan(this.tableLayoutPanel3, 3);
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.gdvOutSitePlacedOrders, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.gdvInSitePlacedOrders, 1, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(473, 395);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(711, 388);
			this.tableLayoutPanel3.TabIndex = 21;
			// 
			// gdvOutSitePlacedOrders
			// 
			this.gdvOutSitePlacedOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gdvOutSitePlacedOrders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gdvOutSitePlacedOrders.Enabled = false;
			this.gdvOutSitePlacedOrders.Location = new System.Drawing.Point(2, 2);
			this.gdvOutSitePlacedOrders.Margin = new System.Windows.Forms.Padding(2);
			this.gdvOutSitePlacedOrders.Name = "gdvOutSitePlacedOrders";
			this.gdvOutSitePlacedOrders.RowTemplate.Height = 30;
			this.gdvOutSitePlacedOrders.Size = new System.Drawing.Size(351, 384);
			this.gdvOutSitePlacedOrders.TabIndex = 20;
			// 
			// gdvInSitePlacedOrders
			// 
			this.gdvInSitePlacedOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gdvInSitePlacedOrders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gdvInSitePlacedOrders.Enabled = false;
			this.gdvInSitePlacedOrders.Location = new System.Drawing.Point(357, 2);
			this.gdvInSitePlacedOrders.Margin = new System.Windows.Forms.Padding(2);
			this.gdvInSitePlacedOrders.Name = "gdvInSitePlacedOrders";
			this.gdvInSitePlacedOrders.RowTemplate.Height = 30;
			this.gdvInSitePlacedOrders.Size = new System.Drawing.Size(352, 384);
			this.gdvInSitePlacedOrders.TabIndex = 21;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 1;
			this.tableLayoutPanelMain.SetColumnSpan(this.tableLayoutPanel4, 2);
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Controls.Add(this.lblStrategyValues, 0, 1);
			this.tableLayoutPanel4.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tableLayoutPanel4.Location = new System.Drawing.Point(473, 195);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 3;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.Size = new System.Drawing.Size(236, 200);
			this.tableLayoutPanel4.TabIndex = 22;
			// 
			// lblStrategyValues
			// 
			this.lblStrategyValues.AutoSize = true;
			this.lblStrategyValues.BackColor = System.Drawing.Color.Plum;
			this.lblStrategyValues.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblStrategyValues.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblStrategyValues.Location = new System.Drawing.Point(0, 40);
			this.lblStrategyValues.Margin = new System.Windows.Forms.Padding(0);
			this.lblStrategyValues.Name = "lblStrategyValues";
			this.lblStrategyValues.Size = new System.Drawing.Size(236, 150);
			this.lblStrategyValues.TabIndex = 22;
			this.lblStrategyValues.Text = "333";
			this.lblStrategyValues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblStrategyValues.Click += new System.EventHandler(this.lblStrategyValues_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Thistle;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(236, 40);
			this.panel1.TabIndex = 23;
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.功能FToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1184, 25);
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
			// cmbOutSite
			// 
			this.cmbOutSite.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cmbOutSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOutSite.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cmbOutSite.FormattingEnabled = true;
			this.cmbOutSite.Location = new System.Drawing.Point(0, 0);
			this.cmbOutSite.Margin = new System.Windows.Forms.Padding(0);
			this.cmbOutSite.Name = "cmbOutSite";
			this.cmbOutSite.Size = new System.Drawing.Size(473, 25);
			this.cmbOutSite.TabIndex = 23;
			// 
			// cmbInSite
			// 
			this.cmbInSite.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cmbInSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbInSite.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cmbInSite.FormattingEnabled = true;
			this.cmbInSite.Location = new System.Drawing.Point(709, 0);
			this.cmbInSite.Margin = new System.Windows.Forms.Padding(0);
			this.cmbInSite.Name = "cmbInSite";
			this.cmbInSite.Size = new System.Drawing.Size(475, 25);
			this.cmbInSite.TabIndex = 23;
			// 
			// Form6
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 808);
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
			((System.ComponentModel.ISupportInitialize)(this.nudParaMin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudParaZ)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tckPecentage)).EndInit();
			this.tableLayoutPanelMain.ResumeLayout(false);
			this.tableLayoutPanelMain.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudParaA)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudParaB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gdvTrades)).EndInit();
			this.tableLayoutPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gdvOutSitePlacedOrders)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gdvInSitePlacedOrders)).EndInit();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TrackBar tckPecentage;
        private System.Windows.Forms.Label lblHuobiPrice;
        private System.Windows.Forms.Button btnStartStopStrategy;
        private System.Windows.Forms.Button btnCancelAllPendingPlacedOrders;
        private System.Windows.Forms.Label lblHuobiAccount;
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
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nudParaZ;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown nudParaB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown nudParaA;
		private System.Windows.Forms.DataGridView gdvTrades;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.DataGridView gdvInSitePlacedOrders;
		private System.Windows.Forms.DataGridView gdvOutSitePlacedOrders;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.CheckBox chkAutoTrade;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown nudAmount;
		private System.Windows.Forms.Button btnPlaceOrder;
		private System.Windows.Forms.Button btnShowPendingPlacedOrders;
		private System.Windows.Forms.Label lblStrategyValues;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox cmbOutSite;
		private System.Windows.Forms.ComboBox cmbInSite;
	}
}