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
        public List<TradeInfo> TradeRecords { get; set; } = new List<TradeInfo>();
        public Trader.Trader Trader { get; set; }


        public abstract bool Buy(int strategyId, double price, double amount);
        public abstract bool Sell(int strategyId, double price, double amount);
    }
}