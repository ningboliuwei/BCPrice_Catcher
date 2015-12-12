﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCPrice_Catcher.Model;
using BCPrice_Catcher.Util;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;

namespace BCPrice_Catcher
{
	class HuobiFetcher : PriceFetcher
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
			using (WebClient client = new WebClient())
			{
				string dataText = client.DownloadString(_tickerBtcCnyUrl);
				JObject o = JObject.Parse(dataText);

				return new TickerInfo()
				{
					Open = Convert.ToDouble(o["ticker"]["open"]),
					Vol = Convert.ToDouble(o["ticker"]["vol"]),
					Last = Convert.ToDouble(o["ticker"]["last"]),
					Buy = Convert.ToDouble(o["ticker"]["buy"]),
					Sell = Convert.ToDouble(o["ticker"]["sell"]),
					High = Convert.ToDouble(o["ticker"]["high"]),
					Low = Convert.ToDouble(o["ticker"]["low"]),
					Time = Convertor.ConvertJsonDateTimeToChinaDateTime(o["time"].ToString())
				};
			}

		}

		public override CurrentTradeInfo GetTrade()
		{

			using (WebClient client = new WebClient())
			{
				string dataText = client.DownloadString(_tradeBtcCnyUrl);
				JObject o = JObject.Parse(dataText);

				return new CurrentTradeInfo()
				{
					Amount = Convert.ToDouble(o["amount"]),
					Level = Convert.ToDouble(o["level"]),
					High = Convert.ToDouble(o["p_high"]),
					Low = Convert.ToDouble(o["p_low"]),
					New = Convert.ToDouble(o["p_new"]),
					Open = Convert.ToDouble(o["p_open"]),
					Last = Convert.ToDouble(o["p_last"]),
					Total = Convert.ToDouble(o["total"]),
				};

			}

		}

		public override List<OrderInfo> GetOrders()
		{
//			using (WebClient client = new WebClient())
//			{
//				string dataText = client.DownloadString(_tradeBtcCnyUrl);
//				if (dataText.Length != 0)
//				{
//					var o = JObject.Parse(dataText);
//
////					var q = (from c in o["grouporder"]["bid"].Children()
////												select new { Price = c["price"], TotalAmount = c["totalamount"], Type = c["type"] })
////						.Union(from c in o["grouporder"]["ask"].Children()
////							   select new { Price = c["price"], TotalAmount = c["totalamount"], Type = c["type"] }).ToList();
//				}
//
//			}
			return null;
		}
	}
}