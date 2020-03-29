using System;
using System.Collections.Generic;

namespace CoinChange
{
    internal class Program
    {
        private static void Main()
        {
            int[] coins = { 1, 3, 4 };
            const int change = 6;
            Console.WriteLine("Hello, this is coin change calculator");
            Console.WriteLine("Available coins: {0}", string.Join(", ", coins));
            Console.WriteLine("Change to be made: {0}", change);
            MakeChangeGreedy(coins, change);
            MakeChangeDynamic(coins, change);
        }

        public static void MakeChangeGreedy(int[] coinsTemp, int change)
        {
            int[] coins = new int[coinsTemp.Length];

            Array.Copy(coinsTemp, coins, coins.Length);
            Array.Sort(coins);
            Array.Reverse(coins);

            List<string> changeList = new List<string>();

            foreach (int coin in coins)
            {
                int howMany = change / coin;

                if (howMany > 0)
                {
                    changeList.Add(howMany + "x" + coin);
                }

                change = change % coin;
            }

            Console.WriteLine(string.Join(", ", changeList.ToArray()));
        }

        public static void MakeChangeDynamic(int[] arrCoins, int value)
        {
            int[] coins = new int[arrCoins.Length];
            Array.Copy(arrCoins, coins, arrCoins.Length);
            Array.Sort(coins);

            int[] minCoins = new int[value + 1];
            int[] firstCoinIndex = new int[value + 1];

            for (int currentChange = 0; currentChange < value + 1; currentChange++)
            {
                int coinCount = currentChange;
                int newCoinIndex = 0;

                for (int coinIndex = 0; coinIndex < coins.Length; coinIndex++)
                {
                    int coin = coins[coinIndex];

                    if (coin > currentChange) continue;

                    if (1 + minCoins[currentChange - coin] < coinCount)
                    {
                        coinCount = 1 + minCoins[currentChange - coin];
                        newCoinIndex = coinIndex;
                    }
                }

                minCoins[currentChange] = coinCount;
                firstCoinIndex[currentChange] = newCoinIndex;
            }

            int currentChange2 = value;
            int[] coinArr = new int[arrCoins.Length];
            List<string> changeList = new List<string>();

            while (currentChange2 > 0)
            {
                int coin = coins[firstCoinIndex[currentChange2]];
                coinArr[firstCoinIndex[currentChange2]]++;
                currentChange2 -= coin;
            }

            for (int i = 0; i < coinArr.Length; i++)
            {
                if (coinArr[i] > 0)
                {
                    changeList.Add(coinArr[i] + "x" + coins[i]);
                }
            }

            Console.WriteLine(string.Join(", ", changeList.ToArray()));
        }
    }
}
