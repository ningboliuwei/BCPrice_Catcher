#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BCPrice_Catcher.Class;

#endregion

namespace BCPrice_Catcher
{
	public partial class Form3 : Form
	{
		private readonly SimulateAccount btccAccount = new SimulateAccount {Balance = 1000000, CoinAmount = 50};
		private readonly SimulateAccount huobiAccount = new SimulateAccount {Balance = 1000000, CoinAmount = 50};
		private double btccPrice;
		private double huobiPrice;

		private double lowerLimit;
		private double totalAmountLimit;
		private double tradeAmount;
		private double upperLimit;

		public Form3()
		{
			InitializeComponent();
			totalAmountLimit = btccAccount.CoinAmount + huobiAccount.CoinAmount;
		}

		public void AutoTrade()
		{
			var differ = Math.Abs(btccPrice - huobiPrice);

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
			lblBtccPrice.Text = $"BTCC:{btccPrice}";
			lblHuobiPrice.Text = $"Huobi:{huobiPrice}";

			if (btccPrice > huobiPrice)
			{
				lblBtccPrice.Text += @"*";
			}
			else
			{
				lblHuobiPrice.Text += @"*";
			}
		}

		private void ShowAccount()
		{
			lblBtccAccountInfo.Text =
				$"BTCC金额：{Environment.NewLine}{btccAccount.Balance}{Environment.NewLine}币数：{btccAccount.CoinAmount}";
			lblHuobiAccountInfo.Text =
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
			txtTotalAssets.Text = txtTotalAssets.Text.Insert(0, huobiAccount.Balance + btccAccount.Balance +
			                                        Environment.NewLine);
		}


		private void GetPrice()
		{
			var prices = Tag as Dictionary<string, double>;

			if (prices?.Count == 2)
			{
				btccPrice = Convert.ToDouble(prices["Btcc"]);
				huobiPrice = Convert.ToDouble(prices["Huobi"]);
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}
	}
}