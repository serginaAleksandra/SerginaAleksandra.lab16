using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cur
{
    class Class1
    {
        private const double Mu = 0.1;
        private const double Sigma = 0.01;
        private const double dt = 0.01;

        private int Date;
        private double Price;
        private Random Rnd;

        public Class1(double InitialPrice)
        {
            this.Price = InitialPrice;
            Date = 0;
            Rnd = new Random();
        }

        public void nextDate()
        {
            Date++;

            var St = Price;
            var Z = MathNet.Numerics.Distributions.Normal.Sample(Rnd, 0.0, 1.0);
            var S = St * Math.Exp((Mu - (Math.Pow(Sigma, 2) / 2)) * dt + Sigma * Math.Sqrt(dt) * Z);
            Price = S;
        }

        public int getDate()
        {
            return Date;
        }

        public double getPrice()
        {
            return Price;
        }
    }
}
