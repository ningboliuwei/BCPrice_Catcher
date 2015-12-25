using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCPrice_Catcher.Model
{
	class StrategyParas
	{
		public double StartupThreshold { get; set; }
		public double RegressionThreshold { get; set; }
		public double StartupThresholdIncrement { get; set; }
		public double StartupThresholdCoefficient { get; set; }
		public int Period { get; set; }
		public double RegressionThresholdIncrement { get; set; }
		public double RegressionThresholdCoefficient { get; set; }
		public int TradeQuantityThreshold { get; set; }
	}
}