using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCPrice_Catcher.Model;

namespace BCPrice_Catcher
{
	class TimerList
	{
		public Dictionary<string, Timer> Timers { get; } = new Dictionary<string, Timer>();

		public void Add(string key, int interval, EventHandler eventHandler)
		{
			using (System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer { Interval = interval })
			{
				timer.Tick += eventHandler;
				Timers.Add(key, timer);
			}
		}
	}
}
