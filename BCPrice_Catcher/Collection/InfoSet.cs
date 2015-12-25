using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCPrice_Catcher.Model;

namespace BCPrice_Catcher
{
    class InfoSet
    {
        public TickerInfo Ticker { get; set; }
        public List<TradeInfo> Trades { get; set; }
        public List<OrderInfo> Orders { get; set; }
    }
}