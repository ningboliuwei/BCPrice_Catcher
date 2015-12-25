using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCPrice_Catcher.Class;

namespace BCPrice_Catcher
{
    public partial class Form3 : Form
    {
        private double btccPrice;
        private double huobiPrice;


        SimulateAccount btccAccount = new SimulateAccount() {Balance = 1000000, CoinAmount = 50};
        SimulateAccount huobiAccount = new SimulateAccount() {Balance = 1000000, CoinAmount = 50};

        private double lowerLimit;
        private double upperLimit;
        private double tradeAmount;
        private double totalAmountLimit;

        public Form3()
        {
            InitializeComponent();
            totalAmountLimit = btccAccount.CoinAmount + huobiAccount.CoinAmount;
        }

        public void AutoTrade()
        {
            double differ = Math.Abs(btccPrice - huobiPrice);

            if (differ >= upperLimit)
            {
                if (btccPrice > huobiPrice) //btcc卖价高
                {
                    if (btccAccount.CoinAmount != 0)
                    {
//                        btccAccount.Sell(btccPrice, tradeAmount, textBox1); //btcc卖出
//                        huobiAccount.Buy(huobiPrice, tradeAmount, textBox2); //huobi买入
                        ShowTotalAssets();
                    }
                }
                else //huobi卖价高
                {
                    if (huobiAccount.CoinAmount != 0)
                    {
//                        huobiAccount.Sell(huobiPrice, tradeAmount, textBox2); //huobi卖出
//                        btccAccount.Buy(btccPrice, tradeAmount, textBox1); //btcc买入
                        ShowTotalAssets();
                    }
                }
            }

            if (differ <= lowerLimit)
            {
                if (btccAccount.CoinAmount > huobiAccount.CoinAmount) //btcc币多
                {
                    if (btccAccount.CoinAmount != 0)
                    {
//                        btccAccount.Sell(btccPrice, tradeAmount, textBox1); //btcc卖出
//                        huobiAccount.Buy(huobiPrice, tradeAmount, textBox2); //huobi买入
                        ShowTotalAssets();
                    }
                }
                else //huobi币多
                {
                    if (huobiAccount.CoinAmount != 0)
                    {
//                        huobiAccount.Sell(huobiPrice, tradeAmount, textBox2); //huobi卖出
//                        btccAccount.Buy(btccPrice, tradeAmount, textBox1); //btcc买入
                        ShowTotalAssets();
                    }
                }
            }
        }

        private void ShowPrice()
        {
            label3.Text = $"BTCC:{btccPrice}";
            label4.Text = $"Huobi:{huobiPrice}";

            if (btccPrice > huobiPrice)
            {
                label3.Text += "*";
            }
            else
            {
                label4.Text += "*";
            }
        }

        private void ShowAccount()
        {
            label5.Text =
                $"BTCC金额：{Environment.NewLine}{btccAccount.Balance}{Environment.NewLine}币数：{btccAccount.CoinAmount}";
            label6.Text =
                $"Huobi金额：{Environment.NewLine}{huobiAccount.Balance}{Environment.NewLine}币数：{huobiAccount.CoinAmount}";
        }

        private void ChangeParas()
        {
            upperLimit = Convert.ToDouble(textBox3.Text.Trim());
            lowerLimit = Convert.ToDouble(textBox4.Text.Trim());
            tradeAmount = Convert.ToDouble(textBox5.Text.Trim());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ChangeParas();
            GetPrice();
            ShowPrice();
            AutoTrade();
            ShowAccount();
        }

        private void ShowTotalAssets()
        {
            textBox6.Text = textBox6.Text.Insert(0, (huobiAccount.Balance + btccAccount.Balance).ToString() +
                                                    Environment.NewLine);
        }


        private void GetPrice()
        {
            if (Tag != null)
            {
                Dictionary<string, double> prices = Tag as Dictionary<string, double>;

                if (prices.Count == 2)
                {
                    btccPrice = Convert.ToDouble(prices["Btcc"]);
                    huobiPrice = Convert.ToDouble(prices["Huobi"]);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}