﻿namespace BCPrice_Catcher
{
	partial class Form2
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
			this.button1 = new System.Windows.Forms.Button();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtAmount = new System.Windows.Forms.TextBox();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.txtAccountInfo = new System.Windows.Forms.TextBox();
			this.txtOrders = new System.Windows.Forms.TextBox();
			this.txtTransactions = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.button10 = new System.Windows.Forms.Button();
			this.txtOrderId = new System.Windows.Forms.TextBox();
			this.button11 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(61, 577);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(188, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "BtccGetOrders";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// txtResult
			// 
			this.txtResult.Location = new System.Drawing.Point(19, 22);
			this.txtResult.Multiline = true;
			this.txtResult.Name = "txtResult";
			this.txtResult.Size = new System.Drawing.Size(671, 175);
			this.txtResult.TabIndex = 1;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(104, 474);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 0;
			this.button2.Text = "BtccSell";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(79, 521);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(136, 23);
			this.button3.TabIndex = 0;
			this.button3.Text = "BtccSellMarket";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(424, 383);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 27);
			this.button4.TabIndex = 0;
			this.button4.Text = "HuobiBuy";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(416, 429);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(159, 27);
			this.button5.TabIndex = 0;
			this.button5.Text = "HuobiBuyMarket";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(92, 387);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 0;
			this.button6.Text = "BtccBuy";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button1_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(61, 431);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(118, 23);
			this.button7.TabIndex = 0;
			this.button7.Text = "BtccBuyMarket";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// txtPrice
			// 
			this.txtPrice.Location = new System.Drawing.Point(201, 238);
			this.txtPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.Size = new System.Drawing.Size(157, 22);
			this.txtPrice.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(92, 238);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 15);
			this.label1.TabIndex = 3;
			this.label1.Text = "price";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(76, 292);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "amount";
			// 
			// txtAmount
			// 
			this.txtAmount.Location = new System.Drawing.Point(201, 292);
			this.txtAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtAmount.Name = "txtAmount";
			this.txtAmount.Size = new System.Drawing.Size(157, 22);
			this.txtAmount.TabIndex = 2;
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(424, 474);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(135, 27);
			this.button8.TabIndex = 0;
			this.button8.Text = "HuobiSell";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(416, 517);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(159, 27);
			this.button9.TabIndex = 0;
			this.button9.Text = "HuobiSellMarket";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// txtAccountInfo
			// 
			this.txtAccountInfo.Location = new System.Drawing.Point(743, 35);
			this.txtAccountInfo.Multiline = true;
			this.txtAccountInfo.Name = "txtAccountInfo";
			this.txtAccountInfo.Size = new System.Drawing.Size(425, 121);
			this.txtAccountInfo.TabIndex = 1;
			// 
			// txtOrders
			// 
			this.txtOrders.Location = new System.Drawing.Point(743, 187);
			this.txtOrders.Multiline = true;
			this.txtOrders.Name = "txtOrders";
			this.txtOrders.Size = new System.Drawing.Size(425, 121);
			this.txtOrders.TabIndex = 1;
			// 
			// txtTransactions
			// 
			this.txtTransactions.Location = new System.Drawing.Point(733, 334);
			this.txtTransactions.Multiline = true;
			this.txtTransactions.Name = "txtTransactions";
			this.txtTransactions.Size = new System.Drawing.Size(425, 121);
			this.txtTransactions.TabIndex = 1;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(709, 501);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 30;
			this.dataGridView1.Size = new System.Drawing.Size(430, 197);
			this.dataGridView1.TabIndex = 4;
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(94, 642);
			this.button10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(131, 19);
			this.button10.TabIndex = 5;
			this.button10.Text = "BtccGetOrder";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// txtOrderId
			// 
			this.txtOrderId.Location = new System.Drawing.Point(9, 637);
			this.txtOrderId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtOrderId.Name = "txtOrderId";
			this.txtOrderId.Size = new System.Drawing.Size(79, 22);
			this.txtOrderId.TabIndex = 6;
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(401, 577);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(188, 23);
			this.button11.TabIndex = 0;
			this.button11.Text = "HuobiGetOrders";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1304, 764);
			this.Controls.Add(this.txtOrderId);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtAmount);
			this.Controls.Add(this.txtPrice);
			this.Controls.Add(this.txtTransactions);
			this.Controls.Add(this.txtOrders);
			this.Controls.Add(this.txtAccountInfo);
			this.Controls.Add(this.txtResult);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.button1);
			this.Name = "Form2";
			this.Text = "Form2";
			this.Load += new System.EventHandler(this.Form2_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox txtAccountInfo;
        private System.Windows.Forms.TextBox txtOrders;
        private System.Windows.Forms.TextBox txtTransactions;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Button button11;
    }
}