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
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.timer3 = new System.Windows.Forms.Timer(this.components);
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.dgvGroupOrders = new System.Windows.Forms.DataGridView();
			this.dgvCurrentTrade = new System.Windows.Forms.DataGridView();
			this.dgvCurrentMarket = new System.Windows.Forms.DataGridView();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.dataGridView3 = new System.Windows.Forms.DataGridView();
			this.timer4 = new System.Windows.Forms.Timer(this.components);
			this.timer5 = new System.Windows.Forms.Timer(this.components);
			this.timer6 = new System.Windows.Forms.Timer(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGroupOrders)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCurrentTrade)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCurrentMarket)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timer2
			// 
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// timer3
			// 
			this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
			this.tableLayoutPanel1.Controls.Add(this.dataGridView3, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.dgvGroupOrders, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.dgvCurrentTrade, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.dgvCurrentMarket, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1976, 744);
			this.tableLayoutPanel1.TabIndex = 8;
			// 
			// dgvGroupOrders
			// 
			this.dgvGroupOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvGroupOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGroupOrders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvGroupOrders.Location = new System.Drawing.Point(661, 3);
			this.dgvGroupOrders.Name = "dgvGroupOrders";
			this.dgvGroupOrders.RowTemplate.Height = 30;
			this.dgvGroupOrders.Size = new System.Drawing.Size(652, 366);
			this.dgvGroupOrders.TabIndex = 10;
			// 
			// dgvCurrentTrade
			// 
			this.dgvCurrentTrade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvCurrentTrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCurrentTrade.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvCurrentTrade.Location = new System.Drawing.Point(3, 3);
			this.dgvCurrentTrade.Name = "dgvCurrentTrade";
			this.dgvCurrentTrade.RowTemplate.Height = 30;
			this.dgvCurrentTrade.Size = new System.Drawing.Size(652, 366);
			this.dgvCurrentTrade.TabIndex = 9;
			// 
			// dgvCurrentMarket
			// 
			this.dgvCurrentMarket.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvCurrentMarket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCurrentMarket.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvCurrentMarket.Location = new System.Drawing.Point(1319, 3);
			this.dgvCurrentMarket.Name = "dgvCurrentMarket";
			this.dgvCurrentMarket.RowTemplate.Height = 30;
			this.dgvCurrentMarket.Size = new System.Drawing.Size(654, 366);
			this.dgvCurrentMarket.TabIndex = 8;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(1319, 375);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 30;
			this.dataGridView1.Size = new System.Drawing.Size(654, 366);
			this.dataGridView1.TabIndex = 11;
			// 
			// dataGridView2
			// 
			this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView2.Location = new System.Drawing.Point(661, 375);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.RowTemplate.Height = 30;
			this.dataGridView2.Size = new System.Drawing.Size(652, 366);
			this.dataGridView2.TabIndex = 12;
			// 
			// dataGridView3
			// 
			this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView3.Location = new System.Drawing.Point(3, 375);
			this.dataGridView3.Name = "dataGridView3";
			this.dataGridView3.RowTemplate.Height = 30;
			this.dataGridView3.Size = new System.Drawing.Size(652, 366);
			this.dataGridView3.TabIndex = 13;
			// 
			// timer4
			// 
			this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1976, 744);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvGroupOrders)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCurrentTrade)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCurrentMarket)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer timer2;
		private System.Windows.Forms.Timer timer3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.DataGridView dgvGroupOrders;
		private System.Windows.Forms.DataGridView dgvCurrentTrade;
		private System.Windows.Forms.DataGridView dgvCurrentMarket;
		private System.Windows.Forms.DataGridView dataGridView3;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Timer timer4;
		private System.Windows.Forms.Timer timer5;
		private System.Windows.Forms.Timer timer6;
	}
}

