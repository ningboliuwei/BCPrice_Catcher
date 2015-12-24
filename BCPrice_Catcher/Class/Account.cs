using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCPrice_Catcher.Class
{
    class Account
    {
        public double Balance { get; set; }
        public double CoinAmount { get; set; }

        public void Sell(double price, double amount)
        {
            if (CoinAmount >= amount)
            {
                CoinAmount -= amount;
                Balance += price * amount;

//                textbox.Text = textbox.Text.Insert(0,
//                    Environment.NewLine + $"卖 {amount} 币 at {price} with 总价 {price * amount}");
            }
        }

        public void Buy(double price, double amount)
        {
            if (Balance >= price * amount)
            {
                CoinAmount += amount;
                Balance -= price * amount;
//                textbox.Text = textbox.Text.Insert(0,
//                    Environment.NewLine + $"买 {amount} 币 at {price} with 总价 {price * amount}");
            }
        }
    }
}