﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCPrice_Catcher.Class;
using BCPrice_Catcher.Model;
using BCPrice_Catcher.Util;

namespace BCPrice_Catcher
{
    public partial class Form4 : Form
    {
        private const int StrategyMaxQuantity = 9;
        private const int StrategyMinQuantity = 1;
        private const double InitialPecentage = 0.4d;

        private Dictionary<string, SimulateAccount> _accounts = new Dictionary<string, SimulateAccount>()
        {
            {
                "btcc",
                new SimulateAccount
                {
                    Balance = Math.Round(TotalBalance * InitialPecentage),
                    CoinAmount = Math.Round(TotalCoinAmount * (1 - InitialPecentage))
                }
            },
            {
                "huobi",
                new SimulateAccount
                {
                    Balance = Math.Round(TotalBalance * (1 - InitialPecentage)),
                    CoinAmount = Math.Round(TotalCoinAmount * (InitialPecentage))
                }
            }
        };

        private List<Strategy> _strategies = new List<Strategy>();
        private TimerList _strategyTimerList = new TimerList();
        //private List<int> _strategyCounters = new List<int>();

        private double _btccPrice;
        private double _huobiPrice;
        private double _baseDifferPrice;

        const double TotalBalance = 2000000;
        const double TotalCoinAmount = 200;

        private static string[] Titles =
        {
            "策略ID", "交易阙值更新时间", "交易阙值", "交易阙值增量", "交易阙值系数", "回归阙值", "回归阙值增量", "回归阙值系数", "交易延时阙值", "交易次数阙值", "总交易次数阙值",
            "周期"
        };

        //额外有两列放按钮
        private readonly int StrategyControlColumnCount = Titles.Length + 2;

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
            btnStartStrategy,
            btnStopStrategy
        }


        public Form4()
        {
            InitializeComponent();
        }

        private void GenerateTitleControls()
        {
            for (int i = 0; i < Titles.Length; i++)
            {
                tableLayoutPanelStrategies.Controls.Add(
                    new Label
                    {
                        Text = Titles[i],
                        TextAlign = ContentAlignment.MiddleCenter
                    }, i, 0);
            }

            tableLayoutPanelStrategies.Controls.Add(
                new Button()
                {
                    Name = "btnAddStrategy",
                    Text = "增加策略",
                    BackColor = Color.LightGreen,
                    Dock = DockStyle.Fill,
                    Width = 80
                }, Titles.Length, 0);

            tableLayoutPanelStrategies.Controls.Add(
                new Button()
                {
                    Name = "btnRemoveStrategy",
                    Text = "减少策略",
                    BackColor = Color.LightCoral,
                    Dock = DockStyle.Fill,
                    Width = 80
                }, Titles.Length + 1, 0);
        }

        private void GenerateStrategyControls(int strategyId)
        {
            int rowPosition = strategyId + 1;
            int columnPosition = 0;
            //策略号

            tableLayoutPanelStrategies.Controls.Add(
                new Label
                {
                    Name = $"{ControlName.lblStrategyID}{strategyId}",
                    Text = (rowPosition).ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                }, columnPosition++, rowPosition);

            //交易阙值更新时间
            tableLayoutPanelStrategies.Controls.Add(
                new Label
                {
                    Name = $"{ControlName.lblTradeThresholdLastUpdated}{strategyId}",
                    Text = (rowPosition).ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                }, columnPosition++, rowPosition);


            //交易阙值
            tableLayoutPanelStrategies.Controls.Add(
                new Label
                {
                    Name = $"{ControlName.lblTradeThreshold}{strategyId}",
                    Text = (rowPosition + 1).ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                }, columnPosition++,
                rowPosition);
            //启动阙值增量
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudTradeThresholdIncrement}{strategyId}",
                    Value = 0,
                    Maximum = int.MaxValue,
                    Minimum = int.MinValue,
                    Dock = DockStyle.Fill,
                    DecimalPlaces = 3,
                    Increment = 0.001M,
                    Width = 50
                }, columnPosition++, rowPosition);
            //启动阙值系数
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudTradeThresholdCoefficient}{strategyId}",
                    Value = 1 + strategyId * 0.3M,
                    Maximum = int.MaxValue,
                    Minimum = 0,
                    DecimalPlaces = 3,
                    Increment = 0.001M,
                    Dock = DockStyle.Fill,
                    Width = 50
                }, columnPosition++, rowPosition);


            //回归阙值
            tableLayoutPanelStrategies.Controls.Add(
                new Label()
                {
                    Name = $"{ControlName.lblRegressionThreshold}{strategyId}",
                    Text = "0",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                }, columnPosition++,
                rowPosition);

            //回归阙值增量
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudRegressionThresholdIncrement}{strategyId}",
                    Value = 0,
                    Maximum = int.MaxValue,
                    Minimum = int.MinValue,
                    Increment = 0.001M,
                    Dock = DockStyle.Fill,
                    Width = 50
                }, columnPosition++, rowPosition);

            //回归阙值系数
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudRegressionThresholdCoefficient}{strategyId}",
                    Value = 0.5M,
                    Maximum = int.MaxValue,
                    Minimum = int.MinValue,
                    DecimalPlaces = 3,
                    Increment = 0.001M,
                    Dock = DockStyle.Fill,
                    Width = 50
                }, columnPosition++, rowPosition);

            //最小时间间隔
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudTradeLagThreshold}{strategyId}",
                    Value = 1,
                    Maximum = int.MaxValue,
                    Minimum = 1,
                    DecimalPlaces = 0,
                    Increment = 1,
                    Dock = DockStyle.Fill,
                    Width = 50
                }, columnPosition++, rowPosition);

            //
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudTradeCountThreshold}{strategyId}",
                    Value = 1,
                    Maximum = int.MaxValue,
                    Minimum = 1,
                    DecimalPlaces = 0,
                    Increment = 1,
                    Dock = DockStyle.Fill,
                    Width = 50
                }, columnPosition++, rowPosition);

            //策略成交总数量限制
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudTotalTradeCountLimit}{strategyId}",
                    Maximum = int.MaxValue,
                    Value = 99999999,
                    Minimum = 1,
                    DecimalPlaces = 0,
                    Increment = 1,
                    Dock = DockStyle.Fill,
                    Width = 50
                }, columnPosition++, rowPosition);

            //周期
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudPeriod}{strategyId}",
                    Value = Convert.ToInt32(Math.Pow(2, strategyId)),
                    Maximum = int.MaxValue,
                    Minimum = 1,
                    DecimalPlaces = 0,
                    Increment = 1,
                    Dock = DockStyle.Fill,
                    Width = 50
                }, columnPosition++, rowPosition);

            //开始按钮
            Button btnStart = new Button
            {
                Name = $"{ControlName.btnStartStrategy}{strategyId}",
                Text = "开始",
                BackColor = Color.LightGreen,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            btnStart.Tag = strategyId;
            btnStart.Click += btnStartStrategy_Click;

            tableLayoutPanelStrategies.Controls.Add(btnStart, columnPosition++, rowPosition);


            //结束按钮

            Button btnStop = new Button()
            {
                Name = $"{ControlName.btnStopStrategy}{strategyId}",
                Text = "停止",
                BackColor = Color.LightCoral,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            btnStop.Tag = strategyId;
            btnStop.Click += btnStopStrategy_Click;
            tableLayoutPanelStrategies.Controls.Add(btnStop, columnPosition++, rowPosition);

            //                foreach (var c in tableLayoutPanelStrategies.Controls)
            //                {
            //                    ((Control) c).Dock = DockStyle.Fill;
            //                    ((Control) c).Anchor = AnchorStyles.Left | AnchorStyles.Right;
            //                }
        }

        private void btnStopStrategy_Click(object sender, EventArgs e)
        {
            int strategyId = Convert.ToInt32((sender as Button).Tag);
            StopStrategy(strategyId);
        }

        private void StopStrategy(int strategyId)
        {
            _strategyTimerList.Timers[$"strategy_timer{strategyId}"].Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void btnStartStrategy_Click(object sender, EventArgs e)
        {
            int strategyId = Convert.ToInt32((sender as Button).Tag);
            StartStrategy(strategyId);
        }

        private void StartStrategy(int strategyId)
        {
            _strategyTimerList.Timers[$"strategy_timer{strategyId}"].Change(0, 1000);
        }

        //add a new strategy
        private void AddStrategy()
        {
            int strategyId = _strategies.Count;
            GenerateStrategyControls(strategyId);


            Strategy strategy = new Strategy()
            {
                Id = strategyId,
                InputParameters = GetStrategyParameters(strategyId),
                //InputParameters = GetStrategyParameters(strategyId).Result,
                PreviousStrategy = strategyId == 0 ? null : _strategies[strategyId - 1]
            };
            _strategies.Add(strategy);

            int tradeAmount = Convert.ToInt32(nudTradeAmount.Value);
            //need await here?
            //need task here?
            _strategyTimerList.Add($"strategy_timer{strategy.Id}", Timeout.Infinite, async o =>
            {
                await Task.Run(() =>
                {
                    _strategies[strategy.Id].Update(GetStrategyParameters(strategy.Id));
                    _strategies[strategy.Id].TryTrade(_accounts, new Dictionary<string, double>
                    {
                        {"btcc", _btccPrice},
                        {"huobi", _huobiPrice}
                    }, tradeAmount);
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
        }

        private void InitializeControls()
        {
            tableLayoutPanelStrategies.Visible = false;
            //            tableLayoutPanelStrategies.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanelStrategies.Visible = true;
            GenerateTitleControls();

            tableLayoutPanelStrategies.Controls["btnAddStrategy"].Enabled = false;
            tableLayoutPanelStrategies.Controls["btnRemoveStrategy"].Enabled = false;
            tableLayoutPanelStrategies.Controls["btnAddStrategy"].Click += btnAddStrategy_Click;
            tableLayoutPanelStrategies.Controls["btnAddStrategy"].Click += CheckControlStatus;
            tableLayoutPanelStrategies.Controls["btnRemoveStrategy"].Click += btnRemoveStrategy_Click;
            tableLayoutPanelStrategies.Controls["btnRemoveStrategy"].Click += CheckControlStatus;
        }

        private void Form4_Activated(object sender, EventArgs e)
        {
        }

        private void Form4_Shown(object sender, EventArgs e)
        {
            //accounts must be set first (because accounts is need in strategy)
            //show accounts for the first time
            trackBar1_ValueChanged(null, null);

            AddStrategy();
            AddStrategy();
            AddStrategy();
        }

        private void btnAddStrategy_Click(object sender, EventArgs e)
        {
            if (_strategies.Count < StrategyMaxQuantity)
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
            for (int i = controlCount - 1;
                i >= controlCount - StrategyControlColumnCount;
                i--)
            {
                tableLayoutPanelStrategies.Controls.Remove(tableLayoutPanelStrategies.Controls[i]);
            }
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
            //_accounts.Clear();

            _accounts["btcc"].Balance = Math.Round(TotalBalance * pecentage);
            _accounts["btcc"].CoinAmount = Math.Round(TotalCoinAmount * (1 - pecentage));

            _accounts["huobi"].Balance = Math.Round(TotalBalance * (1 - pecentage));
            _accounts["huobi"].CoinAmount = Math.Round(TotalCoinAmount * (pecentage));
        }


        private void ShowAccounts()
        {
            lblBtccAccount.Text
                =
                $"BTCC({trackBar1.Value}%){Environment.NewLine}现金：{_accounts["btcc"].Balance}{Environment.NewLine}币数：{_accounts["btcc"].CoinAmount}";
            lblHuobiAccount.Text
                =
                $"HUOBI({trackBar1.Maximum - trackBar1.Value}%){Environment.NewLine}现金：{_accounts["huobi"].Balance}{Environment.NewLine}币数：{_accounts["huobi"].CoinAmount}";
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            AdjustAccounts(Convert.ToDouble(trackBar1.Value) / trackBar1.Maximum);
            ShowAccounts();
        }

        private
            void GetPrices()
        {
            if (
                Tag != null)
            {
                Dictionary<string, double> prices = Tag as Dictionary<string, double>;

                if (
                    prices.Count
                    == 2)
                {
                    _btccPrice = prices["btcc"];
                    _huobiPrice = prices["huobi"];
                    _baseDifferPrice = Math.Abs(_btccPrice - _huobiPrice);
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
                int i = 0;
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
                    ((
                        _btccPrice
                        -
                        _huobiPrice
                        ));
            lblBtccPrice.Text
                = $"BTCC{Environment.NewLine}{_btccPrice.ToString("0.000")}";
            lblHuobiPrice.Text
                = $"HUOBI{Environment.NewLine}{_huobiPrice.ToString("0.000")}";
            lblDifferPrice.Text
                = $"差价{Environment.NewLine}{_baseDifferPrice.ToString("0.000")}";
            lblTotalProfits.Text
                =
                $"总利润{Environment.NewLine}{(_accounts["btcc"].Balance + _accounts["huobi"].Balance - TotalBalance).ToString("0.000")}";

            if (
                _btccPrice
                >
                _huobiPrice
                )
            {
                lblDifferPrice.Text = lblDifferPrice.Text.Insert(4, "<< ");
            }
            else if (
                _btccPrice < _huobiPrice)
            {
                lblDifferPrice.Text
                    =
                    lblDifferPrice.Text
                    + " >>";
            }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ShowStrategyValues(Strategy strategy)
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
        }

        private Strategy.StrategyInputParameters GetStrategyParameters(int strategyId)
        {
            string s1 =
                (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeThresholdIncrement}{strategyId}"] as
                    NumericUpDown).Text;

            string s2 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeThresholdCoefficient}{strategyId}"]
                as
                NumericUpDown).Text;

            string s3 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeLagThreshold}{strategyId}"] as
                NumericUpDown).Text;
            string s4 =
                (tableLayoutPanelStrategies.Controls[
                    $"{ControlName.nudRegressionThresholdIncrement}{strategyId}"]
                    as NumericUpDown).Text;
            string s5 =
                (tableLayoutPanelStrategies.Controls[
                    $"{ControlName.nudRegressionThresholdCoefficient}{strategyId}"]
                    as NumericUpDown).Text;

            string s6 = nudStartPrice.Text;
            string s7 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudPeriod}{strategyId}"]
                as NumericUpDown).Text;

            string s8 = (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTotalTradeCountLimit}{strategyId}"]
                as NumericUpDown).Text;


            var parameters = new Strategy.StrategyInputParameters
            {
                TradeThresholdIncrement = s1.Length != 0 ? Convert.ToDouble(s1) : 0,
                TradeThresholdCoefficient = s2.Length != 0 ? Convert.ToDouble(s2) : 0,
                TradeLagThreshold = s3.Length != 0 ? Convert.ToInt32(s3) : 0,
                RegressionThresholdIncrement = s4.Length != 0 ? Convert.ToDouble(s4) : 0,
                RegressionThresholdCoefficient = s5.Length != 0 ? Convert.ToDouble(s5) : 0,
                StartPrice = s6.Length != 0 ? Convert.ToDouble(s6) : 3,
                Peroid = s7.Length != 0 ? Convert.ToInt32(s7) : 1,
                TotalTradeCountLimit = s8.Length != 0 ? Convert.ToInt32(s8) : 99999999,
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
            foreach (var s in _strategies)
            {
                StartStrategy(s.Id);
            }
        }

        private void btnAllStop_Click(object sender, EventArgs e)
        {
            foreach (var s in _strategies)
            {
                StopStrategy(s.Id);
            }
        }

        private void ShowTrades()
        {
            long index = _accounts["btcc"].Trades.Count;
            gdvBtccTrades.DataSource =
                _accounts["btcc"].Trades.OrderByDescending(t => t.Time)
                    .Select(
                        t =>
                            new
                            {
                                SN = index--,
                                StrategyID = t.StrategyId,
                                Price = t.Price.ToString("0.000"),
                                t.Amount,
                                Time = t.Time.ToString("HH:mm:ss"),
                                t.Type,
                                Profit = t.Profit.ToString("0.000")
                            })
                    .ToList();

            index = _accounts["huobi"].Trades.Count;
            gdvHuobiTrades.DataSource = _accounts["huobi"].Trades.OrderByDescending(t => t.Time).Select(
                t =>
                    new
                    {
                        SN = index--,
                        StrategyID = t.StrategyId,
                        Price = t.Price.ToString("0.000"),
                        t.Amount,
                        Time = t.Time.ToString("HH:mm:ss"),
                        t.Type,
                        Profit = t.Profit.ToString("0.000")
                    }).ToList();
        }
    }
}