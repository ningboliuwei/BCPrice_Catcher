using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCPrice_Catcher.Model;

namespace BCPrice_Catcher.Util
{
	class Convertor
	{
		public static DateTime ConvertJsonDateTimeToChinaDateTime(string dateString)
		{
			string utcTimeString = new DateTime(1970, 1, 1).AddMilliseconds(Convert.ToInt64(dateString) * 1000).ToString("yyyy-MM-dd HH:mm:ss");
			DateTime chinaTime = DateTime.ParseExact(utcTimeString, "yyyy-MM-dd HH:mm:ss", new CultureInfo("zh-CN"), DateTimeStyles.AssumeUniversal);
			return chinaTime;
		}

		public static Dictionary<string, string> ConvertTickerInfoToDictionary(TickerInfo tickerInfo)
		{
			if (tickerInfo != null)
			{
				return new Dictionary<string, string>()
				{
					{"Open", tickerInfo.Open.ToString()},
					{"Vol", tickerInfo.Vol.ToString()},
					{"Last", tickerInfo.Last.ToString()},
					{"Buy", tickerInfo.Buy.ToString()},
					{"Sell", tickerInfo.Sell.ToString()},
					{"High", tickerInfo.High.ToString()},
					{"Low", tickerInfo.Low.ToString()},
					{"Time", tickerInfo.Time.ToString("yyyy-MM-dd HH:mm:ss")}
				};
			}
			return new Dictionary<string, string>();
		}

		public static Dictionary<string, string> ConvertTradeInfoToDictionary(CurrentTradeInfo tradeInfo)
		{
			if (tradeInfo != null)
			{
				return new Dictionary<string, string>()
				{
					{"Amount", tradeInfo.Amount.ToString()},
					{"Level", tradeInfo.Level.ToString()},
					{"High", tradeInfo.High.ToString()},
					{"Low", tradeInfo.Low.ToString()},
					{"New", tradeInfo.New.ToString()},
					{"Open", tradeInfo.Open.ToString()},
					{"Last", tradeInfo.Last.ToString()},
					{"Total", tradeInfo.Total.ToString()},
					{"Time", tradeInfo.Time.ToString("yyyy-MM-dd HH:mm:ss")}
				};
			}
			return new Dictionary<string, string>();
		}

	}
}
