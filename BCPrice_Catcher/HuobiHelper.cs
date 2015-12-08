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
	class HuobiHelper
	{
		private const string _tickerBtcCnyUrl = "http://api.huobi.com/staticmarket/ticker_btc_json.js";
		private const string _tickerLtcCnyTickerUrl = "http://api.huobi.com/staticmarket/ticker_ltc_json.js";
		private const string _tickerBtcUsdUrl = "http://api.huobi.com/usdmarket/ticker_btc_json.js";
		private const string _depthBtcCnyUrl = "http://api.huobi.com/staticmarket/depth_btc_json.js";
		private const string _depthLtcCnyUrl = "http://api.huobi.com/staticmarket/depth_ltc_json.js";
		private const string _depthBtcUsdUrl = "http://api.huobi.com/usdmarket/depth_btc_json.js";

		public static string GetCurrentMarket()
		{
			using (WebClient client = new WebClient())
			{
				return client.DownloadString(_tickerBtcCnyUrl);
			}
		}

	}
}