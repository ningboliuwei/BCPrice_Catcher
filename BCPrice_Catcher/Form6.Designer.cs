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
			this.btnAllStart = new System.Windows.Forms.Button();
			this.btnAllStop = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.nudStartPrice = new System.Windows.Forms.NumericUpDown();
			this.btnSwitchMode = new System.Windows.Forms.Button();
			this.lblBtccPrice = new System.Windows.Forms.Label();
			this.lblHuobiAccount = new System.Windows.Forms.Label();
			this.lblHuobiPrice = new System.Windows.Forms.Label();
			this.lblDifferPrice = new System.Windows.Forms.Label();
			this.tckPecentage = new System.Windows.Forms.TrackBar();
			this.lblBtccAccount = new System.Windows.Forms.Label();
			this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelStrategies = new System.Windows.Forms.TableLayoutPanel();
			this.lblTotalProfits = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.功能FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudStartPrice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tckPecentage)).BeginInit();
			this.tableLayoutPanelMain.SuspendLayout();
			this.menuStrip1.SuspendLayout();
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
			this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.btnAllStart, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnAllStop, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(993, 140);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(664, 50);
			this.tableLayoutPanel1.TabIndex = 11;
			// 
			// btnAllStart
			// 
			this.btnAllStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.btnAllStart.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnAllStart.Location = new System.Drawing.Point(334, 2);
			this.btnAllStart.Margin = new System.Windows.Forms.Padding(2);
			this.btnAllStart.Name = "btnAllStart";
			this.btnAllStart.Size = new System.Drawing.Size(160, 46);
			this.btnAllStart.TabIndex = 8;
			this.btnAllStart.Text = "全部开始(&S)";
			this.btnAllStart.UseVisualStyleBackColor = false;
			this.btnAllStart.Click += new System.EventHandler(this.btnAllStart_Click);
			// 
			// btnAllStop
			// 
			this.btnAllStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.btnAllStop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnAllStop.Location = new System.Drawing.Point(500, 2);
			this.btnAllStop.Margin = new System.Windows.Forms.Padding(2);
			this.btnAllStop.Name = "btnAllStop";
			this.btnAllStop.Size = new System.Drawing.Size(160, 46);
			this.btnAllStop.TabIndex = 8;
			this.btnAllStop.Text = "全部停止(&T)";
			this.btnAllStop.UseVisualStyleBackColor = false;
			this.btnAllStop.Click += new System.EventHandler(this.btnAllStop_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
			this.flowLayoutPanel1.Controls.Add(this.label2);
			this.flowLayoutPanel1.Controls.Add(this.nudStartPrice);
			this.flowLayoutPanel1.Controls.Add(this.btnSwitchMode);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 140);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(662, 50);
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
			this.label2.Size = new System.Drawing.Size(51, 39);
			this.label2.TabIndex = 5;
			this.label2.Text = "启动价";
			// 
			// nudStartPrice
			// 
			this.nudStartPrice.DecimalPlaces = 3;
			this.nudStartPrice.Location = new System.Drawing.Point(57, 2);
			this.nudStartPrice.Margin = new System.Windows.Forms.Padding(2);
			this.nudStartPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudStartPrice.Name = "nudStartPrice";
			this.nudStartPrice.Size = new System.Drawing.Size(100, 26);
			this.nudStartPrice.TabIndex = 6;
			this.nudStartPrice.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// btnSwitchMode
			// 
			this.btnSwitchMode.BackColor = System.Drawing.Color.LimeGreen;
			this.btnSwitchMode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnSwitchMode.Location = new System.Drawing.Point(161, 2);
			this.btnSwitchMode.Margin = new System.Windows.Forms.Padding(2);
			this.btnSwitchMode.Name = "btnSwitchMode";
			this.btnSwitchMode.Size = new System.Drawing.Size(180, 35);
			this.btnSwitchMode.TabIndex = 8;
			this.btnSwitchMode.Text = "启动真实模式(&R)";
			this.btnSwitchMode.UseVisualStyleBackColor = false;
			this.btnSwitchMode.Click += new System.EventHandler(this.btnSwitchMode_Click);
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
			this.lblBtccPrice.Size = new System.Drawing.Size(662, 60);
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
			this.lblHuobiAccount.Location = new System.Drawing.Point(993, 60);
			this.lblHuobiAccount.Margin = new System.Windows.Forms.Padding(0);
			this.lblHuobiAccount.Name = "lblHuobiAccount";
			this.lblHuobiAccount.Size = new System.Drawing.Size(664, 80);
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
			this.lblHuobiPrice.Location = new System.Drawing.Point(993, 0);
			this.lblHuobiPrice.Margin = new System.Windows.Forms.Padding(0);
			this.lblHuobiPrice.Name = "lblHuobiPrice";
			this.lblHuobiPrice.Size = new System.Drawing.Size(664, 60);
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
			this.lblDifferPrice.Location = new System.Drawing.Point(662, 0);
			this.lblDifferPrice.Margin = new System.Windows.Forms.Padding(0);
			this.lblDifferPrice.Name = "lblDifferPrice";
			this.lblDifferPrice.Size = new System.Drawing.Size(331, 60);
			this.lblDifferPrice.TabIndex = 5;
			this.lblDifferPrice.Text = "差价";
			this.lblDifferPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tckPecentage
			// 
			this.tckPecentage.BackColor = System.Drawing.SystemColors.Control;
			this.tckPecentage.LargeChange = 10;
			this.tckPecentage.Location = new System.Drawing.Point(662, 140);
			this.tckPecentage.Margin = new System.Windows.Forms.Padding(0);
			this.tckPecentage.Maximum = 100;
			this.tckPecentage.Name = "tckPecentage";
			this.tckPecentage.Size = new System.Drawing.Size(331, 45);
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
			this.lblBtccAccount.Size = new System.Drawing.Size(662, 80);
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
			this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelStrategies, 0, 3);
			this.tableLayoutPanelMain.Controls.Add(this.lblHuobiPrice, 2, 0);
			this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel1, 2, 2);
			this.tableLayoutPanelMain.Controls.Add(this.lblHuobiAccount, 2, 1);
			this.tableLayoutPanelMain.Controls.Add(this.lblBtccPrice, 0, 0);
			this.tableLayoutPanelMain.Controls.Add(this.lblBtccAccount, 0, 1);
			this.tableLayoutPanelMain.Controls.Add(this.lblDifferPrice, 1, 0);
			this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanel1, 0, 2);
			this.tableLayoutPanelMain.Controls.Add(this.tckPecentage, 1, 2);
			this.tableLayoutPanelMain.Controls.Add(this.lblTotalProfits, 1, 1);
			this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelMain.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 25);
			this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
			this.tableLayoutPanelMain.RowCount = 4;
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelMain.Size = new System.Drawing.Size(1657, 678);
			this.tableLayoutPanelMain.TabIndex = 0;
			// 
			// tableLayoutPanelStrategies
			// 
			this.tableLayoutPanelStrategies.BackColor = System.Drawing.SystemColors.Control;
			this.tableLayoutPanelStrategies.ColumnCount = 8;
			this.tableLayoutPanelMain.SetColumnSpan(this.tableLayoutPanelStrategies, 3);
			this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanelStrategies.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelStrategies.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tableLayoutPanelStrategies.Location = new System.Drawing.Point(2, 192);
			this.tableLayoutPanelStrategies.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanelStrategies.Name = "tableLayoutPanelStrategies";
			this.tableLayoutPanelStrategies.RowCount = 8;
			this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelStrategies.Size = new System.Drawing.Size(1653, 484);
			this.tableLayoutPanelStrategies.TabIndex = 9;
			// 
			// lblTotalProfits
			// 
			this.lblTotalProfits.AutoEllipsis = true;
			this.lblTotalProfits.AutoSize = true;
			this.lblTotalProfits.BackColor = System.Drawing.Color.SkyBlue;
			this.lblTotalProfits.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTotalProfits.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblTotalProfits.Location = new System.Drawing.Point(662, 60);
			this.lblTotalProfits.Margin = new System.Windows.Forms.Padding(0);
			this.lblTotalProfits.Name = "lblTotalProfits";
			this.lblTotalProfits.Size = new System.Drawing.Size(331, 80);
			this.lblTotalProfits.TabIndex = 5;
			this.lblTotalProfits.Text = "总利润";
			this.lblTotalProfits.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.功能FToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1657, 25);
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
			// Form6
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1657, 703);
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
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form4_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4_FormClosed);
			this.Load += new System.EventHandler(this.Form6_Load);
			this.Shown += new System.EventHandler(this.Form6_Shown);
			this.ResizeBegin += new System.EventHandler(this.Form4_ResizeBegin);
			this.ResizeEnd += new System.EventHandler(this.Form4_ResizeEnd);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form4_Paint);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudStartPrice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tckPecentage)).EndInit();
			this.tableLayoutPanelMain.ResumeLayout(false);
			this.tableLayoutPanelMain.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAllStart;
        private System.Windows.Forms.Button btnAllStop;
        private System.Windows.Forms.Label lblHuobiAccount;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudStartPrice;
        private System.Windows.Forms.Label lblBtccPrice;
        private System.Windows.Forms.Label lblBtccAccount;
        private System.Windows.Forms.Label lblDifferPrice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStrategies;
        private System.Windows.Forms.Label lblTotalProfits;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 功能FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.Button btnSwitchMode;
    }
}