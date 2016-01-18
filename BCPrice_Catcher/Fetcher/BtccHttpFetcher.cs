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
	internal class BtccHttpFetcher : Fetcher
	{
		private const string _tickerBtcCnyUrl = "https://data.btcchina.com/data/ticker?market=btccny";
		private const string _tickerLtcCnyUrl = "https://data.btcchina.com/data/ticker?market=ltccny";

		private readonly string _ordersUrl = $"https://data.btcchina.com/data/orderbook?limit={OrdersCount}";

		private readonly string _tradesUrl = $"https://data.btcchina.com/data/historydata?limit={TradesCount}";


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
						Open = Convert.ToDouble(o["ticker"]["open"]),
						Vol = Convert.ToDouble(o["ticker"]["vol"]),
						Last = Convert.ToDouble(o["ticker"]["last"]),
						Buy = Convert.ToDouble(o["ticker"]["buy"]),
						Sell = Convert.ToDouble(o["ticker"]["sell"]),
						High = Convert.ToDouble(o["ticker"]["high"]),
						Low = Convert.ToDouble(o["ticker"]["low"]),
						Time = Convertor.ConvertJsonDateTimeToLocalDateTime(o["ticker"]["date"].ToString())
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
				var dataText = client.DownloadString(_tradesUrl);
				//to become an object for parsing
				try
				{
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

		public override List<FetchedOrderInfo> GetBookOrders()
		{
			using (var client = new WebClient())
			{
				var dataText = client.DownloadString(_ordersUrl);
				try
				{
					var o = JObject.Parse(dataText);

					return (from c in o["asks"].Children().Take(BookOrdersCount)
						select new FetchedOrderInfo
						{
							Amount = Convert.ToDouble(c[1]),
							Price = Convert.ToDouble(c[0]),
							Type = "sell"
						}).Union(from c in o["bids"].Children().Take(BookOrdersCount)
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