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
			MessageBox.Show(new HuobiTrader().GetAccountInfo());
			MessageBox.Show(new HuobiTrader().SellMarket(10, Trader.Trader.CoinType.Btc));
			MessageBox.Show(new HuobiTrader().GetOrders(Trader.Trader.CoinType.Btc));
		}
	}
}