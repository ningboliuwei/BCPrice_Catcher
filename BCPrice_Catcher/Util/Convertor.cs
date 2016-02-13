#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using BCPrice_Catcher.Model;

#endregion

namespace BCPrice_Catcher.Util
{
    internal class Convertor
    {
        public static DateTime ConvertJsonDateTimeToLocalDateTime(string dateString)
        {
            return
                TimeZone.CurrentTimeZone.ToLocalTime(
                    new DateTime(1970, 1, 1).AddMilliseconds(Convert.ToInt64(dateString) * 1000));
        }

        public static long ConvertDateTimeToJsonTimeStamp(DateTime time)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return Convert.ToInt64((time - startTime).TotalSeconds);
        }

        public static long ConvertDateTimeToBtccTonce(DateTime time)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return Convert.ToInt64((time - startTime).TotalMilliseconds * 1000);
        }

        public static Dictionary<string, string> ConvertTickerInfoToDictionary(TickerInfo tickerInfo)
        {
            if (tickerInfo != null)
            {
                return new Dictionary<string, string>
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
                return new Dictionary<string, string>
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

        public static string ConvertPlainTextToMd5Value(string plainText)
        {
            return
                BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(plainText)))
                    .ToLower()
                    .Replace("-", "");
        }

        public static string ConvertPlainTextToHMACSHA1Value(string secretKey, string input)
        {
            var hmacsha1 = new HMACSHA1(Encoding.ASCII.GetBytes(secretKey));
            var stream = new MemoryStream(Encoding.ASCII.GetBytes(input));
            var hashData = hmacsha1.ComputeHash(stream);
            // Format as hexadecimal string.
            var hashBuilder = new StringBuilder();
            foreach (var data in hashData)
            {
                hashBuilder.Append(data.ToString("x2"));
            }
            return hashBuilder.ToString();
        }
    }
}