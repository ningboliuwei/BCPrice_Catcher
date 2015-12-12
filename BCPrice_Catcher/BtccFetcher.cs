using System;
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
	class BtccFetcher : PriceFetcher
	{
		private string _accessKey;
		private string _secretKey;
		private const string Url = "https://websocket.btcc.com/";

		private const string _tickerBtcCnyUrl = "https://data.btcchina.com/data/ticker?market=btccny";
		private const string _tickerLtcCnyUrl = "https://data.btcchina.com/data/ticker?market=ltccny";

		private const string _tradeBtcCnyUrl = "http://api.huobi.com/staticmarket/detail_btc_json.js";
		private const string _tradeLtcCnyUrl = "http://api.huobi.com/staticmarket/detail_ltc_json.js";

		private const string _depthBtcCnyUrl = "http://api.huobi.com/staticmarket/depth_btc_json.js";
		private const string _depthLtcCnyUrl = "http://api.huobi.com/staticmarket/depth_ltc_json.js";

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
					Time = Convertor.ConvertJsonDateTimeToChinaDateTime(o["ticker"]["date"].ToString())
				};
			}

		}

		public override CurrentTradeInfo GetTrade()
		{

//			using (WebClient client = new WebClient())
//			{
//				string dataText = client.DownloadString(_tradeBtcCnyUrl);
//				JObject o = JObject.Parse(dataText);
//
//				return new CurrentTradeInfo()
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
//
//			}
			return null;

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

		//		private readonly Socket _socket = IO.Socket(Url);
		//		private static DateTime _dateOriginal = new DateTime(1970, 1, 1);
		//		private string _dataText = "";
		//
		//		public string Usage { get; set; }
		//
		//		public BtccFetcher(string accessKey, string secretKey)
		//		{
		//			_accessKey = accessKey;
		//			_secretKey = secretKey;
		//		}
		//
		//
		//		public void Subscribe()
		//		{
		//			_socket.On(Socket.EVENT_CONNECT, () =>
		//			{
		//				_socket.Emit("subscribe", "marketdata_cnybtc");
		//				_socket.Emit("subscribe", "grouporder_cnybtc");
		//			});
		//		}
		//
		//
		//		public override TickerInfo GetTicker()
		//		{
		//			_socket.On("ticker", data =>
		//			{
		//				_dataText = data.ToString();
		//			});
		//
		//			if (_dataText.Length != 0)
		//			{
		//				JObject o = JObject.Parse(_dataText);
		//
		//				return new TickerInfo()
		//				{
		//					Open = Convert.ToDouble(o["ticker"]["open"]),
		//					Vol = Convert.ToDouble(o["ticker"]["vol"]),
		//					Last = Convert.ToDouble(o["ticker"]["last"]),
		//					Sell = Convert.ToDouble(o["ticker"]["sell"]),
		//					High = Convert.ToDouble(o["ticker"]["high"]),
		//					Low = Convert.ToDouble(o["ticker"]["low"]),
		//					Time = Convertor.ConvertJsonDateTimeToChinaDateTime(o["ticker"]["date"].ToString())
		//				};
		//			}
		//
		//			return null;
		//		}
		//
		//
		//		public override CurrentTradeInfo GetTrade()
		//		{
		//			_socket.On("trade", data =>
		//			{
		//				_dataText = data.ToString();
		//			});
		//
		//			if (_dataText.Length != 0)
		//			{
		//				JObject o = JObject.Parse(_dataText);
		//
		//				return new CurrentTradeInfo()
		//				{
		//					Amount = Convert.ToDouble(o["amount"]),
		//					New = Convert.ToDouble(o["price"]),
		//					Time = Convertor.ConvertJsonDateTimeToChinaDateTime(o["date"].ToString())
		//				};
		//			}
		//			return null;
		//		}
		//
		//		public override List<OrderInfo> GetOrders()
		//		{
		//			throw new NotImplementedException();
		//		}
		//
		//		public string GetGroupOrder()
		//		{
		//			string s = "";
		//			_socket.On("grouporder", data =>
		//			{
		//				_dataText = data.ToString();
		//			});
		//
		//			return _dataText;
		//		}
		//
		//
		//		public void Close()
		//		{
		//			_socket.Close();
		//		}
		//
		//	}
	}
}