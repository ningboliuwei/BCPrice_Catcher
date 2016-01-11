#region

using System;
using System.Threading;
using BCPrice_Catcher.Model;

#endregion

namespace BCPrice_Catcher.Class
{
	public class RealAccount : Account
	{
	public override bool Sell(int strategyId, double price, double amount)
		{
			lock (this)
			{
				if (CoinAmount >= amount)
				{
					var previousBalance = Balance;

					int orderId = Trader.Sell(price, amount, AccountCoinType);

					PlacedOrderInfo placedOrderInfo =  Trader.GetOrder(orderId, AccountCoinType);
					
					AccountTradeRecords.Add(new AccountTradeInfo
					{
						Type = "Buy",
						Price = price,
						StrategyId = strategyId + 1,
						Amount = amount,
						Time = DateTime.Now,
//						Profit = Balance - previousBalance
					});
					//if sell success
					return true;
				}
				//if fail (coin is not enough)
				return false;
			}
		}

		public override bool Buy(int strategyId, double price, double amount)
		{
			lock (this)
			{
				if (Balance >= price * amount)
				{
					var previousBalance = Balance;
					//					CoinAmount += amount;
					//					Balance -= price * amount;

					Trader.Buy(price, amount, BCPrice_Catcher.Trader.Trader.CoinType.Btc);
					AccountTradeRecords.Add(new AccountTradeInfo
					{
						Type = "Sell",
						Price = price,
						StrategyId = strategyId + 1,
						Amount = amount,
						Time = DateTime.Now,
//						Profit = Balance - previousBalance
					});

					return true;
				}
				return false;
			}
		}
	}
}