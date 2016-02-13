#region

using System;
using BCPrice_Catcher.Model;

#endregion

namespace BCPrice_Catcher.Class
{
    public class SimulateAccount : Account
    {
        public override bool Sell(int strategyId, double price, double amount, string tradePairGuid, string siteCode)
        {
            lock (this)
            {
                if (CoinAmount >= amount)
                {
                    var previousBalance = Balance;
                    CoinAmount -= amount;
                    Balance += price * amount;

                    AccountTradeRecords.Add(new AccountTradeInfo
                    {
                        SiteCode = siteCode,
                        Type = "Buy",
                        Price = price,
                        StrategyId = strategyId + 1,
                        Amount = amount,
                        Time = DateTime.Now
//                        Profit = Balance - previousBalance
                    });
                    //if sell success
                    return true;
                }
                //if fail (coin is not enough)
                return false;
            }
        }

        public override bool Buy(int strategyId, double price, double amount, string tradePairGuid, string siteCode)
        {
            lock (this)
            {
                if (Balance >= price * amount)
                {
                    var previousBalance = Balance;
                    CoinAmount += amount;
                    Balance -= price * amount;
                    AccountTradeRecords.Add(new AccountTradeInfo
                    {
                        SiteCode = siteCode,
                        Type = "Sell",
                        Price = price,
                        StrategyId = strategyId + 1,
                        Amount = amount,
                        Time = DateTime.Now
//                        Profit = Balance - previousBalance
                    });

                    return true;
                }
                return false;
            }
        }
    }
}