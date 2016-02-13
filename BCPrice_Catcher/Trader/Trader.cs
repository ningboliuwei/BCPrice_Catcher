﻿#region

using System.Collections.Generic;
using BCPrice_Catcher.Model;

#endregion

namespace BCPrice_Catcher.Trader
{
    public abstract class Trader
    {
        public enum CoinType
        {
            Btc = 1,
            Ltc = 2
        }

        public abstract AccountInfo GetAccountInfo();
        public abstract int SellMarket(double amount, CoinType coinType);
        public abstract int Sell(double price, double amount, CoinType coinType);
        public abstract List<PlacedOrderInfo> GetAllPlacedOrders(CoinType coinType);
        public abstract int BuyMarket(double amount, CoinType coinType);
        public abstract int Buy(double price, double amount, CoinType coinType);
        public abstract string GetAllTransactions();
        public abstract PlacedOrderInfo GetPlacedOrder(long orderId, CoinType coinType);
        public abstract bool CancelPlacedOrder(long orderId, CoinType coinType);
//        public abstract List<PlacedOrderInfo> GetOrders();
    }
}