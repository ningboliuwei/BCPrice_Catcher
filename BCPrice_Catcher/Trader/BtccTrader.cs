using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCPrice_Catcher.Model;
using BCPrice_Catcher.Properties;
using BCPrice_Catcher.Util;
using Newtonsoft.Json.Linq;

namespace BCPrice_Catcher.Trader
{
    class BtccTrader : Trader
    {
        enum BtccCoinType
        {
            LTCBTC,
            BTCCNY,
            LTCCNY
        }

        private string _headerContent = "application/json-rpc";
        private string postUrl = "https://api.btcc.com/api_trade_v1.php";
        private static readonly string _accessKey = Settings.Default.BtccAccessKey;
        private static readonly string _secretKey = Settings.Default.BtccSecretKey;
        private readonly WebClient _client = new WebClient();
        public BtccParasTextBuilder Builder;
        private const string ErrorMessageHead = "\"error\"";
        //for btcc trader

        //        private const string Market = "cny";
        //        private const string TradePassword = "password";

        public class BtccParasTextBuilder
        {
            public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();

            private readonly string[] _fixParaNamesForSign =
            {
                "tonce", "accesskey", "requestmethod", "id", "method", "params"
            };

            public BtccParasTextBuilder(string method)
            {
                Parameters.Add("tonce", Convertor.ConvertDateTimeToBtccTonce(DateTime.Now).ToString());
                Parameters.Add("accesskey", _accessKey);
                Parameters.Add("requestmethod", "post");
                Parameters.Add("id", "1");
                Parameters.Add("method", method);
                Parameters.Add("params", "");
            }

            public string GetParaValuesTextForSign()
            {
                StringBuilder builder = new StringBuilder();
                var paraValues = (from p in Parameters
                    where !_fixParaNamesForSign.ToArray().Contains(p.Key)
                    select p).ToList();

                foreach (var v in paraValues)
                {
//                    string s = v.Value;

//                    if (s.Contains("\\"))
//                    {
//                        s = s.Replace("\\", "");
//                    }
//
//                    //remove "" in "btccny"
//                    if (s.Contains("\""))
//                    {
//                        s = s.Replace("\"", "");
//                    }

                    builder.Append(v.Value).Append(",");
                }

                builder.Replace("\"", "");

                //remove the redundant ","
                if (builder.ToString().EndsWith(","))
                {
                    builder.Remove(builder.Length - 1, 1).ToString();
                }
                //replace "null" with nothing
                builder.Replace("null", "");


                return builder.ToString();
            }


            public string GetParaValuesTextForPost()
            {
                StringBuilder builder = new StringBuilder();
                var paraValues = (from p in Parameters
                    where !_fixParaNamesForSign.ToArray().Contains(p.Key)
                    select p).ToList();

                foreach (var v in paraValues)
                {
//                    builder.Append("\"")
//                        .Append(v.Value.Contains("\"") ? v.Value.Replace("\"", "") : v.Value)
//                        .Append("\",");
                    builder.Append(v.Value).Append(",");
                }

                //remove the redundant ","
                if (builder.ToString().EndsWith(","))
                {
                    builder.Remove(builder.Length - 1, 1).ToString();
                }
                //replace "null" with null
                builder.Replace("\"null\"", "null");

                return builder.ToString();
            }

            public string GetParasTextForPost()
            {
                string paraValuesText = GetParaValuesTextForPost();

                string result = "{\"method\":\"" + Parameters["method"] + "\",\"params\":[" + paraValuesText +
                                "],\"id\":" + Parameters["id"] + "}";
                return result;
            }

            public string GetSign()
            {
                string[] paraNamesForSign = _fixParaNamesForSign.ToArray();

                StringBuilder builder = new StringBuilder();
                var parasForSign = (from p in Parameters
                    where paraNamesForSign.Contains(p.Key)
                    select p).ToList();

                foreach (var v in parasForSign)
                {
                    //hack for "params"
                    builder.Append(v.Key)
                        .Append("=")
                        .Append(v.Key == "params" ? GetParaValuesTextForSign() : v.Value)
                        .Append("&");
                }
                //Remove the "&" at the end
                if (builder.ToString().EndsWith("&"))
                {
                    builder.Remove(builder.Length - 1, 1).ToString();
                }

//                builder.Replace("\"", "");
//
//                var paraValues = (from p in Parameters
//                    where !paraNamesForSign.Contains(p.Key)
//                    select p).ToList();
//
//                foreach (var v in paraValues)
//                {
//                    builder.Append(v.Value).Append(",");
//                }
//
//
//                if (builder.ToString().EndsWith(","))
//                {
//                    builder.Remove(builder.Length - 1, 1).ToString();
//                }

                string parasTextForSign = builder.ToString();
                string sha1 = Convertor.ConvertPlainTextToHMACSHA1Value(_secretKey, parasTextForSign);

                return Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_accessKey}:{sha1}"));
            }
        }

        public override AccountInfo GetAccountInfo()
        {
            Builder = new BtccParasTextBuilder("getAccountInfo");
            string result = DoMethod();

            if (!result.Contains(ErrorMessageHead))
            {
                try
                {
                    JObject o = JObject.Parse(result);

                    return new AccountInfo()
                    {
                        AvailableBtc = Convert.ToDouble(o["result"]["balance"]["btc"]["amount"]),
                        AvailableCny = Convert.ToDouble(o["result"]["balance"]["cny"]["amount"])
                    };
                }
                catch
                {
                    // ignored
                }
            }
            return null;
        }

        public override string SellMarket(double amount, CoinType coinType)
        {
            Builder = new BtccParasTextBuilder("sellOrder2");
            //price must be added earlier
            Builder.Parameters.Add("price", "null");
            Builder.Parameters.Add("amount", $"{amount.ToString()}");
            Builder.Parameters.Add("coin_type", $"\"{BtccCoinType.BTCCNY}\"");
            return DoMethod();
        }

        public override string Sell(double price, double amount, CoinType coinType)
        {
            Builder = new BtccParasTextBuilder("sellOrder2");
            //price must be added earlier
            Builder.Parameters.Add("price", $"{price.ToString()}");
            Builder.Parameters.Add("amount", $"{amount.ToString()}");
            Builder.Parameters.Add("coin_type", $"\"{BtccCoinType.BTCCNY}\"");
            return DoMethod();
        }

        public override string GetOrders(CoinType coinType)
        {
            throw new NotImplementedException();
        }

        public override string BuyMarket(double amount, CoinType coinType)
        {
            Builder = new BtccParasTextBuilder("buyOrder2");
            //price must be added earlier
            Builder.Parameters.Add("price", "null");
            Builder.Parameters.Add("amount", $"{amount.ToString()}");
            Builder.Parameters.Add("coin_type", $"\"{BtccCoinType.BTCCNY}\"");
            return DoMethod();
        }

        public override string Buy(double price, double amount, CoinType coinType)
        {
            Builder = new BtccParasTextBuilder("buyOrder2");
            //price must be added earlier
            Builder.Parameters.Add("price", $"{price.ToString()}");
            Builder.Parameters.Add("amount", $"{amount.ToString()}");
            Builder.Parameters.Add("coin_type", $"\"{BtccCoinType.BTCCNY}\"");

            return DoMethod();
        }

        private string DoMethod()
        {
            string s = Builder.GetSign();
            _client.Headers.Add("Content-Type", _headerContent);
            _client.Headers.Add("Authorization", $"Basic {s}");
            _client.Headers.Add("Json-Rpc-Tonce", Builder.Parameters["tonce"]);

            string postData = Builder.GetParasTextForPost();

            try
            {
                return Encoding.UTF8.GetString(_client.UploadData(postUrl, "POST", Encoding.Default.GetBytes(postData)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override string GetTransactions()
        {
            Builder = new BtccParasTextBuilder("getTransactions");

            return DoMethod();
        }

        public override string GetOrders()
        {
            Builder = new BtccParasTextBuilder("getOrders");
            return DoMethod();
        }
    }
}