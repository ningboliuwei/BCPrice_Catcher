using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCPrice_Catcher.Model;
using BCPrice_Catcher.Util;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;

namespace BCPrice_Catcher
{
    class BtccSocketFetcher : Fetcher
    {
        private const string Url = "https://websocket.btcc.com/";
        private readonly Socket _socket = IO.Socket(Url);
        private string _dataText = "";

        private const string BtcSocketAccessKey = "000c2d29-2e8a-4d17-b493-dc13a86543d1";
        private const string BtcSocketSecretKey = "62464917-3acf-4fa1-bc02-611e0c833c68";


        public string Usage { get; set; }

        public BtccSocketFetcher()
        {
        }


        public void Subscribe()
        {
            _socket.On(Socket.EVENT_CONNECT, () =>
            {
                _socket.Emit("subscribe", "marketdata_cnybtc");
                _socket.Emit("subscribe", "grouporder_cnybtc");
            });
        }


        public override TickerInfo GetTicker()
        {
            _socket.On("ticker", data => { _dataText = data.ToString(); });

            if (_dataText.Length != 0)
            {
                try
                {
                    JObject o = JObject.Parse(_dataText);

                    return new TickerInfo()
                    {
                        Open = Convert.ToDouble(o["ticker"]["open"]),
                        Vol = Convert.ToDouble(o["ticker"]["vol"]),
                        Last = Convert.ToDouble(o["ticker"]["last"]),
                        Sell = Convert.ToDouble(o["ticker"]["sell"]),
                        High = Convert.ToDouble(o["ticker"]["high"]),
                        Low = Convert.ToDouble(o["ticker"]["low"]),
                        Time = Convertor.ConvertJsonDateTimeToChinaDateTime(o["ticker"]["date"].ToString())
                    };
                }
                catch
                {
                    // ignored
                }
            }

            return null;
        }


        public override TradeDetail GetTradeDetail()
        {
            _socket.On("trade", data => { _dataText = data.ToString(); });

            if (_dataText.Length != 0)
            {
                try
                {
                    JObject o = JObject.Parse(_dataText);

                    return new TradeDetail()
                    {
                        Amount = Convert.ToDouble(o["amount"]),
                        New = Convert.ToDouble(o["price"]),
                        Time = Convertor.ConvertJsonDateTimeToChinaDateTime(o["date"].ToString())
                    };
                }
                catch
                {
                    // ignored
                }
            }
            return null;
        }

        public override List<TradeInfo> GetTrades()
        {
            throw new NotImplementedException();
        }

        public override List<OrderInfo> GetOrders()
        {
            throw new NotImplementedException();
        }

        public string GetGroupOrder()
        {
            _socket.On("grouporder", data => { _dataText = data.ToString(); });

            return _dataText;
        }


        public void Close()
        {
            _socket.Close();
        }
    }
}