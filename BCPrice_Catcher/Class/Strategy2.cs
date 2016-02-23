using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BCPrice_Catcher.Model;

namespace BCPrice_Catcher.Class
{
	internal class Strategy2
	{
		private static readonly object ThreadLock = new object();
		private static bool _trading = false;

		public double m { get; private set; }
		public double A { get; private set; }
		public double B { get; private set; }
		public double X { get; private set; }
		public double Y { get; private set; }
		public double Differ { get; private set; }
		public DateTime LastTradeTime { get; set; } = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


		public StrategyInputParameters InputParameters { get; set; } = new StrategyInputParameters();

		public void Update(StrategyInputParameters parameters)
		{
			InputParameters = parameters;

			if (parameters.SellBookOrders != null && parameters.BuyBookOrders != null)
			{
				var qA = from s in parameters.SellBookOrders
						 where s.Amount > InputParameters.Min
						 select s.Price;
				A = qA.Count() != 0 ? qA.Min() : 0;

				var qB = from s in parameters.BuyBookOrders
						 where s.Amount > InputParameters.Min
						 select s.Price;
				B = qB.Count() != 0 ? qB.Max() : 0;

				X = A;
				Y = B;
				Differ = X - Y;

				var qC = from s in parameters.SellBookOrders
						 where s.Price == A
						 select s.Amount;
				var C = qC.Count() != 0 ? qC.First() : 0;


				var qD = from b in parameters.BuyBookOrders
						 where b.Price == B
						 select b.Amount;
				var D = qD.Count() != 0 ? qD.First() : 0;

				var values = new List<double>();
				values.Add(C);
				values.Add(D);
				values.Add(parameters.OutSiteAmount);
				m = values.Min();

				//sell the last little coins
				if (InputParameters.OutSiteAmount < InputParameters.Min)
				{
					m = InputParameters.OutSiteAmount;
				}
			}
		}

		public void TryTrade(Dictionary<string, Account> accounts, Dictionary<string, double> prices,
			double tradeAmount, string outSiteCode, string inSiteCode)
		{
			lock (ThreadLock)
			{

				var currentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
				//ensure the > Min price exists
				if (MatchTradeCondition(currentTime))
				{

					//                lock (ThreadLock)
					//                {
					if (accounts[outSiteCode].Trader != null && accounts[inSiteCode].Trader != null)
					{
						_trading = true;
						var guid = Guid.NewGuid().ToString();

						accounts[outSiteCode].Sell(-1, prices[outSiteCode] + InputParameters.a, tradeAmount, guid,
							outSiteCode);
						//                    Thread.Sleep(1000);
						accounts[inSiteCode].Buy(-1, prices[inSiteCode] + InputParameters.b, tradeAmount, guid, inSiteCode);
						//                }
						LastTradeTime = currentTime;
						//                    Thread.Sleep(1000);
						_trading = false;
					}
				}

			}
		}

		public bool MatchTradeCondition(DateTime currentTime)
		{
			//&& InputParameters.SiteBAmount >= m
			return Differ > InputParameters.Z && A != 0 && B != 0 && InputParameters.OutSiteAmount >= m && m != 0 &&
				   (currentTime - LastTradeTime).TotalSeconds >= InputParameters.Peroid && !_trading;
		}

		public class StrategyInputParameters
		{
			public double Min { get; set; }
			public double a { get; set; }
			public double b { get; set; }
			public double Z { get; set; }
			public double OutSiteAmount { get; set; }
			public double InSiteAmount { get; set; }
			public List<BookOrderInfo> BuyBookOrders { get; set; }
			public List<BookOrderInfo> SellBookOrders { get; set; }
			public int Peroid { get; set; }
			public int AutoCancelLag { get; set; }
			public int AutoBuyLag { get; set; }
			public int AutoBuyBalancePercentage { get; set; }
			public double SingleTradeCoinLimit { get; set; }

		}
	}
}