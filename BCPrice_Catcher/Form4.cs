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

        private const double TotalBalance = 2000000;
        private const double TotalCoinAmount = 200;

        private static readonly string[] Titles =
        {
            "策略ID", "交易阙值\n更新时间", "交易阙值", "交易阙值\n增量", "交易阙值\n系数", "回归阙值", "回归阙值\n增量", "回归阙值\n系数", "交易延时\n阙值", "交易次数\n阙值",
            "总交易次数\n阙值",
            "周期", "交易数量"
        };

        private readonly Dictionary<string, Account> _accounts = new Dictionary<string, Account>
        {
            {"btcc", new SimulateAccount()},
            {"huobi", new SimulateAccount()}
        };


        private readonly List<Strategy> _strategies = new List<Strategy>();
        private readonly TimerList _strategyTimerList = new TimerList();

        //额外有两列放按钮
        private readonly int StrategyControlColumnCount = Titles.Length + 2;

        private double _baseDifferPrice;
        //private List<int> _strategyCounters = new List<int>();

        private double _btccPrice;
        private double _huobiPrice;

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

        private void GenerateStrategyControls(int strategyId)
        {
            var rowPosition = strategyId + 1;
            var columnPosition = 0;
            //策略号

            tableLayoutPanelStrategies.Controls.Add(
                new Label
                {
                    Name = $"{ControlName.lblStrategyID}{strategyId}",
                    Text = rowPosition.ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                }, columnPosition++, rowPosition);

            //交易阙值更新时间
            tableLayoutPanelStrategies.Controls.Add(
                new Label
                {
                    Name = $"{ControlName.lblTradeThresholdLastUpdated}{strategyId}",
                    Text = rowPosition.ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold)
                }, columnPosition++, rowPosition);


            //交易阙值
            tableLayoutPanelStrategies.Controls.Add(
                new Label
                {
                    Name = $"{ControlName.lblTradeThreshold}{strategyId}",
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
                    Name = $"{ControlName.nudTradeThresholdIncrement}{strategyId}",
                    Value = 0,
                    Maximum = int.MaxValue,
                    Minimum = int.MinValue,
                    Dock = DockStyle.Fill,
                    DecimalPlaces = 3,
                    Increment = 0.001M,
                    Width = 30
                }, columnPosition++, rowPosition);
            //30
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
                    Width = 30
                }, columnPosition++, rowPosition);


            //回归阙值
            tableLayoutPanelStrategies.Controls.Add(
                new Label
                {
                    Name = $"{ControlName.lblRegressionThreshold}{strategyId}",
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
                    Name = $"{ControlName.nudRegressionThresholdIncrement}{strategyId}",
                    Value = 0,
                    Maximum = int.MaxValue,
                    Minimum = int.MinValue,
                    Increment = 0.001M,
                    Dock = DockStyle.Fill,
                    Width = 30
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
                    Width = 30
                }, columnPosition++, rowPosition);

            //最小时间间隔
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudTradeLagThreshold}{strategyId}",
                    Value = 0,
                    Maximum = int.MaxValue,
                    Minimum = 0,
                    DecimalPlaces = 0,
                    Increment = 1,
                    Dock = DockStyle.Fill,
                    Width = 30
                }, columnPosition++, rowPosition);

            //
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudTradeCountThreshold}{strategyId}",
                    Value = 0,
                    Maximum = int.MaxValue,
                    Minimum = 0,
                    DecimalPlaces = 0,
                    Increment = 1,
                    Dock = DockStyle.Fill,
                    Width = 30
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
                    Width = 40
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
                    Width = 40
                }, columnPosition++, rowPosition);

            //交易数量
            tableLayoutPanelStrategies.Controls.Add(
                new Label
                {
                    Name = $"{ControlName.lblTotalTradeCount}{strategyId}",
                    Text = rowPosition.ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font(Font.FontFamily, Font.Size, Font.Style | FontStyle.Bold)
                }, columnPosition++, rowPosition);


            //开始按钮
            var btnStart = new Button
            {
                Name = $"{ControlName.btnStartStopStrategy}{strategyId}",
                Text = "开始",
                BackColor = Color.LightGreen,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            btnStart.Tag = strategyId;
            btnStart.Click += btnStartStopStrategy_Click;

            tableLayoutPanelStrategies.Controls.Add(btnStart, columnPosition++, rowPosition);
        }

        private void btnStopStrategy_Click(object sender, EventArgs e)
        {
        }

        private void StopStrategy(int strategyId)
        {
            _strategyTimerList.Timers[$"strategy_timer{strategyId}"].Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void btnStartStopStrategy_Click(object sender, EventArgs e)
        {
            var strategyId = Convert.ToInt32((sender as Button).Tag);

            var button = sender as Button;

            if (button.Text == ButtonStartText)
            {
                StartStrategy(strategyId);
                (sender as Button).BackColor = Color.LightCoral;
                (sender as Button).Text = ButtonStopText;
            }
            else
            {
                StopStrategy(strategyId);
                (sender as Button).BackColor = Color.LightGreen;
                (sender as Button).Text = ButtonStartText;
            }
        }

        private void StartStrategy(int strategyId)
        {
            _strategyTimerList.Timers[$"strategy_timer{strategyId}"].Change(0, 1000);
        }

        //add a new strategy
        private void AddStrategy()
        {
            var strategyId = _strategies.Count;
            GenerateStrategyControls(strategyId);


            var strategy = new Strategy
            {
                Id = strategyId,
                InputParameters = GetStrategyParameters(strategyId),
                //InputParameters = GetStrategyParameters(strategyId).Result,
                PreviousStrategy = strategyId == 0 ? null : _strategies[strategyId - 1]
            };
            _strategies.Add(strategy);

            var tradeAmount = Convert.ToInt32(nudTradeAmount.Value);
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

            //set gridview font size
            gdvBtccTrades.ColumnHeadersDefaultCellStyle.Font = new Font(gdvBtccTrades.DefaultCellStyle.Font.FontFamily,
                9);
            gdvBtccTrades.DefaultCellStyle.Font = new Font(gdvBtccTrades.DefaultCellStyle.Font.FontFamily, 9);
            gdvHuobiTrades.ColumnHeadersDefaultCellStyle.Font = new Font(
                gdvBtccTrades.DefaultCellStyle.Font.FontFamily, 9);
            gdvHuobiTrades.DefaultCellStyle.Font = new Font(gdvBtccTrades.DefaultCellStyle.Font.FontFamily, 9);
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
            var controlCount = tableLayoutPanelStrategies.Controls.Count;
            for (var i = controlCount - 1;
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
            _accounts["huobi"].CoinAmount = Math.Round(TotalCoinAmount * pecentage);
        }


        private void ShowAccounts()
        {
            lblBtccAccount.Text
                =
                $"BTCC({trackBar1.Value}%){Environment.NewLine}现金：{_accounts["btcc"].Balance.ToString("0.000")}{Environment.NewLine}币数：{_accounts["btcc"].CoinAmount.ToString("0.000")}";
            lblHuobiAccount.Text
                =
                $"HUOBI({trackBar1.Maximum - trackBar1.Value}%){Environment.NewLine}现金：{_accounts["huobi"].Balance.ToString("0.000")}{Environment.NewLine}币数：{_accounts["huobi"].CoinAmount.ToString("0.000")}";
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
                var prices = Tag as Dictionary<string, double>;

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
                    (_btccPrice
                     -
                     _huobiPrice);
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
            (tableLayoutPanelStrategies.Controls[$"{ControlName.lblTotalTradeCount}{strategy.Id}"] as Label)
                .Text =
                strategy.TradeCount.ToString();
        }

        private Strategy.StrategyInputParameters GetStrategyParameters(int strategyId)
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


            var parameters = new Strategy.StrategyInputParameters
            {
                TradeThresholdIncrement = Regex.IsMatch(s1, floatRegex) ? Convert.ToDouble(s1) : 0,
                TradeThresholdCoefficient = Regex.IsMatch(s2, floatRegex) ? Convert.ToDouble(s2) : 0,
                TradeLagThreshold = Regex.IsMatch(s3, integerRegex) ? Convert.ToInt32(s3) : 0,
                RegressionThresholdIncrement = Regex.IsMatch(s4, floatRegex) ? Convert.ToDouble(s4) : 0,
                RegressionThresholdCoefficient = Regex.IsMatch(s5, floatRegex) ? Convert.ToDouble(s5) : 0,
                StartPrice = Regex.IsMatch(s6, floatRegex) ? Convert.ToDouble(s6) : 3,
                Peroid = Regex.IsMatch(s7, integerRegex) ? Convert.ToInt32(s7) : 1,
                TotalTradeCountLimit = Regex.IsMatch(s8, integerRegex) ? Convert.ToInt32(s8) : 99999999
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

            for (var i = 0; i < _strategies.Count; i++)
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
            for (var i = 0; i < _strategies.Count; i++)
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
            long index = _accounts["btcc"].TradeRecords.Count;
            gdvBtccTrades.DataSource =
                _accounts["btcc"].TradeRecords.OrderByDescending(t => t.Time)
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

            index = _accounts["huobi"].TradeRecords.Count;
            gdvHuobiTrades.DataSource = _accounts["huobi"].TradeRecords.OrderByDescending(t => t.Time).Select(
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
                ChangeToRealMode();
            }
            else //change to simulate mode
            {
                _inRealMode = false;
                btnSwitchMode.BackColor = Color.LimeGreen;
                btnSwitchMode.Text = "启动真实模式(&R)";
                ChangeToSimulateMode();
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
            _accounts["btcc"] = btccAccount;

            var huobiAccount = new RealAccount {Trader = new HuobiTrader()};
            accountInfo = huobiAccount.Trader.GetAccountInfo();
            huobiAccount.Balance = accountInfo.AvailableCny;
            huobiAccount.CoinAmount = accountInfo.AvailableBtc;
            _accounts["huobi"] = huobiAccount;
        }


        private void ChangeToSimulateMode()
        {
            UseSimulateAccount();
        }

        private void UseSimulateAccount()
        {
            _accounts["btcc"] = new SimulateAccount
            {
                Balance = Math.Round(TotalBalance * InitialPecentage),
                CoinAmount = Math.Round(TotalCoinAmount * (1 - InitialPecentage))
            };

            _accounts["huobi"] = new SimulateAccount
            {
                Balance = Math.Round(TotalBalance * (1 - InitialPecentage)),
                CoinAmount = Math.Round(TotalCoinAmount * InitialPecentage)
            };
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
            lblTotalTradeCount,
            btnStartStopStrategy
        }
    }
}