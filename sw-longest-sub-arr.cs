/*
Find the length of the longest subarray, with the same value in each position

nums[] = [4, 2, 2, 3, 3, 3, 1]

ans 3
*/

public class LongestSubarray
{

    public static void Run(){
        int[] nums = [4, 2, 2, 3, 3, 3, 1];
        Console.WriteLine(find(nums));

        nums = [-1, -1, -3, 2, 2, 4, 4];
        Console.WriteLine(find(nums));
    }

    private static int find(int[] nums)
    {   
        int maxLength = 0;
        int L = 0;
        
        for(int R = 0; R<nums.Length; R++)
        {
            if(nums[L] != nums[R]){
                L = R;
                Console.WriteLine('-');
            }
            maxLength = Math.Max(maxLength, R - L + 1);
        }
        return maxLength;
    }
}