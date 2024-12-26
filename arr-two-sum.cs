/*
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.

 

Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]
Example 3:

Input: nums = [3,3], target = 6
Output: [0,1]
 

Constraints:

2 <= nums.length <= 104
-109 <= nums[i] <= 109
-109 <= target <= 109
Only one valid answer exists.
 

Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?

*/

//https://learn.microsoft.com/en-us/dotnet/api/system.array?view=net-9.0
//https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-9.0

public static class ArrTwoSum {

    public static void Run()
    {
        int[] nums = new int[]{2,7,11,15};
        int target = 9;
        var result = TwoSumBruteForce(nums, target);
        Console.WriteLine($"{result?[0]},{result?[1]}");


        int[] nums1 = new int[]{3,2,4};
        int target1 = 6;
        var result1 = TwoSumBruteForce(nums1, target1);
        Console.WriteLine($"{result1?[0]},{result1?[1]}");




        nums = new int[]{2,7,11,15};
        target = 9;
        result = TwoSumUsingMap(nums, target);
        Console.WriteLine($"{result?[0]},{result?[1]}");


        nums = new int[]{3,2,4};
        target = 6;
        result = TwoSumUsingMap(nums, target);
        Console.WriteLine($"{result?[0]},{result?[1]}");

    }

    //Time Complexity: O(n^2) due to the nested loops.
    public static int[] TwoSumBruteForce(int[] nums, int target) {
        for(int i = 0; i < nums.Length; i++)
        {
            //here we do i + 1 so we do not repeat the numbers
            for(int j = i + 1; j < nums.Length; j++)
            {
                if(nums[i] + nums[j] == target )
                {
                    return new int[]{i, j};
                }
            }
        }
        return [];
    }


    public static int[] TwoSumUsingMap(int[] nums, int target){
        Dictionary<int, int> map = new Dictionary<int, int>();
        
        for(int i = 0; i < nums.Length; i++ )
        {
            int complement = target - nums[i];
            if(map.ContainsKey(complement)){
                return new int[]{i, map[complement]};
            }else{
                map[nums[i]] = i;
            }
        }
        return [];
    }
}