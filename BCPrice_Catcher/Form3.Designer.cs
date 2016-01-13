namespace BCPrice_Catcher
{
    partial class Form3
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblBtccPrice = new System.Windows.Forms.Label();
            this.lblHuobiPrice = new System.Windows.Forms.Label();
            this.lblBtccAccountInfo = new System.Windows.Forms.Label();
            this.lblHuobiAccountInfo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtTotalAssets = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 138);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(683, 433);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(722, 138);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(642, 433);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(155, 851);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 28);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 858);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "UpperLimit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 854);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "LowerLimit";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(496, 844);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 28);
            this.textBox4.TabIndex = 2;
            this.textBox4.Text = "2";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.lblBtccPrice.AutoSize = true;
            this.lblBtccPrice.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBtccPrice.Location = new System.Drawing.Point(152, 83);
            this.lblBtccPrice.Name = "lblBtccPrice";
            this.lblBtccPrice.Size = new System.Drawing.Size(123, 36);
            this.lblBtccPrice.TabIndex = 4;
            this.lblBtccPrice.Text = "label3";
            // 
            // label4
            // 
            this.lblHuobiPrice.AutoSize = true;
            this.lblHuobiPrice.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHuobiPrice.Location = new System.Drawing.Point(1013, 83);
            this.lblHuobiPrice.Name = "lblHuobiPrice";
            this.lblHuobiPrice.Size = new System.Drawing.Size(123, 36);
            this.lblHuobiPrice.TabIndex = 4;
            this.lblHuobiPrice.Text = "label3";
            // 
            // label5
            // 
            this.lblBtccAccountInfo.AutoSize = true;
            this.lblBtccAccountInfo.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBtccAccountInfo.Location = new System.Drawing.Point(107, 689);
            this.lblBtccAccountInfo.Name = "lblBtccAccountInfo";
            this.lblBtccAccountInfo.Size = new System.Drawing.Size(123, 36);
            this.lblBtccAccountInfo.TabIndex = 4;
            this.lblBtccAccountInfo.Text = "label3";
            // 
            // label6
            // 
            this.lblHuobiAccountInfo.AutoSize = true;
            this.lblHuobiAccountInfo.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHuobiAccountInfo.Location = new System.Drawing.Point(998, 698);
            this.lblHuobiAccountInfo.Name = "lblHuobiAccountInfo";
            this.lblHuobiAccountInfo.Size = new System.Drawing.Size(123, 36);
            this.lblHuobiAccountInfo.TabIndex = 4;
            this.lblHuobiAccountInfo.Text = "label3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(675, 861);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 18);
            this.label7.TabIndex = 3;
            this.label7.Text = "Sell/Buy Amount";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(858, 854);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 28);
            this.textBox5.TabIndex = 2;
            this.textBox5.Text = "10";
            // 
            // textBox6
            // 
            this.txtTotalAssets.Location = new System.Drawing.Point(377, 603);
            this.txtTotalAssets.Multiline = true;
            this.txtTotalAssets.Name = "txtTotalAssets";
            this.txtTotalAssets.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTotalAssets.Size = new System.Drawing.Size(483, 192);
            this.txtTotalAssets.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(152, 590);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 36);
            this.label8.TabIndex = 4;
            this.label8.Text = "总资产";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 941);
            this.Controls.Add(this.lblHuobiAccountInfo);
            this.Controls.Add(this.lblHuobiPrice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblBtccAccountInfo);
            this.Controls.Add(this.lblBtccPrice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtTotalAssets);
            this.Controls.Add(this.textBox1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblBtccPrice;
        private System.Windows.Forms.Label lblHuobiPrice;
        private System.Windows.Forms.Label lblBtccAccountInfo;
        private System.Windows.Forms.Label lblHuobiAccountInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtTotalAssets;
        private System.Windows.Forms.Label label8;
    }
}