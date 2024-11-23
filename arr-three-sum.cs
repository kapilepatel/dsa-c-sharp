/*

Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

Notice that the solution set must not contain duplicate triplets.

 

Example 1:

Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
Explanation: 
nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
The distinct triplets are [-1,0,1] and [-1,-1,2].
Notice that the order of the output and the order of the triplets does not matter.
Example 2:

Input: nums = [0,1,1]
Output: []
Explanation: The only possible triplet does not sum up to 0.
Example 3:

Input: nums = [0,0,0]
Output: [[0,0,0]]
Explanation: The only possible triplet sums up to 0.
 

Constraints:

3 <= nums.length <= 3000
-105 <= nums[i] <= 105

*/

using System.Globalization;

public class ArrThreeSum
{
    public static void Run()
    {
        int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };
        PrintArray(nums);
        var result = ThreeSum(nums);
        Print2DArray(result);
        //[[-1,-1,2],[-1,0,1]]
    }


    public static int[][] ThreeSum(int[] nums)
    {
        List<int[]> result = new List<int[]>();

        Array.Sort(nums);
        //PrintArray(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            int complement = 0 - nums[i];

            Console.WriteLine(complement);
            //to find triplet, current item is first value and 2 other values we will find using 2 pointer
            int leftIndex = i + 1;
            int rightIndex = nums.Length - 1;
            while (leftIndex < rightIndex)
            {
                int sum = nums[leftIndex] + nums[rightIndex];
                if (sum == complement)
                {
                    result.Add(new int[] { nums[i], nums[leftIndex], nums[rightIndex] });
                    while(leftIndex < rightIndex && nums[leftIndex] == nums[leftIndex + 1])
                    {
                        leftIndex++;
                    }
                    while(leftIndex < rightIndex && nums[rightIndex] == nums[rightIndex - 1])
                    {
                        rightIndex--;
                    }

                    leftIndex++;
                    rightIndex--;
                }
                else if (sum < complement)
                {
                    leftIndex++;
                }
                else
                {
                    rightIndex--;
                }
            }
        }

        return result.ToArray();


    }

    public static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write($"{item} ,");
        }
        Console.WriteLine();

    }

    public static void Print2DArray(int[][] twoDArr)
    {
        if (twoDArr == null)
        {
            return;
        }
        foreach (var oneDArr in twoDArr)
        {
            foreach (var item in oneDArr)
            {
                Console.Write($"{item} , ");
            }
            Console.WriteLine();
        }
    }

}