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
		private const int StrategyMaxNumber = 9;
		private const int StrategyMinNumber = 1;
		private const int StrategyControlColumnCount = 12;
		private Dictionary<string, SimulateAccount> _accounts = new Dictionary<string, SimulateAccount>();
		private List<Strategy> _strategies = new List<Strategy>();

		private double _btccPrice;
		private double _huobiPrice;
		private double _baseDifferPrice;

		public Form4()
		{
			InitializeComponent();
		}

		private void AddStrategyControls()
		{
			int rowPosition = _strategies.Count;
			//策略号
			tableLayoutPanelStrategies.Controls.Add(
				new Label
				{
					Name = $"lblStrategyID{rowPosition - 1}",
					Text = (rowPosition).ToString(),
				}, 0, rowPosition);
			//启动阙值
			tableLayoutPanelStrategies.Controls.Add(
				new Label {Name = $"lblStartupThreshold{rowPosition - 1}", Text = (rowPosition + 1).ToString()}, 1,
				rowPosition);
			//启动阙值增量
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"nudStartupThresholdIncrement{rowPosition - 1}",
					Value = 0,
					Maximum = 10,
					Minimum = -10
				}, 2, rowPosition);
			//启动阙值系数
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"nudStartupThresholdCoefficient{rowPosition - 1}",
					Value = 1,
					Maximum = 2M,
					Minimum = 0.1M,
					DecimalPlaces = 1,
					Increment = 0.1M
				}, 3, rowPosition);

			//周期
			tableLayoutPanelStrategies.Controls.Add(
				new TextBox()
				{
					Name = $"txtPeriod{rowPosition - 1}",
					Text = ((rowPosition + 1) * 100).ToString()
				}, 4,
				rowPosition);

			//默认回归价
			tableLayoutPanelStrategies.Controls.Add(
				new Label() {Name = $"lblRegressionThreshold{rowPosition - 1}", Text = "0"}, 5,
				rowPosition);

			//回归阙值增量
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"nudRegressionThresholdIncrement{rowPosition - 1}",
					Value = 1,
					Maximum = 10,
					Minimum = -10,
					Increment = 1
				}, 6, rowPosition);

			//回归阙值系数
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"nudRegressionThresholdCoefficient{rowPosition - 1}",
					Value = 1,
					Maximum = 2,
					Minimum = 0.1M,
					DecimalPlaces = 1,
					Increment = 0.1M
				}, 7, rowPosition);

			//成交数量阙值
			tableLayoutPanelStrategies.Controls.Add(
				new TextBox()
				{
					Name = $"txtTradeQuantityThreshold{rowPosition - 1}",
					Text = ((rowPosition + 1) * 100).ToString()
				}, 8,
				rowPosition);

			//开始按钮
			tableLayoutPanelStrategies.Controls.Add(
				new Button()
				{
					Name = $"btnStrategyStart{rowPosition - 1}",
					Text = "开始",
					BackColor = Color.LightGreen
				}, 9, rowPosition);

			//结束按钮
			tableLayoutPanelStrategies.Controls.Add(
				new Button()
				{
					Name = $"btnStrategyStop{rowPosition - 1}",
					Text = "结束",
					BackColor = Color.LightCoral
				}, 10, rowPosition);

//                foreach (var c in tableLayoutPanelStrategies.Controls)
//                {
//                    ((Control) c).Dock = DockStyle.Fill;
//                    ((Control) c).Anchor = AnchorStyles.Left | AnchorStyles.Right;
//                }
		}

		private void AddStrategy()
		{
			_strategies.Add(new Strategy());
			AddStrategyControls();
		}

		private void Form4_Load(object sender, EventArgs e)
		{
			btnAddStrategy.Click += CheckControlStatus;
			btnRemoveStrategy.Click += CheckControlStatus;

			InitializeControls();
			AddStrategy();

			//show accounts for the first time
			trackBar1_ValueChanged(null, null);
		}

		private void InitializeControls()
		{
			tableLayoutPanelStrategies.Visible = false;
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
			if (_strategies.Count < StrategyMaxNumber)
			{
				AddStrategy();
			}
		}

		private void RemoveStrategy()
		{
			_strategies.Remove(_strategies[_strategies.Count - 1]);
			RemoveStrategyControls();
		}

		private void RemoveStrategyControls()
		{
			int controlCount = tableLayoutPanelStrategies.Controls.Count;
			for (int i = tableLayoutPanelStrategies.Controls.Count - 1;
				i > controlCount - StrategyControlColumnCount;
				i--)
			{
				tableLayoutPanelStrategies.Controls.Remove(tableLayoutPanelStrategies.Controls[i]);
			}
		}

		private void CheckControlStatus(object sender, EventArgs e)
		{
			if (_strategies.Count == StrategyMaxNumber)
			{
				btnAddStrategy.Enabled = false;
			}
			else if (_strategies.Count == StrategyMinNumber)
			{
				btnRemoveStrategy.Enabled = false;
			}
			else
			{
				btnAddStrategy.Enabled = true;
				btnRemoveStrategy.Enabled = true;
			}
		}

		private void btnRemoveStrategy_Click(object sender, EventArgs e)
		{
			RemoveStrategy();
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

			for (int i = 0; i < _strategies.Count; i++)
			{
				GetStrategyParaValues(i);
			}

			ShowStrategyValues();
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

		private void ShowStrategyValues()
		{
			for (int i = 0; i < _strategies.Count; i++)
			{
				(tableLayoutPanelStrategies.Controls[$"lblStartupThreshold{i}"] as Label).Text =
					_strategies[i].StartupThreshold.ToString("0.00");

				(tableLayoutPanelStrategies.Controls[$"lblRegressionThreshold{i}"] as Label).Text =
					_strategies[i].RegressionThreshold.ToString("0.00");
			}
		}

		private void GetStrategyParaValues(int index)
		{
			Strategy currentStrategy = _strategies[index];

			currentStrategy.InputParameters.StartupThresholdIncrement = Convert.ToDouble(
				(tableLayoutPanelStrategies.Controls[$"nudStartupThresholdIncrement{index}"] as NumericUpDown).Value);
			currentStrategy.InputParameters.StartupThresholdCoefficient = Convert.ToDouble(
				(tableLayoutPanelStrategies.Controls[$"nudStartupThresholdCoefficient{index}"] as NumericUpDown).Value);
			currentStrategy.InputParameters.Period =
				Convert.ToInt32((tableLayoutPanelStrategies.Controls[$"txtPeriod{index}"] as TextBox).Text);
			currentStrategy.InputParameters.RegressionThresholdIncrement = Convert.ToDouble(
				(tableLayoutPanelStrategies.Controls[$"nudRegressionThresholdIncrement{index}"] as NumericUpDown).Value);
			currentStrategy.InputParameters.RegressionThresholdCoefficient = Convert.ToDouble(
				(tableLayoutPanelStrategies.Controls[$"nudRegressionThresholdCoefficient{index}"] as NumericUpDown).Value);
			currentStrategy.InputParameters.TradeQuantityThreshold =
				Convert.ToInt32((tableLayoutPanelStrategies.Controls[$"txtTradeQuantityThreshold{index}"] as TextBox).Text);

			if (index == 0) //first strategy
			{
				currentStrategy.StartupThreshold = _baseDifferPrice * currentStrategy.InputParameters.StartupThresholdCoefficient +
				                                   currentStrategy.InputParameters.StartupThresholdIncrement;
			}
			else
			{
				currentStrategy.StartupThreshold = _strategies[index - 1].StartupThreshold *
				                                   currentStrategy.InputParameters.StartupThresholdCoefficient +
				                                   currentStrategy.InputParameters.StartupThresholdIncrement;
			}
			currentStrategy.RegressionThreshold = currentStrategy.StartupThreshold *
			                                      currentStrategy.InputParameters.StartupThresholdCoefficient +
			                                      currentStrategy.InputParameters.StartupThresholdIncrement;
		}
	}
}