using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCPrice_Catcher.Trader;

namespace BCPrice_Catcher
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			HuobiTrader trader = new HuobiTrader();

			textBox1.Text = trader.GetAccountInfo();
			//MessageBox.Show(trader.GetAccountInfo());
		}
	}
}
