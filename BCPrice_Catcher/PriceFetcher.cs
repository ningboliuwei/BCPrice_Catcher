﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCPrice_Catcher.Model;

namespace BCPrice_Catcher
{
	abstract class PriceFetcher
	{
		public abstract TickerInfo GetTicker();
		public abstract TradeInfo GetTrade();
	}
}