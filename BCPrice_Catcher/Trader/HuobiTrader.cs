#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using BCPrice_Catcher.Model;
using BCPrice_Catcher.Properties;
using BCPrice_Catcher.Util;
using Newtonsoft.Json.Linq;

#endregion

namespace BCPrice_Catcher.Trader
{
    internal class HuobiTrader : Trader
    {
        private const string Market = "cny";
        private const string TradePassword = "password";
        private const string ErrorMessageHead = "\"code\"";
        private static readonly string _accessKey = Settings.Default.HuobiAccessKey;
        private static readonly string _secretKey = Settings.Default.HuobiSecretKey;
        private WebClient _client;
        private readonly string _headerContent = "application/x-www-form-urlencoded";
        private readonly string postUrl = "https://api.huobi.com/apiv3";
        public HuobiParasTextBuilder Builder;

        /// <summary>
        ///     获取个人资产信息
        /// </summary>
        /// <returns></returns>
        public override AccountInfo GetAccountInfo()
        {
            Builder = new HuobiParasTextBuilder("get_account_info");
            Builder.Parameters.Add("market", Market);

            var parasText = Builder.GetParasText(new string[] {});
            var result = DoMethod(parasText);

            if (!result.Contains(ErrorMessageHead))
            {
                try
                {
                    var o = JObject.Parse(result);

                    return new AccountInfo
                    {
                        AvailableBtc = Convert.ToDouble(o["available_btc_display"]),
                        AvailableCny = Convert.ToDouble(o["available_cny_display"])
                    };
                }
                catch
                {
                    // ignored
                }
            }
            return null;
        }

        /// <summary>
        ///     卖出（市价单）
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="coinType"></param>
        /// <returns></returns>
        public override int SellMarket(double amount, CoinType coinType)
        {
            Builder = new HuobiParasTextBuilder("sell_market");

            Builder.Parameters.Add("market", Market);
            Builder.Parameters.Add("amount", amount.ToString());
            Builder.Parameters.Add("coin_type", ((int) coinType).ToString());
            Builder.Parameters.Add("trade_password", TradePassword);

            var parasText =
                Builder.GetParasText(new[] {"amount", "coin_type"});
            var result = DoMethod(parasText);
            if (!result.Contains(ErrorMessageHead))
            {
                try
                {
                    var o = JObject.Parse(result);

                    return Convert.ToInt32(o["id"]);
                }
                catch
                {
                    // ignored
                }
            }
            return -1;
        }

        public override int Sell(double price, double amount, CoinType coinType)
        {
            Builder = new HuobiParasTextBuilder("sell");

            Builder.Parameters.Add("market", Market);
            Builder.Parameters.Add("amount", amount.ToString());
            Builder.Parameters.Add("price", price.ToString());
            Builder.Parameters.Add("coin_type", ((int) coinType).ToString());
            Builder.Parameters.Add("trade_password", TradePassword);

            var parasText =
                Builder.GetParasText(new[] {"amount", "coin_type", "price"});
            var result = DoMethod(parasText);
            if (!result.Contains(ErrorMessageHead))
            {
                try
                {
                    var o = JObject.Parse(result);

                    return Convert.ToInt32(o["id"]);
                }
                catch
                {
                    // ignored
                }
            }
            return -1;
        }

        /// <summary>
        ///     获取所有正在进行的委托
        /// </summary>
        /// <param name="coinType"></param>
        /// <returns></returns>
        public override List<PlacedOrderInfo> GetOrders(CoinType coinType)
        {
            Builder = new HuobiParasTextBuilder("get_orders");

            Builder.Parameters.Add("coin_type", ((int) coinType).ToString());
            Builder.Parameters.Add("market", Market);


            var parasText =
                Builder.GetParasText(new[] {"coin_type"});

            var result = DoMethod(parasText);

            if (!result.Contains(ErrorMessageHead))
            {
                try
                {
                    var o = JObject.Parse("{orders:" + result + "}");

                    return (from c in o["orders"].Children()
                        select new PlacedOrderInfo
                        {
                            Id = Convert.ToInt32(c["id"]),
                            Type = c["type"].ToString() == "1" ? OrderType.Bid : OrderType.Ask,
                            Price = Convert.ToDouble(c["order_price"]),
                            AmountProcessed = Convert.ToDouble(c[" processed_amount"]),
                            AmountOriginal = Convert.ToDouble(c["order_amount"]),
                            Time = Convertor.ConvertJsonDateTimeToLocalDateTime(c["order_time"].ToString()),
                            Status =
                                Convert.ToDouble(c["processed_amount"]) == Convert.ToDouble(c["order_amount"])
                                    ? OrderStatus.Closed
                                    : OrderStatus.Open
                            //Status is unknown   
                        }).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    // ignored
                }
            }
            return null;
        }

        public override int BuyMarket(double amount, CoinType coinType)
        {
            Builder = new HuobiParasTextBuilder("buy_market");

            Builder.Parameters.Add("market", Market);
            Builder.Parameters.Add("amount", amount.ToString());
            Builder.Parameters.Add("coin_type", ((int) coinType).ToString());
            Builder.Parameters.Add("trade_password", TradePassword);

            var parasText =
                Builder.GetParasText(new[] {"amount", "coin_type"});
            var result = DoMethod(parasText);
            if (!result.Contains(ErrorMessageHead))
            {
                try
                {
                    var o = JObject.Parse(result);

                    return Convert.ToInt32(o["id"]);
                }
                catch
                {
                    // ignored
                }
            }
            return -1;
        }

        public override int Buy(double price, double amount, CoinType coinType)
        {
            Builder = new HuobiParasTextBuilder("buy");

            Builder.Parameters.Add("market", Market);
			//huobi uses total price (price * amount) for paramater "amount"
            Builder.Parameters.Add("amount", amount.ToString());
            Builder.Parameters.Add("price", price.ToString());
            Builder.Parameters.Add("coin_type", ((int) coinType).ToString());
            Builder.Parameters.Add("trade_password", TradePassword);

            var parasText =
                Builder.GetParasText(new[] {"amount", "coin_type", "price"});
            var result = DoMethod(parasText);
            if (!result.Contains(ErrorMessageHead))
            {
                try
                {
                    var o = JObject.Parse(result);

                    return Convert.ToInt32(o["id"]);
                }
                catch
                {
                    // ignored
                }
            }
            return -1;
        }

        public override string GetTransactions()
        {
            throw new NotImplementedException();
        }

        public override PlacedOrderInfo GetOrder(int orderId, CoinType coinType)
        {
            Builder = new HuobiParasTextBuilder("order_info");

            Builder.Parameters.Add("coin_type", ((int) coinType).ToString());
            Builder.Parameters.Add("market", Market);


            var parasText =
                Builder.GetParasText(new[] { "coin_type" });

            var result = DoMethod(parasText);

            if (!result.Contains(ErrorMessageHead))
            {
                try
                {
                    var o = JObject.Parse("{order:" + result + "}");

                    return new PlacedOrderInfo
                    {
                        Id = Convert.ToInt32(o["id"]),
                        //1 Buy, 2 Sell, 3 BuyMarket, 4 SellMarket
                        Type = (o["type"].ToString() == "1" || o["type"].ToString() == "3") ? OrderType.Bid : OrderType.Ask,
                        Price = Convert.ToDouble(o["order_price"]),
                        AmountProcessed = Convert.ToDouble(o[" processed_amount"]),
                        AmountOriginal = Convert.ToDouble(o["order_amount"]),
                        Time = Convertor.ConvertJsonDateTimeToLocalDateTime(o["order_time"].ToString()),
                        Status =
                            Convert.ToDouble(o["processed_amount"]) == Convert.ToDouble(o["order_amount"])
                                ? OrderStatus.Closed
                                : OrderStatus.Open
                        //Status is unknown   
                    };
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    // ignored
                }
            }
            return null;
        }

        /// <summary>
        ///     从火币网交易 API 得到结果
        /// </summary>
        /// <param name="parasText">要发送的所有参数的文本</param>
        /// <returns></returns>
        private string DoMethod(string parasText)
        {
	        _client = new WebClient();
            _client.Headers.Add("Content-Type", _headerContent);

            return Encoding.UTF8.GetString(_client.UploadData(postUrl, Encoding.UTF8.GetBytes(parasText)));
        }

        /// <summary>
        ///     构建火币网交易 API 请求参数的辅助类
        /// </summary>
        public class HuobiParasTextBuilder
        {
            //固定包含在需要生成签名中的参数
            private readonly string[] _fixParaNamesForSign = {"created", "secret_key", "method", "access_key"};

            public HuobiParasTextBuilder(string method)
            {
                Parameters.Add("access_key", _accessKey);
                Parameters.Add("secret_key", _secretKey);
                Parameters.Add("created", Convertor.ConvertDateTimeToJsonTimeStamp(DateTime.Now).ToString());
                Parameters.Add("method", method);
            }

            public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();

            public string GetParasText(string[] extraParaNamesForSign)
            {
                var paraNamesForSign = _fixParaNamesForSign.Union(extraParaNamesForSign).ToArray();

                var parasForSign = (from p in Parameters
                    where paraNamesForSign.Contains(p.Key)
                    orderby p.Key
                    select p).ToList();

                var plainTextBuilder = new StringBuilder();
                foreach (var v in parasForSign)
                {
                    plainTextBuilder.Append(v.Key).Append("=").Append(v.Value).Append("&");
                }
                //Remove the "&" at the end
                var signText =
                    Convertor.ConvertPlainTextToMd5Value(
                        plainTextBuilder.Remove(plainTextBuilder.Length - 1, 1).ToString());

                //build the final paras string for POST
                var parasTextBuilder = new StringBuilder();
                foreach (var v in Parameters.OrderBy(k => k.Key))
                {
                    if (v.Key != "secret_key")
                    {
                        parasTextBuilder.Append(v.Key).Append("=").Append(v.Value).Append("&");
                    }
                }
                return parasTextBuilder.Append("sign=").Append(signText).ToString();
            }
        }
    }
}