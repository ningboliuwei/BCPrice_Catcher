#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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

		private static string _outSiteCode = "btcc";
		private static string _inSiteCode = "huobi";

		//买或卖的数量限制
		private const int BookOrdersCount = 5;

		private const int InitialRowCount = 5;

		private readonly string[] OutSiteTitles =
		{
			"", "卖价", "量", "", "买价", "量"
		};

		private readonly string[] InSiteTitles =
		{
			"", "卖价", "量", "", "买价", "量"
		};

		private List<Strategy2> Strategies = new List<Strategy2>();
		private TimerList StrategyTimerList = new TimerList();

		private Dictionary<string, Account> _accounts = new Dictionary<string, Account>
		{
			{_outSiteCode, new SimulateAccount()},
			{_inSiteCode, new SimulateAccount()}
		};

		private Dictionary<string, List<BookOrderInfo>> _buyBookOrders = new Dictionary<string, List<BookOrderInfo>>
		{
			{_outSiteCode, null},
			{_inSiteCode, null}
		};

		private Dictionary<string, List<BookOrderInfo>> _sellBookOrders = new Dictionary<string, List<BookOrderInfo>>
		{
			{_outSiteCode, null},
			{_inSiteCode, null}
		};

		//private List<int> _strategyCounters = new List<int>();

		private Dictionary<string, double> _prices = new Dictionary<string, double>
		{
			{_outSiteCode, 0},
			{_inSiteCode, 0}
		};

		private Dictionary<string, List<PlacedOrderInfo>> _pendingPlacedOrders =
			new Dictionary<string, List<PlacedOrderInfo>>
			{
				{_outSiteCode, null},
				{_inSiteCode, null}
			};

		private Dictionary<string, List<PlacedOrderInfo>> _placedOrders = new Dictionary<string, List<PlacedOrderInfo>>
		{
			{_outSiteCode, null},
			{_inSiteCode, null}
		};

		//		private readonly Dictionary<string, List<>> 


		private bool _allowAutoTrade;

		//		private readonly int _strategyControlColumnCount = Titles.Length;

		private double _baseDifferPrice;
		private double _initialTotalBalance;
		private double _initialTotalCoinAmount;
		private bool _inRealMode;
		private bool _matchConition;
		private int _previousSiteIndex;
		private bool _hasNoPendingPlacedOrders;

		private static readonly object _accountLock = new object();
		private static readonly object _threadLock = new object();

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
				//				var columnPosition = 0;

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
			StrategyTimerList.Timers["0"].Change(Timeout.Infinite, Timeout.Infinite);
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
				StartStrategy(0);
				button.BackColor = Color.LightSalmon;
				button.FlatAppearance.BorderColor = Color.LightCoral;
				button.Text = ButtonStopText;
				btnPlaceOrder.Enabled = true;
			}
			else
			{
				StopStrategy(0);
				button.BackColor = Color.LightGreen;
				button.FlatAppearance.BorderColor = Color.ForestGreen;
				button.Text = ButtonStartText;
				btnPlaceOrder.Enabled = false;
			}
		}

		private void StartStrategy(int strategyId)
		{
			StrategyTimerList.Timers["0"].Change(0,
				1 * 1000);
		}

		//add a new strategy
		private void AddStrategy()
		{
			var strategyId = 0;
			var strategy = new Strategy2
			{
				InputParameters = GetStrategyParameters()
			};

			Strategies.Add(strategy);

			StrategyTimerList.Add("0", Timeout.Infinite, o =>
			{
				Task.Run(() =>
				{
					strategy.Update(GetStrategyParameters());
					_matchConition = strategy.MatchTradeCondition();

					var hasNoPendingPlacedOrdersOutSite = _pendingPlacedOrders[_outSiteCode] == null ||
					                                      _pendingPlacedOrders[_outSiteCode]?.Count == 0;

					var hasNoPendingPlacedOrdersInSite = _pendingPlacedOrders[_inSiteCode] == null ||
					                                     _pendingPlacedOrders[_inSiteCode]?.Count == 0;

					_hasNoPendingPlacedOrders = hasNoPendingPlacedOrdersOutSite && hasNoPendingPlacedOrdersInSite;

					// tianxia said no need
					//					if (_allowAutoTrade && _hasNoPendingPlacedOrders 
					if (_allowAutoTrade && (_accounts[_outSiteCode].Trader?.GetType() != _accounts[_inSiteCode].Trader?.GetType()))
						//hacking, not elegant)
					{
						strategy.TryTrade(_accounts, new Dictionary<string, double>
						{
							{_outSiteCode, _prices[_outSiteCode]},
							{_inSiteCode, _prices[_inSiteCode]}
						}, strategy.m, _outSiteCode, _inSiteCode);
					}

					if (_inRealMode)
					{
						UpdateRealAccount();
						UpdatePendingPlacedOrders();
						UpdateAllPlacedOrders();
					}
				});
			});
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
			AutoScaleMode = AutoScaleMode.Dpi;

			//set gridview font size

			gdvTrades.ColumnHeadersDefaultCellStyle.Font = new Font(gdvTrades.DefaultCellStyle.Font.FontFamily, 8);
			gdvTrades.DefaultCellStyle.Font = new Font(gdvTrades.DefaultCellStyle.Font.FontFamily, 8);
			gdvTrades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


			gdvOutSitePlacedOrders.ColumnHeadersDefaultCellStyle.Font =
				new Font(gdvOutSitePlacedOrders.DefaultCellStyle.Font.FontFamily, 8);
			gdvOutSitePlacedOrders.DefaultCellStyle.Font =
				new Font(gdvOutSitePlacedOrders.DefaultCellStyle.Font.FontFamily, 8);
			gdvOutSitePlacedOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			gdvInSitePlacedOrders.ColumnHeadersDefaultCellStyle.Font =
				new Font(gdvInSitePlacedOrders.DefaultCellStyle.Font.FontFamily, 8);
			gdvInSitePlacedOrders.DefaultCellStyle.Font =
				new Font(gdvInSitePlacedOrders.DefaultCellStyle.Font.FontFamily, 8);
			gdvInSitePlacedOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			btnCancelAllPendingPlacedOrders.Enabled = false;

			var siteNames = new Dictionary<string, string> {{"btcc", "BTCC"}, {"huobi", "火币网"}};
			cmbOutSite.DisplayMember = "Name";
			cmbOutSite.ValueMember = "Code";
			cmbOutSite.DataSource = (from n in siteNames select new {Code = n.Key, Name = n.Value}).ToList();
			cmbOutSite.SelectedIndex = 0;

			cmbInSite.DisplayMember = "Name";
			cmbInSite.ValueMember = "Code";
			cmbInSite.DataSource = (from n in siteNames select new {Code = n.Key, Name = n.Value}).ToList();
			cmbInSite.SelectedIndex = 1;
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
			GenerateOrderBookControls(tableLayoutPanelOutSite, OutSiteTitles, lblOutSitePrice.BackColor,
				lblOutSiteAccount.BackColor);
			GenerateOrderBookControls(tableLayoutPanelInSite, InSiteTitles, lblInSitePrice.BackColor,
				lblInSiteAccount.BackColor);
			AddStrategy();
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
			var totalBalance = _accounts[_outSiteCode].Balance + _accounts[_inSiteCode].Balance;
			var totalCoinAmount = _accounts[_outSiteCode].CoinAmount + _accounts[_inSiteCode].CoinAmount;

			_accounts[_outSiteCode].Balance = Math.Round(totalBalance * pecentage);
			_accounts[_outSiteCode].CoinAmount = Math.Round(totalCoinAmount * (1 - pecentage));

			_accounts[_inSiteCode].Balance = Math.Round(totalBalance * (1 - pecentage));
			_accounts[_inSiteCode].CoinAmount = Math.Round(totalCoinAmount * pecentage);
		}


		private void ShowAccounts()
		{
			lblOutSiteAccount.Text
				=
				$"{cmbOutSite.Text}账户({tckPecentage.Value}%){Environment.NewLine}现金：{_accounts[_outSiteCode].Balance.ToString("0.000")}{Environment.NewLine}币数：{_accounts[_outSiteCode].CoinAmount.ToString("0.000")}{Environment.NewLine}总资产：{(_accounts[_outSiteCode].CoinAmount * _prices[_outSiteCode] + _accounts[_outSiteCode].Balance).ToString("0.000")}";

			lblInSiteAccount.Text
				=
				$"{cmbInSite.Text}账户({tckPecentage.Maximum - tckPecentage.Value}%){Environment.NewLine}现金：{_accounts[_inSiteCode].Balance.ToString("0.000")}{Environment.NewLine}币数：{_accounts[_inSiteCode].CoinAmount.ToString("0.000")}{Environment.NewLine}总资产：{(_accounts[_inSiteCode].CoinAmount * _prices[_inSiteCode] + _accounts[_inSiteCode].Balance).ToString("0.000")}";

			//unelegent
			//			if (_strategies.Count != 0)
			//			{
			//				_strategies[0].InputParameters.SiteAAmount = _accounts["btcc"].CoinAmount;
			//				_strategies[0].InputParameters.SiteBAmount = _accounts["huobi"].CoinAmount;
			//			}
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
					_prices[_outSiteCode] = Convert.ToDouble(infos?[$"{_outSiteCode}_price"]);
					_prices[_inSiteCode] = Convert.ToDouble(infos?[$"{_inSiteCode}_price"]);

					_sellBookOrders[_outSiteCode] =
						(infos[$"{_outSiteCode}_bookorders"] as List<BookOrderInfo>).Take(BookOrdersCount).ToList();
					_sellBookOrders[_inSiteCode] =
						(infos[$"{_inSiteCode}_bookorders"] as List<BookOrderInfo>).Take(BookOrdersCount).ToList();

					_buyBookOrders[_outSiteCode] =
						(infos[$"{_outSiteCode}_bookorders"] as List<BookOrderInfo>).Skip(BookOrdersCount)
							.Take(BookOrdersCount)
							.ToList();
					_buyBookOrders[_inSiteCode] =
						(infos[$"{_inSiteCode}_bookorders"] as List<BookOrderInfo>).Skip(BookOrdersCount)
							.Take(BookOrdersCount)
							.ToList();

					//					_baseDifferPrice = Math.Abs(_prices[OutSitePrefix] - _prices[InSitePrefix]);
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			GetInfos();
			ShowPrices();

			ShowBookOrders(tableLayoutPanelOutSite, _sellBookOrders[_outSiteCode], _buyBookOrders[_outSiteCode]);
			ShowBookOrders(tableLayoutPanelInSite, _sellBookOrders[_inSiteCode], _buyBookOrders[_inSiteCode]);

			//            foreach (var s in _strategies)
			//            {
			//                ChangeStrategyValues(s);
			//            }


			//			for (
			//				var i = 0;
			//				i < _strategies.Count;
			//				i
			//					++)
			//			{
			//				ShowStrategyValues(_strategies[i]);
			//			}
			//
			ShowStrategyValues();

			if (_inRealMode)
			{
				//				UpdateRealAccount();
				//                    if (_inRealMode)
				//                    {
//				                        UpdateRealAccount();
//				                        UpdatePendingPlacedOrders();
//				                        UpdateAllPlacedOrders();
				//                    }


				ShowPendingPlacedOrders();
				ShowRealTrades();
			}
			else
			{
				ShowSimulateTrades();
			}

			UpdateControlsStatus();
			ShowAccounts();
		}

		private void UpdateControlsStatus()
		{
			if (_matchConition && _hasNoPendingPlacedOrders)
			{
				btnPlaceOrder.Enabled = true;
				btnPlaceOrder.BackColor = Color.LightGreen;
				btnPlaceOrder.FlatAppearance.BorderColor = Color.ForestGreen;
			}
			else
			{
				btnPlaceOrder.Enabled = false;
				btnPlaceOrder.BackColor = Color.LightSalmon;
				btnPlaceOrder.FlatAppearance.BorderColor = Color.LightCoral;
			}
		}


		//for btcc, huobi and differ price
		private void ShowPrices()
		{
			_baseDifferPrice = Math.Abs(_prices[_outSiteCode] - _prices[_inSiteCode]);
			lblOutSitePrice.Text
				= $"{cmbOutSite.Text}最新价格{Environment.NewLine}{_prices[_outSiteCode].ToString("0.000")}";
			lblInSitePrice.Text
				= $"{cmbInSite.Text}最新价格{Environment.NewLine}{_prices[_inSiteCode].ToString("0.000")}";
			lblDifferPrice.Text
				= $"差价{Environment.NewLine}{_baseDifferPrice.ToString("0.000")}";
			lblTotalProfits.Text
				=
				$"总利润{Environment.NewLine}{(_accounts[_outSiteCode].Balance + _accounts[_inSiteCode].Balance - _initialTotalBalance).ToString("0.000")}{Environment.NewLine}总资产{Environment.NewLine}{(_accounts[_outSiteCode].CoinAmount * _prices[_outSiteCode] + _accounts[_outSiteCode].Balance + _accounts[_inSiteCode].CoinAmount * _prices[_inSiteCode] + _accounts[_inSiteCode].Balance).ToString("0.000")}";

			if (_prices[_outSiteCode] > _prices[_inSiteCode]
				)
			{
				lblDifferPrice.Text = lblDifferPrice.Text.Insert(4, "<< ");
			}
			else if (
				_prices[_outSiteCode] < _prices[_inSiteCode])
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
					((Label)
						((Panel) tableLayoutPanel.Controls["panelSellPrice" + i]).Controls[
							$"{ControlName.lblSellPrice}{i}"]).Text
						=
						sellBookOrders[i].Price.ToString("0.00");

					((Label)
						((Panel) tableLayoutPanel.Controls["panelSellAmount" + i]).Controls[
							$"{ControlName.lblSellAmount}{i}"])
						.Text =
						sellBookOrders[i].Amount.ToString();

					((Label)
						((Panel) tableLayoutPanel.Controls["panelBuyPrice" + i]).Controls[
							$"{ControlName.lblBuyPrice}{i}"]).Text
						=
						buyBookOrders[i].Price.ToString("0.00");

					((Label)
						((Panel) tableLayoutPanel.Controls["panelBuyAmount" + i]).Controls[
							$"{ControlName.lblBuyAmount}{i}"]).Text
						=
						buyBookOrders[i].Amount.ToString();
				}
			}
		}

		private void Form4_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		//		private void ShowStrategyValues(Strategy1 strategy)
		private void ShowStrategyValues()
		{
			if (Strategies.Count != 0)
			{
				var s = Strategies[0];

				lblStrategyValues.Text = "Min " + s.InputParameters.Min.ToString("0.000") + Environment.NewLine
				                         + "m " + s.m.ToString("0.000") + Environment.NewLine
				                         + "A " + s.A.ToString("0.000") + Environment.NewLine
				                         + "B " + s.B.ToString("0.000") + Environment.NewLine
				                         + "实际卖价 " + (s.A + s.InputParameters.a).ToString("0.000") + Environment.NewLine
				                         + "实际买价 " + (s.B + s.InputParameters.b).ToString("0.000") + Environment.NewLine
				                         + "差价 " + s.Differ.ToString("0.000");

				nudAmount.Value = (decimal) s.m;
			}
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
				Min = Regex.IsMatch(s1, floatRegex) ? Convert.ToDouble(s1) : 1,
				a = Regex.IsMatch(s2, floatRegex) ? Convert.ToDouble(s2) : 0,
				b = Regex.IsMatch(s3, floatRegex) ? Convert.ToDouble(s3) : 0,
				Z = Regex.IsMatch(s4, floatRegex) ? Convert.ToDouble(s4) : 0,
				SellBookOrders = _sellBookOrders[_outSiteCode],
				BuyBookOrders = _buyBookOrders[_inSiteCode],
				OutSiteAmount = _accounts[_outSiteCode].CoinAmount,
				InSiteAmount = _accounts[_inSiteCode].CoinAmount
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
		}

		//
		private void btnCancelAllPendingPlacedOrders_Click(object sender, EventArgs e)
		{
			CancelAllPendingPlacedOrders();


			ShowPendingPlacedOrders();
			//			if (!allSucceed)
			//			{
			//				MessageBox.Show("撤单未全部成功");
			//			}
		}

		private bool CancelAllPendingPlacedOrders()
		{
			var allSucceed = true;


			var outSitePlacedOrders = _pendingPlacedOrders[_outSiteCode];
			var inSitePlacedOrders = _pendingPlacedOrders[_inSiteCode];

			lock (_threadLock)
			{
				if (outSitePlacedOrders != null && outSitePlacedOrders.Count != 0)
				{
					Parallel.ForEach(outSitePlacedOrders, o =>
						_accounts[_outSiteCode].Trader.CancelPlacedOrder(o.Id, Trader.Trader.CoinType.Btc));
				}

				if (inSitePlacedOrders != null && inSitePlacedOrders.Count != 0)
				{
					Parallel.ForEach(inSitePlacedOrders, o =>
						_accounts[_inSiteCode].Trader.CancelPlacedOrder(o.Id, Trader.Trader.CoinType.Btc));
				}
			}

			return allSucceed;
		}

		private void ShowPendingPlacedOrders()
		{
			var index = 0;
			//			var outSiteAllPlacedOrders =
			//				await Task.Run(() => (TraderFactory.GetTrader(_outSiteCode)).GetAllPlacedOrders(Trader.Trader.CoinType.Btc)?.
			//					OrderByDescending(t => t.Time));

			var outSitePendingPlacedOrders = _pendingPlacedOrders[_outSiteCode];
			if (outSitePendingPlacedOrders != null)
			{
				//				_pendingPlacedOrders[_outSiteCode] = outSiteAllPlacedOrders.ToList();
				gdvOutSitePlacedOrders.DataSource = outSitePendingPlacedOrders.Select(t =>
					new
					{
						序号 = ++index,
						单号 = t.Id,
						类型 = t.Type,
						价格 = t.Price.ToString("0.000"),
						总量 = t.AmountOriginal.ToString("0.000"),
						已处理 = t.AmountProcessed.ToString("0.000"),
						时间 = t.Time.ToString("HH:mm:ss"),
						状态 = t.Status
					}).ToList();
				;
			}


			index = 0;
			//			var inSiteAllPlacedOrders =
			//				await Task.Run(() => TraderFactory.GetTrader(_inSiteCode).GetAllPlacedOrders(Trader.Trader.CoinType.Btc)?.
			//					OrderByDescending(t => t.Time));

			var inSitePendingPlacedOrders = _pendingPlacedOrders[_inSiteCode];
			if (inSitePendingPlacedOrders != null)
			{
				//				_pendingPlacedOrders[_inSiteCode] = inSiteAllPlacedOrders.ToList();
				gdvInSitePlacedOrders.DataSource = inSitePendingPlacedOrders.Select(t =>
					new
					{
						序号 = ++index,
						单号 = t.Id,
						类型 = t.Type,
						价格 = t.Price.ToString("0.000"),
						总量 = t.AmountOriginal.ToString("0.000"),
						已处理 = t.AmountProcessed.ToString("0.000"),
						时间 = t.Time.ToString("HH:mm:ss"),
						状态 = t.Status
					}).ToList();
				;
			}

			if (gdvOutSitePlacedOrders.ColumnCount != 0)
			{
				for (var i = 0; i < gdvOutSitePlacedOrders.ColumnCount - 1; i++)
				{
					gdvOutSitePlacedOrders.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				}
				gdvOutSitePlacedOrders.Columns[gdvOutSitePlacedOrders.ColumnCount - 1].AutoSizeMode =
					DataGridViewAutoSizeColumnMode.Fill;
			}

			if (gdvInSitePlacedOrders.ColumnCount != 0)
			{
				for (var i = 0; i < gdvInSitePlacedOrders.ColumnCount - 1; i++)
				{
					gdvInSitePlacedOrders.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				}
				gdvInSitePlacedOrders.Columns[gdvInSitePlacedOrders.ColumnCount - 1].AutoSizeMode =
					DataGridViewAutoSizeColumnMode.Fill;
			}
		}

		private void ShowSimulateTrades()
		{
			long outSiteIndex = _accounts[_outSiteCode].AccountTradeRecords.Count;
			//            gdvBtccTrades.DataSource =
			var outSiteAccountTrades =
				_accounts[_outSiteCode].AccountTradeRecords.OrderByDescending(t => t.Time)
					.Select(t => new
					{
						SN = outSiteIndex--,
						t.OrderId,
						t.Type,
						t.Price,
						t.Amount,
						t.Time
						//                                Profit = t.Profit.ToString("0.000")
					});
			//					.ToList();

			long inSiteIndex = _accounts[_inSiteCode].AccountTradeRecords.Count;
			//			gdvHuobiTrades.DataSource = 

			var inSiteAccountTrades =
				_accounts[_inSiteCode].AccountTradeRecords.OrderByDescending(t => t.Time).Select(
					t =>
						new
						{
							SN = inSiteIndex--,
							t.OrderId,
							t.Type,
							t.Price,
							t.Amount,
							t.Time
							//                        Profit = t.Profit.ToString("0.000")
						});
			//					.ToList();

			var totalTrades = from outTrade in outSiteAccountTrades
				join inTrade in inSiteAccountTrades
					on outTrade.SN equals inTrade.SN
				select new
				{
					序号 = outTrade.SN,
					卖出价格 = outTrade.Price.ToString("0.000"),
					卖出数量 = outTrade.Amount.ToString("0.0000"),
					//					BtccType = btcc.Type,
					买入价格 = inTrade.Price.ToString("0.000"),
					买入数量 = inTrade.Amount.ToString("0.0000"),
					利润 = (outTrade.Price * outTrade.Amount - inTrade.Price * inTrade.Amount).ToString("0.000")
					//					HuobiType = huobi.Type
					//					Profit = (btcc.Price * btcc.Amount - huobi.Price * huobi.Amount).ToString("0.000")
					//Profit = btcc.Price + "," + btcc.Amount + "," + huobi.Price + "," + huobi.Amount + (btcc.Price * btcc.Amount - huobi.Price * huobi.Amount).ToString("0.000")
				};

			gdvTrades.DataSource = totalTrades.ToList();
		}


		private void ShowRealTrades()
		{
			//            long outSiteIndex = _accounts[_outSiteCode].RealPlacedOrders.Count;
			//            var outSitePlacedOrders =
			//                _accounts[_outSiteCode].RealPlacedOrders.Where(t => t?.Status == OrderStatus.Closed)
			//                    .OrderByDescending(t => t.Time)
			//                    .Select(
			//                        t =>
			//                            new
			//                            {
			//                                SN = outSiteIndex--,
			//                                t.Type,
			//                                t.Price,
			//                                t.AmountOriginal,
			//                                t.Time
			//                            });
			//
			//
			//            long inSiteIndex = _accounts[_inSiteCode].RealPlacedOrders.Count;
			//            var inSitePlacedOrders =
			//                _accounts[_inSiteCode].RealPlacedOrders.Where(t => t?.Status == OrderStatus.Closed)
			//                    .OrderByDescending(t => t.Time)
			//                    .Select(
			//                        t =>
			//                            new
			//                            {
			//                                SN = inSiteIndex--,
			//                                t.Type,
			//                                t.Price,
			//                                t.AmountOriginal,
			//                                t.Time
			//                            });
			//
			//
			//            var totalTrades = from outOrder in outSitePlacedOrders
			//                join inOrder in inSitePlacedOrders
			//                    on outOrder.SN equals inOrder.SN
			//                select new
			//                {
			//                    序号 = outOrder.SN,
			//                    卖出价格 = outOrder.Price.ToString("0.000"),
			//                    卖出数量 = outOrder.AmountOriginal.ToString("0.0000"),
			//                    //					BtccType = btcc.Type,
			//                    买入价格 = inOrder.Price.ToString("0.000"),
			//                    买入数量 = inOrder.AmountOriginal.ToString("0.0000"),
			//                    利润 =
			//                        (outOrder.Price * outOrder.AmountOriginal - inOrder.Price * inOrder.AmountOriginal).ToString(
			//                            "0.000")
			//                    //					HuobiType = huobi.Type
			//                    //					Profit = (btcc.Price * btcc.Amount - huobi.Price * huobi.Amount).ToString("0.000")
			//                    //Profit = btcc.Price + "," + btcc.Amount + "," + huobi.Price + "," + huobi.Amount + (btcc.Price * btcc.Amount - huobi.Price * huobi.Amount).ToString("0.000")
			//                };

			var outSiteClosedPlacedOrders =
				_accounts[_outSiteCode].RealPlacedOrders.Where(o => o?.Status == OrderStatus.Closed).ToList();
			var outSiteClosedTrades = (from t in _accounts[_outSiteCode].AccountTradeRecords
				where outSiteClosedPlacedOrders.Exists(o => o.Id == t.OrderId)
				select t).ToList();

			var inSiteClosedPlacedOrders =
				_accounts[_inSiteCode].RealPlacedOrders.Where(o => o?.Status == OrderStatus.Closed).ToList();
			var inSiteClosedTrades = (from t in _accounts[_inSiteCode].AccountTradeRecords
				where inSiteClosedPlacedOrders.Exists(o => o.Id == t.OrderId)
				select t).ToList();

			var totalTrades = from outOrder in outSiteClosedTrades
				join inOrder in inSiteClosedTrades
					on outOrder.TradePairGuid equals inOrder.TradePairGuid
				select new
				{
					序号 = outOrder.TradePairGuid,
					卖出价格 = outOrder.Price.ToString("0.000"),
					卖出数量 = outOrder.Amount.ToString("0.0000"),
					//					BtccType = btcc.Type,
					买入价格 = inOrder.Price.ToString("0.000"),
					买入数量 = inOrder.Amount.ToString("0.0000"),
					利润 =
						(outOrder.Price * outOrder.Amount - inOrder.Price * inOrder.Amount).ToString(
							"0.000")
				};

			gdvTrades.DataSource = totalTrades.ToList();
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
				btnSwitchMode.FlatAppearance.BorderColor = Color.Brown;
				tckPecentage.Enabled = false;
				btnCancelAllPendingPlacedOrders.Enabled = true;
				gdvOutSitePlacedOrders.Enabled = true;
				gdvInSitePlacedOrders.Enabled = true;
				btnShowPendingPlacedOrders.Enabled = true;
				ChangeToRealMode();
			}
			else //change to simulate mode
			{
				_inRealMode = false;
				btnSwitchMode.BackColor = Color.LimeGreen;
				btnSwitchMode.FlatAppearance.BorderColor = Color.DarkGreen;
				btnSwitchMode.Text = "启动真实模式(&R)";
				tckPecentage.Enabled = true;
				btnCancelAllPendingPlacedOrders.Enabled = false;
				gdvOutSitePlacedOrders.Enabled = false;
				gdvInSitePlacedOrders.Enabled = false;
				btnShowPendingPlacedOrders.Enabled = false;
				ChangeToSimulateMode();
				//				btnCancelAllOrders_Click(null, null);
			}
		}

		private void ChangeToRealMode()
		{
			UseRealAccount();
		}


		private void UpdateAllPlacedOrders()
		{
//            lock (_threadLock)
//            {
			if (_accounts[_outSiteCode].AccountTradeRecords.Count != 0)
			{
				for (int i = 0; i < _accounts[_outSiteCode].AccountTradeRecords.Count; i++)
				{
					var t = _accounts[_outSiteCode].AccountTradeRecords[i];
					if (_accounts[_outSiteCode].RealPlacedOrders.Count == 0)
					{
						var order = Task.Run(() => _accounts[_outSiteCode].Trader?.GetPlacedOrder(t.OrderId,
							Trader.Trader.CoinType.Btc)).Result;

						if (order != null)
						{
							_accounts[_outSiteCode].RealPlacedOrders.Add(order);
						}
					}
					else
					{
						if (!_accounts[_outSiteCode].RealPlacedOrders.Exists(o => o?.Id == t?.OrderId))
						{
							var order = Task.Run(() => _accounts[_outSiteCode].Trader?.GetPlacedOrder(t.OrderId,
								Trader.Trader.CoinType.Btc)).Result;

							if (order != null)
							{
								_accounts[_outSiteCode].RealPlacedOrders.Add(order);
							}
						}
					}
				}


				if (_accounts[_outSiteCode].RealPlacedOrders.Count != 0)
				{
					var notClosedRealPlacedOrder =
						_accounts[_outSiteCode].RealPlacedOrders.Where(o => o?.Status != OrderStatus.Closed).ToList();

					for (int i = 0; i < notClosedRealPlacedOrder.Count; i++)
					{
						if (notClosedRealPlacedOrder[i] != null)
						{
							notClosedRealPlacedOrder[i] =
								Task.Run(() => _accounts[_outSiteCode].Trader?.GetPlacedOrder(notClosedRealPlacedOrder[i].Id,
									Trader.Trader.CoinType.Btc)).Result;
						}
					}
				}
			}

			if (_accounts[_inSiteCode].AccountTradeRecords.Count != 0)
			{
				for (int i = 0; i < _accounts[_inSiteCode].AccountTradeRecords.Count; i++)
				{
					var t = _accounts[_inSiteCode].AccountTradeRecords[i];
					if (_accounts[_inSiteCode].RealPlacedOrders.Count == 0)
					{
						var order = Task.Run(() => _accounts[_inSiteCode].Trader?.GetPlacedOrder(t.OrderId,
							Trader.Trader.CoinType.Btc)).Result;

						if (order != null)
						{
							_accounts[_inSiteCode].RealPlacedOrders.Add(order);
						}
					}
					else
					{
						if (!_accounts[_inSiteCode].RealPlacedOrders.Exists(o => o?.Id == t?.OrderId))
						{
							var order = Task.Run(() => _accounts[_inSiteCode].Trader?.GetPlacedOrder(t.OrderId,
								Trader.Trader.CoinType.Btc)).Result;

							if (order != null)
							{
								_accounts[_inSiteCode].RealPlacedOrders.Add(order);
							}
						}
					}
				}
				if (_accounts[_inSiteCode].RealPlacedOrders.Count != 0)
				{
					var notClosedRealPlacedOrder =
						_accounts[_inSiteCode].RealPlacedOrders.Where(o => o?.Status != OrderStatus.Closed).ToList();

					for (int i = 0; i < notClosedRealPlacedOrder.Count; i++)
					{
						if (notClosedRealPlacedOrder[i] != null)
						{
							notClosedRealPlacedOrder[i] = Task.Run(() =>
								_accounts[_inSiteCode].Trader?.GetPlacedOrder(notClosedRealPlacedOrder[i].Id,
									Trader.Trader.CoinType.Btc)).Result;
						}
					}
				}
			}
//            }
		}


		private void UseRealAccount()
		{
			_accounts[_outSiteCode] = new RealAccount {Trader = TraderFactory.GetTrader(_outSiteCode)};
			_accounts[_inSiteCode] = new RealAccount {Trader = TraderFactory.GetTrader(_inSiteCode)};

			var outSiteAccountInfo = _accounts[_outSiteCode].Trader?.GetAccountInfo();
			if (outSiteAccountInfo != null)
			{
				_accounts[_outSiteCode].Balance = outSiteAccountInfo.AvailableCny;
				_accounts[_outSiteCode].CoinAmount = outSiteAccountInfo.AvailableBtc;
			}

			var inSiteAccountInfo = _accounts[_inSiteCode].Trader?.GetAccountInfo();
			if (inSiteAccountInfo != null)
			{
				_accounts[_inSiteCode].Balance = inSiteAccountInfo.AvailableCny;
				_accounts[_inSiteCode].CoinAmount = inSiteAccountInfo.AvailableBtc;
			}

			_initialTotalBalance = _accounts[_outSiteCode].Balance + _accounts[_inSiteCode].Balance;
			_initialTotalCoinAmount = _accounts[_outSiteCode].CoinAmount + _accounts[_inSiteCode].CoinAmount;
		}

		private void UpdateRealAccount()
		{
			//			if (_accounts[_outSiteCode].Trader.GetType() != _accounts[_inSiteCode].Trader.GetType())//hacking, not elegant
			//			{
			lock (_threadLock)
			{
				var outSiteAccountInfo = _accounts[_outSiteCode].Trader?.GetAccountInfo();
				if (outSiteAccountInfo != null)
				{
					_accounts[_outSiteCode].Balance = outSiteAccountInfo.AvailableCny;
					_accounts[_outSiteCode].CoinAmount = outSiteAccountInfo.AvailableBtc;
				}

				var inSiteAccountInfo = _accounts[_inSiteCode].Trader?.GetAccountInfo();
				if (inSiteAccountInfo != null)
				{
					_accounts[_inSiteCode].Balance = inSiteAccountInfo.AvailableCny;
					_accounts[_inSiteCode].CoinAmount = inSiteAccountInfo.AvailableBtc;
				}
			}
			//			}
		}

		private void UpdatePendingPlacedOrders()
		{
			lock (_threadLock)
			{
				_pendingPlacedOrders[_outSiteCode] =
					(_accounts[_outSiteCode].Trader?.GetAllPlacedOrders(Trader.Trader.CoinType.Btc))?
						.OrderByDescending(t => t.Time)
						.ToList();

				_pendingPlacedOrders[_inSiteCode] =
					(_accounts[_inSiteCode].Trader?.GetAllPlacedOrders(Trader.Trader.CoinType.Btc))?
						.OrderByDescending(t => t.Time)
						.ToList();
			}
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
			}
				;

			_accounts["huobi"] =
				new SimulateAccount
				{
					Balance = Math.Round(_initialTotalBalance * (1 - InitialPecentage)),
					CoinAmount = Math.Round(_initialTotalCoinAmount * InitialPecentage)
				}
				;
		}

		private void Form6_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show(this, "确定退出程序吗?", "问题", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2) == DialogResult.No)
			{
				e.Cancel = true;
			}
		}

		private void btnAllStop_Click(object sender, EventArgs e)
		{
		}

		private void chkAutoTrade_CheckedChanged(object sender, EventArgs e)
		{
			_allowAutoTrade = chkAutoTrade.Checked;
		}

		private void btnPlaceOrder_Click(object sender, EventArgs e)
		{
			if (Strategies.Count != 0)
			{
				var strategy = Strategies[0];
				strategy.TryTrade
					(
						_accounts,
						new Dictionary<string, double>
						{
							{
								_outSiteCode,
								_prices[_outSiteCode]
							}
							,
							{
								_inSiteCode,
								_prices[_inSiteCode]
							}
						}
						,
						strategy.m,
						_outSiteCode,
						_inSiteCode
					);
			}
		}

		private void btnShowPendingPlacedOrders_Click(object sender, EventArgs e)
		{
			ShowPendingPlacedOrders();
		}

		private void lblStrategyValues_Click(object sender, EventArgs e)
		{
		}

		private enum ControlName
		{
			lblBuyPrice,
			lblBuyAmount,
			lblSellPrice,
			lblSellAmount
		}

		private void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
		{
			var thisComboBox = (ComboBox) sender;
			var thatComboBox = thisComboBox == cmbOutSite ? cmbInSite : cmbOutSite;

			if (thisComboBox.Text == thatComboBox.Text)
			{
				thatComboBox.SelectedIndex = _previousSiteIndex;
			}

			_outSiteCode = cmbOutSite.SelectedValue?.ToString();
			_inSiteCode = cmbInSite.SelectedValue?.ToString();

			//only stop, never start
			if (btnStartStopStrategy.Text == ButtonStopText)
			{
				btnStartStopStrategy_Click(btnStartStopStrategy, null);
			}
		}

		private void cmbSite_Click(object sender, EventArgs e)
		{
			_previousSiteIndex = ((ComboBox) sender).SelectedIndex;
		}
	}
}