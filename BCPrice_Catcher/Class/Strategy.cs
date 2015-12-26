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
            public double BaseDPrice { get; set; }
            public double TradeThresholdIncrement { get; set; }
            public double TradeThresholdCoefficient { get; set; }
            public double RegressionThresholdIncrement { get; set; }
            public double RegressionThresholdCoefficient { get; set; }
            public int TradeLagThreshold { get; set; }
            public int TradeCountThreshold { get; set; }
            public int TotalTradeCountLimit { get; set; }
            public double StartPrice { get; set; }
            public int Peroid { get; set; }

        }

        public int Id { get; set; }
        public double TradeThreshold { get; set; }
        public double RegressionThreshold { get; set; }
        public double Range { get; set; }
        public int Countdown { get; set; }

        public StrategyInputParameters InputParameters { get; set; } = new StrategyInputParameters();

        public void Update(StrategyInputParameters parameters)
        {
            InputParameters = parameters;


            TradeThreshold = parameters.BaseDPrice * parameters.TradeThresholdCoefficient +
                             parameters.TradeThresholdIncrement;


            RegressionThreshold = TradeThreshold * parameters.RegressionThresholdCoefficient +
                                  parameters.RegressionThresholdIncrement;

            if (Countdown != 0)
            {
                Countdown--;
            }
            else
            {
                Countdown = InputParameters.Peroid;
            }
        }
    }
}