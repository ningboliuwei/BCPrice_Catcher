using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCPrice_Catcher.Model
{
    public class TradeInfo
    {
        public int StrategyId { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public DateTime Time { get; set; }
        public double Profit { get; set; }
    }
}