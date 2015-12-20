﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCPrice_Catcher
{
    public partial class Form3 : Form
    {
        private double btccPrice;
        private double huobiPrice;

        class Account
        {
            public double Balance { get; set; }
            public double CoinAmount { get; set; }

            public void Sell(double price, double amount, TextBox textbox)
            {
                if (CoinAmount >= amount)
                {
                    CoinAmount -= amount;
                    Balance += price * amount;

                    textbox.Text = textbox.Text.Insert(0, Environment.NewLine + $"卖 {amount} 币 at {price} with 总价 {price * amount}");
                    
                }
            }

            public void Buy(double price, double amount, TextBox textbox)
            {
                if (Balance >= price * amount)
                {
                    CoinAmount += amount;
                    Balance -= price * amount;
                   textbox.Text= textbox.Text.Insert(0, Environment.NewLine + $"买 {amount} 币 at {price} with 总价 {price * amount}");
                }
            }
        }

        Account btccAccount = new Account() {Balance = 100000, CoinAmount = 5};
        Account huobiAccount = new Account() {Balance = 100000, CoinAmount = 5};

        private double lowerLimit;
        private double upperLimit;
        private double tradeAmount;

        public Form3()
        {
            InitializeComponent();
        }

        public void AutoTrade()
        {
            double differ = Math.Abs(btccPrice - huobiPrice);

            if (differ >= upperLimit)
            {
                if (btccPrice > huobiPrice) //btcc卖价高
                {
                    btccAccount.Sell(btccPrice, tradeAmount, textBox1); //btcc卖出
                    huobiAccount.Buy(huobiPrice, tradeAmount, textBox2); //huobi买入
                }
                else //huobi卖价高
                {
                    btccAccount.Buy(btccPrice, tradeAmount, textBox1); //btcc买入
                    huobiAccount.Sell(huobiPrice, tradeAmount, textBox2); //huobi卖出
                }
            }

            if (differ <= lowerLimit)
            {
                if (btccAccount.CoinAmount > huobiAccount.CoinAmount) //btcc币多
                {
                    btccAccount.Sell(btccPrice, tradeAmount, textBox1); //btcc卖出
                    huobiAccount.Buy(huobiPrice, tradeAmount, textBox2); //huobi买入
                }
                else //huobi币多
                {
                    btccAccount.Buy(btccPrice, tradeAmount, textBox1); //btcc买入
                    huobiAccount.Sell(huobiPrice, tradeAmount, textBox2); //huobi卖出
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
            label5.Text = $"BTCC金额：{Environment.NewLine}{btccAccount.Balance}{Environment.NewLine}币数：{btccAccount.CoinAmount}";
            label6.Text = $"Huobi金额：{Environment.NewLine}{huobiAccount.Balance}{Environment.NewLine}币数：{huobiAccount.CoinAmount}";
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
           
            ShowTotalAssets();
        }

        private void ShowTotalAssets()
        {
           textBox6.Text=  textBox6.Text.Insert(0, (huobiPrice * huobiAccount.CoinAmount + huobiAccount.Balance +
                                     btccPrice * btccAccount.CoinAmount + btccAccount.Balance).ToString() +
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