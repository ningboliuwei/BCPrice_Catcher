#region

using System;

#endregion

namespace BCPrice_Catcher.Model
{
    public enum OrderType
    {
        Bid,
        Ask
    }

    public enum OrderStatus
    {
        Open,
        Closed,
        Cancelled,
        Pending,
        Error
    }

    public class PlacedOrderInfo
    {
        public int Id { get; set; }
        public OrderType Type { get; set; }
        public double Price { get; set; }
        public double AmountProcessed { get; set; }
        public double AmountOriginal { get; set; }
        public DateTime Time { get; set; }
        public OrderStatus Status { get; set; }
    }
}