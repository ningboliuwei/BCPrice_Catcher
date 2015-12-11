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
using BTCChina;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace BCPrice_Catcher
{
	public partial class Form1 : Form
	{
		Dictionary<string, MarketHelper> _helpers = new Dictionary<string, MarketHelper>();

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			timer1.Enabled = true;
			timer1.Interval = 300;
			timer2.Enabled = true;
			timer2.Interval = 300;
			timer3.Enabled = true;
			timer3.Interval = 300;

			timer4.Enabled = true;
			timer4.Interval = 300;
			timer5.Enabled = true;
			timer5.Interval = 300;
			timer6.Enabled = true;
			timer6.Interval = 300;

		
			_helpers.Add("btcc_trade", new BtccHelper("000c2d29-2e8a-4d17-b493-dc13a86543d1", "62464917-3acf-4fa1-bc02-611e0c833c68"));
			_helpers.Add("btcc_ticker", new BtccHelper("000c2d29-2e8a-4d17-b493-dc13a86543d1", "62464917-3acf-4fa1-bc02-611e0c833c68"));
			_helpers.Add("btcc_orders", new BtccHelper("000c2d29-2e8a-4d17-b493-dc13a86543d1", "62464917-3acf-4fa1-bc02-611e0c833c68"));

			_helpers.Add("huobi_trade", new HuobiHelper());
			_helpers.Add("huobi_ticker", new HuobiHelper());

			//			foreach (var a in _helpers)
			//			{
			//				a.Subscribe();
			//			}
		}

		async private void timer1_Tick(object sender, EventArgs e)
		{
//			Task<TickerInfo> task = Task.Run(() => _helpers[0].GetTicker());
			ShowCurrentMarketInDataGridView(await task);
		}

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

		private void ShowCurrentMarketInDataGridView(TickerInfo tickerInfo)
		{
			List<TickerInfo> infos = new List<TickerInfo>() { tickerInfo };
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
												  t.Time
											  }).ToList();
			}
		}

		private void ShowCurrentTradeInDataGridView(string dataText)
		{
			if (dataText.Length != 0)
			{
				JObject jo = JObject.Parse(dataText);

				jo["date"] = ConvertJsonDateToDotNetDate(jo["date"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");

				Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jo.ToString());

				dgvCurrentTrade.DataSource = (from c in values
											  select new
											  {
												  c.Key,
												  c.Value
											  }).ToList();
			}
		}

		public DateTime ConvertJsonDateToDotNetDate(string dateString)
		{
			string utcTimeString = new DateTime(1970, 1, 1).AddMilliseconds(Convert.ToInt64(dateString) * 1000).ToString("yyyy-MM-dd HH:mm:ss");
			DateTime chinaTime = DateTime.ParseExact(utcTimeString, "yyyy-MM-dd HH:mm:ss", new CultureInfo("zh-CN"), DateTimeStyles.AssumeUniversal);
			return chinaTime;
		}

		private void ShowGroupOrdersInDataGridView(string dataText)
		{
			if (dataText.Length != 0)
			{
				JObject o = JObject.Parse(dataText);

				dgvGroupOrders.DataSource = ((from c in o["grouporder"]["bid"].Children()
											  select new { Price = c["price"], TotalAmount = c["totalamount"], Type = c["type"] })
					.Union(from c in o["grouporder"]["ask"].Children()
						   select new { Price = c["price"], TotalAmount = c["totalamount"], Type = c["type"] })).ToList();
			}
		}

		private void timer4_Tick(object sender, EventArgs e)
		{
			//MessageBox.Show(HuobiHelper.GetTicker());
		}
	}
}