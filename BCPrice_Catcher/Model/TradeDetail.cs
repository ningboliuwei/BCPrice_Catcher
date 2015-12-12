using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCPrice_Catcher.Model
{
	class TradeDetail
	{
		//成交量
		public double Amount { get; set; }
		//涨幅
		public double Level { get; set; }
		//最高价
		public double High { get; set; }
		//最低价
		public double Low { get; set; }
		//最新价
		public double New { get; set; }
		//开盘价
		public double Open { get; set; }
		//收盘价
		public double Last { get; set; }
		//成交总金额
		public double Total { get; set; }
		//时间
		public DateTime Time { get; set; }

	}
}
