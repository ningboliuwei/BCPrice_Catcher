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
	internal class HuobiFetcher : Fetcher
	{
		private const string _tickerBtcCnyUrl = "http://api.huobi.com/staticmarket/ticker_btc_json.js";
		private const string _tickerLtcCnyUrl = "http://api.huobi.com/staticmarket/ticker_ltc_json.js";
		private const string _tickerBtcUsdUrl = "http://api.huobi.com/usdmarket/ticker_btc_json.js";

		private const string _tradeBtcCnyUrl = "http://api.huobi.com/staticmarket/detail_btc_json.js";
		private const string _tradeLtcCnyUrl = "http://api.huobi.com/staticmarket/detail_ltc_json.js";
		private const string _tradeBtcUsdUrl = "http://api.huobi.com/usdmarket/detail_btc_json.js";

		private const string _depthBtcCnyUrl = "http://api.huobi.com/staticmarket/depth_btc_json.js";
		private const string _depthLtcCnyUrl = "http://api.huobi.com/staticmarket/depth_ltc_json.js";
		private const string _depthBtcUsdUrl = "http://api.huobi.com/usdmarket/depth_btc_json.js";

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
						Time = Convertor.ConvertJsonDateTimeToLocalDateTime(o["time"].ToString())
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
			using (var client = new WebClient())
			{
				try
				{
					var dataText = client.DownloadString(_tradeBtcCnyUrl);


					var o = JObject.Parse(dataText);

					return new TradeDetail
					{
						Amount = Convert.ToDouble(o["amount"]),
						Level = Convert.ToDouble(o["level"]),
						High = Convert.ToDouble(o["p_high"]),
						Low = Convert.ToDouble(o["p_low"]),
						New = Convert.ToDouble(o["p_new"]),
						Open = Convert.ToDouble(o["p_open"]),
						Last = Convert.ToDouble(o["p_last"]),
						Total = Convert.ToDouble(o["total"])
					};
				}
				catch
				{
					// ignored
				}
				return null;
			}
		}

		public override List<FetchedTradeInfo> GetTrades()
		{
			using (var client = new WebClient())
			{
				try
				{
					var dataText = client.DownloadString(_tradeBtcCnyUrl);
					var o = JObject.Parse(dataText);

					return (from c in o["trades"].Children()
						select new FetchedTradeInfo
						{
							Amount = Convert.ToDouble(c["amount"]),
							Price = Convert.ToDouble(c["price"]),
							Time = c["time"].ToString(),
							Type = c["en_type"].ToString()
						}).Take(TradesCount).ToList();
				}
				catch
				{
					// ignored
				}
				return null;
			}
		}

		public override List<BookOrderInfo> GetBookOrders()
		{
			using (var client = new WebClient())
			{
				try
				{
					var dataText = client.DownloadString(_tradeBtcCnyUrl);
					var o = JObject.Parse(dataText);

					return (from c in o["top_sell"].Children()
						select new BookOrderInfo
						{
							Amount = Convert.ToDouble(c["amount"]),
							Price = Convert.ToDouble(c["price"]),
							Type = "sell"
						}).Union(from c in o["top_buy"].Children()
							select new BookOrderInfo
							{
								Amount = Convert.ToDouble(c["amount"]),
								Price = Convert.ToDouble(c["price"]),
								Type = "buy"
							}).OrderByDescending(b => b.Price).ToList();
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