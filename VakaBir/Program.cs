using System;

namespace VakaBir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var r = new int[] { 7, 1, 5, 3, 6, 4 };
            //var r = new int[] { 37, , 5, 3, 6, 4 };
            var response = Calculate(r);
            Console.WriteLine(response);

        }

        static int Calculate(int[] prices)
        {
            if (prices.Length == 1 || prices.Length >= 10000)
                return 0;

            int minElement = prices[0];
            int maxDiff = prices[1] - prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                if ((prices[i] - minElement) > maxDiff)
                    maxDiff = prices[i] - minElement;
                if (prices[i] < minElement)
                    minElement = prices[i];
            }

            return maxDiff < 0 ? 0 : maxDiff;
        }
    }    
}
