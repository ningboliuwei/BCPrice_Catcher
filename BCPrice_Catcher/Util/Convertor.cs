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

		public static double ConvertDateTimeToJsonTimeStamp(DateTime dateTime)
		{
			return (dateTime - new DateTime(1970, 1, 1)).Milliseconds;

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

		public static Dictionary<string, string> ConvertTradeDetailToDictionary(TradeDetail tradeDetail)
		{
			if (tradeDetail != null)
			{
				return new Dictionary<string, string>()
				{
					{"Amount", tradeDetail.Amount.ToString()},
					{"Level", tradeDetail.Level.ToString()},
					{"High", tradeDetail.High.ToString()},
					{"Low", tradeDetail.Low.ToString()},
					{"New", tradeDetail.New.ToString()},
					{"Open", tradeDetail.Open.ToString()},
					{"Last", tradeDetail.Last.ToString()},
					{"Total", tradeDetail.Total.ToString()},
					{"Time", tradeDetail.Time.ToString("yyyy-MM-dd HH:mm:ss")}
				};
			}
			return new Dictionary<string, string>();
		}

	}
}
