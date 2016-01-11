﻿#region

using System.Collections.Generic;
using BCPrice_Catcher.Model;

#endregion

namespace BCPrice_Catcher.Class
{
    public abstract class Account
    {
        public double Balance { get; set; }
        public double CoinAmount { get; set; }
        public List<AccountTradeInfo> AccountTradeRecords { get; set; } = new List<AccountTradeInfo>();
        public Trader.Trader Trader { get; set; }
	    public readonly Trader.Trader.CoinType AccountCoinType = BCPrice_Catcher.Trader.Trader.CoinType.Btc;


        public abstract bool Buy(int strategyId, double price, double amount);
        public abstract bool Sell(int strategyId, double price, double amount);
    }
}