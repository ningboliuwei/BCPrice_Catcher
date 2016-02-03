#region

using System.Collections.Generic;
using BCPrice_Catcher.Model;

#endregion

namespace BCPrice_Catcher.Class
{
	public abstract class Account
	{
		public readonly Trader.Trader.CoinType AccountCoinType = BCPrice_Catcher.Trader.Trader.CoinType.Btc;
		public double Balance { get; set; }
		public double CoinAmount { get; set; }
		public List<AccountTradeInfo> AccountTradeRecords { get; set; } = new List<AccountTradeInfo>();
		public List<PlacedOrderInfo> RealPlacedOrders { get; set; } = new List<PlacedOrderInfo>();
		public Trader.Trader Trader { get; set; }

		public abstract bool Buy(int strategyId, double price, double amount, string tradePairGuid, string siteCode);
		public abstract bool Sell(int strategyId, double price, double amount, string tradePairGuid, string siteCode);
	}
}