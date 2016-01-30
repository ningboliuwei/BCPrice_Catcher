#region

using System;
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

					var orderId = Trader.Sell(price, amount, AccountCoinType);

//					var placedOrderInfo = Trader.GetPlacedOrder(orderId, AccountCoinType);

					AccountTradeRecords.Add(new AccountTradeInfo
					{
						OrderId = orderId,
						Type = "Sell",
						Price = price,
						StrategyId = strategyId + 1,
						Amount = amount,
						Time = DateTime.Now
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

					var orderId = Trader.Buy(price, amount, BCPrice_Catcher.Trader.Trader.CoinType.Btc);
					AccountTradeRecords.Add(new AccountTradeInfo
					{
						OrderId = orderId,
						Type = "Buy",
						Price = price,
						StrategyId = strategyId + 1,
						Amount = amount,
						Time = DateTime.Now
//						Profit = Balance - previousBalance
					});

					return true;
				}
				return false;
			}
		}
	}
}