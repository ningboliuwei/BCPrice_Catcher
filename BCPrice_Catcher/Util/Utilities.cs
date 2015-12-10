using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCPrice_Catcher.Util
{
	class Utilities
	{
		public static DateTime ConvertJsonDateTimeToChinaDateTime(string dateString)
		{
			string utcTimeString = new DateTime(1970, 1, 1).AddMilliseconds(Convert.ToInt64(dateString) * 1000).ToString("yyyy-MM-dd HH:mm:ss");
			DateTime chinaTime = DateTime.ParseExact(utcTimeString, "yyyy-MM-dd HH:mm:ss", new CultureInfo("zh-CN"), DateTimeStyles.AssumeUniversal);
			return chinaTime;
		}
	}
}
