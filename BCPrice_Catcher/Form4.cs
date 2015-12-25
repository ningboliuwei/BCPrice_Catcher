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
using BCPrice_Catcher.Model;
using BCPrice_Catcher.Util;

namespace BCPrice_Catcher
{
	public partial class Form4 : Form
	{
		private int _strategyCount = 0;
		private const int StrategyLimit = 8;
		private const int StrategyControlColumnCount = 12;
		private Dictionary<string, SimulateAccount> _accounts = new Dictionary<string, SimulateAccount>();
		private List<StrategyParas> _strategyParasList = new List<StrategyParas>();

		private double _btccPrice;
		private double _huobiPrice;
		private double _baseDifferPrice;

		public Form4()
		{
			InitializeComponent();
		}

		private void AutoGenerateStrategyControls(int rowIndex)
		{

			//策略号
			tableLayoutPanelStrategies.Controls.Add(
				new Label
				{
					Name = $"lblStrategyID{rowIndex}",
					Text = (rowIndex).ToString(),
				}, 0, rowIndex);
			//启动阙值
			tableLayoutPanelStrategies.Controls.Add(
				new Label {Name = $"lblStartupThreshold{rowIndex}", Text = (rowIndex + 1).ToString()}, 1,
				rowIndex);
			//启动阙值增量
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"nudStartupThresholdIncrement{rowIndex}",
					Value = 0,
					Maximum = 10,
					Minimum = -10
				}, 2, rowIndex);
			//启动阙值系数
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"nudStartupThresholdCoefficient{rowIndex}",
					Value = 1,
					Maximum = 2M,
					Minimum = 0.1M,
					DecimalPlaces = 1,
					Increment = 0.1M
				}, 3, rowIndex);

			//周期
			tableLayoutPanelStrategies.Controls.Add(
				new TextBox()
				{
					Name = $"txtPeriod{rowIndex}",
					Text = ((rowIndex + 1) * 100).ToString()
				}, 4,
				rowIndex);

			//默认回归价
			tableLayoutPanelStrategies.Controls.Add(
				new Label() {Name = $"lblRegressionThreshold{rowIndex}", Text = "0"}, 5,
				rowIndex);

			//回归阙值增量
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"nudRegressionThresholdIncrement{rowIndex}",
					Value = 1,
					Maximum = 10,
					Minimum = -10,
					Increment = 1
				}, 6, rowIndex);

			//回归阙值系数
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"nudRegressionThresholdCoefficient{rowIndex}",
					Value = 1,
					Maximum = 2,
					Minimum = 0.1M,
					DecimalPlaces = 1,
					Increment = 0.1M
				}, 7, rowIndex);

			//成交数量阙值
			tableLayoutPanelStrategies.Controls.Add(
				new TextBox()
				{
					Name = $"txtTradeQuantityThreshold{rowIndex}",
					Text = ((rowIndex + 1) * 100).ToString()
				}, 8,
				rowIndex);

			//开始按钮
			tableLayoutPanelStrategies.Controls.Add(
				new Button()
				{
					Name = $"btnStrategyStart{rowIndex}",
					Text = "开始",
					BackColor = Color.LightGreen
				}, 9, rowIndex);

			//结束按钮
			tableLayoutPanelStrategies.Controls.Add(
				new Button()
				{
					Name = $"btnStrategyStop{rowIndex}",
					Text = "结束",
					BackColor = Color.LightCoral
				}, 10, rowIndex);

//                foreach (var c in tableLayoutPanelStrategies.Controls)
//                {
//                    ((Control) c).Dock = DockStyle.Fill;
//                    ((Control) c).Anchor = AnchorStyles.Left | AnchorStyles.Right;
//                }
		}

		private void Form4_Load(object sender, EventArgs e)
		{
			InitializeControls();
			_strategyParasList.Add(new StrategyParas());

			//show accounts for the first time
			trackBar1_ValueChanged(null, null);
		}

		private void InitializeControls()
		{
			tableLayoutPanelStrategies.Visible = false;
			AutoGenerateStrategyControls(_strategyCount + 1);
			//tableLayoutPanelStrategies.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanelStrategies.Visible = true;
		}

		private void Form4_Activated(object sender, EventArgs e)
		{
		}

		private void Form4_Shown(object sender, EventArgs e)
		{
		}

		private void btnAddStrategy_Click(object sender, EventArgs e)
		{
			if (_strategyCount < StrategyLimit)
			{
				_strategyCount++;
				AutoGenerateStrategyControls(_strategyCount + 1);
				_strategyParasList.Add(new StrategyParas());
			}
		}

		private void btnRemoveStrategy_Click(object sender, EventArgs e)
		{
			//至少保留一行控件
			if (_strategyCount > 0)
			{
				_strategyCount--;

				int controlCount = tableLayoutPanelStrategies.Controls.Count;
				for (int i = tableLayoutPanelStrategies.Controls.Count - 1;
					i > controlCount - StrategyControlColumnCount;
					i--)
				{
					tableLayoutPanelStrategies.Controls.Remove(tableLayoutPanelStrategies.Controls[i]);
				}
			}
		}

		private void Form4_Paint(object sender, PaintEventArgs e)
		{
		}

		private void Form4_ResizeBegin(object sender, EventArgs e)
		{
		}

		private void Form4_ResizeEnd(object sender, EventArgs e)
		{
		}

		private void AdjustAccounts(double pecentage)
		{
			const double totalBalance = 400000;
			const double totalCoinAmount = 100;

			_accounts.Clear();
			_accounts.Add("btcc",
				new SimulateAccount
				{
					Balance = Math.Round(totalBalance * pecentage),
					CoinAmount = Math.Round(totalCoinAmount * (1 - pecentage))
				});
			_accounts.Add("huobi",
				new SimulateAccount
				{
					Balance = Math.Round(totalBalance * (1 - pecentage)),
					CoinAmount = Math.Round(totalCoinAmount * (pecentage))
				});
		}

		private void ShowAccountsInfo()
		{
			lblBtccAccount.Text =
				$"BTCC({trackBar1.Value}%){Environment.NewLine}现金：{_accounts["btcc"].Balance}{Environment.NewLine}币数：{_accounts["btcc"].CoinAmount}";
			lblHuobiAccount.Text =
				$"HUOBI({trackBar1.Maximum - trackBar1.Value}%){Environment.NewLine}现金：{_accounts["huobi"].Balance}{Environment.NewLine}币数：{_accounts["huobi"].CoinAmount}";
		}

		private void trackBar1_ValueChanged(object sender, EventArgs e)
		{
			AdjustAccounts(trackBar1.Value / trackBar1.Maximum);
			ShowAccountsInfo();
		}

		private void GetPrices()
		{
			if (Tag != null)
			{
				Dictionary<string, double> prices = Tag as Dictionary<string, double>;

				if (prices.Count == 2)
				{
					_btccPrice = prices["btcc"];
					_huobiPrice = prices["huobi"];
					_baseDifferPrice = Math.Abs(_btccPrice - _huobiPrice);
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			GetPrices();
			ShowPrices();
			GetStrategyParaValues(0);
			(tableLayoutPanelStrategies.Controls[$"lblStartupThreshold1"] as Label).Text =
				_strategyParasList[0].StartupThresholdCoefficient.ToString();

			(tableLayoutPanelStrategies.Controls[$"lblRegressionThreshold1"] as Label).Text =
				_strategyParasList[0].RegressionThreshold.ToString();
		}

		//for btcc, huobi and differ price
		private void ShowPrices()
		{
			_baseDifferPrice = Math.Abs((_btccPrice - _huobiPrice));
			lblBtccPrice.Text = $"BTCC{Environment.NewLine}{_btccPrice.ToString("0.00")}";
			lblHuobiPrice.Text = $"HUOBI{Environment.NewLine}{_huobiPrice.ToString("0.00")}";
			lblDifferPrice.Text = $"差价{Environment.NewLine}{_baseDifferPrice.ToString("0.00")}";

			if (_btccPrice > _huobiPrice)
			{
				lblDifferPrice.Text = lblDifferPrice.Text.Insert(0, "<< ");
			}
			else if (_btccPrice < _huobiPrice)
			{
				lblDifferPrice.Text = lblDifferPrice.Text + " >>";
			}
		}

		private void Form4_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void GetStrategyParaValues(int index)
		{
			int controlRowIndex = index + 1;
			StrategyParas paras = _strategyParasList[index];

			paras.StartupThresholdIncrement = Convert.ToDouble(
				(tableLayoutPanelStrategies.Controls[$"nudStartupThresholdIncrement{controlRowIndex}"] as NumericUpDown).Value);
			paras.StartupThresholdCoefficient = Convert.ToDouble(
				(tableLayoutPanelStrategies.Controls[$"nudStartupThresholdCoefficient{controlRowIndex}"] as NumericUpDown).Value);
			paras.Period =
				Convert.ToInt32((tableLayoutPanelStrategies.Controls[$"txtPeriod{controlRowIndex}"] as TextBox).Text);
			paras.RegressionThresholdIncrement = Convert.ToDouble(
				(tableLayoutPanelStrategies.Controls[$"nudRegressionThresholdIncrement{controlRowIndex}"] as NumericUpDown).Value);
			paras.RegressionThresholdCoefficient = Convert.ToDouble(
				(tableLayoutPanelStrategies.Controls[$"nudRegressionThresholdCoefficient{controlRowIndex}"] as NumericUpDown).Value);
			paras.TradeQuantityThreshold =
				Convert.ToInt32((tableLayoutPanelStrategies.Controls[$"txtTradeQuantityThreshold{controlRowIndex}"] as TextBox).Text);

			if (index == 0) //first strategy
			{
				paras.StartupThreshold = _baseDifferPrice * paras.StartupThresholdCoefficient + paras.StartupThresholdIncrement;
			}
			else
			{
				paras.StartupThreshold = _strategyParasList[index - 1].StartupThreshold * paras.StartupThresholdCoefficient +
				                         paras.StartupThresholdIncrement;
			}
			paras.RegressionThreshold = paras.StartupThreshold * paras.StartupThresholdCoefficient +
			                            paras.StartupThresholdIncrement;
		}
	}
}