using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCPrice_Catcher.Model
{
	class TickerInfo
	{
		public double Open { get; set; }
		public double Vol { get; set; }
		public double Last { get; set; }
		public double Buy { get; set; }
		public double Sell { get; set; }
		public double High { get; set; }
		public double Low { get; set; }
		public DateTime Time { get; set; }
	}
}
