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

        public void Sell(int strategyId, double price, double amount)
        {
            if (CoinAmount >= amount)
            {
                CoinAmount -= amount;
                Balance += price * amount;

                Trades.Add(new SimulateTradeInfo
                {
                    Type = "Buy",
                    Price = price,
                    StrategyId = strategyId,
                    Amount = amount,
                    Time = DateTime.Now
                });
//                textbox.Text = textbox.Text.Insert(0,
//                    Environment.NewLine + $"卖 {amount} 币 at {price} with 总价 {price * amount}");
            }
        }

        public void Buy(int strategyId, double price, double amount)
        {
            if (Balance >= price * amount)
            {
                CoinAmount += amount;
                Balance -= price * amount;
                //                textbox.Text = textbox.Text.Insert(0,
                //                    Environment.NewLine + $"买 {amount} 币 at {price} with 总价 {price * amount}");
                Trades.Add(new SimulateTradeInfo
                {
                    Type = "Sell",
                    Price = price,
                    StrategyId = strategyId,
                    Amount = amount,
                    Time = DateTime.Now
                });
            }
        }
    }
}