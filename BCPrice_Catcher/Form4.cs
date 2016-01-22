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
	public partial class Form4 : Form
	{
		private const int StrategyMaxQuantity = 9;
		private const int StrategyMinQuantity = 1;
		private const double InitialPecentage = 0.4d;
		private const string ButtonStartText = "开始";
		private const string ButtonStopText = "停止";

		private const string BtccPrefix = "btcc";
		private const string HuobiPrefix = "huobi";

		private const int InitialStrategyCount = 3;
		private static int _strategyControlsCount;

		private static readonly string[] Titles =
		{
			"策略ID", "交易阙值\n更新时间", "交易阙值", "交易阙值\n增量", "交易阙值\n系数", "回归阙值", "回归阙值\n增量", "回归阙值\n系数", "交易延时\n阙值", "交易次数\n阙值",
			"总交易次数\n阙值",
			"周期", "每次交易个数", "交易数量"
		};


		private static readonly List<Strategy1> _strategies = new List<Strategy1>();
		private static readonly TimerList _strategyTimerList = new TimerList();

		private readonly Dictionary<string, Account> _accounts = new Dictionary<string, Account>
		{
			{BtccPrefix, new SimulateAccount()},
			{HuobiPrefix, new SimulateAccount()}
		};

		//private List<int> _strategyCounters = new List<int>();

		private readonly Dictionary<string, double> _prices = new Dictionary<string, double>
		{
			{BtccPrefix, 0},
			{HuobiPrefix, 0}
		};

		//额外有两列放按钮
		private readonly int StrategyControlColumnCount = Titles.Length + 1;

		private double _baseDifferPrice;

		private double _initialTotalBalance;
		private double _initialTotalCoinAmount;

		private bool _inRealMode;


		public Form4()
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

			tableLayoutPanelStrategies.Controls.Add(
				new Button
				{
					Name = "btnAddStrategy",
					Text = "增加策略",
					BackColor = Color.LightGreen,
					Dock = DockStyle.Fill,
					Width = 80
				}, Titles.Length, 0);

			tableLayoutPanelStrategies.Controls.Add(
				new Button
				{
					Name = "btnRemoveStrategy",
					Text = "减少策略",
					BackColor = Color.LightCoral,
					Dock = DockStyle.Fill,
					Width = 80
				}, Titles.Length + 1, 0);
		}

		private void GenerateStrategyControls()
		{
			var strategyControlId = _strategyControlsCount;

			var rowPosition = strategyControlId + 1;
			var columnPosition = 0;
			//策略号

			tableLayoutPanelStrategies.Controls.Add(
				new Label
				{
					Name = $"{ControlName.lblStrategyID}{strategyControlId}",
					Text = rowPosition.ToString(),
					Dock = DockStyle.Fill,
					TextAlign = ContentAlignment.MiddleCenter
				}, columnPosition++, rowPosition);

			//交易阙值更新时间
			tableLayoutPanelStrategies.Controls.Add(
				new Label
				{
					Name = $"{ControlName.lblTradeThresholdLastUpdated}{strategyControlId}",
					Text = rowPosition.ToString(),
					Dock = DockStyle.Fill,
					TextAlign = ContentAlignment.MiddleCenter,
					Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold)
				}, columnPosition++, rowPosition);


			//交易阙值
			tableLayoutPanelStrategies.Controls.Add(
				new Label
				{
					Name = $"{ControlName.lblTradeThreshold}{strategyControlId}",
					Text = (rowPosition + 1).ToString(),
					Dock = DockStyle.Fill,
					TextAlign = ContentAlignment.MiddleCenter,
					Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold)
				}, columnPosition++,
				rowPosition);
			//启动阙值增量
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"{ControlName.nudTradeThresholdIncrement}{strategyControlId}",
					Maximum = int.MaxValue,
					Minimum = int.MinValue,
					Value = 0,
					Dock = DockStyle.Fill,
					DecimalPlaces = 3,
					Increment = 0.001M,
					Width = 30
				}, columnPosition++, rowPosition);
			//30
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"{ControlName.nudTradeThresholdCoefficient}{strategyControlId}",
					Maximum = int.MaxValue,
					Minimum = 0,
					Value = 1 + strategyControlId * 0.3M,
					DecimalPlaces = 3,
					Increment = 0.001M,
					Dock = DockStyle.Fill,
					Width = 30
				}, columnPosition++, rowPosition);


			//回归阙值
			tableLayoutPanelStrategies.Controls.Add(
				new Label
				{
					Name = $"{ControlName.lblRegressionThreshold}{strategyControlId}",
					Text = "0",
					Dock = DockStyle.Fill,
					TextAlign = ContentAlignment.MiddleCenter,
					Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold)
				}, columnPosition++,
				rowPosition);

			//回归阙值增量
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"{ControlName.nudRegressionThresholdIncrement}{strategyControlId}",
					Maximum = int.MaxValue,
					Minimum = int.MinValue,
					Value = 0,
					Increment = 0.001M,
					Dock = DockStyle.Fill,
					Width = 30
				}, columnPosition++, rowPosition);

			//回归阙值系数
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"{ControlName.nudRegressionThresholdCoefficient}{strategyControlId}",
					Maximum = int.MaxValue,
					Minimum = int.MinValue,
					Value = 0.5M,
					DecimalPlaces = 3,
					Increment = 0.001M,
					Dock = DockStyle.Fill,
					Width = 30
				}, columnPosition++, rowPosition);

			//最小时间间隔
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"{ControlName.nudTradeLagThreshold}{strategyControlId}",
					Maximum = int.MaxValue,
					Minimum = 0,
					Value = 0,
					DecimalPlaces = 0,
					Increment = 1,
					Dock = DockStyle.Fill,
					Width = 30
				}, columnPosition++, rowPosition);

			//
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"{ControlName.nudTradeCountThreshold}{strategyControlId}",
					Maximum = int.MaxValue,
					Minimum = 0,
					Value = 0,
					DecimalPlaces = 0,
					Increment = 1,
					Dock = DockStyle.Fill,
					Width = 30
				}, columnPosition++, rowPosition);

			//策略成交总数量限制
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"{ControlName.nudTotalTradeCountLimit}{strategyControlId}",
					Maximum = int.MaxValue,
					Minimum = 1,
					Value = 9999999,
					DecimalPlaces = 0,
					Increment = 1,
					Dock = DockStyle.Fill,
					Width = 40
				}, columnPosition++, rowPosition);

			//周期
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"{ControlName.nudPeriod}{strategyControlId}",
					Maximum = int.MaxValue,
					Minimum = 1,
					Value = Convert.ToInt32(Math.Pow(2, strategyControlId)),
					DecimalPlaces = 0,
					Increment = 1,
					Dock = DockStyle.Fill,
					Width = 40
				}, columnPosition++, rowPosition);

			//每次交易个数
			tableLayoutPanelStrategies.Controls.Add(
				new NumericUpDown
				{
					Name = $"{ControlName.nudTradeAmount}{strategyControlId}",
					Maximum = int.MaxValue,
					Minimum = 0,
					Value = 0.001M,
					DecimalPlaces = 4,
					Increment = 0.001M,
					Dock = DockStyle.Fill,
					Width = 40
				}, columnPosition++, rowPosition);


			//交易数量
			tableLayoutPanelStrategies.Controls.Add(
				new Label
				{
					Name = $"{ControlName.lblTotalTradeCount}{strategyControlId}",
					Text = rowPosition.ToString(),
					Dock = DockStyle.Fill,
					TextAlign = ContentAlignment.MiddleCenter,
					Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold)
				}, columnPosition++, rowPosition);


			//开始按钮
			var btnStart = new Button
			{
				Name = $"{ControlName.btnStartStopStrategy}{strategyControlId}",
				Text = "开始",
				BackColor = Color.LightGreen,
				TextAlign = ContentAlignment.MiddleCenter,
				Dock = DockStyle.Fill,
				Tag = strategyControlId
			};
			btnStart.Click += btnStartStopStrategy_Click;

			tableLayoutPanelStrategies.Controls.Add(btnStart, columnPosition++, rowPosition);

			_strategyControlsCount++;
		}

		private void StopStrategy(int strategyId)
		{
			_strategyTimerList.Timers[strategyId.ToString()].Change(Timeout.Infinite, Timeout.Infinite);
		}

		private void RemoveStrategy(int strategyId)
		{
			//_strategies.Remove()
			//_strategyTimerList.Timers[strategyId.ToString()].Change(Timeout.Infinite, Timeout.Infinite);
			_strategies.RemoveAt(strategyId);
			var timer = _strategyTimerList.Timers[strategyId.ToString()];
			_strategyTimerList.Timers.Remove(strategyId.ToString());
			timer.Dispose();
		}

		private void btnStartStopStrategy_Click(object sender, EventArgs e)
		{
			var strategyId = Convert.ToInt32((sender as Button).Tag);

			var button = sender as Button;

			if (button != null && button.Text == ButtonStartText)
			{
				StartStrategy(strategyId);
				(sender as Button).BackColor = Color.LightCoral;
				(sender as Button).Text = ButtonStopText;
			}
			else
			{
				StopStrategy(strategyId);
				((Button) sender).BackColor = Color.LightGreen;
				((Button) sender).Text = ButtonStartText;
			}
		}

		private void StartStrategy(int strategyId)
		{
			_strategyTimerList.Timers[strategyId.ToString()].Change(0,
				_strategies[strategyId].InputParameters.Peroid * 1000);
		}

		//add a new strategy
		private void AddStrategy()
		{
			var strategyId = _strategyControlsCount - 1;
			var strategy = new Strategy1
			{
				Id = strategyId,
				InputParameters = GetStrategyParameters(strategyId),
				//InputParameters = GetStrategyParameters(strategyId).Result,
				PreviousStrategy = strategyId == 0 ? null : _strategies[strategyId - 1]
			};
			_strategies.Add(strategy);

//            double tradeAmount = Convert.ToDouble(nudTradeAmount.Value);
			//need await here?
			//need task here?
			_strategyTimerList.Add(strategyId.ToString(), Timeout.Infinite, async o =>
			{
				await Task.Run(() =>
				{
					strategy.Update(GetStrategyParameters(strategy.Id));
					strategy.TryTrade(_accounts, new Dictionary<string, double>
					{
						{BtccPrefix, _prices[BtccPrefix]},
						{HuobiPrefix, _prices[HuobiPrefix]}
					}, strategy.InputParameters.TradeAmount);
				});
			});
		}


		private void Strategy_Updated(int strategyId)
		{
			ShowStrategyValues(_strategies[strategyId]);
		}

		private void Form4_Load(object sender, EventArgs e)
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

			tableLayoutPanelStrategies.Controls["btnAddStrategy"].Enabled = true;
			tableLayoutPanelStrategies.Controls["btnRemoveStrategy"].Enabled = true;
			tableLayoutPanelStrategies.Controls["btnAddStrategy"].Click += btnAddStrategy_Click;
			tableLayoutPanelStrategies.Controls["btnAddStrategy"].Click += CheckControlStatus;
			tableLayoutPanelStrategies.Controls["btnRemoveStrategy"].Click += btnRemoveStrategy_Click;
			tableLayoutPanelStrategies.Controls["btnRemoveStrategy"].Click += CheckControlStatus;

			//set gridview font size
			gdvBtccTrades.ColumnHeadersDefaultCellStyle.Font = new Font(gdvBtccTrades.DefaultCellStyle.Font.FontFamily,
				9);
			gdvBtccTrades.DefaultCellStyle.Font = new Font(gdvBtccTrades.DefaultCellStyle.Font.FontFamily, 9);
//			gdvHuobiTrades.ColumnHeadersDefaultCellStyle.Font = new Font(
//				gdvBtccTrades.DefaultCellStyle.Font.FontFamily, 9);
//			gdvHuobiTrades.DefaultCellStyle.Font = new Font(gdvBtccTrades.DefaultCellStyle.Font.FontFamily, 9);
		}

		private void Form4_Activated(object sender, EventArgs e)
		{
		}

		private void Form4_Shown(object sender, EventArgs e)
		{
			//accounts must be set first (because accounts is need in strategy)
			//show accounts for the first time
			trackBar1_ValueChanged(null, null);

			for (var i = 0; i < InitialStrategyCount; i++)
			{
				GenerateStrategyControls();
				AddStrategy();
			}
		}

		private void btnAddStrategy_Click(object sender, EventArgs e)
		{
			if (_strategies.Count < StrategyMaxQuantity)
			{
				GenerateStrategyControls();
				AddStrategy();
			}
		}

		private void RemoveStrategy()
		{
			//must before removing the strategy, or the .Count is not correct
			var strategyId = _strategies.Count - 1;
			var timer = _strategyTimerList.Timers[strategyId.ToString()];
			_strategyTimerList.Timers.Remove(strategyId.ToString());
			timer.Dispose();
			_strategies.Remove(_strategies[strategyId]);
		}

		private void RemoveStrategyControls()
		{
			var controlCount = tableLayoutPanelStrategies.Controls.Count;
			for (var i = controlCount - 1;
				i >= controlCount - StrategyControlColumnCount;
				i--)
			{
				tableLayoutPanelStrategies.Controls.Remove(tableLayoutPanelStrategies.Controls[i]);
			}
			_strategyControlsCount--;
		}

		private void CheckControlStatus(object sender, EventArgs e)
		{
			if (_strategies.Count == StrategyMaxQuantity)
			{
				tableLayoutPanelStrategies.Controls["btnAddStrategy"].Enabled = false;
			}
			else if (_strategies.Count == StrategyMinQuantity)
			{
				tableLayoutPanelStrategies.Controls["btnRemoveStrategy"].Enabled = false;
			}
			else
			{
				tableLayoutPanelStrategies.Controls["btnAddStrategy"].Enabled = true;
				tableLayoutPanelStrategies.Controls["btnRemoveStrategy"].Enabled = true;
			}
		}

		private void btnRemoveStrategy_Click(object sender, EventArgs e)
		{
			if (_strategies.Count > StrategyMinQuantity)
			{
				RemoveStrategy();
				RemoveStrategyControls();
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
			//_accounts.Clear();
			var totalBalance = _accounts[BtccPrefix].Balance + _accounts[HuobiPrefix].Balance;
			var totalCoinAmount = _accounts[BtccPrefix].CoinAmount + _accounts[HuobiPrefix].CoinAmount;

			_accounts[BtccPrefix].Balance = Math.Round(totalBalance * pecentage);
			_accounts[BtccPrefix].CoinAmount = Math.Round(totalCoinAmount * (1 - pecentage));

			_accounts[HuobiPrefix].Balance = Math.Round(totalBalance * (1 - pecentage));
			_accounts[HuobiPrefix].CoinAmount = Math.Round(totalCoinAmount * pecentage);
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

		private
			void GetPrices()
		{
			if (
				Tag != null)
			{
				var prices = Tag as Dictionary<string, double>;

				if (
					prices != null && prices.Count
					== 2)
				{
					_prices[BtccPrefix] = prices[BtccPrefix];
					_prices[HuobiPrefix] = prices[HuobiPrefix];
					_baseDifferPrice = Math.Abs(_prices[BtccPrefix] - _prices[HuobiPrefix]);
				}
			}
		}

		private
			void timer1_Tick(object sender, EventArgs e)
		{
			GetPrices();
			ShowPrices();

			//            foreach (var s in _strategies)
			//            {
			//                ChangeStrategyValues(s);
			//            }

			ShowAccounts();

			for (
				var i = 0;
				i < _strategies.Count;
				i
					++)
			{
				ShowStrategyValues(_strategies[i]);
			}

			ShowTrades();
		}

		//for btcc, huobi and differ price
		private
			void ShowPrices()
		{
			_baseDifferPrice
				=
				Math.Abs
					(_prices[BtccPrefix]
					 -
					 _prices[HuobiPrefix]);
			lblBtccPrice.Text
				= $"BTCC{Environment.NewLine}{_prices[BtccPrefix].ToString("0.000")}";
			lblHuobiPrice.Text
				= $"HUOBI{Environment.NewLine}{_prices[HuobiPrefix].ToString("0.000")}";
			lblDifferPrice.Text
				= $"差价{Environment.NewLine}{_baseDifferPrice.ToString("0.000")}";
			lblTotalProfits.Text
				=
				$"总利润{Environment.NewLine}{(_accounts[BtccPrefix].Balance + _accounts[HuobiPrefix].Balance - _initialTotalBalance).ToString("0.000")}";

			if (
				_prices[BtccPrefix]
				>
				_prices[HuobiPrefix]
				)
			{
				lblDifferPrice.Text = lblDifferPrice.Text.Insert(4, "<< ");
			}
			else if (
				_prices[BtccPrefix] < _prices[HuobiPrefix])
			{
				lblDifferPrice.Text
					=
					lblDifferPrice.Text
					+ @" >>";
			}
		}

		private void Form4_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void ShowStrategyValues(Strategy1 strategy)
		{
			(tableLayoutPanelStrategies.Controls[$"{ControlName.lblTradeThreshold}{strategy.Id}"] as Label).Text =
				strategy.TradeThreshold.ToString("0.000");

			(tableLayoutPanelStrategies.Controls[$"{ControlName.lblRegressionThreshold}{strategy.Id}"] as Label).Text =
				strategy.RegressionThreshold.ToString("0.000");

			(tableLayoutPanelStrategies.Controls[$"{ControlName.lblStrategyID}{strategy.Id}"] as Label).Text =
				(strategy.Id + 1).ToString();

			(tableLayoutPanelStrategies.Controls[$"{ControlName.lblTradeThresholdLastUpdated}{strategy.Id}"] as Label)
				.Text =
				strategy.TradeThresholdLastUpdated.ToString("HH:mm:ss");
			(tableLayoutPanelStrategies.Controls[$"{ControlName.lblTotalTradeCount}{strategy.Id}"] as Label)
				.Text =
				strategy.TradeCount.ToString();
		}

		private Strategy1.StrategyInputParameters GetStrategyParameters(int strategyId)
		{
			const string floatRegex = @"^(-?\d+)(\.\d+)?$";
			const string integerRegex = @"^(\+|-)?\d+$";

			var s1 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeThresholdIncrement}{strategyId}"] as
				NumericUpDown).Text;


			var s2 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeThresholdCoefficient}{strategyId}"]
				as
				NumericUpDown).Text;

			var s3 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeLagThreshold}{strategyId}"] as
				NumericUpDown).Text;
			var s4 =
				(tableLayoutPanelStrategies.Controls[
					$"{ControlName.nudRegressionThresholdIncrement}{strategyId}"]
					as NumericUpDown).Text;
			var s5 =
				(tableLayoutPanelStrategies.Controls[
					$"{ControlName.nudRegressionThresholdCoefficient}{strategyId}"]
					as NumericUpDown).Text;

			var s6 = nudStartPrice.Text;
			var s7 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudPeriod}{strategyId}"]
				as NumericUpDown).Text;

			var s8 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTotalTradeCountLimit}{strategyId}"]
				as NumericUpDown).Text;

			var s9 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeAmount}{strategyId}"] as
				NumericUpDown).Text;


			var parameters = new Strategy1.StrategyInputParameters
			{
				TradeThresholdIncrement = Regex.IsMatch(s1, floatRegex) ? Convert.ToDouble(s1) : 0,
				TradeThresholdCoefficient = Regex.IsMatch(s2, floatRegex) ? Convert.ToDouble(s2) : 0,
				TradeLagThreshold = Regex.IsMatch(s3, integerRegex) ? Convert.ToInt32(s3) : 0,
				RegressionThresholdIncrement = Regex.IsMatch(s4, floatRegex) ? Convert.ToDouble(s4) : 0,
				RegressionThresholdCoefficient = Regex.IsMatch(s5, floatRegex) ? Convert.ToDouble(s5) : 0,
				StartPrice = Regex.IsMatch(s6, floatRegex) ? Convert.ToDouble(s6) : 3,
				Peroid = Regex.IsMatch(s7, integerRegex) ? Convert.ToInt32(s7) : 1,
				TotalTradeCountLimit = Regex.IsMatch(s8, integerRegex) ? Convert.ToInt32(s8) : 9999999,
				TradeAmount = Regex.IsMatch(s9, floatRegex) ? Convert.ToDouble(s9) : 0.001
			};


			if (strategyId == 0)
			{
				parameters.BaseThreshold = _baseDifferPrice;
			}
			else
			{
				parameters.BaseThreshold = _strategies[strategyId - 1].TradeThreshold;
			}

			parameters.DifferPrice = _baseDifferPrice;
			//            currentStrategy.InputParameters.TradeQuantityThreshold =
			//                Convert.ToInt32(
			//                    (tableLayoutPanelStrategies.Controls[$"{ControlNames[8]}{index}"] as TextBox).Text);
			return parameters;
		}

		private void btnAllStart_Click(object sender, EventArgs e)
		{
			//            foreach (var s in _strategies)
			//            {
			//                StartStrategy(s.Id);
			//            }


			for (var i = 0; i < _strategyControlsCount; i++)
			{
				var button = tableLayoutPanelStrategies.Controls[$"{ControlName.btnStartStopStrategy}{i}"];

				if (button.Text == ButtonStartText)
				{
					btnStartStopStrategy_Click(button, null);
				}
			}
		}

		private void btnAllStop_Click(object sender, EventArgs e)
		{
			var strategyCount = _strategies.Count;
			for (var i = strategyCount - 1; i >= 0; i--)
			{
				var button = tableLayoutPanelStrategies.Controls[$"{ControlName.btnStartStopStrategy}{i}"];

				if (button.Text == ButtonStopText)
				{
					btnStartStopStrategy_Click(button, null);
				}
			}
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

			gdvBtccTrades.DataSource = totalTrades.ToList();
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
			_accounts[BtccPrefix] = btccAccount;

			var huobiAccount = new RealAccount {Trader = new HuobiTrader()};
			accountInfo = huobiAccount.Trader.GetAccountInfo();
			huobiAccount.Balance = accountInfo.AvailableCny;
			huobiAccount.CoinAmount = accountInfo.AvailableBtc;
			_accounts[HuobiPrefix] = huobiAccount;

			_initialTotalBalance = btccAccount.Balance + huobiAccount.Balance;
			_initialTotalCoinAmount = btccAccount.CoinAmount + huobiAccount.CoinAmount;
		}

		private void UpdateRealAccount()
		{
			var btccAccount = _accounts[BtccPrefix];
//		    btccAccount.Trader = new BtccTrader();
			var accountInfo = btccAccount.Trader.GetAccountInfo();
			btccAccount.Balance = accountInfo.AvailableCny;
			btccAccount.CoinAmount = accountInfo.AvailableBtc;
			_accounts[BtccPrefix] = btccAccount;

			var huobiAccount = _accounts[HuobiPrefix];
//			huobiAccount.Trader = new HuobiTrader();
			accountInfo = huobiAccount.Trader.GetAccountInfo();
			huobiAccount.Balance = accountInfo.AvailableCny;
			huobiAccount.CoinAmount = accountInfo.AvailableBtc;
			_accounts[HuobiPrefix] = huobiAccount;
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
			lblStrategyID = 0,
			lblTradeThresholdLastUpdated,
			lblTradeThreshold,
			nudTradeThresholdIncrement,
			nudTradeThresholdCoefficient,
			lblRegressionThreshold,
			nudRegressionThresholdIncrement,
			nudRegressionThresholdCoefficient,
			nudTradeLagThreshold,
			nudTradeCountThreshold,
			nudTotalTradeCountLimit,
			nudPeriod,
			nudTradeAmount,
			lblTotalTradeCount,
			btnStartStopStrategy
		}
	}
}