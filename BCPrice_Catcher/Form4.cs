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
using BCPrice_Catcher.Util;

namespace BCPrice_Catcher
{
    public partial class Form4 : Form
    {
        private int _strategyCount = 0;
        private const int StrategyLimit = 8;
        private const int StrategyControlColumnCount = 12;
        private Dictionary<string, Account> _accounts = new Dictionary<string, Account>();

        private double _btccPrice;
        private double _huobiPrice;

        public Form4()
        {
            InitializeComponent();
        }

        private void AutoGenerateStrategyControls(int rowIndex)
        {
            //策略号
            tableLayoutPanelStrategies.Controls.Add(
                new Label
                {
                    Name = $"lblStrategyID{rowIndex}",
                    Text = (rowIndex).ToString(),
                }, 0, rowIndex);
            //差价R
            tableLayoutPanelStrategies.Controls.Add(
                new Label {Name = $"lblDifferPrice{rowIndex}", Text = (rowIndex + 1).ToString()}, 1,
                rowIndex);
            //差价R配重加减
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"nudDifferPriceIncrement{rowIndex}",
                    Value = 0,
                    Maximum = 10,
                    Minimum = -10
                }, 2, rowIndex);
            //差价R配重系数
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"nudDifferPriceCoefficient{rowIndex}",
                    Value = 1,
                    Maximum = 0,
                    Minimum = 2,
                    Increment = Convert.ToDecimal(0.1)
                }, 3, rowIndex);

            //周期
            tableLayoutPanelStrategies.Controls.Add(
                new TextBox()
                {
                    Name = $"txtPeroid{rowIndex}",
                    Text = ((rowIndex + 1) * 100).ToString()
                }, 4,
                rowIndex);

            //默认回归价
            tableLayoutPanelStrategies.Controls.Add(
                new Label() {Name = $"lblDefaultRegressionPrice{rowIndex}", Text = "0"}, 5,
                rowIndex);

            //回归价配重加减
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"nudRegressionPriceIncreament{rowIndex}",
                    Value = 1,
                    Maximum = 0,
                    Minimum = 2,
                    Increment = Convert.ToDecimal(0.1)
                }, 6, rowIndex);

            //回归价配重系数
            tableLayoutPanelStrategies.Controls.Add(
                new NumericUpDown
                {
                    Name = $"nudRegressionPriceCoefficient{rowIndex}",
                    Value = 1,
                    Maximum = 0,
                    Minimum = 2,
                    Increment = Convert.ToDecimal(0.1)
                }, 7, rowIndex);

            //数量
            tableLayoutPanelStrategies.Controls.Add(
                new TextBox()
                {
                    Name = $"txtTradeQuantityLimit{rowIndex}",
                    Text = ((rowIndex + 1) * 100).ToString()
                }, 8,
                rowIndex);

            //开始按钮
            tableLayoutPanelStrategies.Controls.Add(
                new Button()
                {
                    Name = $"btnStrategyStart{rowIndex}",
                    Text = "开始",
                    BackColor = Color.LightGreen
                }, 9, rowIndex);

            //结束按钮
            tableLayoutPanelStrategies.Controls.Add(
                new Button()
                {
                    Name = $"btnStrategyStop{rowIndex}",
                    Text = "结束",
                    BackColor = Color.LightCoral
                }, 10, rowIndex);

//                foreach (var c in tableLayoutPanelStrategies.Controls)
//                {
//                    ((Control) c).Dock = DockStyle.Fill;
//                    ((Control) c).Anchor = AnchorStyles.Left | AnchorStyles.Right;
//                }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            InitializeControls();

            //show accounts for the first time
            trackBar1_ValueChanged(null, null);
        }

        private void InitializeControls()
        {
            tableLayoutPanelStrategies.Visible = false;
            AutoGenerateStrategyControls(_strategyCount + 1);
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
            if (_strategyCount < StrategyLimit)
            {
                _strategyCount++;
                AutoGenerateStrategyControls(_strategyCount + 1);
            }
        }

        private void btnRemoveStrategy_Click(object sender, EventArgs e)
        {
            //至少保留一行控件
            if (_strategyCount > 0)
            {
                _strategyCount--;

                int controlCount = tableLayoutPanelStrategies.Controls.Count;
                for (int i = tableLayoutPanelStrategies.Controls.Count - 1;
                    i > controlCount - StrategyControlColumnCount;
                    i--)
                {
                    tableLayoutPanelStrategies.Controls.Remove(tableLayoutPanelStrategies.Controls[i]);
                }
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
            const double totalBalance = 400000;
            const double totalCoinAmount = 100;

            _accounts.Clear();
            _accounts.Add("btcc",
                new Account
                {
                    Balance = Math.Round(totalBalance * pecentage),
                    CoinAmount = Math.Round(totalCoinAmount * (1 - pecentage))
                });
            _accounts.Add("huobi",
                new Account
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
                $"HUOBI({trackBar1.Maximum-trackBar1.Value}%){Environment.NewLine}现金：{_accounts["huobi"].Balance}{Environment.NewLine}币数：{_accounts["huobi"].CoinAmount}";
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            AdjustAccounts(trackBar1.Value / Convert.ToDouble(trackBar1.Maximum));
            ShowAccountsInfo();
        }

        private void GetPrices()
        {
            if (Tag != null)
            {
                Dictionary<string, double> prices = Tag as Dictionary<string, double>;

                if (prices.Count == 2)
                {
                    _btccPrice = Convert.ToDouble(prices["btcc"]);
                    _huobiPrice = Convert.ToDouble(prices["huobi"]);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetPrices();
            ShowPrices();
        }

        private void ShowPrices()
        {
            lblBtccPrice.Text = $"BTCC{Environment.NewLine}{_btccPrice.ToString("0.00")}";
            lblHuobiPrice.Text = $"HUOBI{Environment.NewLine}{_huobiPrice.ToString("0.00")}";
            lblDifferPrice.Text =Math.Abs((_btccPrice - _huobiPrice)).ToString("0.00");

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
    }
}