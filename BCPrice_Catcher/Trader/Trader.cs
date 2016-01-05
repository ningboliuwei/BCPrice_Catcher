#region

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
        public abstract List<PlacedOrderInfo> GetOrders(CoinType coinType);
        public abstract int BuyMarket(double amount, CoinType coinType);
        public abstract int Buy(double price, double amount, CoinType coinType);
        public abstract string GetTransactions();
        public abstract PlacedOrderInfo GetOrder(int orderId);
//        public abstract List<PlacedOrderInfo> GetOrders();
    }
}