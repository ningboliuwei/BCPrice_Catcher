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
	class BtccSocketFetcher : PriceFetcher
	{
		private string _accessKey;
		private string _secretKey;
		private const string Url = "https://websocket.btcc.com/";
		private readonly Socket _socket = IO.Socket(Url);
		private string _dataText = "";

		public string Usage { get; set; }

		public BtccSocketFetcher(string accessKey, string secretKey)
		{
			_accessKey = accessKey;
			_secretKey = secretKey;
		}


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
			_socket.On("ticker", data =>
			{
				_dataText = data.ToString();
			});

			if (_dataText.Length != 0)
			{
				JObject o = JObject.Parse(_dataText);

				return new TickerInfo()
				{
					Open = Convert.ToDouble(o["ticker"]["open"]),
					Vol = Convert.ToDouble(o["ticker"]["vol"]),
					Last = Convert.ToDouble(o["ticker"]["last"]),
					Sell = Convert.ToDouble(o["ticker"]["sell"]),
					High = Convert.ToDouble(o["ticker"]["high"]),
					Low = Convert.ToDouble(o["ticker"]["low"]),
					Time = Convertor.ConvertJsonDateTimeToChinaDateTime(o["ticker"]["date"].ToString())
				};
			}

			return null;
		}


		public override TradeDetail GetTradeDetail()
		{
			_socket.On("trade", data =>
			{
				_dataText = data.ToString();
			});

			if (_dataText.Length != 0)
			{
				JObject o = JObject.Parse(_dataText);

				return new TradeDetail()
				{
					Amount = Convert.ToDouble(o["amount"]),
					New = Convert.ToDouble(o["price"]),
					Time = Convertor.ConvertJsonDateTimeToChinaDateTime(o["date"].ToString())
				};
			}
			return null;
		}

		public string GetGroupOrder()
		{
			_socket.On("grouporder", data =>
			{
				_dataText = data.ToString();
			});

			return _dataText;
		}


		public void Close()
		{
			_socket.Close();
		}

	}
}