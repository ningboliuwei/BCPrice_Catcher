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
        private WebClient _client = new WebClient();
        private const string Market = "cny";

        public HuobiTrader()
        {
            _client.Headers.Add("Content-Type", _headerContent);
        }


        public override string GetAccountInfo()
        {
            DateTime dateTime = DateTime.Now;
            string plainText = $"access_key={AccessKey}&created={Convertor.ConvertDateTimeToJsonTimeStamp(dateTime)}&method=get_account_info&secret_key={SecretKey}";
            string sign = Convertor.ConvertPlainTextToMd5Value(plainText);
            string paraString =
                $"access_key={AccessKey}&created={Convertor.ConvertDateTimeToJsonTimeStamp(dateTime)}&market={Market}&method=get_account_info&sign={sign}";
            //return sign;
            return Encoding.UTF8.GetString(_client.UploadData(postUrl, Encoding.UTF8.GetBytes(paraString)));
        }
    }
}

