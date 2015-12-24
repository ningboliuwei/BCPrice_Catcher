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
            this.dgvHuobiOrders = new System.Windows.Forms.DataGridView();
            this.dgvHuobiTrades = new System.Windows.Forms.DataGridView();
            this.dgvHuobiTicker = new System.Windows.Forms.DataGridView();
            this.dgvBtccTrades = new System.Windows.Forms.DataGridView();
            this.dgvBtccTicker = new System.Windows.Forms.DataGridView();
            this.dgvBtccOrders = new System.Windows.Forms.DataGridView();
            this.dgvOkcTicker = new System.Windows.Forms.DataGridView();
            this.dgvOkcTrades = new System.Windows.Forms.DataGridView();
            this.dgvOkcOrders = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHuobiOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHuobiTrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHuobiTicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBtccTrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBtccTicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBtccOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOkcTicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOkcTrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOkcOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel1.Controls.Add(this.dgvHuobiOrders, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvHuobiTrades, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvHuobiTicker, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvBtccTrades, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvBtccTicker, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvBtccOrders, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvOkcTicker, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvOkcTrades, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvOkcOrders, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1641, 827);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // dgvHuobiOrders
            // 
            this.dgvHuobiOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHuobiOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHuobiOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHuobiOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHuobiOrders.Location = new System.Drawing.Point(1095, 277);
            this.dgvHuobiOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvHuobiOrders.Name = "dgvHuobiOrders";
            this.dgvHuobiOrders.RowTemplate.Height = 30;
            this.dgvHuobiOrders.Size = new System.Drawing.Size(543, 271);
            this.dgvHuobiOrders.TabIndex = 11;
            // 
            // dgvHuobiTrades
            // 
            this.dgvHuobiTrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHuobiTrades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHuobiTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHuobiTrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHuobiTrades.Location = new System.Drawing.Point(549, 277);
            this.dgvHuobiTrades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvHuobiTrades.Name = "dgvHuobiTrades";
            this.dgvHuobiTrades.RowTemplate.Height = 30;
            this.dgvHuobiTrades.Size = new System.Drawing.Size(540, 271);
            this.dgvHuobiTrades.TabIndex = 12;
            // 
            // dgvHuobiTicker
            // 
            this.dgvHuobiTicker.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHuobiTicker.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHuobiTicker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHuobiTicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHuobiTicker.Location = new System.Drawing.Point(3, 277);
            this.dgvHuobiTicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvHuobiTicker.Name = "dgvHuobiTicker";
            this.dgvHuobiTicker.RowTemplate.Height = 30;
            this.dgvHuobiTicker.Size = new System.Drawing.Size(540, 271);
            this.dgvHuobiTicker.TabIndex = 13;
            // 
            // dgvBtccTrades
            // 
            this.dgvBtccTrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBtccTrades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBtccTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBtccTrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBtccTrades.Location = new System.Drawing.Point(549, 2);
            this.dgvBtccTrades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvBtccTrades.Name = "dgvBtccTrades";
            this.dgvBtccTrades.RowTemplate.Height = 30;
            this.dgvBtccTrades.Size = new System.Drawing.Size(540, 271);
            this.dgvBtccTrades.TabIndex = 10;
            // 
            // dgvBtccTicker
            // 
            this.dgvBtccTicker.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBtccTicker.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBtccTicker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBtccTicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBtccTicker.Location = new System.Drawing.Point(3, 2);
            this.dgvBtccTicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvBtccTicker.Name = "dgvBtccTicker";
            this.dgvBtccTicker.RowTemplate.Height = 30;
            this.dgvBtccTicker.Size = new System.Drawing.Size(540, 271);
            this.dgvBtccTicker.TabIndex = 17;
            // 
            // dgvBtccOrders
            // 
            this.dgvBtccOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBtccOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBtccOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBtccOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBtccOrders.Location = new System.Drawing.Point(1095, 2);
            this.dgvBtccOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvBtccOrders.Name = "dgvBtccOrders";
            this.dgvBtccOrders.RowTemplate.Height = 30;
            this.dgvBtccOrders.Size = new System.Drawing.Size(543, 271);
            this.dgvBtccOrders.TabIndex = 19;
            // 
            // dgvOkcTicker
            // 
            this.dgvOkcTicker.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOkcTicker.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOkcTicker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOkcTicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOkcTicker.Location = new System.Drawing.Point(3, 552);
            this.dgvOkcTicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvOkcTicker.Name = "dgvOkcTicker";
            this.dgvOkcTicker.RowTemplate.Height = 30;
            this.dgvOkcTicker.Size = new System.Drawing.Size(540, 273);
            this.dgvOkcTicker.TabIndex = 13;
            // 
            // dgvOkcTrades
            // 
            this.dgvOkcTrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOkcTrades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOkcTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOkcTrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOkcTrades.Location = new System.Drawing.Point(549, 552);
            this.dgvOkcTrades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvOkcTrades.Name = "dgvOkcTrades";
            this.dgvOkcTrades.RowTemplate.Height = 30;
            this.dgvOkcTrades.Size = new System.Drawing.Size(540, 273);
            this.dgvOkcTrades.TabIndex = 13;
            // 
            // dgvOkcOrders
            // 
            this.dgvOkcOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOkcOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOkcOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOkcOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOkcOrders.Location = new System.Drawing.Point(1095, 552);
            this.dgvOkcOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvOkcOrders.Name = "dgvOkcOrders";
            this.dgvOkcOrders.RowTemplate.Height = 30;
            this.dgvOkcOrders.Size = new System.Drawing.Size(543, 273);
            this.dgvOkcOrders.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1641, 827);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHuobiOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHuobiTrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHuobiTicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBtccTrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBtccTicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBtccOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOkcTicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOkcTrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOkcOrders)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.DataGridView dgvBtccTrades;
		private System.Windows.Forms.DataGridView dgvHuobiTicker;
		private System.Windows.Forms.DataGridView dgvHuobiTrades;
		private System.Windows.Forms.DataGridView dgvHuobiOrders;
		private System.Windows.Forms.DataGridView dgvBtccTicker;
		private System.Windows.Forms.DataGridView dgvBtccOrders;
		private System.Windows.Forms.DataGridView dgvOkcTicker;
		private System.Windows.Forms.DataGridView dgvOkcTrades;
		private System.Windows.Forms.DataGridView dgvOkcOrders;
	}
}

