using System;
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

        private Dictionary<string, SimulateAccount> _accounts = new Dictionary<string, SimulateAccount>();
        private List<Strategy> _strategies = new List<Strategy>();
        private TimerList _strategyTimerList = new TimerList();
        private List<int> _strategyCounters = new List<int>();

        private double _btccPrice;
        private double _huobiPrice;
        private double _baseDifferPrice;

        private static string[] Titles =
        {
            "策略ID", "交易阙值", "交易阙值增量", "交易阙值系数", "回归阙值", "回归阙值增量", "回归阙值系数", "交易延时阙值", "交易次数阙值", "总交易次数阙值"
        };

        //额外有两列放按钮
        private readonly int StrategyControlColumnCount = Titles.Length + 2;

        private enum ControlName
        {
            lblStrategyID = 0,
            lblTradeThreshold,
            nudTradeThresholdIncrement,
            nudTradeThresholdCoefficient,
            lblRegressionThreshold,
            nudRegressionThresholdIncrement,
            nudRegressionThresholdCoefficient,
            nudTradeLagThreshold,
            nudTradeCountThreshold,
            nudTotalTradeCountLimit,
            btnStrategyStart,
            btnStrategyStop
        }


        public Form4()
        {
            InitializeComponent();
        }

        private void AddTitleControls()
        {
            for (int i = 0; i < Titles.Length; i++)
            {
                tableLayoutPanelStrategies.Controls.Add(
                    new Label
                    {
                        Text = Titles[i]
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
                }, 10, 0);

            tableLayoutPanelStrategies.Controls.Add(
                new Button()
                {
                    Name = "btnRemoveStrategy",
                    Text = "减少策略",
                    BackColor = Color.LightCoral,
                    Dock = DockStyle.Fill,
                    Width = 80
                }, 11, 0);
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
                    Dock = DockStyle.Fill
                }, columnPosition++, rowPosition);

            //启动阙值
            tableLayoutPanelStrategies.Controls.Add(
                new Label
                {
                    Name = $"{ControlName.lblTradeThreshold}{strategyId}",
                    Text = (rowPosition + 1).ToString(),
                    Dock = DockStyle.Fill
                }, columnPosition++,
                rowPosition);
            //启动阙值增量
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudTradeThresholdIncrement}{strategyId}",
                    Value = 0,
                    Maximum = 10,
                    Minimum = -10,
                    Dock = DockStyle.Fill
                }, columnPosition++, rowPosition);
            //启动阙值系数
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudTradeThresholdCoefficient}{strategyId}",
                    Value = 1 + strategyId * 0.3M,
                    Maximum = int.MaxValue,
                    Minimum = 0.1M,
                    DecimalPlaces = 1,
                    Increment = 0.1M,
                    Dock = DockStyle.Fill
                }, columnPosition++, rowPosition);


            //回归阙值
            tableLayoutPanelStrategies.Controls.Add(
                new Label()
                {
                    Name = $"{ControlName.lblRegressionThreshold}{strategyId}",
                    Text = "0",
                    Dock = DockStyle.Fill
                }, columnPosition++,
                rowPosition);

            //回归阙值增量
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudRegressionThresholdIncrement}{strategyId}",
                    Value = 0,
                    Maximum = 10,
                    Minimum = -10,
                    Increment = 1,
                    Dock = DockStyle.Fill
                }, columnPosition++, rowPosition);

            //回归阙值系数
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudRegressionThresholdCoefficient}{strategyId}",
                    Value = 0.5M,
                    Maximum = 1,
                    Minimum = 0.1M,
                    DecimalPlaces = 1,
                    Increment = 0.1M,
                    Dock = DockStyle.Fill
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
                    Dock = DockStyle.Fill
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
                    Dock = DockStyle.Fill
                }, columnPosition++, rowPosition);

            //成交数量阙值
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudTotalTradeCountLimit}{strategyId}",
                    Value = 1,
                    Maximum = int.MaxValue,
                    Minimum = 1,
                    DecimalPlaces = 0,
                    Increment = 1,
                    Dock = DockStyle.Fill
                }, columnPosition++, rowPosition);

            //开始按钮


            Button button = new Button
            {
                Name = $"{ControlName.btnStrategyStart}{strategyId}",
                Text = "开始",
                BackColor = Color.LightGreen,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            button.Click += StartStrategy;

            tableLayoutPanelStrategies.Controls.Add(button, columnPosition++, rowPosition);


            //结束按钮
            tableLayoutPanelStrategies.Controls.Add(
                new Button()
                {
                    Name = $"{ControlName.btnStrategyStop}{strategyId}",
                    Text = "结束",
                    BackColor = Color.LightCoral,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, columnPosition++, rowPosition);

//                foreach (var c in tableLayoutPanelStrategies.Controls)
//                {
//                    ((Control) c).Dock = DockStyle.Fill;
//                    ((Control) c).Anchor = AnchorStyles.Left | AnchorStyles.Right;
//                }
        }

        private void StartStrategy(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }

        private void AddStrategy()
        {
            int strategyId = _strategies.Count;
            GenerateStrategyControls(strategyId);

            Strategy strategy = new Strategy()
            {
                Id = strategyId,
                InputParameters = GetStrategyParameters(strategyId)
            };
            _strategies.Add(strategy);

            //need await here?
            //need task here?
            _strategyTimerList.Add($"strategy_timer{strategy.Id}", ((strategy.Id + 1) * 2) * 1000, async o =>
            {
                await Task.Run(() => { _strategies[strategy.Id].Update(GetStrategyParameters(strategy.Id)); });


                //strategies[strategy.Id] = await task;
            });
            //_strategyTimerList.Timers[$"strategy{strategy.Id}"].Change()

            _strategyCounters.Add(((strategy.Id + 1) * 2 - 1));
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
            AddTitleControls();

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
            AddStrategy();
            AddStrategy();
            AddStrategy();

            //show accounts for the first time
            trackBar1_ValueChanged(null, null);
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

        private void ShowAccounts()
        {
            lblBtccAccount.Text =
                $"BTCC({trackBar1.Value}%){Environment.NewLine}现金：{_accounts["btcc"].Balance}{Environment.NewLine}币数：{_accounts["btcc"].CoinAmount}";
            lblHuobiAccount.Text =
                $"HUOBI({trackBar1.Maximum - trackBar1.Value}%){Environment.NewLine}现金：{_accounts["huobi"].Balance}{Environment.NewLine}币数：{_accounts["huobi"].CoinAmount}";
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            AdjustAccounts(Convert.ToDouble(trackBar1.Value) / trackBar1.Maximum);
            ShowAccounts();
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

//            foreach (var s in _strategies)
//            {
//                ChangeStrategyValues(s);
//            }

            for (int i = 0; i < _strategies.Count; i++)
            {
                ShowStrategyValues(_strategies[i]);

                if (_strategyCounters[i] != 0)
                {
                    _strategyCounters[i]--;
                }
                else
                {
                    _strategyCounters[i] = ((_strategies[i].Id + 1) * 2-1);
                }

                (tableLayoutPanelStrategies.Controls[$"{ControlName.lblStrategyID}{i}"] as Label).Text =
                    _strategyCounters[i].ToString();
            }

            ShowAccounts();
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
                lblDifferPrice.Text = lblDifferPrice.Text.Insert(4, "<< ");
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

        private void ShowStrategyValues(Strategy strategy)
        {
            (tableLayoutPanelStrategies.Controls[$"{ControlName.lblTradeThreshold}{strategy.Id}"] as Label).Text =
                strategy.TradeThreshold.ToString("0.00");

            (tableLayoutPanelStrategies.Controls[$"{ControlName.lblRegressionThreshold}{strategy.Id}"] as Label).Text =
                strategy.RegressionThreshold.ToString("0.00");
        }

        private Strategy.StrategyInputParameters GetStrategyParameters(int strategyId)
        {
            var parameters = new Strategy.StrategyInputParameters
            {
                TradeThresholdIncrement = Convert.ToDouble(
                    (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeThresholdIncrement}{strategyId}"] as
                        NumericUpDown).Value),
                TradeThresholdCoefficient = Convert.ToDouble(
                    (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeThresholdCoefficient}{strategyId}"] as
                        NumericUpDown).Value),
                TradeLagThreshold = Convert.ToInt32(
                    (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeLagThreshold}{strategyId}"] as
                        NumericUpDown)
                        .Value),
                RegressionThresholdIncrement = Convert.ToDouble(
                    (tableLayoutPanelStrategies.Controls[$"{ControlName.nudRegressionThresholdIncrement}{strategyId}"]
                        as
                        NumericUpDown).Value),
                RegressionThresholdCoefficient = Convert.ToDouble(
                    (tableLayoutPanelStrategies.Controls[$"{ControlName.nudRegressionThresholdCoefficient}{strategyId}"]
                        as
                        NumericUpDown)
                        .Value),
                StartPrice = Convert.ToDouble(nudStartPrice.Value)
            };


            if (strategyId == 0)
            {
                parameters.BaseDPrice = _baseDifferPrice;
            }
            else
            {
                parameters.BaseDPrice = _strategies[strategyId - 1].TradeThreshold;
            }
            //            currentStrategy.InputParameters.TradeQuantityThreshold =
            //                Convert.ToInt32(
            //                    (tableLayoutPanelStrategies.Controls[$"{ControlNames[8]}{index}"] as TextBox).Text);

            return parameters;
        }
    }
}