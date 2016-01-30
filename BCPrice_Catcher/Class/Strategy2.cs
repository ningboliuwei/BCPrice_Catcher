using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCPrice_Catcher.Model;

namespace BCPrice_Catcher.Class
{
	class Strategy2
	{
		public double m { get; set; }
		public double A { get; set; }
		public double B { get; set; }
		public double X { get; set; }
		public double Y { get; set; }
		public double Differ { get; set; }

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
				double C = qC.Count() != 0 ? qC.First() : 0;


				var qD = from b in parameters.BuyBookOrders
					where b.Price == B
					select b.Amount;
				double D = qD.Count() != 0 ? qD.First() : 0;

				var values = new List<double>();
				values.Add(C);
				values.Add(D);
				values.Add(parameters.OutSiteAmount);
				values.Add(parameters.InSiteAmount);
				m = values.Min();

				//sell the last little coins
				if (InputParameters.InSiteAmount < InputParameters.Min)
				{
					m = InputParameters.InSiteAmount;
				}
			}
		}

		public void TryTrade(Dictionary<string, Account> accounts, Dictionary<string, double> prices,
			double tradeAmount, string outSiteCode, string inSiteCode)
		{
			//ensure the > Min price exists
			if (MatchTradeCondition())
			{
				accounts[outSiteCode].Sell(-1, prices[outSiteCode] + InputParameters.a, tradeAmount);
				accounts[inSiteCode].Buy(-1, prices[inSiteCode] + InputParameters.b, tradeAmount);
			}
		}

		public bool MatchTradeCondition()
		{
			//&& InputParameters.SiteBAmount >= m
			return Differ > InputParameters.Z && A != 0 && B != 0 && InputParameters.OutSiteAmount >= m && m != 0;
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
		}
	}
}