#region

using System.Collections.Generic;
using BCPrice_Catcher.Model;

#endregion

namespace BCPrice_Catcher
{
	internal abstract class Fetcher
	{
		public abstract TickerInfo GetTicker();
		public abstract TradeDetail GetTradeDetail();
		public abstract List<FetchedTradeInfo> GetTrades();
		public abstract List<FetchedOrderInfo> GetOrders();
	}
}