/*

Two-pointer technique to find two numbers in a sorted array that sum to a target.
Input: Sorted array [-4, -1, 0, 1, 2], Target: 3.
Question: Can you identify two numbers in the array that sum to 3?

https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/submissions/1460764035/

Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number. Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.

Return the indices of the two numbers, index1 and index2, added by one as an integer array [index1, index2] of length 2.

The tests are generated such that there is exactly one solution. You may not use the same element twice.

Your solution must use only constant extra space.

 

Example 1:

Input: numbers = [2,7,11,15], target = 9
Output: [1,2]
Explanation: The sum of 2 and 7 is 9. Therefore, index1 = 1, index2 = 2. We return [1, 2].
Example 2:

Input: numbers = [2,3,4], target = 6
Output: [1,3]
Explanation: The sum of 2 and 4 is 6. Therefore index1 = 1, index2 = 3. We return [1, 3].
Example 3:

Input: numbers = [-1,0], target = -1
Output: [1,2]
Explanation: The sum of -1 and 0 is -1. Therefore index1 = 1, index2 = 2. We return [1, 2].
 

Constraints:

2 <= numbers.length <= 3 * 104
-1000 <= numbers[i] <= 1000
numbers is sorted in non-decreasing order.
-1000 <= target <= 1000
The tests are generated such that there is exactly one solution.


*/


public class ArrTwoSumTwoPointer
{
    public static void Run()
    {
        int[] nums = new int[]{-4, -1, 0, 1, 2};
        int target = 3;
        var result = TwoPointer(nums, target);
        Console.WriteLine($"{result[0]}, {result[1]}");

        nums = new int[]{1, 3, 4, 6, 8, 10, 13 };
        target = 13;
        result = TwoPointer(nums, target);
        Console.WriteLine($"{result[0]}, {result[1]}");
    }

    //1 2 3 
    //1 2 3 4
    public static int[] TwoPointer(int[] nums, int target)
    {
        int left=0;
        int right = nums.Length-1;
        int currentSum;
        while(left < right)
        {
            currentSum = nums[left] + nums[right];
            if (currentSum == target )
            {
                return new int[]{left, right};
            }else if (currentSum < target )
            {
                left++;
            }else
            {
                right--;
            }
        }
        return null;
    }
}