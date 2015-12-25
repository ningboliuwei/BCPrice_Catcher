using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCPrice_Catcher.Model;
using BCPrice_Catcher.Util;

namespace BCPrice_Catcher.Trader
{
    class HuobiTrader : Trader
    {
        private string _headerContent = "application/x-www-form-urlencoded";
        private string postUrl = "https://api.huobi.com/apiv3";
        private const string AccessKey = "48a8ded8-963359c3-1aaa1237-51909";
        private const string SecretKey = "57c362c4-2462acb0-23369fb2-469b8";
        private readonly WebClient _client = new WebClient();
        private const string Market = "cny";
        private const string TradePassword = "password";

        /// <summary>
        /// 构建火币网交易 API 请求参数的辅助类
        /// </summary>
        public class HuobiParasTextBuilder
        {
            public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
            //固定包含在需要生成签名中的参数
            private readonly string[] _fixParaNamesForSign = {"created", "secret_key", "method", "access_key"};

            public HuobiParasTextBuilder(string method)
            {
                Parameters.Add("access_key", AccessKey);
                Parameters.Add("secret_key", SecretKey);
                Parameters.Add("created", Convertor.ConvertDateTimeToJsonTimeStamp(DateTime.Now).ToString());
                Parameters.Add("method", method);
            }

            public string GetParasText(string[] extraParaNamesForSign)
            {
                string[] paraNamesForSign = _fixParaNamesForSign.Union(extraParaNamesForSign).ToArray();

                var parasForSign = (from p in Parameters
                    where paraNamesForSign.Contains(p.Key)
                    orderby p.Key
                    select p).ToList();

                StringBuilder plainTextBuilder = new StringBuilder();
                foreach (var v in parasForSign)
                {
                    plainTextBuilder.Append(v.Key).Append("=").Append(v.Value).Append("&");
                }
                //Remove the "&" at the end
                string signText =
                    Convertor.ConvertPlainTextToMd5Value(
                        plainTextBuilder.Remove(plainTextBuilder.Length - 1, 1).ToString());

                //build the final paras string for POST
                StringBuilder parasTextBuilder = new StringBuilder();
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

        /// <summary>
        /// 火币网交易辅助类
        /// </summary>
        public HuobiTrader()
        {
            _client.Headers.Add("Content-Type", _headerContent);
        }

        /// <summary>
        /// 获取个人资产信息
        /// </summary>
        /// <returns></returns>
        public override string GetAccountInfo()
        {
            var builder = new HuobiParasTextBuilder("get_account_info");

            builder.Parameters.Add("market", Market);

            string parasText = builder.GetParasText(new string[] {});
            return DoMethod(parasText);
        }

        /// <summary>
        /// 卖出（市价单）
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="coinType"></param>
        /// <returns></returns>
        public override string SellMarket(double amount, CoinType coinType)
        {
            var builder = new HuobiParasTextBuilder("sell_market");

            builder.Parameters.Add("market", Market);
            builder.Parameters.Add("amount", amount.ToString());
            builder.Parameters.Add("coin_type", ((int) coinType).ToString());
            builder.Parameters.Add("trade_password", TradePassword);

            string parasText =
                builder.GetParasText(new string[] {"amount", "coin_type"});
            return DoMethod(parasText);
        }

        /// <summary>
        /// 获取所有正在进行的委托
        /// </summary>
        /// <param name="coinType"></param>
        /// <returns></returns>
        public override string GetOrders(CoinType coinType)
        {
            var builder = new HuobiParasTextBuilder("get_orders");

            builder.Parameters.Add("coin_type", ((int) coinType).ToString());

            string parasText =
                builder.GetParasText(new[] {"coin_type"});
            return DoMethod(parasText);
        }

        public override string BuyMarket(double amount, CoinType coinType)
        {
            var builder = new HuobiParasTextBuilder("buy_market");

            builder.Parameters.Add("market", Market);
            builder.Parameters.Add("amount", amount.ToString());
            builder.Parameters.Add("coin_type", ((int) coinType).ToString());
            builder.Parameters.Add("trade_password", TradePassword);

            string parasText =
                builder.GetParasText(new string[] {"amount", "coin_type"});
            return DoMethod(parasText);
        }

        public override string Buy(double price, double amount, CoinType coinType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 从火币网交易 API 得到结果
        /// </summary>
        /// <param name="parasText">要发送的所有参数的文本</param>
        /// <returns></returns>
        private string DoMethod(string parasText)
        {
            return Encoding.UTF8.GetString(_client.UploadData(postUrl, Encoding.UTF8.GetBytes(parasText)));
        }
    }
}