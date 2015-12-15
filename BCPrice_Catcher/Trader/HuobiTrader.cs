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
		private const string AccessKey = "405c317f-bb0efb31-4e3a21db-73122";
		private const string SecretKey = "f4e57175-be5f9ecf-49ada379-82f1d";
		private WebClient _client = new WebClient();

		public HuobiTrader()
		{
			_client.Headers.Add("Content-Type", _headerContent);
		}


		public override string GetAccountInfo()
		{
			string plainText = $"access_key={AccessKey}&created={Convertor.ConvertDateTimeToJsonTimeStamp(DateTime.Now)}&method=get_account_info&secret_key={SecretKey})";
			string sign = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(plainText))).ToLower().Replace("-","");
			string paraString =
				$"sign={sign}access_key={AccessKey}&created={Convertor.ConvertDateTimeToJsonTimeStamp(DateTime.Now)}&method=get_account_info&secret_key={SecretKey})";


			byte[] result = _client.UploadData(postUrl,"POST", Encoding.UTF8.GetBytes(paraString));

			return Encoding.UTF8.GetString(result);

		}
	}
}

