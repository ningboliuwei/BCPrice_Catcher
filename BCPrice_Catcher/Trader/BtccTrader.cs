﻿#region

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
	internal class BtccTrader : Trader
	{
		private const string ErrorMessageHead = "\"error\"";
		private static readonly string AccessKey = Settings.Default.BtccAccessKey;
		private static readonly string SecretKey = Settings.Default.BtccSecretKey;

		private const string HeaderContent = "application/json-rpc";
		private const string PostUrl = "https://api.btcc.com/api_trade_v1.php";
		private WebClient _client;
		public BtccParasTextBuilder Builder;

		public override AccountInfo GetAccountInfo()
		{
			Builder = new BtccParasTextBuilder("getAccountInfo");

			try
			{
				var result = DoMethod();

				if (!result.Contains(ErrorMessageHead))
				{
					var o = JObject.Parse(result);

					return new AccountInfo
					{
						AvailableBtc = Convert.ToDouble(o["result"]["balance"]["btc"]["amount"]),
						AvailableCny = Convert.ToDouble(o["result"]["balance"]["cny"]["amount"])
					};
				}
			}
			catch
			{
				// ignored
			}

			return null;
		}

		public override int SellMarket(double amount, CoinType coinType)
		{
			Builder = new BtccParasTextBuilder("sellOrder2");
			//price must be added earlier
			Builder.Parameters.Add("price", "null");
			Builder.Parameters.Add("amount", $"{amount}");
			Builder.Parameters.Add("coin_type", $"\"{BtccCoinType.BTCCNY}\"");

			try
			{
				var result = DoMethod();
				if (!result.Contains(ErrorMessageHead))
				{
					var o = JObject.Parse(result);

					return Convert.ToInt32(o["result"]);
				}
			}
			catch
			{
				// ignored
			}

			return -1;
		}

		public override int Sell(double price, double amount, CoinType coinType)
		{
			Builder = new BtccParasTextBuilder("sellOrder2");
			//price must be added earlier
			Builder.Parameters.Add("price", $"{price}");
			Builder.Parameters.Add("amount", $"{amount}");
			Builder.Parameters.Add("coin_type", $"\"{BtccCoinType.BTCCNY}\"");

			try
			{
				var result = DoMethod();
				if (!result.Contains(ErrorMessageHead))
				{
					var o = JObject.Parse(result);

					return Convert.ToInt32(o["result"]);
				}
			}
			catch
			{
				// ignored
			}

			return -1;
		}

		public override int BuyMarket(double amount, CoinType coinType)
		{
			Builder = new BtccParasTextBuilder("buyOrder2");
			//price must be added earlier
			Builder.Parameters.Add("price", "null");
			Builder.Parameters.Add("amount", $"{amount}");
			Builder.Parameters.Add("coin_type", $"\"{BtccCoinType.BTCCNY}\"");


			try
			{
				var result = DoMethod();

				if (!result.Contains(ErrorMessageHead))
				{
					var o = JObject.Parse(result);

					return Convert.ToInt32(o["result"]);
				}
			}
			catch
			{
				// ignored
			}

			return -1;
		}

		public override int Buy(double price, double amount, CoinType coinType)
		{
			Builder = new BtccParasTextBuilder("buyOrder2");
			//price must be added earlier
			Builder.Parameters.Add("price", $"{price}");
			Builder.Parameters.Add("amount", $"{amount}");
			Builder.Parameters.Add("coin_type", $"\"{BtccCoinType.BTCCNY}\"");

			try
			{
				var result = DoMethod();
				if (!result.Contains(ErrorMessageHead))
				{
					var o = JObject.Parse(result);

					return Convert.ToInt32(o["result"]);
				}
			}
			catch
			{
				// ignored
			}

			return -1;
		}

		public override string GetAllTransactions()
		{
			throw new NotImplementedException();
		}

		public override PlacedOrderInfo GetPlacedOrder(int orderId, CoinType coinType)
		{
			Builder = new BtccParasTextBuilder("getOrder");
			Builder.Parameters.Add("order_id", $"{orderId}");


			try
			{
				var result = DoMethod();

				if (!result.Contains(ErrorMessageHead))
				{
					var o = JObject.Parse(result);

					return new PlacedOrderInfo
					{
						Id = Convert.ToInt32(o["result"]["order"]["id"]),
						Type = o["result"]["order"]["type"].ToString() == "bid" ? OrderType.Bid : OrderType.Ask,
						Price = Convert.ToDouble(o["result"]["order"]["price"]),
						AmountProcessed = Convert.ToDouble(o["result"]["order"]["amount"]),
						AmountOriginal = Convert.ToDouble(o["result"]["order"]["amount_original"]),
						Time = Convertor.ConvertJsonDateTimeToLocalDateTime(o["result"]["order"]["date"].ToString()),
						Status =
							(OrderStatus)
								Enum.Parse(typeof (OrderStatus), o["result"]["order"]["status"].ToString(), true)
					};
				}
			}
			catch
			{
				// ignored
			}

			return null;
		}

		public override bool CancelPlacedOrder(int orderId, CoinType coinType)
		{
			Builder = new BtccParasTextBuilder("cancelOrder");
			//price must be added earlier
			Builder.Parameters.Add("order_id", $"{orderId}");


			try
			{
				var result = DoMethod();

				if (!result.Contains(ErrorMessageHead))
				{
					var o = JObject.Parse(result);

					if (o["result"].ToString() == "true")
					{
						return true;
					}
				}
			}
			catch
			{
				// ignored
			}

			return false;
		}

		private string DoMethod()
		{
			//get latest tonce first
			Builder.Parameters["tonce"] = Convertor.ConvertDateTimeToBtccTonce(DateTime.Now).ToString();
			var s = Builder.GetSign();
			_client = new WebClient();
			_client.Headers.Add("Content-Type", HeaderContent);
			_client.Headers.Add("Authorization", $"Basic {s}");
			_client.Headers.Add("Json-Rpc-Tonce", Builder.Parameters["tonce"]);

			var postData = Builder.GetParasTextForPost();

			try
			{
				return Encoding.UTF8.GetString(_client.UploadData(PostUrl, "POST", Encoding.Default.GetBytes(postData)));
			}
			catch
			{
//				throw new Exception(ex.Message);
			}
			return null;
		}

		public override List<PlacedOrderInfo> GetAllPlacedOrders(CoinType coinType)
		{
			Builder = new BtccParasTextBuilder("getOrders");
			Builder.Parameters.Add("openonly", "true");


			try
			{
				var result = DoMethod();
				if (!result.Contains(ErrorMessageHead))
				{
					var o = JObject.Parse(result);

					return (from c in o["result"]["order"].Children()
						select new PlacedOrderInfo
						{
							Id = Convert.ToInt32(c["id"]),
							Type = c["type"].ToString() == "bid" ? OrderType.Bid : OrderType.Ask,
							Price = Convert.ToDouble(c["price"]),
							AmountOriginal = Convert.ToDouble(c["amount_original"]),
							Time = Convertor.ConvertJsonDateTimeToLocalDateTime(c["date"].ToString()),
							Status =
								(OrderStatus)
									Enum.Parse(typeof (OrderStatus), c["status"].ToString(), true)
						}).ToList();
				}
			}
			catch
			{
				// ignored
			}

			return null;
		}

		private enum BtccCoinType
		{
			LTCBTC,
			BTCCNY,
			LTCCNY
		}

		public class BtccParasTextBuilder
		{
			private readonly string[] _fixParaNamesForSign =
			{
				"tonce", "accesskey", "requestmethod", "id", "method", "params"
			};

			public BtccParasTextBuilder(string method)
			{
				Parameters.Add("tonce", Convertor.ConvertDateTimeToBtccTonce(DateTime.Now).ToString());
				Parameters.Add("accesskey", AccessKey);
				Parameters.Add("requestmethod", "post");
				Parameters.Add("id", "1");
				Parameters.Add("method", method);
				Parameters.Add("params", "");
			}

			public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();

			public string GetParaValuesTextForSign()
			{
				var builder = new StringBuilder();
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
				var builder = new StringBuilder();
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
				var paraValuesText = GetParaValuesTextForPost();

				var result = "{\"method\":\"" + Parameters["method"] + "\",\"params\":[" + paraValuesText +
				             "],\"id\":" + Parameters["id"] + "}";
				return result;
			}

			public string GetSign()
			{
				var paraNamesForSign = _fixParaNamesForSign.ToArray();

				var builder = new StringBuilder();
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

				var parasTextForSign = builder.ToString();
				var sha1 = Convertor.ConvertPlainTextToHMACSHA1Value(SecretKey, parasTextForSign);

				return Convert.ToBase64String(Encoding.ASCII.GetBytes($"{AccessKey}:{sha1}"));
			}
		}
	}
}