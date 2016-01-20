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
		public double differ { get; set; }

		public StrategyInputParameters InputParameters { get; set; } = new StrategyInputParameters();

		public void Update(StrategyInputParameters parameters)
		{
			InputParameters = parameters;

			A = (from s in parameters.SellBookOrders
				where s.Amount > InputParameters.Min
				select s.Price).Min();

			B = (from s in parameters.BuyBookOrders
				where s.Amount > InputParameters.Min
				select s.Price).Max();

			X = A + parameters.a;
			Y = B + parameters.b;
			differ = X - Y;

			double C = (from s in parameters.SellBookOrders
				where s.Price == A
				select s.Amount).First();

			double D = (from b in parameters.BuyBookOrders
						where b.Price == B
						select b.Amount).First();

			var values = new List<double>();
			values.Add(C);
			values.Add(D);
			values.Add(parameters.SiteAAmount);
			values.Add(parameters.SiteBAmount);
			m = values.Min();
		}


		public class StrategyInputParameters
		{
			public double Min { get; set; }
			public double a { get; set; }
			public double b { get; set; }
			public double Z { get; set; }
			public double SiteAAmount { get; set; }
			public double SiteBAmount { get; set; }
			public List<BookOrderInfo> BuyBookOrders { get; set; }
			public List<BookOrderInfo> SellBookOrders { get; set; }
		}
	}
}