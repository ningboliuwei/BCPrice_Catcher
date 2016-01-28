using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCPrice_Catcher.Trader;

namespace BCPrice_Catcher.Class
{
	public class TraderFactory
	{
		public static Trader.Trader GetTrader(string siteCode)
		{
			switch (siteCode)
			{
				case "btcc":
					return new BtccTrader();
				case "huobi":
					return new HuobiTrader();
				default:
					return null;
			}
		}
	}
}
