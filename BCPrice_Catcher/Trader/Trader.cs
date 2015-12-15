using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BCPrice_Catcher.Model;

namespace BCPrice_Catcher.Trader
{
	abstract class Trader
	{
		public enum CoinType
		{
			Btc = 1,
			Ltc = 2
		}

		public abstract string GetAccountInfo();
		public abstract string SellMarket(double amount, CoinType coinType);
		public abstract string GetOrders(CoinType coinType);
		public abstract string BuyMarket(double amount, CoinType coinType);
	}
}
