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
	class BtccHelper : MarketHelper
	{
		private string _accessKey;
		private string _secretKey;
		private const string Url = "https://websocket.btcc.com/";
		private readonly Socket _socket = IO.Socket(Url);
		private static DateTime _dateOriginal = new DateTime(1970, 1, 1);
		private string _result = "";

		public string Usage { get; set; }

		public BtccHelper(string accessKey, string secretKey)
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
				_result = data.ToString();
			});

			if (_result.Length != 0)
			{
				JObject o = JObject.Parse(_result);

				return new TickerInfo()
				{
					Open = Convert.ToDouble(o["ticker"]["open"]),
					Vol = Convert.ToDouble(o["ticker"]["vol"]),
					Last = Convert.ToDouble(o["ticker"]["last"]),
					Sell = Convert.ToDouble(o["ticker"]["sell"]),
					High = Convert.ToDouble(o["ticker"]["high"]),
					Low = Convert.ToDouble(o["ticker"]["low"]),
					Time = Utilities.ConvertJsonDateTimeToChinaDateTime(o["ticker"]["date"].ToString())
				};
			}

			return null;
		}


		public TradeInfo GetTrade()
		{
			_socket.On("trade", data =>
			{
				_result = data.ToString();
			});

			
		}

		public string GetGroupOrder()
		{
			string s = "";
			_socket.On("grouporder", data =>
			{
				_result = data.ToString();
			});

			return _result;
		}


		public void Close()
		{
			_socket.Close();
		}

	}
}