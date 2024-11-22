/*
Best time to buy and sell stock
You are given an array prices where prices[i] is the price of a given stock on the ith day.

You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

 

Example 1:

Input: prices = [7,1,5,3,6,4]
Output: 5
Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
Example 2:

Input: prices = [7,6,4,3,1]
Output: 0
Explanation: In this case, no transactions are done and the max profit = 0.
 

Constraints:

1 <= prices.length <= 105
0 <= prices[i] <= 104
*/



public class ArrBestTimeBuySell
{
    public static void Run()
    {
        int[] stockPrices = new int[] { 7, 1, 5, 3, 6, 4 };
        var result = BestTimeBruteForce(stockPrices);
        Console.WriteLine(result);

        stockPrices = new int[] { 7, 6, 4, 3, 1 };
        result = BestTimeBruteForce(stockPrices);
        Console.WriteLine(result);

        stockPrices = new int[] { 7, 1, 5, 3, 6, 4 };
        result = BestTimeOptimized(stockPrices);
        Console.WriteLine(result);

        stockPrices = new int[] { 7, 6, 4, 3, 1 };
        result = BestTimeOptimized(stockPrices);
        Console.WriteLine(result);
    }

    public static int BestTimeBruteForce(int[] prices)
    {
        int maxProfit = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            for (int j = i + 1; j < prices.Length; j++)
            {
                if (prices[j] - prices[i] > maxProfit)
                {
                    maxProfit = prices[j] - prices[i];
                }
            }
        }
        return maxProfit;
    }


    public static int BestTimeOptimized(int[] prices)
    {
        //7,1,5,3,6,4
        //if we loop over prices and keep track of min price, and compare min price with each value, we see max Profit
        int minPrice = 0;
        int maxProfit = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            if (i == 0)
            {
                minPrice = prices[0];
                continue;
            }
            
            if (prices[i] < minPrice)
            {
                minPrice = prices[i];
            }
            else if (prices[i] - minPrice > maxProfit)
            {
                maxProfit = prices[i] - minPrice;
            }
        }
        return maxProfit;
    }

}