﻿using System;
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


        public HuobiTrader()
        {
            _client.Headers.Add("Content-Type", _headerContent);
        }


        public override string GetAccountInfo()
        {
            var builder = new HuobiParasTextBuilder();


            builder.Parameters.Add("method", "get_account_info");
            builder.Parameters.Add("market", Market);

            string parasText = builder.GetPostDataString(new[] {"created", "secret_key", "method", "access_key"});
            return Encoding.UTF8.GetString(_client.UploadData(postUrl, Encoding.UTF8.GetBytes(parasText)));
        }

        public class HuobiParasTextBuilder
        {
            public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();

            public HuobiParasTextBuilder()
            {
                Parameters.Add("access_key", AccessKey);
                Parameters.Add("secret_key", SecretKey);
                Parameters.Add("created", Convertor.ConvertDateTimeToJsonTimeStamp(DateTime.Now).ToString());
            }

            public string GetPostDataString(string[] paraNamesToEncrypt)
            {
                var parasForSign = (from p in Parameters
                    where paraNamesToEncrypt.Contains(p.Key)
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
                foreach (var v in Parameters)
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