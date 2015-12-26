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
            public double DifferPrice { get; set; }
            public double BaseThreshold { get; set; }
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
        public double RealtimeTradeThreshold { get; set; }
        public double RegressionThreshold { get; set; }
        public double Range { get; set; }
        public int Countdown { get; set; }
        public int TradeCount { get; set; }

        public StrategyInputParameters InputParameters { get; set; } = new StrategyInputParameters();

        public void Update(StrategyInputParameters parameters)
        {
            if (Countdown != 0)
            {
                Countdown--;
            }
            else
            {
                Countdown = InputParameters.Peroid - 1;
            }

            InputParameters = parameters;
            RealtimeTradeThreshold = parameters.BaseThreshold * parameters.TradeThresholdCoefficient +
                                     parameters.TradeThresholdIncrement;

            if (Countdown == 0)
            {
                TradeThreshold = RealtimeTradeThreshold;
            }

            RegressionThreshold = RealtimeTradeThreshold * parameters.RegressionThresholdCoefficient +
                                  parameters.RegressionThresholdIncrement;
        }

        public void TryTrade(Dictionary<string, SimulateAccount> accounts, Dictionary<string, double> prices)
        {
            double differPrice = InputParameters.DifferPrice;

            SimulateAccount btccAccount = accounts["btcc"];
            SimulateAccount huobiAccount = accounts["huobi"];


            double btccPrice = prices["btcc"];
            double huobiPrice = prices["huobi"];

            const int tradeAmount = 10;

            bool sellSucceeded = false;
            bool buySucceeded = false;
            if (differPrice > InputParameters.StartPrice && TradeCount < InputParameters.TotalTradeCountLimit)
            {
                if (differPrice > TradeThreshold)
                {
                    if (btccPrice > huobiPrice) //btcc卖价高
                    {
                        if (btccAccount.CoinAmount != 0)
                        {
                            sellSucceeded = btccAccount.Sell(Id, btccPrice, tradeAmount); //btcc卖出
                            buySucceeded = huobiAccount.Buy(Id, huobiPrice, tradeAmount); //huobi买入
                        }
                    }
                    else //huobi卖价高
                    {
                        if (huobiAccount.CoinAmount != 0)
                        {
                            sellSucceeded = huobiAccount.Sell(Id, huobiPrice, tradeAmount); //huobi卖出
                            buySucceeded = btccAccount.Buy(Id, btccPrice, tradeAmount); //btcc买入
                        }
                    }
                }

                if (differPrice < RegressionThreshold)
                {
                    if (btccAccount.CoinAmount > huobiAccount.CoinAmount) //btcc币多
                    {
                        if (btccAccount.CoinAmount != 0)
                        {
                            sellSucceeded = btccAccount.Sell(Id, btccPrice, tradeAmount); //btcc卖出
                            buySucceeded = huobiAccount.Buy(Id, huobiPrice, tradeAmount); //huobi买入
                        }
                    }
                    else //huobi币多
                    {
                        if (huobiAccount.CoinAmount != 0)
                        {
                            sellSucceeded = huobiAccount.Sell(Id, huobiPrice, tradeAmount); //huobi卖出
                            buySucceeded = btccAccount.Buy(Id, btccPrice, tradeAmount); //btcc买入
                        }
                    }
                }

                if (sellSucceeded || buySucceeded)
                {
                    TradeCount++;
                }
            }
        }
    }
}