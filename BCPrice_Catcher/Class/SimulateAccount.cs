using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCPrice_Catcher.Model;

namespace BCPrice_Catcher.Class
{
    public class SimulateAccount
    {
        public double Balance { get; set; }
        public double CoinAmount { get; set; }

        public List<SimulateTradeInfo> Trades { get; set; } = new List<SimulateTradeInfo>();

        public bool Sell(int strategyId, double price, double amount)
        {
            lock (this)
            {
                if (CoinAmount >= amount)
                {
                    double previousBalance = Balance;
                    CoinAmount -= amount;
                    Balance += price * amount;

                    Trades.Add(new SimulateTradeInfo
                    {
                        Type = "Buy",
                        Price = price,
                        StrategyId = strategyId + 1,
                        Amount = amount,
                        Time = DateTime.Now,
                        Profit = Balance - previousBalance
                    });
                    //if sell success
                    return true;
                }
                //if fail (coin is not enough)
                return false;
            }
        }

        public bool Buy(int strategyId, double price, double amount)
        {
            lock (this)
            {
                if (Balance >= price * amount)
                {
                    double previousBalance = Balance;
                    CoinAmount += amount;
                    Balance -= price * amount;
                    Trades.Add(new SimulateTradeInfo
                    {
                        Type = "Sell",
                        Price = price,
                        StrategyId = strategyId + 1,
                        Amount = amount,
                        Time = DateTime.Now,
                        Profit = Balance - previousBalance
                    });

                    return true;
                }
                return false;
            }
        }
    }
}