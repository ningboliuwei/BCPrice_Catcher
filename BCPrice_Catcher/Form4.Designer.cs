﻿namespace BCPrice_Catcher
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBtccPrice = new System.Windows.Forms.Label();
            this.lblHuobiPrice = new System.Windows.Forms.Label();
            this.lblPriceDiffer = new System.Windows.Forms.Label();
            this.lblBtccPercentage = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAllStart = new System.Windows.Forms.Button();
            this.btnAllStop = new System.Windows.Forms.Button();
            this.tableLayoutPanelStrategies = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRegressionPrice = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAddStrategy = new System.Windows.Forms.Button();
            this.btnRemoveStrategy = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelStrategies.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.lblBtccPrice, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblHuobiPrice, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPriceDiffer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBtccPercentage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.trackBar1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAllStart, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAllStop, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelStrategies, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1821, 1199);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblBtccPrice
            // 
            this.lblBtccPrice.AutoSize = true;
            this.lblBtccPrice.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBtccPrice.Location = new System.Drawing.Point(3, 0);
            this.lblBtccPrice.Name = "lblBtccPrice";
            this.lblBtccPrice.Size = new System.Drawing.Size(159, 36);
            this.lblBtccPrice.TabIndex = 5;
            this.lblBtccPrice.Text = "Btcc价格";
            // 
            // lblHuobiPrice
            // 
            this.lblHuobiPrice.AutoSize = true;
            this.lblHuobiPrice.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHuobiPrice.Location = new System.Drawing.Point(1217, 0);
            this.lblHuobiPrice.Name = "lblHuobiPrice";
            this.lblHuobiPrice.Size = new System.Drawing.Size(177, 36);
            this.lblHuobiPrice.TabIndex = 5;
            this.lblHuobiPrice.Text = "Huobi价格";
            // 
            // lblPriceDiffer
            // 
            this.lblPriceDiffer.AutoSize = true;
            this.lblPriceDiffer.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPriceDiffer.Location = new System.Drawing.Point(610, 0);
            this.lblPriceDiffer.Name = "lblPriceDiffer";
            this.lblPriceDiffer.Size = new System.Drawing.Size(87, 36);
            this.lblPriceDiffer.TabIndex = 5;
            this.lblPriceDiffer.Text = "差价";
            // 
            // lblBtccPercentage
            // 
            this.lblBtccPercentage.AutoSize = true;
            this.lblBtccPercentage.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBtccPercentage.Location = new System.Drawing.Point(3, 80);
            this.lblBtccPercentage.Name = "lblBtccPercentage";
            this.lblBtccPercentage.Size = new System.Drawing.Size(159, 36);
            this.lblBtccPercentage.TabIndex = 5;
            this.lblBtccPercentage.Text = "Btcc比例";
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(610, 83);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(601, 74);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.Value = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1217, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "Huobi比例";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 163);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(601, 74);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "启动价";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(132, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(436, 55);
            this.textBox1.TabIndex = 6;
            // 
            // btnAllStart
            // 
            this.btnAllStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAllStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAllStart.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllStart.Location = new System.Drawing.Point(610, 163);
            this.btnAllStart.Name = "btnAllStart";
            this.btnAllStart.Size = new System.Drawing.Size(601, 74);
            this.btnAllStart.TabIndex = 8;
            this.btnAllStart.Text = "全部开始(&S)";
            this.btnAllStart.UseVisualStyleBackColor = false;
            // 
            // btnAllStop
            // 
            this.btnAllStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAllStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAllStop.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllStop.Location = new System.Drawing.Point(1217, 163);
            this.btnAllStop.Name = "btnAllStop";
            this.btnAllStop.Size = new System.Drawing.Size(601, 74);
            this.btnAllStop.TabIndex = 8;
            this.btnAllStop.Text = "全部停止(&T)";
            this.btnAllStop.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanelStrategies
            // 
            this.tableLayoutPanelStrategies.ColumnCount = 14;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanelStrategies, 3);
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanelStrategies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142856F));
            this.tableLayoutPanelStrategies.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanelStrategies.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanelStrategies.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanelStrategies.Controls.Add(this.label6, 3, 0);
            this.tableLayoutPanelStrategies.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanelStrategies.Controls.Add(this.lblRegressionPrice, 5, 0);
            this.tableLayoutPanelStrategies.Controls.Add(this.label9, 6, 0);
            this.tableLayoutPanelStrategies.Controls.Add(this.btnAddStrategy, 12, 0);
            this.tableLayoutPanelStrategies.Controls.Add(this.btnRemoveStrategy, 13, 0);
            this.tableLayoutPanelStrategies.Controls.Add(this.label10, 7, 0);
            this.tableLayoutPanelStrategies.Controls.Add(this.label11, 8, 0);
            this.tableLayoutPanelStrategies.Controls.Add(this.label12, 9, 0);
            this.tableLayoutPanelStrategies.Controls.Add(this.label13, 10, 0);
            this.tableLayoutPanelStrategies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelStrategies.Location = new System.Drawing.Point(3, 243);
            this.tableLayoutPanelStrategies.Name = "tableLayoutPanelStrategies";
            this.tableLayoutPanelStrategies.RowCount = 11;
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanelStrategies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanelStrategies.Size = new System.Drawing.Size(1815, 953);
            this.tableLayoutPanelStrategies.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "策略号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(132, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "差价R";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(261, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 48);
            this.label5.TabIndex = 5;
            this.label5.Text = "差价R配重加减";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(390, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 48);
            this.label6.TabIndex = 5;
            this.label6.Text = "差价R配重系数";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(519, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 24);
            this.label7.TabIndex = 5;
            this.label7.Text = "周期";
            // 
            // lblRegressionPrice
            // 
            this.lblRegressionPrice.AutoSize = true;
            this.lblRegressionPrice.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRegressionPrice.Location = new System.Drawing.Point(648, 0);
            this.lblRegressionPrice.Name = "lblRegressionPrice";
            this.lblRegressionPrice.Size = new System.Drawing.Size(106, 48);
            this.lblRegressionPrice.TabIndex = 5;
            this.lblRegressionPrice.Text = "默认回归价";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(777, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 48);
            this.label9.TabIndex = 5;
            this.label9.Text = "回归价配重加减";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(906, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 48);
            this.label10.TabIndex = 5;
            this.label10.Text = "回归价配重系数";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(1035, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "数量";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(1164, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 24);
            this.label12.TabIndex = 5;
            this.label12.Text = "涌动";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(1293, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 24);
            this.label13.TabIndex = 5;
            this.label13.Text = "成交";
            // 
            // btnAddStrategy
            // 
            this.btnAddStrategy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddStrategy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddStrategy.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddStrategy.Location = new System.Drawing.Point(1551, 3);
            this.btnAddStrategy.Name = "btnAddStrategy";
            this.btnAddStrategy.Size = new System.Drawing.Size(123, 80);
            this.btnAddStrategy.TabIndex = 8;
            this.btnAddStrategy.Text = "＋";
            this.btnAddStrategy.UseVisualStyleBackColor = false;
            this.btnAddStrategy.Click += new System.EventHandler(this.btnAddStrategy_Click);
            // 
            // btnRemoveStrategy
            // 
            this.btnRemoveStrategy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRemoveStrategy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveStrategy.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemoveStrategy.Location = new System.Drawing.Point(1680, 3);
            this.btnRemoveStrategy.Name = "btnRemoveStrategy";
            this.btnRemoveStrategy.Size = new System.Drawing.Size(132, 80);
            this.btnRemoveStrategy.TabIndex = 8;
            this.btnRemoveStrategy.Text = "－";
            this.btnRemoveStrategy.UseVisualStyleBackColor = false;
            this.btnRemoveStrategy.Click += new System.EventHandler(this.btnRemoveStrategy_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1821, 1199);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form4";
            this.Text = "Form4";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Form4_Activated);
            this.Load += new System.EventHandler(this.Form4_Load);
            this.Shown += new System.EventHandler(this.Form4_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanelStrategies.ResumeLayout(false);
            this.tableLayoutPanelStrategies.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblBtccPrice;
        private System.Windows.Forms.Label lblHuobiPrice;
        private System.Windows.Forms.Label lblPriceDiffer;
        private System.Windows.Forms.Label lblBtccPercentage;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAllStart;
        private System.Windows.Forms.Button btnAllStop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStrategies;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblRegressionPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnAddStrategy;
        private System.Windows.Forms.Button btnRemoveStrategy;
    }
}