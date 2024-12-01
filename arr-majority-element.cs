/*
Majority Element
Given an array nums of size n, return the majority element.

The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume that the majority element always exists in the array.

 

Example 1:

Input: nums = [3,2,3]
Output: 3
Example 2:

Input: nums = [2,2,1,1,1,2,2]
Output: 2
 

Constraints:

n == nums.length
1 <= n <= 5 * 104
-109 <= nums[i] <= 109

Follow-up: Could you solve the problem in linear time and in O(1) space?

*/



public class SolutionArrMajorityElement
{

    public static void Run()
    {
        int[] nums1 = [3, 2, 3];
        var result = MajorityElementExtraSpace(nums1);
        Console.WriteLine(result);

        int[] nums2 = [2, 2, 1, 1, 1, 2, 2];
        result = MajorityElementExtraSpace(nums2);
        Console.WriteLine(result);


        //Boyer Moore Voting
        result = MajorityElementBoyerMooreVoting(nums1);
        Console.WriteLine(result);

        result = MajorityElementBoyerMooreVoting(nums2);
        Console.WriteLine(result);

    }

    public static int MajorityElementExtraSpace(int[] nums)
    {
        Dictionary<int, int> numFrequency = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (numFrequency.ContainsKey(num))
            {
                numFrequency[num]++;
            }
            else
            {
                numFrequency[num] = 1;
            }
            //Console.WriteLine(numFrequency[num] );
        }
        int maxFrequency = 0;
        int majorityElement = 0;
        foreach (var item in numFrequency)
        {
            if (item.Value > maxFrequency)
            {
                maxFrequency = item.Value;
                majorityElement = item.Key;
            }
            //Console.WriteLine($"numFrequency {item.Key} {item.Value}");
        }
        return majorityElement;

    }

    public static int MajorityElementBoyerMooreVoting(int[] nums)
    {
        if (nums.Length == 0)
        {
            throw new Exception("0 length input not supported");
        }
        int current=0, count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (count == 0)
            {
                current = nums[i];
            }

            if (current == nums[i])
            {
                count++;
            }
            else
            {
                count--;
            }
        }
        return current;
    }
}