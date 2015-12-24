using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCPrice_Catcher.Model
{
    class StrategyInfo
    {
        public double DifferPrice { get; set; }
        public double DifferPriceIncrement { get; set; }
        public double DifferPriceCoefficient { get; set; }
        public int Peroid { get; set; }
        public double DefaultRegressionPrice { get; set; }
        public double RegressionPriceIncreament { get; set; }
        public double RegressionPriceCoefficient { get; set; }
        public int TradeQuantityLimit { get; set; }
    }
}
