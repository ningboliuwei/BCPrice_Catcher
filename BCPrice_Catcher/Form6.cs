#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCPrice_Catcher.Class;
using BCPrice_Catcher.Model;
using BCPrice_Catcher.Trader;

#endregion

namespace BCPrice_Catcher
{
	[Guid("B4B1879D-17FD-44CF-8D31-6DD9C0115186")]
	public partial class Form6 : Form
	{
//		private const int StrategyMaxQuantity = 9;
//		private const int StrategyMinQuantity = 1;
		private const double InitialPecentage = 0.4d;
		private const string ButtonStartText = "开始(&S)";
		private const string ButtonStopText = "停止(&T)";

		private const string OutSitePrefix = "btcc";
		private const string InSitePrefix = "huobi";

		//买或卖的数量限制
		private const int BookOrdersCount = 5;

		private const int InitialRowCount = 5;

		private static readonly string[] OutSiteTitles =
		{
			"", "卖价", "量", "", "买价", "量"
		};

		private static readonly string[] InSiteTitles =
		{
			"", "卖价", "量", "", "买价", "量"
		};

		private static readonly List<Strategy2> _strategies = new List<Strategy2>();
		private static readonly TimerList _strategyTimerList = new TimerList();

		private readonly Dictionary<string, Account> _accounts = new Dictionary<string, Account>
		{
			{OutSitePrefix, new SimulateAccount()},
			{InSitePrefix, new SimulateAccount()}
		};

		private readonly Dictionary<string, List<BookOrderInfo>> _buyBookOrders = new Dictionary<string, List<BookOrderInfo>>
		{
			{OutSitePrefix, null},
			{InSitePrefix, null}
		};

		//private List<int> _strategyCounters = new List<int>();

		private readonly Dictionary<string, double> _prices = new Dictionary<string, double>
		{
			{OutSitePrefix, 0},
			{InSitePrefix, 0}
		};

		private readonly Dictionary<string, List<BookOrderInfo>> _sellBookOrders = new Dictionary<string, List<BookOrderInfo>>
		{
			{OutSitePrefix, null},
			{InSitePrefix, null}
		};

		//		private readonly int _strategyControlColumnCount = Titles.Length;

		private double _baseDifferPrice;

		private double _initialTotalBalance;
		private double _initialTotalCoinAmount;

		private bool _inRealMode;


		public Form6()
		{
			InitializeComponent();
		}

		private void GenerateOrderBookControls(TableLayoutPanel tableLayoutPanel, string[] titles, Color rowHeaderColor,
			Color columnHeaderColor)
		{
			for (var i = 0; i < titles.Length; i++)
			{
				#region 标题

				tableLayoutPanel.Controls.Add(
					new Label
					{
						Text = titles[i],
						TextAlign = ContentAlignment.MiddleCenter,
						AutoSize = false,
						Dock = DockStyle.Fill,
						Font = new Font(Font.FontFamily, Font.Size + 3, Font.Style | FontStyle.Bold),
						BackColor = rowHeaderColor,
						Margin = new Padding(0),
						Padding = new Padding(0)
					}, i, 0);

				#endregion
			}

			for (var i = 0; i < InitialRowCount; i++)
			{
				var rowPosition = i + 1;
				var columnPosition = 0;

				#region 卖N

				var panelSellRowHeader = new Panel
				{
					BackColor = columnHeaderColor,
					Margin = new Padding(0),
					Padding = new Padding(0),
					Dock = DockStyle.Fill
				};

				panelSellRowHeader.Controls.Add(
					new Label
					{
						Text = $"卖 {InitialRowCount - i}",
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold),
						BackColor = Color.Transparent,
						Dock = DockStyle.Fill
					});

				tableLayoutPanel.Controls.Add(panelSellRowHeader, 0, rowPosition);

				#endregion

				#region 卖价

				var panelSellPrice = new Panel
				{
					Name = $"panelSellPrice" + i,
					BackColor = Color.LightCoral,
					Margin = new Padding(0),
					Padding = new Padding(0),
					Dock = DockStyle.Fill
				};

				panelSellPrice.Controls.Add(
					new Label
					{
						Name = $"{ControlName.lblSellPrice}{i}",
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold),
						BackColor = Color.Transparent,
						Dock = DockStyle.Fill,
						ForeColor = Color.DarkRed
					});

				tableLayoutPanel.Controls.Add(panelSellPrice, 1, rowPosition);

				#endregion

				#region 卖量

				var panelSellAmount = new Panel
				{
					Name = $"panelSellAmount" + i,
					BackColor = Color.LightCoral,
					Margin = new Padding(0),
					Padding = new Padding(0),
					Dock = DockStyle.Fill
				};

				panelSellAmount.Controls.Add(
					new Label
					{
						Name = $"{ControlName.lblSellAmount}{i}",
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold),
						BackColor = Color.Transparent,
						Dock = DockStyle.Fill,
						ForeColor = Color.DarkRed
					});

				tableLayoutPanel.Controls.Add(panelSellAmount, 2, rowPosition);

				#endregion

				#region 买N

				var panelBuyRowHeader = new Panel
				{
					Dock = DockStyle.Fill,
					BackColor = columnHeaderColor,
					Margin = new Padding(0),
					Padding = new Padding(0)
				};

				panelBuyRowHeader.Controls.Add(
					new Label
					{
						Text = $"买 {rowPosition}",
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold),
						BackColor = Color.Transparent,
						Dock = DockStyle.Fill
					});

				tableLayoutPanel.Controls.Add(panelBuyRowHeader, 3, rowPosition);

				#endregion

				#region 买价

				var panelBuyPrice = new Panel
				{
					Name = $"panelBuyPrice" + i,
					BackColor = Color.LightGreen,
					Margin = new Padding(0),
					Padding = new Padding(0),
					Dock = DockStyle.Fill
				};

				panelBuyPrice.Controls.Add(
					new Label
					{
						Name = $"{ControlName.lblBuyPrice}{i}",
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold),
						BackColor = Color.Transparent,
						Dock = DockStyle.Fill,
						ForeColor = Color.DarkGreen
					});

				tableLayoutPanel.Controls.Add(panelBuyPrice, 4, rowPosition);

				#endregion

				#region 买量

				var panelBuyAmount = new Panel
				{
					Name = $"panelBuyAmount" + i,
					BackColor = Color.LightGreen,
					Margin = new Padding(0),
					Padding = new Padding(0),
					Dock = DockStyle.Fill
				};

				panelBuyAmount.Controls.Add(
					new Label
					{
						Name = $"{ControlName.lblBuyAmount}{i}",
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold),
						BackColor = Color.Transparent,
						Dock = DockStyle.Fill,
						ForeColor = Color.DarkGreen
					});

				tableLayoutPanel.Controls.Add(panelBuyAmount, 5, rowPosition);

				#endregion
			}
		}

		private void StopStrategy(int strategyId)
		{
			_strategyTimerList.Timers[strategyId.ToString()].Change(Timeout.Infinite, Timeout.Infinite);
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
			
			var button = sender as Button;

			if (button != null && button.Text == ButtonStartText)
			{
				StartStrategy(-1);
				(sender as Button).BackColor = Color.LightCoral;
				(sender as Button).Text = ButtonStopText;
			}
			else
			{
				StopStrategy(-1);
				((Button) sender).BackColor = Color.LightGreen;
				((Button) sender).Text = ButtonStartText;
			}
		}

		private void StartStrategy(int strategyId)
		{
			_strategyTimerList.Timers[strategyId.ToString()].Change(0,
				1 * 1000);
		}

		//add a new strategy
		private void AddStrategy()
		{
			var strategyId = -1;
			var strategy = new Strategy2
			{
				InputParameters = GetStrategyParameters(),
			};

			_strategies.Add(strategy);

			_strategyTimerList.Add(strategyId.ToString(), Timeout.Infinite, async o =>
			{
				await Task.Run(() =>
				{
					strategy.Update(GetStrategyParameters());

					
						strategy.TryTrade(_accounts, new Dictionary<string, double>
						{
							{OutSitePrefix, _prices[OutSitePrefix]},
							{InSitePrefix, _prices[InSitePrefix]}
						}, strategy.m);
					
				});
			});


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
//			tableLayoutPanelOutSite.Visible = false;
			//            tableLayoutPanelStrategies.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
//			tableLayoutPanelBookOrders.Visible = true;
//			GenerateTitleControls();

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

			btnCancelAllOrders.Enabled = false;
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
			GenerateOrderBookControls(tableLayoutPanelOutSite, OutSiteTitles, lblBtccPrice.BackColor, lblBtccAccount.BackColor);
			GenerateOrderBookControls(tableLayoutPanelInSite, InSiteTitles, lblHuobiPrice.BackColor, lblHuobiAccount.BackColor);
							AddStrategy();
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

		private void Form6_Paint(object sender, PaintEventArgs e)
		{
		}

		private void Form6_ResizeBegin(object sender, EventArgs e)
		{
		}

		private void Form6_ResizeEnd(object sender, EventArgs e)
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

			//unelegent
			if (_strategies.Count != 0)
			{
				_strategies[0].InputParameters.SiteAAmount = _accounts["btcc"].CoinAmount;
				_strategies[0].InputParameters.SiteBAmount = _accounts["huobi"].CoinAmount;
			}
		}

		private void trackBar1_ValueChanged(object sender, EventArgs e)
		{
			AdjustAccounts(Convert.ToDouble(tckPecentage.Value) / tckPecentage.Maximum);
			ShowAccounts();
		}

		private void GetInfos()
		{
			if (Tag != null)
			{
				var infos = Tag as Dictionary<string, object>;

				if (infos.Count != 0)
				{
					_prices[OutSitePrefix] = Convert.ToDouble(infos?["btcc_price"]);
					_prices[InSitePrefix] = Convert.ToDouble(infos?["huobi_price"]);

					_sellBookOrders[OutSitePrefix] = (infos["btcc_bookorders"] as List<BookOrderInfo>).Take(BookOrdersCount).ToList();
					_sellBookOrders[InSitePrefix] = (infos["huobi_bookorders"] as List<BookOrderInfo>).Take(BookOrdersCount).ToList();

					_buyBookOrders[OutSitePrefix] =
						(infos["btcc_bookorders"] as List<BookOrderInfo>).Skip(BookOrdersCount).Take(BookOrdersCount).ToList();
					_buyBookOrders[InSitePrefix] =
						(infos["huobi_bookorders"] as List<BookOrderInfo>).Skip(BookOrdersCount).Take(BookOrdersCount).ToList();

					//					_baseDifferPrice = Math.Abs(_prices[OutSitePrefix] - _prices[InSitePrefix]);
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			GetInfos();
			ShowPrices();
			ShowBookOrders(tableLayoutPanelOutSite, _sellBookOrders[OutSitePrefix], _buyBookOrders[OutSitePrefix]);
			ShowBookOrders(tableLayoutPanelInSite, _sellBookOrders[InSitePrefix], _buyBookOrders[InSitePrefix]);

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
			ShowTrades();

			ShowStrategyInfo();
			


		}

		private void ShowStrategyInfo()
		{
			if (_strategies.Count != 0)
			{
				var s = _strategies[0];

				lblM.Text = "Min" + s.InputParameters.Min + Environment.NewLine
				            + "a" + s.InputParameters.a + Environment.NewLine
				            + "b" + s.InputParameters.b + Environment.NewLine
				            + "Z" + s.InputParameters.Z + Environment.NewLine
				            + "siteAamount" + s.InputParameters.SiteAAmount + Environment.NewLine
				            + "siteBamount" + s.InputParameters.SiteBAmount + Environment.NewLine
				            + "m" + s.m + Environment.NewLine
				            + "A" + s.A + Environment.NewLine
				            + "B" + s.B + Environment.NewLine
				            + "X" + s.X + Environment.NewLine
				            + "Y" + s.Y + Environment.NewLine;
			}
		}

		//for btcc, huobi and differ price
		private void ShowPrices()
		{
			_baseDifferPrice = Math.Abs(_prices[OutSitePrefix] - _prices[InSitePrefix]);
			lblBtccPrice.Text
				= $"BTCC{Environment.NewLine}{_prices[OutSitePrefix].ToString("0.000")}";
			lblHuobiPrice.Text
				= $"HUOBI{Environment.NewLine}{_prices[InSitePrefix].ToString("0.000")}";
			lblDifferPrice.Text
				= $"差价{Environment.NewLine}{_baseDifferPrice.ToString("0.000")}";
			lblTotalProfits.Text
				=
				$"总利润{Environment.NewLine}{(_accounts[OutSitePrefix].Balance + _accounts[InSitePrefix].Balance - _initialTotalBalance).ToString("0.000")}";

			if (_prices[OutSitePrefix] > _prices[InSitePrefix]
				)
			{
				lblDifferPrice.Text = lblDifferPrice.Text.Insert(4, "<< ");
			}
			else if (
				_prices[OutSitePrefix] < _prices[InSitePrefix])
			{
				lblDifferPrice.Text = lblDifferPrice.Text + @" >>";
			}
		}

		private void ShowBookOrders(TableLayoutPanel tableLayoutPanel, List<BookOrderInfo> sellBookOrders,
			List<BookOrderInfo> buyBookOrders)
		{
			if (sellBookOrders != null && sellBookOrders.Count != 0)
			{
				for (var i = 0; i < InitialRowCount; i++)
				{
					((Label) ((Panel) tableLayoutPanel.Controls["panelSellPrice" + i]).Controls[$"{ControlName.lblSellPrice}{i}"]).Text
						=
						sellBookOrders[i].Price.ToString("0.00");

					((Label) ((Panel) tableLayoutPanel.Controls["panelSellAmount" + i]).Controls[$"{ControlName.lblSellAmount}{i}"])
						.Text =
						sellBookOrders[i].Amount.ToString();

					((Label) ((Panel) tableLayoutPanel.Controls["panelBuyPrice" + i]).Controls[$"{ControlName.lblBuyPrice}{i}"]).Text
						=
						buyBookOrders[i].Price.ToString("0.00");

					((Label) ((Panel) tableLayoutPanel.Controls["panelBuyAmount" + i]).Controls[$"{ControlName.lblBuyAmount}{i}"]).Text
						=
						buyBookOrders[i].Amount.ToString();
				}
			}
		}

		private void Form4_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void ShowStrategyValues(Strategy1 strategy)
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

		private Strategy2.StrategyInputParameters GetStrategyParameters()
		{
			const string floatRegex = @"^(-?\d+)(\.\d+)?$";
//			const string integerRegex = @"^(\+|-)?\d+$";

			var s1 = nudParaMin.Text;
			var s2 = nudParaA.Text;
			var s3 = nudParaB.Text;
			var s4 = nudParaZ.Text;
//			var s5 =
//				(tableLayoutPanelStrategies.Controls[
//					$"{ControlName.nudRegressionThresholdCoefficient}{strategyId}"]
//					as NumericUpDown).Text;
//
//			var s6 = nudParaMin.Text;
//			var s7 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudPeriod}{strategyId}"]
//				as NumericUpDown).Text;
//
//			var s8 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTotalTradeCountLimit}{strategyId}"]
//				as NumericUpDown).Text;
//
//			var s9 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeAmount}{strategyId}"] as
//				NumericUpDown).Text;


			var parameters = new Strategy2.StrategyInputParameters
			{
				a = Regex.IsMatch(s1, floatRegex) ? Convert.ToDouble(s1) : 0,
				b = Regex.IsMatch(s1, floatRegex) ? Convert.ToDouble(s1) : 0,
				Min = Regex.IsMatch(s1, floatRegex) ? Convert.ToDouble(s1) : 1,
				Z = Regex.IsMatch(s1, floatRegex) ? Convert.ToDouble(s1) : 0,
				SellBookOrders = _sellBookOrders[OutSitePrefix],
				BuyBookOrders = _buyBookOrders[InSitePrefix],


				//				TradeThresholdIncrement = Regex.IsMatch(s1, floatRegex) ? Convert.ToDouble(s1) : 0,
				//				TradeThresholdCoefficient = Regex.IsMatch(s2, floatRegex) ? Convert.ToDouble(s2) : 0,
				//				TradeLagThreshold = Regex.IsMatch(s3, integerRegex) ? Convert.ToInt32(s3) : 0,
				//				RegressionThresholdIncrement = Regex.IsMatch(s4, floatRegex) ? Convert.ToDouble(s4) : 0,
				//				RegressionThresholdCoefficient = Regex.IsMatch(s5, floatRegex) ? Convert.ToDouble(s5) : 0,
				//				StartPrice = Regex.IsMatch(s6, floatRegex) ? Convert.ToDouble(s6) : 3,
				//				Peroid = Regex.IsMatch(s7, integerRegex) ? Convert.ToInt32(s7) : 1,
				//				TotalTradeCountLimit = Regex.IsMatch(s8, integerRegex) ? Convert.ToInt32(s8) : 9999999,
				//				TradeAmount = Regex.IsMatch(s9, floatRegex) ? Convert.ToDouble(s9) : 0.001
			};


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
			//            currentStrategy.InputParameters.TradeQuantityThreshold =
			//                Convert.ToInt32(
			//                    (tableLayoutPanelStrategies.Controls[$"{ControlNames[8]}{index}"] as TextBox).Text);
			return parameters;
		}

		private void btnAllStart_Click(object sender, EventArgs e)
		{
			StartStrategy(-1);

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
		private void btnCancelAllOrders_Click(object sender, EventArgs e)
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

			if (!CancelAllPlacedOrders())
			{
				MessageBox.Show("撤单未全部成功");
			}
		}

		private bool CancelAllPlacedOrders()
		{
			var allSucceed = true;

			var outSitePlacedOrders = _accounts[OutSitePrefix].Trader.GetAllPlacedOrders(Trader.Trader.CoinType.Btc);
			var inSitePlacedOrders = _accounts[InSitePrefix].Trader.GetAllPlacedOrders(Trader.Trader.CoinType.Btc);

			foreach (var order in outSitePlacedOrders)
			{
				allSucceed = allSucceed && _accounts[OutSitePrefix].Trader.CancelPlacedOrder(order.Id, Trader.Trader.CoinType.Btc);
			}

			foreach (var order in inSitePlacedOrders)
			{
				allSucceed = allSucceed && _accounts[InSitePrefix].Trader.CancelPlacedOrder(order.Id, Trader.Trader.CoinType.Btc);
			}

			return allSucceed;
		}

		private void ShowTrades()
		{
			long btccIndex = _accounts[OutSitePrefix].AccountTradeRecords.Count;
//            gdvBtccTrades.DataSource =
			var btccAccountTrades =
				_accounts[InSitePrefix].AccountTradeRecords.OrderByDescending(t => t.Time)
					.Select(
						t =>
							new
							{
								SN = btccIndex--,
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
				btnCancelAllOrders.Enabled = true;
				ChangeToRealMode();
			}
			else //change to simulate mode
			{
				_inRealMode = false;
				btnSwitchMode.BackColor = Color.LimeGreen;
				btnSwitchMode.Text = "启动真实模式(&R)";
				tckPecentage.Enabled = true;
				btnCancelAllOrders.Enabled = false;
				ChangeToSimulateMode();
				btnCancelAllOrders_Click(null, null);
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

		private void Form6_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show(this, "确定退出程序吗?", "问题", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2) == DialogResult.No)
			{
				e.Cancel = true;
			}
//			else
//			{
//				btnCancelAllOrders_Click(null, null);
//			}
		}

		private enum ControlName
		{
			lblBuyPrice,
			lblBuyAmount,
			lblSellPrice,
			lblSellAmount
		}

		private void btnAllStop_Click(object sender, EventArgs e)
		{
		}
	}
}