using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BCPrice_Catcher.Model;

namespace BCPrice_Catcher.Trader
{
	abstract class Trader
	{

		public abstract string GetAccountInfo();
	}
}
