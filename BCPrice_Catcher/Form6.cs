#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCPrice_Catcher.Class;
using BCPrice_Catcher.Trader;

#endregion

namespace BCPrice_Catcher
{
	public partial class Form6 : Form
	{
//		private const int StrategyMaxQuantity = 9;
//		private const int StrategyMinQuantity = 1;
		private const double InitialPecentage = 0.4d;
//		private const string ButtonStartText = "开始";
//		private const string ButtonStopText = "停止";

		private const string OutSitePrefix = "btcc";
		private const string InSitePrefix = "huobi";

		private const int InitialRowCount = 6;

		private static readonly string[] Titles =
		{
			"买价", "量", "卖价", "量", "卖价", "量", "买价", "量"
		};

//		private static readonly List<Strategy> _strategies = new List<Strategy>();
//		private static readonly TimerList _strategyTimerList = new TimerList();

		private readonly Dictionary<string, Account> _accounts = new Dictionary<string, Account>
		{
			{OutSitePrefix, new SimulateAccount()},
			{InSitePrefix, new SimulateAccount()}
		};

		//private List<int> _strategyCounters = new List<int>();

//		private readonly Dictionary<string, double> _prices = new Dictionary<string, double>
//		{
//			{OutSitePrefix, 0},
//			{InSitePrefix, 0}
//		};

		private readonly int _strategyControlColumnCount = Titles.Length;

//		private double _baseDifferPrice;

		private double _initialTotalBalance;
		private double _initialTotalCoinAmount;

		private bool _inRealMode;


		public Form6()
		{
			InitializeComponent();
		}

		private void GenerateTitleControls()
		{
			for (var i = 0; i < Titles.Length; i++)
			{
				tableLayoutPanelStrategies.Controls.Add(
					new Label
					{
						Text = Titles[i],
						TextAlign = ContentAlignment.TopCenter,
						AutoSize = false,
						Dock = DockStyle.Fill
					}, i, 0);
			}
		}

		private void GenerateStrategyControls()
		{
//			var strategyControlId = _strategyControlsCount;

			for (int rowPosition = 0; rowPosition < InitialRowCount; rowPosition++)
			{
				var columnPosition = 0;
				//左侧买价
				tableLayoutPanelStrategies.Controls.Add(
					new Label
					{
						Name = $"{ControlName.lblOutBuyPrice}{rowPosition}",
						Text = rowPosition.ToString(),
						Dock = DockStyle.Fill,
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold)
					}, columnPosition++, rowPosition);

				//左侧买量
				tableLayoutPanelStrategies.Controls.Add(
					new Label
					{
						Name = $"{ControlName.lblOutBuyAmount}{rowPosition}",
						Text = rowPosition.ToString(),
						Dock = DockStyle.Fill,
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold)
					}, columnPosition++, rowPosition);

				//左侧卖价
				tableLayoutPanelStrategies.Controls.Add(
					new Label
					{
						Name = $"{ControlName.lblOutSellPrice}{rowPosition}",
						Text = rowPosition.ToString(),
						Dock = DockStyle.Fill,
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold)
					}, columnPosition++, rowPosition);

				//左侧卖量
				tableLayoutPanelStrategies.Controls.Add(
					new Label
					{
						Name = $"{ControlName.lblOutSellAmount}{rowPosition}",
						Text = rowPosition.ToString(),
						Dock = DockStyle.Fill,
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold)
					}, columnPosition++, rowPosition);

				//右侧卖价
				tableLayoutPanelStrategies.Controls.Add(
					new Label
					{
						Name = $"{ControlName.lblInSellPrice}{rowPosition}",
						Text = rowPosition.ToString(),
						Dock = DockStyle.Fill,
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold)
					}, columnPosition++, rowPosition);

				//右侧卖量
				tableLayoutPanelStrategies.Controls.Add(
					new Label
					{
						Name = $"{ControlName.lblInSellAmount}{rowPosition}",
						Text = rowPosition.ToString(),
						Dock = DockStyle.Fill,
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold)
					}, columnPosition++, rowPosition);

				//右侧买价
				tableLayoutPanelStrategies.Controls.Add(
					new Label
					{
						Name = $"{ControlName.lblInBuyPrice}{rowPosition}",
						Text = rowPosition.ToString(),
						Dock = DockStyle.Fill,
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold)
					}, columnPosition++, rowPosition);

				//右侧买量
				tableLayoutPanelStrategies.Controls.Add(
					new Label
					{
						Name = $"{ControlName.lblInBuyAmount}{rowPosition}",
						Text = rowPosition.ToString(),
						Dock = DockStyle.Fill,
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold)
					}, columnPosition++, rowPosition);
				columnPosition = 0;
			}
		}

		private void StopStrategy(int strategyId)
		{
//			_strategyTimerList.Timers[strategyId.ToString()].Change(Timeout.Infinite, Timeout.Infinite);
		}

		private void RemoveStrategy(int strategyId)
		{
			//_strategies.Remove()
			//_strategyTimerList.Timers[strategyId.ToString()].Change(Timeout.Infinite, Timeout.Infinite);
//			_strategies.RemoveAt(strategyId);
//			var timer = _strategyTimerList.Timers[strategyId.ToString()];
//			_strategyTimerList.Timers.Remove(strategyId.ToString());
//			timer.Dispose();
		}

		private void btnStartStopStrategy_Click(object sender, EventArgs e)
		{
//			var strategyId = Convert.ToInt32((sender as Button).Tag);
//
//			var button = sender as Button;
//
//			if (button != null && button.Text == ButtonStartText)
//			{
//				StartStrategy(strategyId);
//				(sender as Button).BackColor = Color.LightCoral;
//				(sender as Button).Text = ButtonStopText;
//			}
//			else
//			{
//				StopStrategy(strategyId);
//				((Button) sender).BackColor = Color.LightGreen;
//				((Button) sender).Text = ButtonStartText;
//			}
		}

		private void StartStrategy(int strategyId)
		{
//			_strategyTimerList.Timers[strategyId.ToString()].Change(0,
//				_strategies[strategyId].InputParameters.Peroid * 1000);
		}

		//add a new strategy
		private void AddStrategy()
		{
//			var strategyId = _strategyControlsCount - 1;
//			var strategy = new Strategy
//			{
//				Id = strategyId,
//				InputParameters = GetStrategyParameters(strategyId),
//				//InputParameters = GetStrategyParameters(strategyId).Result,
//				PreviousStrategy = strategyId == 0 ? null : _strategies[strategyId - 1]
//			};
//			_strategies.Add(strategy);
//
////            double tradeAmount = Convert.ToDouble(nudTradeAmount.Value);
//			//need await here?
//			//need task here?
//			_strategyTimerList.Add(strategyId.ToString(), Timeout.Infinite, async o =>
//			{
//				await Task.Run(() =>
//				{
//					strategy.Update(GetStrategyParameters(strategy.Id));
//					strategy.TryTrade(_accounts, new Dictionary<string, double>
//					{
//						{OutSitePrefix, _prices[OutSitePrefix]},
//						{InSitePrefix, _prices[InSitePrefix]}
//					}, strategy.InputParameters.TradeAmount);
//				});
//			});
		}


		private void Strategy_Updated(int strategyId)
		{
//			ShowStrategyValues(_strategies[strategyId]);
		}

		private void Form6_Load(object sender, EventArgs e)
		{
			InitializeControls();
			ChangeToSimulateMode();
		}

		private void InitializeControls()
		{
			tableLayoutPanelStrategies.Visible = false;
			//            tableLayoutPanelStrategies.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanelStrategies.Visible = true;
			GenerateTitleControls();

//			tableLayoutPanelStrategies.Controls["btnAddStrategy"].Enabled = true;
//			tableLayoutPanelStrategies.Controls["btnRemoveStrategy"].Enabled = true;
//			tableLayoutPanelStrategies.Controls["btnAddStrategy"].Click += btnAddStrategy_Click;
//			tableLayoutPanelStrategies.Controls["btnAddStrategy"].Click += CheckControlStatus;
//			tableLayoutPanelStrategies.Controls["btnRemoveStrategy"].Click += btnRemoveStrategy_Click;
//			tableLayoutPanelStrategies.Controls["btnRemoveStrategy"].Click += CheckControlStatus;

			//set gridview font size

//			gdvHuobiTrades.ColumnHeadersDefaultCellStyle.Font = new Font(
//				gdvBtccTrades.DefaultCellStyle.Font.FontFamily, 9);
//			gdvHuobiTrades.DefaultCellStyle.Font = new Font(gdvBtccTrades.DefaultCellStyle.Font.FontFamily, 9);
		}

		private void Form6_Activated(object sender, EventArgs e)
		{
		}

		private void Form6_Shown(object sender, EventArgs e)
		{
			//accounts must be set first (because accounts is need in strategy)
			//show accounts for the first time
			trackBar1_ValueChanged(null, null);

//			for (var i = 0; i < InitialRowCount; i++)
//			{
//			GenerateStrategyControls();
//				AddStrategy();
//			}
		}

		private void btnAddStrategy_Click(object sender, EventArgs e)
		{
//			if (_strategies.Count < StrategyMaxQuantity)
//			{
//				GenerateStrategyControls();
//				AddStrategy();
//			}
		}

		private void RemoveStrategy()
		{
			//must before removing the strategy, or the .Count is not correct
//			var strategyId = _strategies.Count - 1;
//			var timer = _strategyTimerList.Timers[strategyId.ToString()];
//			_strategyTimerList.Timers.Remove(strategyId.ToString());
//			timer.Dispose();
//			_strategies.Remove(_strategies[strategyId]);
		}

		private void RemoveStrategyControls()
		{
//			var controlCount = tableLayoutPanelStrategies.Controls.Count;
//			for (var i = controlCount - 1;
//				i >= controlCount - _strategyControlColumnCount;
//				i--)
//			{
//				tableLayoutPanelStrategies.Controls.Remove(tableLayoutPanelStrategies.Controls[i]);
//			}
//			_strategyControlsCount--;
		}

		private void CheckControlStatus(object sender, EventArgs e)
		{
//			if (_strategies.Count == StrategyMaxQuantity)
//			{
//				tableLayoutPanelStrategies.Controls["btnAddStrategy"].Enabled = false;
//			}
//			else if (_strategies.Count == StrategyMinQuantity)
//			{
//				tableLayoutPanelStrategies.Controls["btnRemoveStrategy"].Enabled = false;
//			}
//			else
//			{
//				tableLayoutPanelStrategies.Controls["btnAddStrategy"].Enabled = true;
//				tableLayoutPanelStrategies.Controls["btnRemoveStrategy"].Enabled = true;
//			}
		}

		private void btnRemoveStrategy_Click(object sender, EventArgs e)
		{
//			if (_strategies.Count > StrategyMinQuantity)
//			{
//				RemoveStrategy();
//				RemoveStrategyControls();
//			}
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
			//_accounts.Clear();
			var totalBalance = _accounts[OutSitePrefix].Balance + _accounts[InSitePrefix].Balance;
			var totalCoinAmount = _accounts[OutSitePrefix].CoinAmount + _accounts[InSitePrefix].CoinAmount;

			_accounts[OutSitePrefix].Balance = Math.Round(totalBalance * pecentage);
			_accounts[OutSitePrefix].CoinAmount = Math.Round(totalCoinAmount * (1 - pecentage));

			_accounts[InSitePrefix].Balance = Math.Round(totalBalance * (1 - pecentage));
			_accounts[InSitePrefix].CoinAmount = Math.Round(totalCoinAmount * pecentage);
		}


		private void ShowAccounts()
		{
			if (_inRealMode)
			{
				UpdateRealAccount();
			}

			lblBtccAccount.Text
				=
				$"BTCC({tckPecentage.Value}%){Environment.NewLine}现金：{_accounts["btcc"].Balance.ToString("0.000")}{Environment.NewLine}币数：{_accounts["btcc"].CoinAmount.ToString("0.000")}";
			lblHuobiAccount.Text
				=
				$"HUOBI({tckPecentage.Maximum - tckPecentage.Value}%){Environment.NewLine}现金：{_accounts["huobi"].Balance.ToString("0.000")}{Environment.NewLine}币数：{_accounts["huobi"].CoinAmount.ToString("0.000")}";
		}

		private void trackBar1_ValueChanged(object sender, EventArgs e)
		{
			AdjustAccounts(Convert.ToDouble(tckPecentage.Value) / tckPecentage.Maximum);
			ShowAccounts();
		}

		private void GetPrices()
		{
//			if (
//				Tag != null)
//			{
//				var prices = Tag as Dictionary<string, double>;
//
//				if (
//					prices != null && prices.Count
//					== 2)
//				{
//					_prices[OutSitePrefix] = prices[OutSitePrefix];
//					_prices[InSitePrefix] = prices[InSitePrefix];
//					_baseDifferPrice = Math.Abs(_prices[OutSitePrefix] - _prices[InSitePrefix]);
//				}
//			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			GetPrices();
			ShowPrices();

			//            foreach (var s in _strategies)
			//            {
			//                ChangeStrategyValues(s);
			//            }

			ShowAccounts();

//			for (
//				var i = 0;
//				i < _strategies.Count;
//				i
//					++)
//			{
//				ShowStrategyValues(_strategies[i]);
//			}
//
//			ShowTrades();
		}

		//for btcc, huobi and differ price
		private void ShowPrices()
		{
//			_baseDifferPrice
//				=
//				Math.Abs
//					(_prices[OutSitePrefix]
//					 -
//					 _prices[InSitePrefix]);
//			lblBtccPrice.Text
//				= $"BTCC{Environment.NewLine}{_prices[OutSitePrefix].ToString("0.000")}";
//			lblHuobiPrice.Text
//				= $"HUOBI{Environment.NewLine}{_prices[InSitePrefix].ToString("0.000")}";
//			lblDifferPrice.Text
//				= $"差价{Environment.NewLine}{_baseDifferPrice.ToString("0.000")}";
//			lblTotalProfits.Text
//				=
//				$"总利润{Environment.NewLine}{(_accounts[OutSitePrefix].Balance + _accounts[InSitePrefix].Balance - _initialTotalBalance).ToString("0.000")}";
//
//			if (
//				_prices[OutSitePrefix]
//				>
//				_prices[InSitePrefix]
//				)
//			{
//				lblDifferPrice.Text = lblDifferPrice.Text.Insert(4, "<< ");
//			}
//			else if (
//				_prices[OutSitePrefix] < _prices[InSitePrefix])
//			{
//				lblDifferPrice.Text
//					=
//					lblDifferPrice.Text
//					+ @" >>";
//			}
		}

		private void Form4_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void ShowStrategyValues(Strategy strategy)
		{
//			(tableLayoutPanelStrategies.Controls[$"{ControlName.lblTradeThreshold}{strategy.Id}"] as Label).Text =
//				strategy.TradeThreshold.ToString("0.000");
//
//			(tableLayoutPanelStrategies.Controls[$"{ControlName.lblRegressionThreshold}{strategy.Id}"] as Label).Text =
//				strategy.RegressionThreshold.ToString("0.000");
//
//			(tableLayoutPanelStrategies.Controls[$"{ControlName.lblStrategyID}{strategy.Id}"] as Label).Text =
//				(strategy.Id + 1).ToString();
//
//			(tableLayoutPanelStrategies.Controls[$"{ControlName.lblTradeThresholdLastUpdated}{strategy.Id}"] as Label)
//				.Text =
//				strategy.TradeThresholdLastUpdated.ToString("HH:mm:ss");
//			(tableLayoutPanelStrategies.Controls[$"{ControlName.lblTotalTradeCount}{strategy.Id}"] as Label)
//				.Text =
//				strategy.TradeCount.ToString();
		}

//		private Strategy.StrategyInputParameters GetStrategyParameters(int strategyId)
//		{
//			const string floatRegex = @"^(-?\d+)(\.\d+)?$";
//			const string integerRegex = @"^(\+|-)?\d+$";
//
//			var s1 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeThresholdIncrement}{strategyId}"] as
//				NumericUpDown).Text;
//
//
//			var s2 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeThresholdCoefficient}{strategyId}"]
//				as
//				NumericUpDown).Text;
//
//			var s3 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeLagThreshold}{strategyId}"] as
//				NumericUpDown).Text;
//			var s4 =
//				(tableLayoutPanelStrategies.Controls[
//					$"{ControlName.nudRegressionThresholdIncrement}{strategyId}"]
//					as NumericUpDown).Text;
//			var s5 =
//				(tableLayoutPanelStrategies.Controls[
//					$"{ControlName.nudRegressionThresholdCoefficient}{strategyId}"]
//					as NumericUpDown).Text;
//
//			var s6 = nudStartPrice.Text;
//			var s7 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudPeriod}{strategyId}"]
//				as NumericUpDown).Text;
//
//			var s8 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTotalTradeCountLimit}{strategyId}"]
//				as NumericUpDown).Text;
//
//			var s9 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeAmount}{strategyId}"] as
//				NumericUpDown).Text;
//
//
//			var parameters = new Strategy.StrategyInputParameters
//			{
//				TradeThresholdIncrement = Regex.IsMatch(s1, floatRegex) ? Convert.ToDouble(s1) : 0,
//				TradeThresholdCoefficient = Regex.IsMatch(s2, floatRegex) ? Convert.ToDouble(s2) : 0,
//				TradeLagThreshold = Regex.IsMatch(s3, integerRegex) ? Convert.ToInt32(s3) : 0,
//				RegressionThresholdIncrement = Regex.IsMatch(s4, floatRegex) ? Convert.ToDouble(s4) : 0,
//				RegressionThresholdCoefficient = Regex.IsMatch(s5, floatRegex) ? Convert.ToDouble(s5) : 0,
//				StartPrice = Regex.IsMatch(s6, floatRegex) ? Convert.ToDouble(s6) : 3,
//				Peroid = Regex.IsMatch(s7, integerRegex) ? Convert.ToInt32(s7) : 1,
//				TotalTradeCountLimit = Regex.IsMatch(s8, integerRegex) ? Convert.ToInt32(s8) : 9999999,
//				TradeAmount = Regex.IsMatch(s9, floatRegex) ? Convert.ToDouble(s9) : 0.001
//			};
//
//
//			if (strategyId == 0)
//			{
//				parameters.BaseThreshold = _baseDifferPrice;
//			}
//			else
//			{
//				parameters.BaseThreshold = _strategies[strategyId - 1].TradeThreshold;
//			}
//
//			parameters.DifferPrice = _baseDifferPrice;
//			//            currentStrategy.InputParameters.TradeQuantityThreshold =
//			//                Convert.ToInt32(
//			//                    (tableLayoutPanelStrategies.Controls[$"{ControlNames[8]}{index}"] as TextBox).Text);
//			return parameters;
//		}

		private void btnAllStart_Click(object sender, EventArgs e)
		{
			//            foreach (var s in _strategies)
			//            {
			//                StartStrategy(s.Id);
			//            }


//			for (var i = 0; i < _strategyControlsCount; i++)
//			{
//				var button = tableLayoutPanelStrategies.Controls[$"{ControlName.btnStartStopStrategy}{i}"];
//
//				if (button.Text == ButtonStartText)
//				{
//					btnStartStopStrategy_Click(button, null);
//				}
//			}
		}
//
		private void btnAllStop_Click(object sender, EventArgs e)
		{
//			var strategyCount = _strategies.Count;
//			for (var i = strategyCount - 1; i >= 0; i--)
//			{
//				var button = tableLayoutPanelStrategies.Controls[$"{ControlName.btnStartStopStrategy}{i}"];
//
//				if (button.Text == ButtonStopText)
//				{
//					btnStartStopStrategy_Click(button, null);
//				}
//			}
		}

		private void ShowTrades()
		{
			long btccIndex = _accounts["btcc"].AccountTradeRecords.Count;
//            gdvBtccTrades.DataSource =
			var btccAccountTrades =
				_accounts["btcc"].AccountTradeRecords.OrderByDescending(t => t.Time)
					.Select(
						t =>
							new
							{
								SN = btccIndex--,
								t.StrategyId,
								t.Price,
								t.Amount,
								t.Time,
								t.Type
//                                Profit = t.Profit.ToString("0.000")
							});
//					.ToList();

			long huobiIndex = _accounts["huobi"].AccountTradeRecords.Count;
			//			gdvHuobiTrades.DataSource = 

			var huobiAccountTrades =
				_accounts["huobi"].AccountTradeRecords.OrderByDescending(t => t.Time).Select(
					t =>
						new
						{
							SN = huobiIndex--,
							t.StrategyId,
							t.Price,
							t.Amount,
							t.Time,
							t.Type
//                        Profit = t.Profit.ToString("0.000")
						});
//					.ToList();

			var totalTrades = from btcc in btccAccountTrades
				join huobi in huobiAccountTrades
					on btcc.SN equals huobi.SN
				select new
				{
					btcc.SN,
					StrategoyID = btcc.StrategyId,
					BtccPrice = btcc.Price.ToString("0.000"),
					BtccAmount = btcc.Amount.ToString("0.0000"),
					BtccType = btcc.Type,
					HuobiPrice = huobi.Price.ToString("0.000"),
					HuobiAmount = huobi.Amount.ToString("0.0000"),
					HuobiType = huobi.Type
//					Profit = (btcc.Price * btcc.Amount - huobi.Price * huobi.Amount).ToString("0.000")
//Profit = btcc.Price + "," + btcc.Amount + "," + huobi.Price + "," + huobi.Amount + (btcc.Price * btcc.Amount - huobi.Price * huobi.Amount).ToString("0.000")
				};

//			gdvBtccTrades.DataSource = totalTrades.ToList();
		}

		private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new frmConfig();
			frm.ShowDialog();
		}

		private void btnSwitchMode_Click(object sender, EventArgs e)
		{
			if (!_inRealMode) //change to real mode
			{
				_inRealMode = true;
				btnSwitchMode.Text = "停止真实模式(&R)";
				btnSwitchMode.BackColor = Color.Crimson;
				tckPecentage.Enabled = false;
				ChangeToRealMode();
			}
			else //change to simulate mode
			{
				_inRealMode = false;
				btnSwitchMode.BackColor = Color.LimeGreen;
				btnSwitchMode.Text = "启动真实模式(&R)";
				tckPecentage.Enabled = true;
				ChangeToSimulateMode();
				btnAllStop_Click(null, null);
			}
		}

		private void ChangeToRealMode()
		{
			UseRealAccount();
		}

		private void UseRealAccount()
		{
			var btccAccount = new RealAccount {Trader = new BtccTrader()};
			var accountInfo = btccAccount.Trader.GetAccountInfo();
			btccAccount.Balance = accountInfo.AvailableCny;
			btccAccount.CoinAmount = accountInfo.AvailableBtc;
			_accounts[OutSitePrefix] = btccAccount;

			var huobiAccount = new RealAccount {Trader = new HuobiTrader()};
			accountInfo = huobiAccount.Trader.GetAccountInfo();
			huobiAccount.Balance = accountInfo.AvailableCny;
			huobiAccount.CoinAmount = accountInfo.AvailableBtc;
			_accounts[InSitePrefix] = huobiAccount;

			_initialTotalBalance = btccAccount.Balance + huobiAccount.Balance;
			_initialTotalCoinAmount = btccAccount.CoinAmount + huobiAccount.CoinAmount;
		}

		private void UpdateRealAccount()
		{
			var btccAccount = _accounts[OutSitePrefix];
//		    btccAccount.Trader = new BtccTrader();
			var accountInfo = btccAccount.Trader.GetAccountInfo();
			btccAccount.Balance = accountInfo.AvailableCny;
			btccAccount.CoinAmount = accountInfo.AvailableBtc;
			_accounts[OutSitePrefix] = btccAccount;

			var huobiAccount = _accounts[InSitePrefix];
//			huobiAccount.Trader = new HuobiTrader();
			accountInfo = huobiAccount.Trader.GetAccountInfo();
			huobiAccount.Balance = accountInfo.AvailableCny;
			huobiAccount.CoinAmount = accountInfo.AvailableBtc;
			_accounts[InSitePrefix] = huobiAccount;
		}


		private void ChangeToSimulateMode()
		{
			UseSimulateAccount();
		}

		private void UseSimulateAccount()
		{
			_initialTotalBalance = 2000000;
			_initialTotalCoinAmount = 200;
			_accounts["btcc"] = new SimulateAccount
			{
				Balance = Math.Round(_initialTotalBalance * InitialPecentage),
				CoinAmount = Math.Round(_initialTotalCoinAmount * (1 - InitialPecentage))
			};

			_accounts["huobi"] = new SimulateAccount
			{
				Balance = Math.Round(_initialTotalBalance * (1 - InitialPecentage)),
				CoinAmount = Math.Round(_initialTotalCoinAmount * InitialPecentage)
			};
		}

		private void Form4_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show(this, "确定退出程序吗?", "问题", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2) == DialogResult.No)
			{
				e.Cancel = true;
			}
			else
			{
				btnAllStop_Click(null, null);
			}
		}

		private enum ControlName
		{
			lblOutBuyPrice,
			lblOutBuyAmount,
			lblOutSellPrice,
			lblOutSellAmount,
			lblInSellPrice,
			lblInSellAmount,
			lblInBuyPrice,
			lblInBuyAmount
		}
	}
}