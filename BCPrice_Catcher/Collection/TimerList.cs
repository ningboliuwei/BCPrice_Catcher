#region

using System.Collections.Generic;
using System.Threading;

#endregion

namespace BCPrice_Catcher
{
    internal class TimerList
    {
        public Dictionary<string, Timer> Timers { get; } = new Dictionary<string, Timer>();

        public void Add(string key, int interval, TimerCallback timerCallback)
        {
            var timer = new Timer(timerCallback, null, 0, interval);
            Timers.Add(key, timer);
        }
    }
}