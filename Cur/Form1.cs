using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cur
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private double rub = 100000;
        private double usd = 0;
        Class1 stock;

        private void btStart_Click(object sender, EventArgs e)
        {
            stock = new Class1((double)edRate.Value);
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(stock.getDate(), stock.getPrice());
            timer1.Start();
            rubValue.Text = rub.ToString();
            usdValue.Text = usd.ToString();
        }

        private void btBuy_Click(object sender, EventArgs e)
        {
            if (rub >= stock.getPrice())
            {
                rub -= stock.getPrice();
                usd++;
                rubValue.Text = Math.Round(rub, 2).ToString();
                usdValue.Text = Math.Round(usd, 2).ToString();
            }
        }

        private void btSell_Click(object sender, EventArgs e)
        {
            if (usd > 0)
            {
                rub += stock.getPrice();
                usd--;
                rubValue.Text = Math.Round(rub, 2).ToString();
                usdValue.Text = Math.Round(usd, 2).ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            stock.nextDate();
            chart1.Series[0].Points.AddXY(stock.getDate(), stock.getPrice());
            edDays.Text = stock.getDate().ToString();
            chart1.ChartAreas[0].AxisX.Minimum = (int)stock.getDate() - 3;
            chart1.ChartAreas[0].AxisX.Maximum = (int)stock.getDate() + 3;
            chart1.ChartAreas[0].AxisY.Minimum = (int)stock.getPrice() - 3;
            chart1.ChartAreas[0].AxisY.Maximum = (int)stock.getPrice() + 3;
        }
    }
}
