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

#endregion

namespace BCPrice_Catcher
{
	[Guid("B4B1879D-17FD-44CF-8D31-6DD9C0115186")]
	public partial class Form6 : Form
	{
		private const double InitialPercentage = 0.4d;
		private const string ButtonStartText = "开始(&S)";
		private const string ButtonStopText = "停止(&T)";

		//买或卖的数量限制
		private const int BookOrdersCount = 5;
		private const int InitialRowCount = 5;
		private const int StrategyInterval = 1000;
		private const int UIRefreshInterval = 250;
		private const int DataRefreshInterval = 250;
		private const int AutoCancelInterval = 250;
		private const int AutoBuyInterval = 1000;
		private string _outSiteCode = "btcc";
		private string _inSiteCode = "huobi";
		private static readonly object ThreadLock = new object();
		private static bool Trading;
		private static DateTime _noCoinStartTime = DateTime.MaxValue;

		private readonly Dictionary<string, Account> _accounts = new Dictionary<string, Account>
		{
			{"btcc", new SimulateAccount()},
			{"huobi", new SimulateAccount()}
		};

		private readonly Dictionary<string, List<BookOrderInfo>> _buyBookOrders = new Dictionary
			<string, List<BookOrderInfo>>
		{
			{"btcc", null},
			{"huobi", null}
		};

		private readonly Dictionary<string, List<PlacedOrderInfo>> _pendingPlacedOrders =
			new Dictionary<string, List<PlacedOrderInfo>>
			{
				{"btcc", null},
				{"huobi", null}
			};

		private readonly Dictionary<string, double> _prices = new Dictionary<string, double>
		{
			{"btcc", 0},
			{"huobi", 0}
		};

		private readonly Dictionary<string, List<BookOrderInfo>> _sellBookOrders = new Dictionary
			<string, List<BookOrderInfo>>
		{
			{"btcc", null},
			{"huobi", null}
		};

		private readonly string[] InSiteTitles =
		{
			"", "卖价", "量", "", "买价", "量"
		};

		private readonly string[] OutSiteTitles =
		{
			"", "卖价", "量", "", "买价", "量"
		};

		private readonly List<Strategy2> Strategies = new List<Strategy2>();
		private readonly TimerList StrategyTimerList = new TimerList();
		private bool _allowAutoCancel = true;
		private bool _allowAutoTrade;
		private bool _allowAutoBuy = true;
		private double _baseDifferPrice;
		private bool _hasNoPendingPlacedOrders;
		private double _initialTotalBalance;
		private double _initialTotalCoinAmount;
		private bool _inRealMode;
		private bool _matchConition;

		private Dictionary<string, List<PlacedOrderInfo>> _placedOrders = new Dictionary<string, List<PlacedOrderInfo>>
		{
			{"btcc", null},
			{"huobi", null}
		};

		private int _previousSiteIndex;

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
			//            StrategyTimerList.Timers["strategy"].Change(Timeout.Infinite, Timeout.Infinite);
			//            StrategyTimerList.Timers["1"].Change(Timeout.Infinite, Timeout.Infinite);

			foreach (var t in StrategyTimerList.Timers.Values)
			{
				t.Change(Timeout.Infinite, Timeout.Infinite);
			}
		}

		private void btnStartStopStrategy_Click(object sender, EventArgs e)
		{
			var button = sender as Button;

			if (button != null && button.Text == ButtonStartText)
			{
				StartStrategy();
				button.BackColor = Color.LightSalmon;
				button.FlatAppearance.BorderColor = Color.LightCoral;
				button.Text = ButtonStopText;
				btnPlaceOrder.Enabled = true;
			}
			else
			{
				StopStrategy(0);
				if (button != null)
				{
					button.BackColor = Color.LightGreen;
					button.FlatAppearance.BorderColor = Color.ForestGreen;
					button.Text = ButtonStartText;
				}
				btnPlaceOrder.Enabled = false;
			}
		}

		private void StartStrategy()
		{
			StrategyTimerList.Timers["strategy"].Change(0, StrategyInterval);
			//            StrategyTimerList.Timers["account"].Change(0, DataRefreshInterval);
			//            StrategyTimerList.Timers["pending_order"].Change(0, DataRefreshInterval);
			//            StrategyTimerList.Timers["all_order"].Change(0, DataRefreshInterval);
			StrategyTimerList.Timers["auto_cancel"].Change(0, AutoCancelInterval);
			StrategyTimerList.Timers["auto_buy"].Change(0, AutoBuyInterval);
		}

		//add a new strategy
		private void AddStrategy()
		{
			var strategy = new Strategy2
			{
				InputParameters = GetStrategyParameters()
			};

			Strategies.Add(strategy);

			StrategyTimerList.Add("strategy", Timeout.Infinite, o =>
			{
				Task.Run(() =>
				{
					try
					{
						strategy.Update(GetStrategyParameters());
						_matchConition = strategy.MatchTradeCondition(DateTime.Now);

						var hasNoPendingPlacedOrdersOutSite = _pendingPlacedOrders[_outSiteCode] == null ||
															  _pendingPlacedOrders[_outSiteCode]?.Count == 0;

						var hasNoPendingPlacedOrdersInSite = _pendingPlacedOrders[_inSiteCode] == null ||
															 _pendingPlacedOrders[_inSiteCode]?.Count == 0;

						_hasNoPendingPlacedOrders = hasNoPendingPlacedOrdersOutSite && hasNoPendingPlacedOrdersInSite;

						// tianxia said no need
						//					if (_allowAutoTrade && _hasNoPendingPlacedOrders 
						//					if (_allowAutoTrade &&
						//					    (_accounts[_outSiteCode].Trader?.GetType() != _accounts[_inSiteCode].Trader?.GetType()))
						//hacking, not elegant)
						var pendingOrdersCondition = !chkDoNotTradeWhenHasPendingOrders.Checked ||
													 _hasNoPendingPlacedOrders;

						if (_inRealMode)
						{
							UpdateRealAccount();
							UpdatePendingPlacedOrders();
							UpdateAllPlacedOrders();
						}

						if (_allowAutoTrade && pendingOrdersCondition)
						{
							//                            lock (ThreadLock)
							//                            {
							//                                if (!Trading)
							//                                {
							Trading = true;
							var amount = strategy.m <= strategy.InputParameters.SingleTradeCoinLimit
								? strategy.m
								: strategy.InputParameters.SingleTradeCoinLimit;


							strategy.TryTrade(_accounts, new Dictionary<string, double>
							{
								{_outSiteCode, _prices[_outSiteCode]},
								{_inSiteCode, _prices[_inSiteCode]}
							}, amount, _outSiteCode, _inSiteCode);
							//                                }
							//                                Trading = false;
							//                            }
						}
					}
					catch
					{
						//do nothing
					}
				});
			});

			//				);

			#region temp

			//                StrategyTimerList.Add("account", Timeout.Infinite, o =>
			//                {
			//                    if (_inRealMode)
			//                    {
			//                        UpdateRealAccount();
			//                    }
			//                });
			//
			//                StrategyTimerList.Add("pending_order", Timeout.Infinite, o =>
			//                {
			//                    if (_inRealMode)
			//                    {
			//                        UpdatePendingPlacedOrders();
			//                    }
			//                });
			//
			//                StrategyTimerList.Add("all_order", Timeout.Infinite, o =>
			//                {
			//                    if (_inRealMode)
			//                    {
			//                        UpdateAllPlacedOrders();
			//                    }
			//                });
			//

			#endregion

			StrategyTimerList.Add("auto_cancel", Timeout.Infinite, o =>
			{
				try
				{
					if (_inRealMode && _allowAutoCancel)
					{
						CancelAllOverduePlacedOrders();
					}
				}
				catch
				{
				}
			});

			StrategyTimerList.Add("auto_buy", Timeout.Infinite, o =>
			{
				try
				{
					if (_inRealMode)
					{
						if (_accounts[_outSiteCode].CoinAmount == 0 && _accounts[_inSiteCode].CoinAmount == 0)
						{
							_noCoinStartTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
						}

						if (DateTime.Now.Subtract(_noCoinStartTime).Seconds >= Strategies[0].InputParameters.AutoBuyLag && _allowAutoBuy)
						{
							if (_prices[_outSiteCode] <= _prices[_inSiteCode])
							{
								//outsite buy
								var amountToBuy = Math.Round(_accounts[_outSiteCode].Balance *
												  (Strategies[0].InputParameters.AutoBuyBalancePercentage / 100) / _prices[_outSiteCode], 3);
								_accounts[_outSiteCode].Trader.Buy(_prices[_outSiteCode], amountToBuy, Trader.Trader.CoinType.Btc);
							}
							else
							{
								var amountToBuy = Math.Round(_accounts[_inSiteCode].Balance *
												  (Strategies[0].InputParameters.AutoBuyBalancePercentage / 100) / _prices[_inSiteCode], 3);
								_accounts[_inSiteCode].Trader.Buy(_prices[_inSiteCode], amountToBuy, Trader.Trader.CoinType.Btc);
								//insite buy
							}
						}
					}
				}
				catch
				{
				}
			});
		}

		private void CancelAllOverduePlacedOrders()
		{
			var currentTime = DateTime.Now;
			var cancelLag = Strategies[0].InputParameters.AutoCancelLag;

			if (_pendingPlacedOrders[_outSiteCode] != null)
			{
				var sellOrderIdsToCancel =
					(from o in _pendingPlacedOrders[_outSiteCode]
					 where (currentTime - o.Time).TotalSeconds > cancelLag
					 select o.Id).Select(dummy => (long)dummy).ToList();

				//            from a in _pendingPlacedOrders[_outSiteCode].Where(o=>(currentTime-o.Time).TotalSeconds>cancelLag) select a 


				if (sellOrderIdsToCancel.Count != 0)
				{
					//                    Parallel.ForEach(from o in sellOrderIdsToCancel select o,
					//                         id =>
					//
					//                                Task.Run(
					//                                    () =>
					//                                    {
					//                                        _accounts[_outSiteCode].Trader.CancelPlacedOrder(id, Trader.Trader.CoinType.Btc);
					//                                    }));
					Task.Run(() =>
					{
						foreach (var o in sellOrderIdsToCancel)
						{
							_accounts[_outSiteCode].Trader?.CancelPlacedOrder(o, Trader.Trader.CoinType.Btc);
							Task.Delay(100);
						}
					});
				}
			}

			if (_pendingPlacedOrders[_inSiteCode] != null)
			{
				var buyOrderIdsToCancel =
					(from o in _pendingPlacedOrders[_inSiteCode]
					 where (currentTime - o.Time).TotalSeconds > cancelLag
					 select o.Id).Select(dummy => (long)dummy).ToList();

				if (buyOrderIdsToCancel.Count != 0)
				{
					//                    Parallel.ForEach(from o in buyOrderIdsToCancel select o,
					//                         id =>
					//
					//                                Task.Run(
					//                                    () =>
					//                                    {
					//                                        _accounts[_inSiteCode].Trader.CancelPlacedOrder(id, Trader.Trader.CoinType.Btc);
					//                                    }));
					Task.Run(() =>
					{
						foreach (var o in buyOrderIdsToCancel)
						{
							_accounts[_inSiteCode].Trader?.CancelPlacedOrder(o, Trader.Trader.CoinType.Btc);
							Task.Delay(100);
						}
					});
				}
			}
		}

		private void Form6_Load(object sender, EventArgs e)
		{
			InitializeControls();
			ChangeToSimulateMode();
		}

		private void InitializeControls()
		{
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

			var siteNames = new Dictionary<string, string> { { "btcc", "BTCC" }, { "huobi", "火币网" } };
			cmbOutSite.DisplayMember = "Name";
			cmbOutSite.ValueMember = "Code";
			cmbOutSite.DataSource = (from n in siteNames select new { Code = n.Key, Name = n.Value }).ToList();
			cmbOutSite.SelectedIndex = 0;

			cmbInSite.DisplayMember = "Name";
			cmbInSite.ValueMember = "Code";
			cmbInSite.DataSource = (from n in siteNames select new { Code = n.Key, Name = n.Value }).ToList();
			cmbInSite.SelectedIndex = 1;

			//            nudPeroid.Enabled = false;

			chkAutoCancel.Checked = true;
			chkAutoBuy.Checked = true;

			timer1.Interval = UIRefreshInterval;
		}


		private void Form6_Activated(object sender, EventArgs e)
		{
		}

		private void Form6_Shown(object sender, EventArgs e)
		{
			//accounts must be set first (because accounts is need in strategy)
			//show accounts for the first time
			trackBar1_ValueChanged(null, null);

			GenerateOrderBookControls(tableLayoutPanelOutSite, OutSiteTitles, lblOutSitePrice.BackColor,
				lblOutSiteAccount.BackColor);
			GenerateOrderBookControls(tableLayoutPanelInSite, InSiteTitles, lblInSitePrice.BackColor,
				lblInSiteAccount.BackColor);
			AddStrategy();
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
					_prices[_outSiteCode] = Convert.ToDouble(infos[$"{_outSiteCode}_price"]);
					_prices[_inSiteCode] = Convert.ToDouble(infos[$"{_inSiteCode}_price"]);

					_sellBookOrders[_outSiteCode] =
						((List<BookOrderInfo>)infos[$"{_outSiteCode}_bookorders"]).Take(BookOrdersCount).ToList();
					_sellBookOrders[_inSiteCode] =
						((List<BookOrderInfo>)infos[$"{_inSiteCode}_bookorders"]).Take(BookOrdersCount).ToList();

					_buyBookOrders[_outSiteCode] =
						((List<BookOrderInfo>)infos[$"{_outSiteCode}_bookorders"]).Skip(BookOrdersCount)
							.Take(BookOrdersCount)
							.ToList();
					_buyBookOrders[_inSiteCode] =
						((List<BookOrderInfo>)infos[$"{_inSiteCode}_bookorders"]).Skip(BookOrdersCount)
							.Take(BookOrdersCount)
							.ToList();
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				GetInfos();
				ShowPrices();

				ShowBookOrders(tableLayoutPanelOutSite, _sellBookOrders[_outSiteCode], _buyBookOrders[_outSiteCode]);
				ShowBookOrders(tableLayoutPanelInSite, _sellBookOrders[_inSiteCode], _buyBookOrders[_inSiteCode]);

				ShowStrategyValues();

				if (_inRealMode)
				{
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
			catch
			{
				//do nothing
			}
		}

		private void UpdateControlsStatus()
		{
			var pendingOrdersCondition = !chkDoNotTradeWhenHasPendingOrders.Checked || _hasNoPendingPlacedOrders;

			if (_matchConition && pendingOrdersCondition)
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
						((Panel)tableLayoutPanel.Controls["panelSellPrice" + i]).Controls[
							$"{ControlName.lblSellPrice}{i}"]).Text
						=
						sellBookOrders[i].Price.ToString("0.00");

					((Label)
						((Panel)tableLayoutPanel.Controls["panelSellAmount" + i]).Controls[
							$"{ControlName.lblSellAmount}{i}"])
						.Text =
						sellBookOrders[i].Amount.ToString();

					((Label)
						((Panel)tableLayoutPanel.Controls["panelBuyPrice" + i]).Controls[
							$"{ControlName.lblBuyPrice}{i}"]).Text
						=
						buyBookOrders[i].Price.ToString("0.00");

					((Label)
						((Panel)tableLayoutPanel.Controls["panelBuyAmount" + i]).Controls[
							$"{ControlName.lblBuyAmount}{i}"]).Text
						=
						buyBookOrders[i].Amount.ToString();
				}
			}
		}

		private void Form6_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

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

				nudAmount.Value = (decimal)s.m;
			}
		}

		private Strategy2.StrategyInputParameters GetStrategyParameters()
		{
			const string floatRegex = @"^(-?\d+)(\.\d+)?$";
			const string integerRegex = @"^(\+|-)?\d+$";

			var s1 = nudParaMin.Text;
			var s2 = nudParaA.Text;
			var s3 = nudParaB.Text;
			var s4 = nudParaZ.Text;
			var s5 = nudPeroid.Text;
			var s6 = nudAutoCancelLag.Text;
			var s7 = nudAutoBuyLag.Text;
			var s8 = nudAutoBuyBalancePercentage.Text;
			var s9 = nudSingleTradeCoinLimit.Text;

			var parameters = new Strategy2.StrategyInputParameters
			{
				Min = Regex.IsMatch(s1, floatRegex) ? Convert.ToDouble(s1) : 1,
				a = Regex.IsMatch(s2, floatRegex) ? Convert.ToDouble(s2) : 0,
				b = Regex.IsMatch(s3, floatRegex) ? Convert.ToDouble(s3) : 0,
				Z = Regex.IsMatch(s4, floatRegex) ? Convert.ToDouble(s4) : 0,
				Peroid = Regex.IsMatch(s5, integerRegex) ? Convert.ToInt32(s5) : 1,
				AutoCancelLag = Regex.IsMatch(s6, integerRegex) ? Convert.ToInt32(s6) : 8,
				AutoBuyLag = Regex.IsMatch(s7, integerRegex) ? Convert.ToInt32(s7) : 30,
				AutoBuyBalancePercentage = Regex.IsMatch(s8, integerRegex) ? Convert.ToInt32(s8) : 60,
				SingleTradeCoinLimit = Regex.IsMatch(s9, floatRegex) ? Convert.ToDouble(s9) : 1,
				SellBookOrders = _sellBookOrders[_outSiteCode],
				BuyBookOrders = _buyBookOrders[_inSiteCode],
				OutSiteAmount = _accounts[_outSiteCode].CoinAmount,
				InSiteAmount = _accounts[_inSiteCode].CoinAmount
			};

			return parameters;
		}

		private void btnCancelAllPendingPlacedOrders_Click(object sender, EventArgs e)
		{
			CancelAllPendingPlacedOrders();
			ShowPendingPlacedOrders();
		}

		private void CancelAllPendingPlacedOrders()
		{
			//            Debug.Assert(_accounts[_outSiteCode].Trader.GetType() != _accounts[_inSiteCode].Trader.GetType());

			//            Task.Run(() =>
			//            {
			//				lock (_threadLock)
			//				{
			var outSitePlacedOrders = _pendingPlacedOrders[_outSiteCode];
			var inSitePlacedOrders = _pendingPlacedOrders[_inSiteCode];
			//            lock (_threadLock)
			//            {
			if (outSitePlacedOrders != null && outSitePlacedOrders.Count != 0)
			{
				//					Parallel.ForEach(from o in outSitePlacedOrders select o.Id, id => Task.Run(() =>
				//						_accounts[_outSiteCode].Trader.CancelPlacedOrder(id, Trader.Trader.CoinType.Btc)));
				//                Parallel.ForEach(from o in outSitePlacedOrders select o.Id,
				//                    async id =>
				//                        await
				//                            Task.Run(
				//                                () =>
				//                                {
				//                                    _accounts[_outSiteCode].Trader.CancelPlacedOrder(id, Trader.Trader.CoinType.Btc);
				//                                }));
				Task.Run(() =>
				{
					foreach (var o in outSitePlacedOrders)
					{
						_accounts[_outSiteCode].Trader?.CancelPlacedOrder(o.Id, Trader.Trader.CoinType.Btc);
						Task.Delay(100);
					}
				});
			}

			if (inSitePlacedOrders != null && inSitePlacedOrders.Count != 0)
			{
				//                Parallel.ForEach(from o in outSitePlacedOrders select o.Id,
				//                    async id =>
				//                        await
				//                            Task.Run(
				//                                () =>
				//                                {
				//                                    _accounts[_inSiteCode].Trader.CancelPlacedOrder(id, Trader.Trader.CoinType.Btc);
				//                                }));

				Task.Run(() =>
				{
					foreach (var o in inSitePlacedOrders)
					{
						_accounts[_inSiteCode].Trader?.CancelPlacedOrder(o.Id, Trader.Trader.CoinType.Btc);
						Task.Delay(100);
					}
				});
			}
			//				}
			//            });
		}

		private void ShowPendingPlacedOrders()
		{
			var index = 0;
			var outSitePendingPlacedOrders = _pendingPlacedOrders[_outSiteCode];

			if (outSitePendingPlacedOrders != null)
			{
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

			var inSitePendingPlacedOrders = _pendingPlacedOrders[_inSiteCode];
			if (inSitePendingPlacedOrders != null)
			{
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
			var outSiteAccountTrades =
				_accounts[_outSiteCode].AccountTradeRecords.OrderByDescending(t => t.Time)
					.Select(t => new
					{
						SN = outSiteIndex--,
						t.SiteCode,
						t.OrderId,
						t.Type,
						t.Price,
						t.Amount,
						t.Time
					});

			long inSiteIndex = _accounts[_inSiteCode].AccountTradeRecords.Count;
			var inSiteAccountTrades =
				_accounts[_inSiteCode].AccountTradeRecords.OrderByDescending(t => t.Time).Select(
					t =>
						new
						{
							SN = inSiteIndex--,
							t.SiteCode,
							t.OrderId,
							t.Type,
							t.Price,
							t.Amount,
							t.Time
						});

			var totalTrades = from outTrade in outSiteAccountTrades
							  join inTrade in inSiteAccountTrades
								  on outTrade.SN equals inTrade.SN
							  select new
							  {
								  序号 = outTrade.SN,
								  卖出网站 = outTrade.SiteCode == "btcc" ? "BTCC" : "火币网",
								  卖出价格 = outTrade.Price.ToString("0.000"),
								  卖出数量 = outTrade.Amount.ToString("0.0000"),
								  卖出时间 = outTrade.Time.ToString("HH:mm:ss"),
								  买入网站 = inTrade.SiteCode == "btcc" ? "BTCC" : "火币网",
								  买入价格 = inTrade.Price.ToString("0.000"),
								  买入数量 = inTrade.Amount.ToString("0.0000"),
								  买入时间 = inTrade.Time.ToString("HH:mm:ss"),
								  利润 = (outTrade.Price * outTrade.Amount - inTrade.Price * inTrade.Amount).ToString("0.000")
							  };

			gdvTrades.DataSource = totalTrades.ToList();
		}


		private void ShowRealTrades()
		{
			var outSiteClosedPlacedOrders =
				_accounts[_outSiteCode].RealPlacedOrders.Where(o => o.Status == OrderStatus.Closed).ToList();
			var outSiteClosedTrades = (from t in _accounts[_outSiteCode].AccountTradeRecords
									   where outSiteClosedPlacedOrders.Exists(o => o.Id == t.OrderId)
									   select t).ToList();

			var inSiteClosedPlacedOrders =
				_accounts[_inSiteCode].RealPlacedOrders.Where(o => o.Status == OrderStatus.Closed).ToList();
			var inSiteClosedTrades = (from t in _accounts[_inSiteCode].AccountTradeRecords
									  where inSiteClosedPlacedOrders.Exists(o => o.Id == t.OrderId)
									  select t).ToList();

			var totalTrades = (from outOrder in outSiteClosedTrades
							   join inOrder in inSiteClosedTrades
								   on outOrder.TradePairGuid equals inOrder.TradePairGuid
							   select new
							   {
								   卖出网站 = outOrder.SiteCode == "btcc" ? "BTCC" : "火币网",
								   卖出价格 = outOrder.Price.ToString("0.000"),
								   卖出数量 = outOrder.Amount.ToString("0.0000"),
								   卖出时间 = outOrder.Time.ToString("HH:mm:ss"),
								   买入网站 = inOrder.SiteCode == "btcc" ? "BTCC" : "火币网",
								   买入价格 = inOrder.Price.ToString("0.000"),
								   买入数量 = inOrder.Amount.ToString("0.0000"),
								   买入时间 = inOrder.Time.ToString("HH:mm:ss"),
								   利润 =
									   (outOrder.Price * outOrder.Amount - inOrder.Price * inOrder.Amount).ToString(
										   "0.000")
							   }).ToList();

			//            long tradeIndex = totalTrades.Count();
			long tradeIndex = 1;
			gdvTrades.DataSource = (from t in totalTrades
									select new
									{
										序号 = tradeIndex++,
										t.卖出网站,
										t.卖出价格,
										t.卖出数量,
										t.卖出时间,
										t.买入网站,
										t.买入价格,
										t.买入数量,
										t.买入时间,
										t.利润
									}).OrderByDescending(i => i.买入时间).ToList();
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
			//			lock (_threadLock)
			{
				//                Debug.Assert(_accounts[_outSiteCode].Trader.GetType() != _accounts[_inSiteCode].Trader.GetType());

				if (_accounts[_outSiteCode].AccountTradeRecords.Count != 0)
				{
					var outOrderIds = new List<long>();
					for (var index = 0; index < _accounts[_outSiteCode].AccountTradeRecords.Count; index++)
					{
						var t = _accounts[_outSiteCode].AccountTradeRecords[index];
						if (_accounts[_outSiteCode].RealPlacedOrders.Count == 0 ||
							_accounts[_outSiteCode].RealPlacedOrders.All(o => o.Id != t.OrderId))
						{
							outOrderIds.Add(t.OrderId);
						}
					}

					Parallel.ForEach(outOrderIds, o =>
					{
						var order =
							Task.Run(() => _accounts[_outSiteCode].Trader?.GetPlacedOrder(o, Trader.Trader.CoinType.Btc)).Result;

						//                        var order = _accounts[_outSiteCode].Trader?.GetPlacedOrder(o, Trader.Trader.CoinType.Btc);
						if (order != null)
						{
							_accounts[_outSiteCode].RealPlacedOrders.Add(order);
						}
					});
				}

				if (_accounts[_inSiteCode].AccountTradeRecords.Count != 0)
				{
					var inOrderIds = new List<long>();
					foreach (var t in _accounts[_inSiteCode].AccountTradeRecords)
					{
						if (_accounts[_inSiteCode].RealPlacedOrders.Count == 0 ||
							_accounts[_inSiteCode].RealPlacedOrders.All(o => o.Id != t.OrderId))
						{
							inOrderIds.Add(t.OrderId);
						}
					}

					Parallel.ForEach(inOrderIds, o =>
					{
						var order =
							Task.Run(() => _accounts[_inSiteCode].Trader?.GetPlacedOrder(o, Trader.Trader.CoinType.Btc)).Result;
						//                        var order = _accounts[_inSiteCode].Trader?.GetPlacedOrder(o, Trader.Trader.CoinType.Btc);
						if (order != null)
						{
							_accounts[_inSiteCode].RealPlacedOrders.Add(order);
						}
					});
				}
			}
		}

		private void UseRealAccount()
		{
			//            lock (ThreadLock)
			{
				_accounts[_outSiteCode] = new RealAccount { Trader = TraderFactory.GetTrader(_outSiteCode) };
				_accounts[_inSiteCode] = new RealAccount { Trader = TraderFactory.GetTrader(_inSiteCode) };
			}
			//            var outSiteAccountInfo = await Task.Run(() => _accounts[_outSiteCode].Trader?.GetAccountInfo());
			//            var inSiteAccountInfo = await Task.Run(() => _accounts[_inSiteCode].Trader?.GetAccountInfo());

			var outSiteAccountInfo = Task.Run(() => _accounts[_outSiteCode].Trader?.GetAccountInfo()).Result;
			var inSiteAccountInfo = Task.Run(() => _accounts[_inSiteCode].Trader?.GetAccountInfo()).Result;

			//            Debug.Assert(_accounts[_outSiteCode].Trader.GetType() != _accounts[_inSiteCode].Trader.GetType());

			//            var outSiteAccountInfo = _accounts[_outSiteCode].Trader?.GetAccountInfo();
			//            var inSiteAccountInfo = _accounts[_inSiteCode].Trader?.GetAccountInfo();


			if (outSiteAccountInfo != null)
			{
				_accounts[_outSiteCode].Balance = outSiteAccountInfo.AvailableCny;
				_accounts[_outSiteCode].CoinAmount = outSiteAccountInfo.AvailableBtc;
			}

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
			{
				//			lock (_threadLock)
				//			{
				//			var outSiteAccountInfo = Task.Run(() => _accounts[_outSiteCode].Trader?.GetAccountInfo()).Result;
				//			var outSiteAccountInfo = _accounts[_outSiteCode].Trader?.GetAccountInfo();
				//			var inSiteAccountInfo = _accounts[_inSiteCode].Trader?.GetAccountInfo();
				//                lock (ThreadLock)
				{
					//				var outSiteAccountInfo = Task.Run(() => _accounts[_outSiteCode].Trader?.GetAccountInfo()).Result;
					//				var inSiteAccountInfo = Task.Run(() => _accounts[_inSiteCode].Trader?.GetAccountInfo()).Result;

					//                    Debug.Assert(_accounts[_outSiteCode].Trader.GetType() != _accounts[_inSiteCode].Trader.GetType());

					var outSiteAccountInfo = _accounts[_outSiteCode].Trader?.GetAccountInfo();
					var inSiteAccountInfo = _accounts[_inSiteCode].Trader?.GetAccountInfo();

					if (outSiteAccountInfo != null)
					{
						_accounts[_outSiteCode].Balance = outSiteAccountInfo.AvailableCny;
						_accounts[_outSiteCode].CoinAmount = outSiteAccountInfo.AvailableBtc;
					}

					if (inSiteAccountInfo != null)
					{
						_accounts[_inSiteCode].Balance = inSiteAccountInfo.AvailableCny;
						_accounts[_inSiteCode].CoinAmount = inSiteAccountInfo.AvailableBtc;
					}
				}
			}
			//			}
			//			}
		}

		private void UpdatePendingPlacedOrders()
		{
			//			lock (_threadLock)
			//			{
			//			_pendingPlacedOrders[_outSiteCode] = 
			//				_accounts[_outSiteCode].Trader?.GetAllPlacedOrders(Trader.Trader.CoinType.Btc)?
			//					.OrderByDescending(t => t.Time)
			//					.ToList();
			//
			//			_pendingPlacedOrders[_inSiteCode] =
			//				_accounts[_inSiteCode].Trader?.GetAllPlacedOrders(Trader.Trader.CoinType.Btc)?
			//					.OrderByDescending(t => t.Time)
			//					.ToList();

			//			lock (_threadLock)
			//				_pendingPlacedOrders[_outSiteCode] = Task.Run(() =>
			//					_accounts[_outSiteCode].Trader?.GetAllPlacedOrders(Trader.Trader.CoinType.Btc)?
			//						.OrderByDescending(t => t.Time)
			//						.ToList()).Result;
			//
			//				_pendingPlacedOrders[_inSiteCode] = Task.Run(() =>
			//					_accounts[_inSiteCode].Trader?.GetAllPlacedOrders(Trader.Trader.CoinType.Btc)?
			//						.OrderByDescending(t => t.Time)
			//						.ToList()).Result;
			//            Debug.Assert(_accounts[_outSiteCode].Trader.GetType() != _accounts[_inSiteCode].Trader.GetType());


			_pendingPlacedOrders[_outSiteCode] = Task.Run(() =>
				_accounts[_outSiteCode].Trader?.GetAllPlacedOrders(Trader.Trader.CoinType.Btc)?
					.OrderByDescending(t => t.Time)
					.ToList()).Result;

			_pendingPlacedOrders[_inSiteCode] = Task.Run(() =>
				_accounts[_inSiteCode].Trader?.GetAllPlacedOrders(Trader.Trader.CoinType.Btc)?
					.OrderByDescending(t => t.Time)
					.ToList()).Result;

			//			}
		}

		private void ChangeToSimulateMode()
		{
			UseSimulateAccount();
		}

		private void UseSimulateAccount()
		{
			_initialTotalBalance = 2000000;
			_initialTotalCoinAmount = 200;
			_accounts[_outSiteCode] = new SimulateAccount
			{
				Balance = Math.Round(_initialTotalBalance * InitialPercentage),
				CoinAmount = Math.Round(_initialTotalCoinAmount * (1 - InitialPercentage))
			};

			_accounts[_inSiteCode] =
				new SimulateAccount
				{
					Balance = Math.Round(_initialTotalBalance * (1 - InitialPercentage)),
					CoinAmount = Math.Round(_initialTotalCoinAmount * InitialPercentage)
				};
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
			//            nudPeroid.Enabled = _allowAutoTrade;
		}

		private void btnPlaceOrder_Click(object sender, EventArgs e)
		{
			if (Strategies.Count != 0)
			{
				var strategy = Strategies[0];
				var amount = strategy.m <= strategy.InputParameters.SingleTradeCoinLimit
					? strategy.m
					: strategy.InputParameters.SingleTradeCoinLimit;


				Task.Run(() => strategy.TryTrade
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
						amount,
						_outSiteCode,
						_inSiteCode
					));

				if (_inRealMode)
				{
					UpdateRealAccount();
					UpdatePendingPlacedOrders();
					UpdateAllPlacedOrders();
				}
			}
		}

		private void btnShowPendingPlacedOrders_Click(object sender, EventArgs e)
		{
			ShowPendingPlacedOrders();
		}

		private void lblStrategyValues_Click(object sender, EventArgs e)
		{
		}

		private void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
		{
			var thisComboBox = (ComboBox)sender;
			var thatComboBox = thisComboBox == cmbOutSite ? cmbInSite : cmbOutSite;

			if (thisComboBox.Text == thatComboBox.Text)
			{
				thatComboBox.SelectedIndex = _previousSiteIndex;
			}

			//			lock (_threadLock)
			{
				_outSiteCode = cmbOutSite.SelectedValue?.ToString();
				_inSiteCode = cmbInSite.SelectedValue?.ToString();
			}

			//only stop, never start
			if (btnStartStopStrategy.Text == ButtonStopText)
			{
				btnStartStopStrategy_Click(btnStartStopStrategy, null);
			}


			//			if (_placedOrders[_outSiteCode] != null)
			//			{
			//				_placedOrders[_outSiteCode].Clear();
			//			}
			//
			//			if (_placedOrders[_inSiteCode] != null)
			//			{
			//				_placedOrders[_inSiteCode].Clear();
			//			}
			//
			//			if (_accounts[_outSiteCode].AccountTradeRecords != null)
			//			{
			//				_accounts[_outSiteCode].AccountTradeRecords.Clear();
			//			}
			//
			//			if (_accounts[_inSiteCode].AccountTradeRecords != null)
			//			{
			//				_accounts[_inSiteCode].AccountTradeRecords.Clear();
			//			}
		}

		private void cmbSite_Click(object sender, EventArgs e)
		{
			_previousSiteIndex = ((ComboBox)sender).SelectedIndex;
		}

		private void label8_Click(object sender, EventArgs e)
		{
		}

		private void chkAutoCancel_CheckedChanged(object sender, EventArgs e)
		{
			_allowAutoCancel = chkAutoCancel.Checked;
			//            nudAutoCancelLag.Enabled = _allowAutoCancel;
		}

		private enum ControlName
		{
			lblBuyPrice,
			lblBuyAmount,
			lblSellPrice,
			lblSellAmount
		}

		private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
		{
		}

		private void chkAutoBuy_CheckedChanged(object sender, EventArgs e)
		{
			_allowAutoBuy = chkAutoBuy.Checked;
		}
	}
}