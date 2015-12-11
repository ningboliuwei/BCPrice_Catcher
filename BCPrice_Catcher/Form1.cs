using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCPrice_Catcher.Model;
using BCPrice_Catcher.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Timer = System.Threading.Timer;


namespace BCPrice_Catcher
{
	public partial class Form1 : Form
	{
		private Dictionary<string, MarketHelper> _helpers = new Dictionary<string, MarketHelper>();
		private TimerList _timerList = new TimerList();

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			_helpers.Add("btcc_orders",
				new BtccHelper("000c2d29-2e8a-4d17-b493-dc13a86543d1", "62464917-3acf-4fa1-bc02-611e0c833c68"));

//			#region 添加 huobi_ticker
//
//			_helpers.Add("huobi_ticker", new HuobiHelper());
//
//			_timerList.Add(
//				"huobi_ticker",
//				300,
//				async (a, b) =>
//				{
//					Task<TickerInfo> task = Task.Run(() => _helpers["huobi_ticker"].GetTicker());
//					dgvHuobiTicker.DataSource = Convertor.ConvertTickerInfoToDictionary(await task).ToList();
//				}
//				);
//
//			#endregion

			#region 添加 btcc_ticker

			_helpers.Add("btcc_ticker",
				new BtccHelper("000c2d29-2e8a-4d17-b493-dc13a86543d1", "62464917-3acf-4fa1-bc02-611e0c833c68"));
			(_helpers["btcc_ticker"] as BtccHelper).Subscribe();

			_timerList.Add(
				"btcc_ticker",
				1000,
				async (a, b) =>
				{
					Task<TickerInfo> task = Task.Run(() => _helpers["btcc_ticker"].GetTicker());
					dgvBtccTicker.DataSource = Convertor.ConvertTickerInfoToDictionary(await task).ToList();
				}
				);

			#endregion

//			#region 添加 huobi_trade
//
//			_helpers.Add("huobi_trade",
//				new HuobiHelper());
//
//			_timerList.Add(
//				"huobi_trade",
//				1000,
//				async (a, b) =>
//				{
//					Task<TradeInfo> task = Task.Run(() => _helpers["huobi_trade"].GetTrade());
//					dgvHuobiTrade.DataSource = Convertor.ConvertTradeInfoToDictionary(await task).ToList();
//				}
//				);
//
//			#endregion

			#region 添加 btcc_trade

			_helpers.Add("btcc_trade",
				new BtccHelper("000c2d29-2e8a-4d17-b493-dc13a86543d1", "62464917-3acf-4fa1-bc02-611e0c833c68"));
			(_helpers["btcc_trade"] as BtccHelper).Subscribe();

			_timerList.Add(
				"btcc_trade",
				1000,
				async (a, b) =>
				{
					Task<TradeInfo> task = Task.Run(() => _helpers["btcc_trade"].GetTrade());
					dgvBtccTrade.DataSource = Convertor.ConvertTradeInfoToDictionary(await task).ToList();
				}
				);

			#endregion

			foreach (var v in _timerList.Timers)
			{
				v.Value.Start();
			}
		}

		//		async private void timer_Tick(object sender, EventArgs e)
		//		{
		//			//					ShowCurrentMarketInDataGridView(await task);
		//			//					Task<TickerInfo> task = Task.Run(() => _helpers[0].GetTicker(););
		//		}


		//		private void LoopShowTicker()
		//		{
		//			Timer timer = new Timer(TimerCallback,null,1000,50000);
		//			timer.Dispose();
		//		}

		async private void timer2_Tick(object sender, EventArgs e)
		{
			//			Task<TradeInfo> task = Task.Run(() => _helpers[1].GetTrade());
			//			ShowCurrentTradeInDataGridView(await task);
		}

		async private void timer3_Tick(object sender, EventArgs e)
		{
			//			Task<string> task = Task.Run(() => _helpers[2].GetGroupOrder());
			//			ShowGroupOrdersInDataGridView(await task);
		}

		private void ShowTickerInfoInDataGridView(TickerInfo tickerInfo)
		{
			List<TickerInfo> infos = new List<TickerInfo>() {tickerInfo};
			//			if (dataText.Length != 0)
			//			{
			//				JObject o = JObject.Parse(dataText);
			//				Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(o["ticker"].ToString());
			//
			//				dgvCurrentMarket.DataSource = (from c in values
			//					select new
			//					{
			//						c.Key,
			//						c.Value
			//					}).ToList();
			//			}
			if (tickerInfo != null)
			{
				dgvCurrentMarket.DataSource = (from t in infos
					select new
					{
						t.Open,
						t.High,
						Time = t.Time.ToString("yyyy-MM-dd HH:mm:ss")
					}).ToList();
			}
		}

		private void ShowCurrentTradeInDataGridView(string dataText)
		{
			if (dataText.Length != 0)
			{
				JObject jo = JObject.Parse(dataText);

				jo["date"] = Convertor.ConvertJsonDateTimeToChinaDateTime(jo["date"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");

				Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jo.ToString());

				dgvBtccTicker.DataSource = (from c in values
					select new
					{
						c.Key,
						c.Value
					}).ToList();
			}
		}

		private void ShowGroupOrdersInDataGridView(string dataText)
		{
			if (dataText.Length != 0)
			{
				JObject o = JObject.Parse(dataText);

				dgvHuobiTrade.DataSource = ((from c in o["grouporder"]["bid"].Children()
					select new {Price = c["price"], TotalAmount = c["totalamount"], Type = c["type"]})
					.Union(from c in o["grouporder"]["ask"].Children()
						select new {Price = c["price"], TotalAmount = c["totalamount"], Type = c["type"]})).ToList();
			}
		}

		private void timer4_Tick(object sender, EventArgs e)
		{
			//MessageBox.Show(HuobiHelper.GetTicker());
		}

		private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}
	}
}