public class Solution1 {
    public int MaxSubArray(int[] nums) {
        int maxSum=Int32.MinValue;
        for(int i = 0; i < nums.Length; i++)
        {
            int currentSum = 0;
            for(int j = i; j < nums.Length; j++){
                currentSum += nums[j];
                maxSum = Math.Max(maxSum, currentSum);
            }
        }
        return maxSum;
    }
}

//Kadane' algorithm
public class Solution {
    public int MaxSubArray(int[] nums) {
        int maxSum = Int32.MinValue;
        int currentSum = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            currentSum = Math.Max(currentSum+nums[i], nums[i]);            
            maxSum = Math.Max(maxSum, currentSum);
        }
        return maxSum;
    }
}