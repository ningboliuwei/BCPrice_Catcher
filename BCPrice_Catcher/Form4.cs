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
        private const int StrategyMaxQuantity = 9;
        private const int StrategyMinQuantity = 1;

        private Dictionary<string, SimulateAccount> _accounts = new Dictionary<string, SimulateAccount>();
        private List<Strategy> _strategies = new List<Strategy>();

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
                    Dock = DockStyle.Fill
                }, 10, 0);

            tableLayoutPanelStrategies.Controls.Add(
                new Button()
                {
                    Name = "btnRemoveStrategy",
                    Text = "减少策略",
                    BackColor = Color.LightCoral,
                    Dock=DockStyle.Fill
                }, 11, 0);
        }

        private void AddStrategyControls()
        {
            int rowPosition = _strategies.Count;
            int controlIndex = rowPosition - 1;
            int columnPosition = 0;
            //策略号

            tableLayoutPanelStrategies.Controls.Add(
                new Label
                {
                    Name = $"{ControlName.lblStrategyID}{controlIndex}",
                    Text = (rowPosition).ToString(),
                    Dock = DockStyle.Fill
                }, columnPosition++, rowPosition);

            //启动阙值
            tableLayoutPanelStrategies.Controls.Add(
                new Label
                {
                    Name = $"{ControlName.lblTradeThreshold}{controlIndex}",
                    Text = (rowPosition + 1).ToString(),
                    Dock = DockStyle.Fill
                }, columnPosition++,
                rowPosition);
            //启动阙值增量
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudTradeThresholdIncrement}{controlIndex}",
                    Value = 0,
                    Maximum = 10,
                    Minimum = -10,
                    Dock = DockStyle.Fill
                }, columnPosition++, rowPosition);
            //启动阙值系数
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudTradeThresholdCoefficient}{controlIndex}",
                    Value = 1 + controlIndex * 0.3M,
                    Maximum = int.MaxValue,
                    Minimum = 0.1M,
                    DecimalPlaces = 1,
                    Increment = 0.1M,
                    Dock = DockStyle.Fill
                }, columnPosition++, rowPosition);


            //回归阙值
            tableLayoutPanelStrategies.Controls.Add(
                new Label() {Name = $"{ControlName.lblRegressionThreshold}{controlIndex}", Text = "0",
                    Dock = DockStyle.Fill
                }, columnPosition++,
                rowPosition);

            //回归阙值增量
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"{ControlName.nudRegressionThresholdIncrement}{controlIndex}",
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
                    Name = $"{ControlName.nudRegressionThresholdCoefficient}{controlIndex}",
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
                    Name = $"{ControlName.nudTradeLagThreshold}{controlIndex}",
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
                    Name = $"{ControlName.nudTradeCountThreshold}{controlIndex}",
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
                    Name = $"{ControlName.nudTotalTradeCountLimit}{controlIndex}",
                    Value = 1,
                    Maximum = int.MaxValue,
                    Minimum = 1,
                    DecimalPlaces = 0,
                    Increment = 1,
                    Dock = DockStyle.Fill
                }, columnPosition++, rowPosition);

            //开始按钮
            tableLayoutPanelStrategies.Controls.Add(
                new Button()
                {
                    Name = $"{ControlName.btnStrategyStart}{controlIndex}",
                    Text = "开始",
                    BackColor = Color.LightGreen,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, columnPosition++, rowPosition);

            //结束按钮
            tableLayoutPanelStrategies.Controls.Add(
                new Button()
                {
                    Name = $"{ControlName.btnStrategyStop}{controlIndex}",
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

        private void AddStrategy()
        {
            _strategies.Add(new Strategy());
            AddStrategyControls();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            InitializeControls();
            AddStrategy();
            AddStrategy();
            AddStrategy();

            //show accounts for the first time
            trackBar1_ValueChanged(null, null);
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

            for (int i = 0; i < _strategies.Count; i++)
            {
                GetStrategyParaValues(i);
            }

            ShowStrategyValues();
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

        private void ShowStrategyValues()
        {
            for (int i = 0; i < _strategies.Count; i++)
            {
                (tableLayoutPanelStrategies.Controls[$"{ControlName.lblTradeThreshold}{i}"] as Label).Text =
                    _strategies[i].TradeThreshold.ToString("0.00");

                (tableLayoutPanelStrategies.Controls[$"{ControlName.lblRegressionThreshold}{i}"] as Label).Text =
                    _strategies[i].RegressionThreshold.ToString("0.00");
            }
        }

        private void GetStrategyParaValues(int index)
        {
            Strategy currentStrategy = _strategies[index];

            currentStrategy.InputParameters.TradeThresholdIncrement = Convert.ToDouble(
                (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeThresholdIncrement}{index}"] as
                    NumericUpDown).Value);
            currentStrategy.InputParameters.TradeThresholdCoefficient = Convert.ToDouble(
                (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeThresholdCoefficient}{index}"] as
                    NumericUpDown).Value);
            currentStrategy.InputParameters.TradeLagThreshold =
                Convert.ToInt32(
                    (tableLayoutPanelStrategies.Controls[$"{ControlName.nudTradeLagThreshold}{index}"] as NumericUpDown)
                        .Text);
            currentStrategy.InputParameters.RegressionThresholdIncrement = Convert.ToDouble(
                (tableLayoutPanelStrategies.Controls[$"{ControlName.nudRegressionThresholdIncrement}{index}"] as
                    NumericUpDown).Value);
            currentStrategy.InputParameters.RegressionThresholdCoefficient = Convert.ToDouble(
                (tableLayoutPanelStrategies.Controls[$"{ControlName.nudRegressionThresholdCoefficient}{index}"] as
                    NumericUpDown)
                    .Value);
            currentStrategy.InputParameters.StartPrice = Convert.ToDouble(nudStartPrice.Value);
            //            currentStrategy.InputParameters.TradeQuantityThreshold =
            //                Convert.ToInt32(
            //                    (tableLayoutPanelStrategies.Controls[$"{ControlNames[8]}{index}"] as TextBox).Text);

            if (index == 0) //first strategy
            {
                currentStrategy.TradeThreshold = _baseDifferPrice *
                                                 currentStrategy.InputParameters.TradeThresholdCoefficient +
                                                 currentStrategy.InputParameters.TradeThresholdIncrement;
            }
            else
            {
                currentStrategy.TradeThreshold = _strategies[index - 1].TradeThreshold *
                                                 currentStrategy.InputParameters.TradeThresholdCoefficient +
                                                 currentStrategy.InputParameters.TradeThresholdIncrement;
            }
            currentStrategy.RegressionThreshold = currentStrategy.TradeThreshold *
                                                  currentStrategy.InputParameters.RegressionThresholdCoefficient +
                                                  currentStrategy.InputParameters.RegressionThresholdIncrement;
        }
    }
}