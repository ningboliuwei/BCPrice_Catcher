using System.Collections.Generic;
using BCPrice_Catcher.Model;

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
        public abstract string SellMarket(double amount, CoinType coinType);
        public abstract string Sell(double price, double amount, CoinType coinType);
        public abstract List<PlacedOrderInfo> GetOrders(CoinType coinType);
        public abstract string BuyMarket(double amount, CoinType coinType);
        public abstract string Buy(double price, double amount, CoinType coinType);
        public abstract string GetTransactions();
        public abstract PlacedOrderInfo GetOrder(int orderId);
//        public abstract List<PlacedOrderInfo> GetOrders();
    }
}