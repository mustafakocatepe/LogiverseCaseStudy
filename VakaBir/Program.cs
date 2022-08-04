using System;

namespace VakaBir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var b = new int[] { 1, 4, 9, 5, 3, 7 };
            var b = new int[] { 7, 1, 5, 3, 6, 4 };
            //var c = new int[] { 37, , 5, 3, 6, 4 };
            var a = Calculate(b);
            Console.WriteLine(a);

        }

       //static int Calculate(int[] prices)
       // {
       //     int maxDiff = 0;
       //     for (int i = 0; i < prices.Length -1 ; i++)
       //     {
       //         for (int j = i + 1; j < prices.Length; j++)
       //         {
       //             if (prices[j] > prices[i])
       //             {
       //                 maxDiff = Math.Max(maxDiff, prices[j]  - prices[i]);
       //             }
       //         }
       //     }

       //     return maxDiff;
       // }

        static int Calculate(int[] prices)
        {
            int minElement = prices[0];
            int maxDiff = prices[1] - prices[0];

            for (int i = 1; i < prices.Length - 1; i++)
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
