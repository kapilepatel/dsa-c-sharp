/*
Product of array except self
Given an integer array nums, return an array answer such that answer[i] is equal 
to the product of all the elements of nums except nums[i].

The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

You must write an algorithm that runs in O(n) time and without using the division operation.

Example 1:

Input: nums = [1,2,3,4]
Output: [24,12,8,6]
Example 2:

Input: nums = [-1,1,0,-3,3]
Output: [0,0,9,0,0]
 
Constraints:

2 <= nums.length <= 105
-30 <= nums[i] <= 30
The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
 

Follow up: Can you solve the problem in O(1) extra space complexity? (The output array does not count as extra space for space complexity analysis.)

*/


using System.ComponentModel;
using System.Net.Http.Headers;

public class ArrProductSelf
{

    public static void Run()
    {
        int[] nums1 = new int[] { 1, 2, 3, 4 };
        var result = ArrProductExceptSelfBruteForce(nums1);
        PrintArray(result);

        int[] nums2 = new int[] { -1, 1, 0, -3, 3 };
        result = ArrProductExceptSelfBruteForce(nums2);
        PrintArray(result);

        int[] nums3 = new int[] { 1, 1, 0, 0, 2 };
        result = ArrProductExceptSelfBruteForce(nums3);
        PrintArray(result);

        Console.WriteLine();


        PrintArray(nums1);
        result = ArrProductUsingDivision(nums1);
        PrintArray(result);

        PrintArray(nums2);
        result = ArrProductUsingDivision(nums2);
        PrintArray(result);

        PrintArray(nums3);
        result = ArrProductUsingDivision(nums3);
        PrintArray(result);

        Console.WriteLine();

        PrintArray(nums1);
        result = ArrProductPrefixSuffix(nums1);
        PrintArray(result);
        Console.WriteLine();

        PrintArray(nums2);
        result = ArrProductPrefixSuffix(nums2);
        PrintArray(result);
        Console.WriteLine();

        PrintArray(nums3);
        result = ArrProductPrefixSuffix(nums3);
        PrintArray(result);

    }

    public static int[] ArrProductExceptSelfBruteForce(int[] nums)
    {
        int[] result = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            int product = 1;
            for (int j = 0; j < nums.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }
                product = product * nums[j];
            }
            result[i] = product;
        }

        return result;
    }

    public static int[] ArrProductUsingDivision(int[] nums)
    {
        if (nums.Length == 0) return null;
        int[] result = new int[nums.Length];
        int totalProduct = 1;
        int zeroCount = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                zeroCount++;
                continue;
            }
            totalProduct *= nums[i];
        }
        if (zeroCount > 1)
        {
            return result;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                result[i] = totalProduct;
                continue;
            }
            if (zeroCount == 0)
            {
                result[i] = totalProduct / nums[i];
            }
            else
            {
                result[i] = 0;
            }
        }
        return result;
    }

    public static int[] ArrProductPrefixSuffix(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[n];
        int[] prefix = new int[n];
        int[] suffix = new int[n];

        Array.Fill(prefix, 1);
        Array.Fill(suffix, 1);

        prefix[0] = 1;
        for (int i = 1; i < n; i++)
        {
            prefix[i] = prefix[i-1] * nums[i - 1];
        }
        //PrintArray(prefix);

        suffix[n - 1] = 1;
        int total = 1;
        for (int i = n - 2; i >= 0; i--)
        {
            total *= nums[i + 1];
            suffix[i] = total;
        }
        //PrintArray(suffix);

        for (int i = 0; i < n; i++)
        {
            result[i] = prefix[i] * suffix[i];
        }
        return result;
    }

    public static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write($"{item} ,");
        }
        Console.WriteLine();
    }

}