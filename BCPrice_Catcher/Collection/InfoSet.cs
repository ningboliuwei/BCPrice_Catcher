#region

using System.Collections.Generic;
using BCPrice_Catcher.Model;

#endregion

namespace BCPrice_Catcher
{
    internal class InfoSet
    {
        public TickerInfo Ticker { get; set; }
        public List<FetchedTradeInfo> Trades { get; set; }
        public List<FetchedOrderInfo> Orders { get; set; }
    }
}