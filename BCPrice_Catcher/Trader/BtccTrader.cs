using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BCPrice_Catcher.Properties;
using BCPrice_Catcher.Util;

namespace BCPrice_Catcher.Trader
{
    class BtccTrader : Trader
    {
        private string _headerContent = "application/json-rpc";
        private string postUrl = "https://api.btcc.com/api_trade_v1.php";
        private static readonly string _accessKey = Settings.Default.BtccAccessKey;
        private static readonly string _secretKey = Settings.Default.BtccSecretKey;
        private readonly WebClient _client = new WebClient();
        //for btcc trader
        private static string _tonce = Convertor.ConvertDateTimeToBtccTonce(DateTime.Now).ToString();
        //        private const string Market = "cny";
        //        private const string TradePassword = "password";

        public class BtccParasTextBuilder
        {
            public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();

            public BtccParasTextBuilder(string method)
            {
                Parameters.Add("tonce", _tonce);
                Parameters.Add("accesskey", _accessKey);
                Parameters.Add("requestmethod", "post");
                Parameters.Add("id", "1");
                Parameters.Add("method", method);
                Parameters.Add("params", "");
            }

            public string GetParasTextForHMACSHA1()
            {
                StringBuilder builder = new StringBuilder();
                foreach (var v in Parameters)
                {
                    builder.Append(v.Key).Append("=").Append(v.Value).Append("&");
                }
                //Remove the "&" at the end
                return builder.Remove(builder.Length - 1, 1).ToString();
            }

            public string GetParasTextForPost()
            {
                return "{\"method\": \"" + Parameters["method"] + "\", \"params\": [], \"id\":" + Parameters["id"] +
                       " }";
            }

            public string GetSign()
            {
                string sha1 = Convertor.ConvertPlainTextToHMACSHA1Value(_secretKey, GetParasTextForHMACSHA1());

                return Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_accessKey}:{sha1}"));
            }
        }


        public BtccTrader()
        {
            _client.Headers.Add("Content-Type", _headerContent);
            _client.Headers.Add("Json-Rpc-Tonce", _tonce);
        }

        public override string GetAccountInfo()
        {
            var builder = new BtccParasTextBuilder("getAccountInfo");

            string sha1 = builder.GetSign();

            _client.Headers.Add("Authorization", $"Basic {sha1}");
//            builder.Parameters.Add("market", Market);

            string postData = builder.GetParasTextForPost();
            return DoMethod(postData);
        }

        public override string SellMarket(double amount, CoinType coinType)
        {
            throw new NotImplementedException();
        }

        public override string Sell(double price, double amount, CoinType coinType)
        {
            throw new NotImplementedException();
        }

        public override string GetOrders(CoinType coinType)
        {
            throw new NotImplementedException();
        }

        public override string BuyMarket(double amount, CoinType coinType)
        {
            throw new NotImplementedException();
        }

        public override string Buy(double price, double amount, CoinType coinType)
        {
            throw new NotImplementedException();
        }

        private string DoMethod(string parasText)
        {
            return Encoding.UTF8.GetString(_client.UploadData(postUrl, "POST", Encoding.UTF8.GetBytes(parasText)));
        }
    }
}