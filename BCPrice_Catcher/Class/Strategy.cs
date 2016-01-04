#region

using System;
using System.Collections.Generic;

#endregion

namespace BCPrice_Catcher.Class
{
    public class Strategy
    {
        public int Id { get; set; }
        public double TradeThreshold { get; set; }
        public double RealtimeTradeThreshold { get; set; }
        public double RegressionThreshold { get; set; }
        public double Range { get; set; }
        public int TradeCount { get; set; }
        public DateTime TradeLastTime { get; set; }

        public DateTime TradeThresholdLastUpdated { get; set; } =
            Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        public Strategy PreviousStrategy { get; set; }


        public StrategyInputParameters InputParameters { get; set; } = new StrategyInputParameters();

        public void Update(StrategyInputParameters parameters)
        {
            InputParameters = parameters;
            RealtimeTradeThreshold = parameters.BaseThreshold * parameters.TradeThresholdCoefficient +
                                     parameters.TradeThresholdIncrement;

            var currentTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if ((currentTime - TradeThresholdLastUpdated).TotalSeconds >= InputParameters.Peroid)
            {
                TradeThreshold = RealtimeTradeThreshold;
                TradeThresholdLastUpdated = currentTime;
            }

            RegressionThreshold = RealtimeTradeThreshold * parameters.RegressionThresholdCoefficient +
                                  parameters.RegressionThresholdIncrement;
        }

        public void TryTrade(Dictionary<string, Account> accounts, Dictionary<string, double> prices,
            double tradeAmount)
        {
            var differPrice = InputParameters.DifferPrice;

            var btccAccount = accounts["btcc"];
            var huobiAccount = accounts["huobi"];


            var btccPrice = prices["btcc"];
            var huobiPrice = prices["huobi"];

            var sellSucceeded = false;
            var buySucceeded = false;

            var currentTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


            if (differPrice > InputParameters.StartPrice && TradeCount < InputParameters.TotalTradeCountLimit
                &&
                (Id == 0 || (PreviousStrategy?.TradeCount > PreviousStrategy?.InputParameters.TradeCountThreshold))
                &&
                (Id == 0 ||
                 (currentTime > PreviousStrategy?.TradeLastTime.AddSeconds(InputParameters.TradeLagThreshold))))
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
                TradeThresholdLastUpdated = currentTime;
            }
        }

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
            public double TradeAmount { get; set; }
        }
    }
}