using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCPrice_Catcher.Trader;

namespace BCPrice_Catcher
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
//            MessageBox.Show(new HuobiTrader().GetAccountInfo());
//            MessageBox.Show(new HuobiTrader().SellMarket(10, Trader.Trader.CoinType.Btc));
//            MessageBox.Show(new HuobiTrader().BuyMarket(10, Trader.Trader.CoinType.Btc));
//            MessageBox.Show(new HuobiTrader().Buy(2000, 0.1, Trader.Trader.CoinType.Btc));
//            MessageBox.Show(new HuobiTrader().Sell(2000, 0.1, Trader.Trader.CoinType.Btc));
//            MessageBox.Show(new HuobiTrader().GetOrders(Trader.Trader.CoinType.Btc));
//            MessageBox.Show(new BtccTrader().GetAccountInfo());
//            MessageBox.Show(new BtccTrader().Sell(4000.00, 0.005, Trader.Trader.CoinType.Btc));
//            MessageBox.Show(new BtccTrader().SellMarket(0.005, Trader.Trader.CoinType.Btc));
//            MessageBox.Show(new BtccTrader().Buy(4000.00, 0.005, Trader.Trader.CoinType.Btc));
//            MessageBox.Show(new BtccTrader().BuyMarket(0.005, Trader.Trader.CoinType.Btc));
//            MessageBox.Show(new BtccTrader().GetTransactions());
            //            MessageBox.Show(new BtccTrader().Sell(500, 1, Trader.Trader.CoinType.Btc));
            //            MessageBox.Show(new BtccTrader().SellMarket(10, Trader.Trader.CoinType.Btc));


//            txtResult.Text = new BtccTrader().Buy(Convert.ToDouble(txtPrice.Text), Convert.ToDouble(txtAmount.Text),
//                Trader.Trader.CoinType.Btc);

//            dataGridView1.DataSource = new BtccTrader().GetOrders();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //            txtAccountInfo.Text = new BtccTrader().GetAccountInfo().AvailableBtc + "," + new BtccTrader().GetAccountInfo().AvailableCny.ToString() +"\n" + new BtccTrader().GetAccountInfo().AvailableBtc + "," + new HuobiTrader().GetAccountInfo().AvailableCny.ToString();
            txtAccountInfo.Text = new HuobiTrader().GetAccountInfo().AvailableBtc + "," +
                                  new HuobiTrader().GetAccountInfo().AvailableCny.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtResult.Text = new BtccTrader().BuyMarket(Convert.ToDouble(txtAmount.Text), Trader.Trader.CoinType.Btc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtResult.Text = new BtccTrader().Sell(Convert.ToDouble(txtPrice.Text), Convert.ToDouble(txtAmount.Text),
                Trader.Trader.CoinType.Btc);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtResult.Text = new BtccTrader().SellMarket(Convert.ToDouble(txtAmount.Text), Trader.Trader.CoinType.Btc);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //new HuobiTrader().GetAccountInfo();
            //txtOrders.Text = new BtccTrader().GetOrders();
            //txtTransactions.Text = new BtccTrader().GetTransactions();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show(new BtccTrader().GetOrder(Convert.ToInt32(txtOrderId.Text)).Status.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtResult.Text = new HuobiTrader().Buy(Convert.ToDouble(txtPrice.Text), Convert.ToDouble(txtAmount.Text),
                Trader.Trader.CoinType.Btc);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtResult.Text = new HuobiTrader().BuyMarket(Convert.ToDouble(txtAmount.Text),
                Trader.Trader.CoinType.Btc);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtResult.Text = new HuobiTrader().Sell(Convert.ToDouble(txtPrice.Text), Convert.ToDouble(txtAmount.Text),
                Trader.Trader.CoinType.Btc);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtResult.Text = new HuobiTrader().SellMarket(Convert.ToDouble(txtAmount.Text),
               Trader.Trader.CoinType.Btc);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int index = 0;
            dataGridView1.DataSource = new HuobiTrader().GetOrders(Trader.Trader.CoinType.Btc).
                OrderByDescending(t => t.Time).Select(t =>
                    new
                    {
                        SN = index++,
                        t.Id,
                        t.Type,
                        Price = t.Price.ToString("0.000"),
                        t.AmountOriginal,
                        Time = t.Time.ToString("HH:mm:ss"),
                        t.Status
                         
                    }).ToList();
        }
    }
}