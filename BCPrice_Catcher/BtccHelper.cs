using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quobject.SocketIoClientDotNet.Client;

namespace BCPrice_Catcher
{
	class BtccHelper
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


		public string GetCurrentMarket()
		{
			_socket.On("ticker", data =>
			{
				_result = data.ToString();
			});

			return _result;
		}


		public string GetCurrentTrade()
		{
			string s = "";
			_socket.On("trade", data =>
			{
				_result = data.ToString();
			});

			return _result;
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