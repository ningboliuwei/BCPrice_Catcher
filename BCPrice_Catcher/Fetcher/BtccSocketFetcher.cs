#region

using System;
using System.Collections.Generic;
using BCPrice_Catcher.Model;
using BCPrice_Catcher.Properties;
using BCPrice_Catcher.Util;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;

#endregion

namespace BCPrice_Catcher
{
	internal class BtccSocketFetcher : Fetcher
	{
		private const string Url = "https://websocket.btcc.com/";
		private readonly Socket _socket = IO.Socket(Url);

		private readonly string BtcSocketAccessKey = Settings.Default.BtccAccessKey;
		private readonly string BtcSocketSecretKey = Settings.Default.BtccSecretKey;
		private string _dataText = "";


		public string Usage { get; set; }


		public void Subscribe()
		{
			_socket.On(Socket.EVENT_CONNECT, () =>
			{
				_socket.Emit("subscribe", "marketdata_cnybtc");
				_socket.Emit("subscribe", "grouporder_cnybtc");
			});
		}


		public override TickerInfo GetTicker()
		{
			_socket.On("ticker", data => { _dataText = data.ToString(); });

			if (_dataText.Length != 0)
			{
				try
				{
					var o = JObject.Parse(_dataText);

					return new TickerInfo
					{
						Open = Convert.ToDouble(o["ticker"]["open"]),
						Vol = Convert.ToDouble(o["ticker"]["vol"]),
						Last = Convert.ToDouble(o["ticker"]["last"]),
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
			}

			return null;
		}


		public override TradeDetail GetTradeDetail()
		{
			_socket.On("trade", data => { _dataText = data.ToString(); });

			if (_dataText.Length != 0)
			{
				try
				{
					var o = JObject.Parse(_dataText);

					return new TradeDetail
					{
						Amount = Convert.ToDouble(o["amount"]),
						New = Convert.ToDouble(o["price"]),
						Time = Convertor.ConvertJsonDateTimeToLocalDateTime(o["date"].ToString())
					};
				}
				catch
				{
					// ignored
				}
			}
			return null;
		}

		public override List<FetchedTradeInfo> GetTrades()
		{
			throw new NotImplementedException();
		}

		public override List<FetchedOrderInfo> GetOrders()
		{
			throw new NotImplementedException();
		}

		public string GetGroupOrder()
		{
			_socket.On("grouporder", data => { _dataText = data.ToString(); });

			return _dataText;
		}


		public void Close()
		{
			_socket.Close();
		}
	}
}