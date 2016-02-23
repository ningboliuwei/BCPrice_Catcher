#region

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCPrice_Catcher.Model;

#endregion

namespace BCPrice_Catcher.Class
{
    public class RealAccount : Account
    {
        public override bool Sell(int strategyId, double price, double amount, string tradePairGuid, string siteCode)
        {
            //		    lock (this)
            //		    {
            if (CoinAmount >= amount)
            {
                var previousBalance = Balance;

                var orderId = Trader.Sell(price, amount, AccountCoinType);
                //				var orderId = Trader.Sell(price, amount, AccountCoinType);

                //					var placedOrderInfo = Trader.GetPlacedOrder(orderId, AccountCoinType);

                //                if (orderId == -1) return false;
                var currentTime = DateTime.Now;
                AccountTradeRecords.Add(new AccountTradeInfo
                {
                    SiteCode = siteCode,
                    TradePairGuid = tradePairGuid,
                    OrderId = orderId,
                    Type = "Sell",
                    Price = price,
                    StrategyId = strategyId + 1,
                    Amount = amount,
                    Time = currentTime
                    //						Profit = Balance - previousBalance
                });

                StringBuilder builder = new StringBuilder();
                builder.Append(siteCode)
                    .Append("sell,")
                    .Append(tradePairGuid)
                    .Append(",")
                    .Append(orderId)
                    .Append(",")
                    .Append(price)
                    .Append(",")
                    .Append(amount)
                    .Append(",")
                    .Append(currentTime).Append(":").Append(currentTime.Millisecond).Append(",").Append(Thread.CurrentThread.ManagedThreadId).Append("\n");
                WriteLog(builder.ToString());
                return true;
                //                    }
                //if sell success
                //if fail (coin is not enough)
            }
            return false;
            //		    }
        }

        private void WriteLog(string content)
        {
            string path = Application.StartupPath + "\\tradelog.txt";
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                StreamWriter writer = File.AppendText(path);
                writer.Write(content);
                writer.Close();
            }
            catch
            {
            }
        }

        public override bool Buy(int strategyId, double price, double amount, string tradePairGuid, string siteCode)
        {
            //			lock (this)
            //			{
            if (!(Balance >= price * amount)) return false;
            var previousBalance = Balance;
            //					CoinAmount += amount;
            //					Balance -= price * amount;

            var orderId =
                Task.Run(() => Trader.Buy(price, amount, BCPrice_Catcher.Trader.Trader.CoinType.Btc)).Result;

            //                var orderId = Trader.Buy(price, amount, BCPrice_Catcher.Trader.Trader.CoinType.Btc);
            //            if (orderId == -1) return false;
            var currentTime = DateTime.Now;
            AccountTradeRecords.Add(new AccountTradeInfo
            {
                SiteCode = siteCode,
                TradePairGuid = tradePairGuid,
                OrderId = orderId,
                Type = "Buy",
                Price = price,
                StrategyId = strategyId + 1,
                Amount = amount,
                Time = currentTime
                //						Profit = Balance - previousBalance
            });


            StringBuilder builder = new StringBuilder();
            builder.Append(siteCode)
                .Append("buy,")
                .Append(tradePairGuid)
                .Append(",")
                .Append(orderId)
                .Append(",")
                .Append(price)
                .Append(",")
                .Append(amount)
                .Append(",")
                .Append(currentTime).Append(":").Append(currentTime.Millisecond).Append(",").Append(Thread.CurrentThread.ManagedThreadId).Append("\n");
            WriteLog(builder.ToString());


            return true;
            //			}
        }
    }
}