using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BCPrice_Catcher.Model;

namespace BCPrice_Catcher
{
	class TimerList
	{
		public Dictionary<string, Timer> Timers { get; } = new Dictionary<string, Timer>();

		public void Add(string key, int interval, TimerCallback timerCallback)
		{
			Timer timer = new Timer(timerCallback, null, 0, interval);
			Timers.Add(key, timer);
		}
	}
}
