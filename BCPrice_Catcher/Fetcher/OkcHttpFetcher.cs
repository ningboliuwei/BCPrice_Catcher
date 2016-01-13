#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BCPrice_Catcher.Model;
using BCPrice_Catcher.Util;
using Newtonsoft.Json.Linq;

#endregion

namespace BCPrice_Catcher
{
	internal class OkcHttpFetcher : Fetcher
	{
		private const string _tickerBtcCnyUrl = "https://www.okcoin.cn/api/v1/ticker.do?symbol=btc_cny";
//        private const string _tickerLtcCnyUrl = "https://www.okcoin.cn/api/v1/ticker.do?symbol=ltc_cny";

		private readonly string _ordersBtcCnyUrl = "https://www.okcoin.cn/api/v1/depth.do?symbol=btc_cny";
//        private readonly string _ordersLtcCnyUrl = "https://www.okcoin.cn/api/v1/depth.do?symbol=ltc_cny";

		private readonly string _tradesBtcCnyUrl = "https://www.okcoin.cn/api/v1/trades.do?symbol=btc_cny";
//        private readonly string _tradesLtcCnyUrl = "https://www.okcoin.cn/api/v1/trades.do?symbol=ltc_cny";

		public static int TradesCount { get; set; } = 100;
		public static int OrdersCount { get; set; } = 100;

		public override TickerInfo GetTicker()
		{
			using (var client = new WebClient())
			{
				try
				{
					var dataText = client.DownloadString(_tickerBtcCnyUrl);
					var o = JObject.Parse(dataText);

					return new TickerInfo
					{
						Open = -1,
						Vol = Convert.ToDouble(o["ticker"]["vol"]),
						Last = Convert.ToDouble(o["ticker"]["last"]),
						Buy = Convert.ToDouble(o["ticker"]["buy"]),
						Sell = Convert.ToDouble(o["ticker"]["sell"]),
						High = Convert.ToDouble(o["ticker"]["high"]),
						Low = Convert.ToDouble(o["ticker"]["low"]),
						Time = Convertor.ConvertJsonDateTimeToLocalDateTime(o["date"].ToString())
					};
				}
				catch
				{
					// ignored
				}
				return null;
			}
		}

		public override TradeDetail GetTradeDetail()
		{
			//			using (WebClient client = new WebClient())
			//			{
			//				string dataText = client.DownloadString(_tradeBtcCnyUrl);
			//				JObject o = JObject.Parse(dataText);
			//
			//				return new TradeDetail()
			//				{
			//					Amount = Convert.ToDouble(o["amount"]),
			//					Level = Convert.ToDouble(o["level"]),
			//					High = Convert.ToDouble(o["p_high"]),
			//					Low = Convert.ToDouble(o["p_low"]),
			//					New = Convert.ToDouble(o["p_new"]),
			//					Open = Convert.ToDouble(o["p_open"]),
			//					Last = Convert.ToDouble(o["p_last"]),
			//					Total = Convert.ToDouble(o["total"]),
			//				};
			//			}
			return null;
		}

		public override List<FetchedTradeInfo> GetTrades()
		{
			using (var client = new WebClient())
			{
				try
				{
					var dataText = client.DownloadString(_tradesBtcCnyUrl);
					var o = JObject.Parse("{trades:" + dataText + "}");

					return (from c in o["trades"].Children()
						select new FetchedTradeInfo
						{
							Amount = Convert.ToDouble(c["amount"]),
							Price = Convert.ToDouble(c["price"]),
							Time =
								Convertor.ConvertJsonDateTimeToLocalDateTime(c["date"].ToString()).ToString("HH:mm:ss"),
							Type = c["type"].ToString()
						}).Take(TradesCount).ToList();
				}
				catch
				{
					// ignored
				}
				return null;
			}
		}

		public override List<FetchedOrderInfo> GetOrders()
		{
			using (var client = new WebClient())
			{
				try
				{
					var dataText = client.DownloadString(_ordersBtcCnyUrl);
					var o = JObject.Parse(dataText);

					return (from c in o["asks"].Children().Take(5)
						select new FetchedOrderInfo
						{
							Amount = Convert.ToDouble(c[1]),
							Price = Convert.ToDouble(c[0]),
							Type = "sell"
						}).Union(from c in o["bids"].Children().Take(5)
							select new FetchedOrderInfo
							{
								Amount = Convert.ToDouble(c[1]),
								Price = Convert.ToDouble(c[0]),
								Type = "buy"
							}).ToList();
				}
				catch
				{
					// ignored
				}
				return null;
			}
		}
	}
}