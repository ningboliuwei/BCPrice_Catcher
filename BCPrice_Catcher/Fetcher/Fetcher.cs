#region

using System.Collections.Generic;
using BCPrice_Catcher.Model;

#endregion

namespace BCPrice_Catcher
{
	internal abstract class Fetcher
	{
		public static int TradesCount { get; set; } = 100;
		public static int OrdersCount { get; set; } = 100;
		public static int BookOrdersCount { get; set; } = 5;

		public abstract TickerInfo GetTicker();
		public abstract TradeDetail GetTradeDetail();
		public abstract List<FetchedTradeInfo> GetTrades();
		public abstract List<FetchedOrderInfo> GetBookOrders();
	}
}