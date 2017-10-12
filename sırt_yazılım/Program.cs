using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sırt_yazılım
{
    class GreedyKnapsack
    {
        double[] profit;
        double[] weight;
        double[] take;

        public GreedyKnapsack(int n)
        {
            profit = new double[n];
            weight = new double[n];
            take = new double[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                profit[i] = (int)(rnd.NextDouble() * 96 + 44);
                weight[i] = (int)(rnd.NextDouble() * 89 + 15);
            }
        }

        public void unitPriceOrder()
        {
            for (int i = 0; i < profit.Length; i++)
            {
                for (int j = 1; j < (profit.Length - i); j++)
                {
                    double x = profit[j - 1] / weight[j - 1];
                    double y = profit[j] / weight[j];
                    if (x <= y)
                    {
                        double temp = profit[j - 1];
                        profit[j - 1] = profit[j];
                        profit[j] = temp;

                        double temp1 = weight[j - 1];
                        weight[j - 1] = weight[j];
                        weight[j] = temp1;
                    }
                }
            }
        }

        public void Knapsack(int m)
        {
            unitPriceOrder();
            int j;
            for (j = 0; j < profit.Length; j++)
            {
                take[j] = 0;
            }
            double total = m;
            for (j = 0; j < profit.Length; j++)
            {
                if (weight[j] <= total)
                {
                    take[j] = 1.00;
                    total = total - weight[j];
                }
                else
                {
                    break;// to exit the for-loop
                }
            }
            if (j < profit.Length)
            {
                take[j] = (double)(total / weight[j]);
            }
        }

        public void print()
        {

            Console.WriteLine("Numara" + " |\t" + "Kazanç" + "\t|\t" + "Yük" + "\t|\t\t" + "Birim Fiyat" + "\t|\t\t" + "Kazanılan Ağırlık");
            for (int n = 0; n < profit.Length; n++)
            {
                Console.WriteLine(n + "\t\t" + profit[n] + "\t\t" + weight[n] + "\t\t" + (profit[n] / weight[n]) + "\t\t" + take[n]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GreedyKnapsack G = new GreedyKnapsack(10);
            Console.WriteLine("Sırt çantası örneği için aşağıdaki gibi verilen değerlere en uygun çözüm : m=35");
            G.Knapsack(35);
            G.print();
            Console.WriteLine("=======+============+=======+============+=" + "===========");
            Console.WriteLine("Sırt çantası örneği için aşağıdaki gibi verilen değerlere en uygun çözüm : m=120");
            G.Knapsack(120);
            G.print();

            Console.ReadLine();
        }
    }
}
