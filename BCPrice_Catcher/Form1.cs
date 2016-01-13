#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCPrice_Catcher.Util;
using Newtonsoft.Json.Linq;

#endregion

namespace BCPrice_Catcher
{
	public partial class Form1 : Form
	{
		private const int FetchInterval = 500;

		private const string BtccHttpPrefix = "btc_http";
		private const string BtcSocketPrefix = "btc_socket";
		private const string HuobiPrefix = "huobi";
		private const string OkcHttpPrefix = "okc_http";
		private readonly Dictionary<string, Fetcher> _fetchers = new Dictionary<string, Fetcher>();

		private readonly Form4 _form4 = new Form4();
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
			_infoSets.Add(BtccHttpPrefix, new InfoSet());
			_infoSets.Add(HuobiPrefix, new InfoSet());

			_infoSets.Add(BtcSocketPrefix, new InfoSet());

			_infoSets.Add("okc_http", new InfoSet());

			InitializeFetchers();
		}

		private void InitializeFetchers()
		{
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

			//---------------------------------------------------------------------------

			#region 添加 btcc_http_ticker

			_fetchers.Add($"{BtccHttpPrefix}_ticker",
				new BtccHttpFetcher());

			_timerList.Add($"{BtccHttpPrefix}_ticker", FetchInterval, async o =>
			{
				var task = Task.Run(() => _fetchers[$"{BtccHttpPrefix}_ticker"].GetTicker());
				_infoSets[BtccHttpPrefix].Ticker = await task;
			});

			#endregion

			#region 添加 btcc_http_trades

			_fetchers.Add($"{BtccHttpPrefix}_trades",
				new BtccHttpFetcher());

			_timerList.Add($"{BtccHttpPrefix}_trades", FetchInterval, async o =>
			{
				var task = Task.Run(() => _fetchers[$"{BtccHttpPrefix}_trades"].GetTrades());
				_infoSets[BtccHttpPrefix].Trades = await task;
			});

			#endregion

			#region 添加 btcc_http_orders

			_fetchers.Add($"{BtccHttpPrefix}_orders",
				new BtccHttpFetcher());

			_timerList.Add($"{BtccHttpPrefix}_orders", FetchInterval, async o =>
			{
				var task = Task.Run(() => _fetchers[$"{BtccHttpPrefix}_orders"].GetOrders());
				_infoSets[BtccHttpPrefix].Orders = await task;
			});

			//---------------------------------------------------------------------------

			#region 添加 huobi_ticker

			_fetchers.Add($"{HuobiPrefix}_ticker", new HuobiFetcher());
			_timerList.Add($"{HuobiPrefix}_ticker", FetchInterval, async o =>
			{
				var task = Task.Run(() => _fetchers[$"{HuobiPrefix}_ticker"].GetTicker());
				_infoSets[HuobiPrefix].Ticker = await task;
			});

			#endregion

			#region 添加 huobi_trades

			_fetchers.Add($"{HuobiPrefix}_trades",
				new HuobiFetcher());

			_timerList.Add($"{HuobiPrefix}_trades", FetchInterval, async o =>
			{
				var task = Task.Run(() => _fetchers[$"{HuobiPrefix}_trades"].GetTrades());
				_infoSets[HuobiPrefix].Trades = await task;
			});

			#endregion

			#region 添加 huobi_orders

			_fetchers.Add($"{HuobiPrefix}_orders",
				new HuobiFetcher());

			_timerList.Add($"{HuobiPrefix}_orders", FetchInterval, async o =>
			{
				var task = Task.Run(() => _fetchers[$"{HuobiPrefix}_orders"].GetOrders());
				_infoSets[HuobiPrefix].Orders = await task;
			});

			#endregion

			#endregion

			//---------------------------------------------------------------------------

			#region 添加 okc_http_ticker

			_fetchers.Add($"{OkcHttpPrefix}_ticker",
				new OkcHttpFetcher());

			_timerList.Add($"{OkcHttpPrefix}_ticker", FetchInterval, async o =>
			{
				var task = Task.Run(() => _fetchers[$"{OkcHttpPrefix}_ticker"].GetTicker());
				_infoSets[OkcHttpPrefix].Ticker = await task;
			});

			#endregion

			#region 添加 okc_http_orders

			_fetchers.Add($"{OkcHttpPrefix}_trades",
				new OkcHttpFetcher());

			_timerList.Add($"{OkcHttpPrefix}_trades", FetchInterval, async o =>
			{
				var task = Task.Run(() => _fetchers[$"{OkcHttpPrefix}_trades"].GetTrades());
				_infoSets[OkcHttpPrefix].Trades = await task;
			});

			#endregion

			#region 添加 okc_http_orders

			_fetchers.Add($"{OkcHttpPrefix}_orders",
				new OkcHttpFetcher());

			_timerList.Add($"{OkcHttpPrefix}_orders", FetchInterval, async o =>
			{
				var task = Task.Run(() => _fetchers[$"{OkcHttpPrefix}_orders"].GetOrders());
				_infoSets[OkcHttpPrefix].Orders = await task;
			});

			#endregion

			//---------------------------------------------------------------------------

			#region 添加 btcc_socket_ticker

			_fetchers.Add($"{BtcSocketPrefix}_ticker",
				new BtccSocketFetcher());

			(_fetchers[$"{BtcSocketPrefix}_ticker"] as BtccSocketFetcher)?.Subscribe();

			_timerList.Add($"{BtcSocketPrefix}_ticker", FetchInterval, async o =>
			{
				var task = Task.Run(() => _fetchers[$"{BtcSocketPrefix}_ticker"].GetTicker());
				_infoSets[BtcSocketPrefix].Ticker = await task;
			});

			#endregion

			//---------------------------------------------------------------------------
		}

		private void ShowGroupOrdersInDataGridView(string dataText)
		{
			if (dataText.Length != 0)
			{
				try
				{
					var o = JObject.Parse(dataText);

					dgvHuobiTrades.DataSource = (from c in o["grouporder"]["bid"].Children()
						select new {Price = c["price"], TotalAmount = c["totalamount"], Type = c["type"]})
						.Union(from c in o["grouporder"]["ask"].Children()
							select new {Price = c["price"], TotalAmount = c["totalamount"], Type = c["type"]}).ToList();
				}
				catch
				{
					// ignored
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			dgvBtccTicker.DataSource =
				Convertor.ConvertTickerInfoToDictionary(_infoSets[BtccHttpPrefix].Ticker).ToList();
			dgvBtccTrades.DataSource = _infoSets[BtccHttpPrefix].Trades;
			dgvBtccOrders.DataSource = _infoSets[BtccHttpPrefix].Orders;


			dgvHuobiTicker.DataSource = Convertor.ConvertTickerInfoToDictionary(_infoSets[HuobiPrefix].Ticker).ToList();
			dgvHuobiTrades.DataSource = _infoSets[HuobiPrefix].Trades;
			dgvHuobiOrders.DataSource = _infoSets[HuobiPrefix].Orders;

			dgvOkcTicker.DataSource = Convertor.ConvertTickerInfoToDictionary(_infoSets[OkcHttpPrefix].Ticker).ToList();
			dgvOkcTrades.DataSource = _infoSets[OkcHttpPrefix].Trades;
			dgvOkcOrders.DataSource = _infoSets[OkcHttpPrefix].Orders;


			//			dgvBtccTrade.DataSource = Convertor.ConvertTradeDetailToDictionary(_infoSets["btcc"].Trade).ToList();
			//			dgvHuobiTrade.DataSource = Convertor.ConvertTradeDetailToDictionary(_infoSets["huobi"].Trade).ToList();

			SendPrice();
		}


		private void SendPrice()
		{
			var prices = new Dictionary<string, double>();
			;
			if (_infoSets[BtccHttpPrefix].Ticker != null && _infoSets[HuobiPrefix].Ticker != null)
			{
				prices.Add("btcc", _infoSets[BtccHttpPrefix].Ticker.Last);
				prices.Add("huobi", _infoSets[HuobiPrefix].Ticker.Last);
			}
			//change to send to form4
			//_form3.Tag = prices;
			_form4.Tag = prices;
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			_form4.Show();
			_form4.Activate();
		}
	}
}