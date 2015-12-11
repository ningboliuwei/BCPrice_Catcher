namespace BCPrice_Catcher
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
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.dgvHuobiTicker = new System.Windows.Forms.DataGridView();
			this.dgvHuobiTrade = new System.Windows.Forms.DataGridView();
			this.dgvHuobiOrders = new System.Windows.Forms.DataGridView();
			this.dgvBtccTrade = new System.Windows.Forms.DataGridView();
			this.dgvBtccTicker = new System.Windows.Forms.DataGridView();
			this.dgvBtccOrders = new System.Windows.Forms.DataGridView();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvHuobiTicker)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvHuobiTrade)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvHuobiOrders)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvBtccTrade)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvBtccTicker)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvBtccOrders)).BeginInit();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 200;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
			this.tableLayoutPanel1.Controls.Add(this.dgvHuobiOrders, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.dgvHuobiTrade, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.dgvHuobiTicker, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.dgvBtccTrade, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.dgvBtccTicker, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.dgvBtccOrders, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1641, 744);
			this.tableLayoutPanel1.TabIndex = 8;
			// 
			// dgvHuobiTicker
			// 
			this.dgvHuobiTicker.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvHuobiTicker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvHuobiTicker.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvHuobiTicker.Location = new System.Drawing.Point(3, 374);
			this.dgvHuobiTicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dgvHuobiTicker.Name = "dgvHuobiTicker";
			this.dgvHuobiTicker.RowTemplate.Height = 30;
			this.dgvHuobiTicker.Size = new System.Drawing.Size(540, 368);
			this.dgvHuobiTicker.TabIndex = 13;
			// 
			// dgvHuobiTrade
			// 
			this.dgvHuobiTrade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvHuobiTrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvHuobiTrade.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvHuobiTrade.Location = new System.Drawing.Point(549, 374);
			this.dgvHuobiTrade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dgvHuobiTrade.Name = "dgvHuobiTrade";
			this.dgvHuobiTrade.RowTemplate.Height = 30;
			this.dgvHuobiTrade.Size = new System.Drawing.Size(540, 368);
			this.dgvHuobiTrade.TabIndex = 12;
			// 
			// dgvHuobiOrders
			// 
			this.dgvHuobiOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvHuobiOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvHuobiOrders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvHuobiOrders.Location = new System.Drawing.Point(1095, 374);
			this.dgvHuobiOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dgvHuobiOrders.Name = "dgvHuobiOrders";
			this.dgvHuobiOrders.RowTemplate.Height = 30;
			this.dgvHuobiOrders.Size = new System.Drawing.Size(543, 368);
			this.dgvHuobiOrders.TabIndex = 11;
			// 
			// dgvBtccTrade
			// 
			this.dgvBtccTrade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvBtccTrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBtccTrade.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvBtccTrade.Location = new System.Drawing.Point(549, 2);
			this.dgvBtccTrade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dgvBtccTrade.Name = "dgvBtccTrade";
			this.dgvBtccTrade.RowTemplate.Height = 30;
			this.dgvBtccTrade.Size = new System.Drawing.Size(540, 368);
			this.dgvBtccTrade.TabIndex = 10;
			// 
			// dgvBtccTicker
			// 
			this.dgvBtccTicker.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvBtccTicker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBtccTicker.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvBtccTicker.Location = new System.Drawing.Point(3, 2);
			this.dgvBtccTicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dgvBtccTicker.Name = "dgvBtccTicker";
			this.dgvBtccTicker.RowTemplate.Height = 30;
			this.dgvBtccTicker.Size = new System.Drawing.Size(540, 368);
			this.dgvBtccTicker.TabIndex = 17;
			// 
			// dgvBtccOrders
			// 
			this.dgvBtccOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBtccOrders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvBtccOrders.Location = new System.Drawing.Point(1095, 2);
			this.dgvBtccOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dgvBtccOrders.Name = "dgvBtccOrders";
			this.dgvBtccOrders.RowTemplate.Height = 30;
			this.dgvBtccOrders.Size = new System.Drawing.Size(543, 368);
			this.dgvBtccOrders.TabIndex = 19;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1641, 744);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvHuobiTicker)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvHuobiTrade)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvHuobiOrders)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvBtccTrade)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvBtccTicker)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvBtccOrders)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.DataGridView dgvBtccTrade;
		private System.Windows.Forms.DataGridView dgvHuobiTicker;
		private System.Windows.Forms.DataGridView dgvHuobiTrade;
		private System.Windows.Forms.DataGridView dgvHuobiOrders;
		private System.Windows.Forms.DataGridView dgvBtccTicker;
		private System.Windows.Forms.DataGridView dgvBtccOrders;
	}
}

