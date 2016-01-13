#region

using System;

#endregion

namespace BCPrice_Catcher.Model
{
	public class AccountTradeInfo
	{
		public int StrategyId { get; set; }
		public string Type { get; set; }
		public double Price { get; set; }
		public double Amount { get; set; }
		public DateTime Time { get; set; }
	}
}