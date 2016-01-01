﻿using System;
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
        public BtccParasTextBuilder Builder;
        //for btcc trader
        private static string _tonce = Convertor.ConvertDateTimeToBtccTonce(DateTime.Now).ToString();
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
                Parameters.Add("tonce", _tonce);
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
                    builder.Append(v.Value).Append(",");
                }

                //remove the redundant ","
                if (builder.ToString().EndsWith(","))
                {
                    builder.Remove(builder.Length - 1, 1).ToString();
                }
                //replace "null" with null
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

                string result = "{\"method\": \"" + Parameters["method"] + "\", \"params\": [" + paraValuesText +
                                "], \"id\":" + Parameters["id"] +
                                " }";
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

                builder.Replace("\"", "");
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

        public override string GetAccountInfo()
        {
            Builder = new BtccParasTextBuilder("getAccountInfo");
            string postData = Builder.GetParasTextForPost();
            return DoMethod(postData);
        }

        public override string SellMarket(double amount, CoinType coinType)
        {
            Builder = new BtccParasTextBuilder("sellOrder2");
            //price must be added earlier
            Builder.Parameters.Add("price", "null");
            Builder.Parameters.Add("amount", amount.ToString());
            Builder.Parameters.Add("coin_type", "\"BTCCNY\"");
            string postData = Builder.GetParasTextForPost();
            return DoMethod(postData);
        }

        public override string Sell(double price, double amount, CoinType coinType)
        {
            Builder = new BtccParasTextBuilder("sellOrder2");
            //price must be added earlier
            Builder.Parameters.Add("price", price.ToString("0.00"));
            Builder.Parameters.Add("amount", amount.ToString("0.00"));
            Builder.Parameters.Add("coin_type","\"BTCCNY\"");
            string postData = Builder.GetParasTextForPost();
            return DoMethod(postData);
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
            string s = Builder.GetSign();
            _client.Headers.Add("Content-Type", _headerContent);
            _client.Headers.Add("Json-Rpc-Tonce", _tonce);
            _client.Headers.Add("Authorization", $"Basic {s}");

            return Encoding.UTF8.GetString(_client.UploadData(postUrl, "POST", Encoding.UTF8.GetBytes(parasText)));
        }
    }
}