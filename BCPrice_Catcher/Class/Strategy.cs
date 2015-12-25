using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCPrice_Catcher.Model;

namespace BCPrice_Catcher.Class
{
	public class Strategy
	{
		public class StrategyInputParameters
		{
			public double StartupThresholdIncrement { get; set; }
			public double StartupThresholdCoefficient { get; set; }
			public int Period { get; set; }
			public double RegressionThresholdIncrement { get; set; }
			public double RegressionThresholdCoefficient { get; set; }
			public int TradeQuantityThreshold { get; set; }
		}

		public double StartupThreshold { get; set; }
		public double RegressionThreshold { get; set; }

		public StrategyInputParameters InputParameters { get; set; } = new StrategyInputParameters();
	}
}