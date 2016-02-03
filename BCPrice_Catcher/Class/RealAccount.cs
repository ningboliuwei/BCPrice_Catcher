﻿#region

using System;
using System.Threading.Tasks;
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

				var orderId= Task.Run(() => Trader.Sell(price, amount, AccountCoinType)).Result;

//					var placedOrderInfo = Trader.GetPlacedOrder(orderId, AccountCoinType);

				if (orderId != -1)
				{
					AccountTradeRecords.Add(new AccountTradeInfo
					{
						SiteCode = siteCode,
						TradePairGuid = tradePairGuid,
						OrderId = orderId,
						Type = "Sell",
						Price = price,
						StrategyId = strategyId + 1,
						Amount = amount,
						Time = DateTime.Now
//						Profit = Balance - previousBalance
					});
					return true;
//                    }
					//if sell success
				}
				//if fail (coin is not enough)
			}
			return false;
			//		    }
		}

		public override bool Buy(int strategyId, double price, double amount, string tradePairGuid, string siteCode)
		{
//			lock (this)
//			{
			if (Balance >= price * amount)
			{
				var previousBalance = Balance;
				//					CoinAmount += amount;
				//					Balance -= price * amount;

				var orderId = Task.Run(() => Trader.Buy(price, amount, BCPrice_Catcher.Trader.Trader.CoinType.Btc)).Result;
				if (orderId != -1)
				{
					AccountTradeRecords.Add(new AccountTradeInfo
					{
						SiteCode = siteCode,
						TradePairGuid = tradePairGuid,
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
			}
			return false;
//			}
		}
	}
}