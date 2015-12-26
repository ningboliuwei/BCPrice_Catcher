namespace BCPrice_Catcher
{
    partial class Form4
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
            this.lblBtccPrice = new System.Windows.Forms.Label();
            this.lblHuobiAccount = new System.Windows.Forms.Label();
            this.lblHuobiPrice = new System.Windows.Forms.Label();
            this.lblDifferPrice = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblBtccAccount = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelStrategies = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelTrades = new System.Windows.Forms.TableLayoutPanel();
            this.gdvHuobiTrades = new System.Windows.Forms.DataGridView();
            this.gdvBtccTrades = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelTrades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvHuobiTrades)).BeginInit();
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
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanelMain.SetColumnSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnAllStart, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAllStop, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(662, 140);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(995, 60);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // btnAllStart
            // 
            this.btnAllStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAllStart.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllStart.Location = new System.Drawing.Point(500, 3);
            this.btnAllStart.Name = "btnAllStart";
            this.btnAllStart.Size = new System.Drawing.Size(242, 54);
            this.btnAllStart.TabIndex = 8;
            this.btnAllStart.Text = "全部开始(&S)";
            this.btnAllStart.UseVisualStyleBackColor = false;
            this.btnAllStart.Click += new System.EventHandler(this.btnAllStart_Click);
            // 
            // btnAllStop
            // 
            this.btnAllStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAllStop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllStop.Location = new System.Drawing.Point(748, 3);
            this.btnAllStop.Name = "btnAllStop";
            this.btnAllStop.Size = new System.Drawing.Size(244, 54);
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
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 140);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(662, 60);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 41);
            this.label2.TabIndex = 5;
            this.label2.Text = "启动价";
            // 
            // nudStartPrice
            // 
            this.nudStartPrice.Location = new System.Drawing.Point(84, 3);
            this.nudStartPrice.Name = "nudStartPrice";
            this.nudStartPrice.Size = new System.Drawing.Size(261, 35);
            this.nudStartPrice.TabIndex = 6;
            this.nudStartPrice.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
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
            this.lblDifferPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
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
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.Green;
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(662, 60);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(331, 80);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 40;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
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
            this.tableLayoutPanelMain.Controls.Add(this.trackBar1, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelStrategies, 0, 4);
            this.tableLayoutPanelMain.Controls.Add(this.lblHuobiPrice, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel1, 1, 2);
            this.tableLayoutPanelMain.Controls.Add(this.lblHuobiAccount, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelTrades, 0, 3);
            this.tableLayoutPanelMain.Controls.Add(this.lblBtccPrice, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.lblBtccAccount, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.lblDifferPrice, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 5;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1657, 703);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tableLayoutPanelStrategies
            // 
            this.tableLayoutPanelStrategies.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanelStrategies.ColumnCount = 13;
            this.tableLayoutPanelMain.SetColumnSpan(this.tableLayoutPanelStrategies, 3);
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelStrategies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelStrategies.Location = new System.Drawing.Point(3, 597);
            this.tableLayoutPanelStrategies.Name = "tableLayoutPanelStrategies";
            this.tableLayoutPanelStrategies.RowCount = 17;
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStrategies.Size = new System.Drawing.Size(1651, 114);
            this.tableLayoutPanelStrategies.TabIndex = 9;
            // 
            // tableLayoutPanelTrades
            // 
            this.tableLayoutPanelTrades.BackColor = System.Drawing.Color.Silver;
            this.tableLayoutPanelTrades.ColumnCount = 2;
            this.tableLayoutPanelMain.SetColumnSpan(this.tableLayoutPanelTrades, 3);
            this.tableLayoutPanelTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTrades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelTrades.Controls.Add(this.gdvHuobiTrades, 0, 0);
            this.tableLayoutPanelTrades.Controls.Add(this.gdvBtccTrades, 0, 0);
            this.tableLayoutPanelTrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTrades.Location = new System.Drawing.Point(0, 200);
            this.tableLayoutPanelTrades.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelTrades.Name = "tableLayoutPanelTrades";
            this.tableLayoutPanelTrades.RowCount = 1;
            this.tableLayoutPanelTrades.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTrades.Size = new System.Drawing.Size(1657, 394);
            this.tableLayoutPanelTrades.TabIndex = 12;
            // 
            // gdvHuobiTrades
            // 
            this.gdvHuobiTrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvHuobiTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvHuobiTrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdvHuobiTrades.Location = new System.Drawing.Point(831, 2);
            this.gdvHuobiTrades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gdvHuobiTrades.Name = "gdvHuobiTrades";
            this.gdvHuobiTrades.RowTemplate.Height = 30;
            this.gdvHuobiTrades.Size = new System.Drawing.Size(823, 390);
            this.gdvHuobiTrades.TabIndex = 19;
            // 
            // gdvBtccTrades
            // 
            this.gdvBtccTrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvBtccTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvBtccTrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdvBtccTrades.Location = new System.Drawing.Point(3, 2);
            this.gdvBtccTrades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gdvBtccTrades.Name = "gdvBtccTrades";
            this.gdvBtccTrades.RowTemplate.Height = 30;
            this.gdvBtccTrades.Size = new System.Drawing.Size(822, 390);
            this.gdvBtccTrades.TabIndex = 18;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1657, 703);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form4";
            this.Text = "Form4";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Form4_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4_FormClosed);
            this.Load += new System.EventHandler(this.Form4_Load);
            this.Shown += new System.EventHandler(this.Form4_Shown);
            this.ResizeBegin += new System.EventHandler(this.Form4_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form4_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form4_Paint);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.tableLayoutPanelTrades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvHuobiTrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvBtccTrades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TrackBar trackBar1;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTrades;
        private System.Windows.Forms.DataGridView gdvHuobiTrades;
        private System.Windows.Forms.DataGridView gdvBtccTrades;
    }
}