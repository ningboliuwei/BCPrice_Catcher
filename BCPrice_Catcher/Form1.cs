using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCPrice_Catcher.Util;
using Newtonsoft.Json.Linq;

namespace BCPrice_Catcher
{
	public partial class Form1 : Form
	{
		private const int FetchInterval = 250;
		private readonly Dictionary<string, PriceFetcher> _fetchers = new Dictionary<string, PriceFetcher>();
		private readonly Dictionary<string, InfoSet> _infoSets = new Dictionary<string, InfoSet>();
		private readonly TimerList _timerList = new TimerList();

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			_infoSets.Add("huobi", new InfoSet());
			_infoSets.Add("btcc_socket", new InfoSet());
			_infoSets.Add("btcc_http", new InfoSet());

			#region 添加 btcc_ticker

			//
			//			_fetchers.Add("btcc_socket_ticker",
			//				new BtccSocketFetcher("000c2d29-2e8a-4d17-b493-dc13a86543d1", "62464917-3acf-4fa1-bc02-611e0c833c68"));
			//			(_fetchers["btcc_socket_ticker"] as BtccSocketFetcher)?.Subscribe();
			//
			//			_timerList.Add("btcc_socket_ticker", FetchInterval, async o =>
			//			{
			//				var task = Task.Run(() => _fetchers["btcc_ticker"].GetTicker());
			//				_infoSets["btcc_socket"].Ticker = await task;
			//			});
			//

			#endregion

			#region 添加 btcc_http_ticker

			_fetchers.Add("btcc_http_ticker",
				new BtccHttpFetcher());

			_timerList.Add("btcc_http_ticker", FetchInterval, async o =>
			{
				var task = Task.Run(() => _fetchers["btcc_http_ticker"].GetTicker());
				_infoSets["btcc_http"].Ticker = await task;
			});

			#endregion

			#region 添加 huobi_ticker

			_fetchers.Add("huobi_ticker", new HuobiFetcher());
			_timerList.Add("huobi_ticker", FetchInterval, async o =>
			{
				var task = Task.Run(() => _fetchers["huobi_ticker"].GetTicker());
				_infoSets["huobi"].Ticker = await task;
			});

			#endregion

			//			#region 添加 huobi_trade
			//
			//			_fetchers.Add("huobi_trade", new HuobiFetcher());
			//			_timerList.Add("huobi_trade", FetchInterval, async o =>
			//			{
			//				var task = Task.Run(() => _fetchers["huobi_trade"].GetTradeDetail());
			//				_infoSets["huobi"].Trade = await task;
			//			});
			//
			//			#endregion

			//			#region 添加 btcc_trade
			//
			//			_fetchers.Add("btcc_trade",
			//				new BtccFetcher("000c2d29-2e8a-4d17-b493-dc13a86543d1", "62464917-3acf-4fa1-bc02-611e0c833c68"));
			//			(_fetchers["btcc_trade"] as BtccFetcher).Subscribe();
			//
			//			_timerList.Add("btcc_trade", FetchInterval, async o =>
			//			{
			//				var task = Task.Run(() => _fetchers["btcc_trade"].GetTradeDetail());
			//				_infoSets["btcc"].Trade = await task;
			//			});
			//
			//			#endregion

						#region 添加 huobi_trades
			
						_fetchers.Add("huobi_trades",
							new HuobiFetcher());
			
						_timerList.Add("huobi_trades", FetchInterval, async o =>
						{
							var task = Task.Run(() => _fetchers["huobi_trades"].GetTrades());
							_infoSets["huobi"].Trades = await task;
						});

			#endregion

			#region 添加 btcc_http_trades

			_fetchers.Add("btcc_http_trades",
				new HuobiFetcher());

			_timerList.Add("btcc_http_trades", FetchInterval, async o =>
			{
				var task = Task.Run(() => _fetchers["btcc_http_trades"].GetTrades());
				_infoSets["btcc_http"].Trades = await task;
			});

			#endregion
		}

		private void ShowGroupOrdersInDataGridView(string dataText)
		{
			if (dataText.Length != 0)
			{
				var o = JObject.Parse(dataText);

				dgvHuobiTrades.DataSource = (from c in o["grouporder"]["bid"].Children()
					select new {Price = c["price"], TotalAmount = c["totalamount"], Type = c["type"]})
					.Union(from c in o["grouporder"]["ask"].Children()
						select new {Price = c["price"], TotalAmount = c["totalamount"], Type = c["type"]}).ToList();
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			dgvBtccTicker.DataSource = Convertor.ConvertTickerInfoToDictionary(_infoSets["btcc_http"].Ticker).ToList();
			dgvHuobiTicker.DataSource = Convertor.ConvertTickerInfoToDictionary(_infoSets["huobi"].Ticker).ToList();
			dgvHuobiTrades.DataSource = _infoSets["huobi"].Trades;
			dgvBtccTrades.DataSource = _infoSets["btcc_http"].Trades;

			//			dgvBtccTrade.DataSource = Convertor.ConvertTradeDetailToDictionary(_infoSets["btcc"].Trade).ToList();
			//			dgvHuobiTrade.DataSource = Convertor.ConvertTradeDetailToDictionary(_infoSets["huobi"].Trade).ToList();
		}
	}
}