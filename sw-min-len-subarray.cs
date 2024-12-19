
/*

Q: Find the minimum length subarray, where the sum is greater than or equal to the target. Assume all values are positive.

int[]   [2, 3, 1, 2, 4, 3]
target = 6
answer 2

*/

public class MinLengthSubarray
{
    public static void Run(){
        int[] nums = [2, 3, 1, 2, 4, 3];
        Console.WriteLine(find(nums, 6));

        Console.WriteLine(find([1,2, 3,4], 9));

        Console.WriteLine(find([1,2, 3,4], 99));
    }

    private static int find(int[] nums, int target)
    {   
        int minLength = Int32.MaxValue;
        int L = 0;
        int total = 0;
        for(int R = 0; R < nums.Length; R++)
        {
            total += nums[R];

            while(total >= target)
            {
                total -= nums[L];
                minLength = Math.Min(minLength, R-L+1);
                L += 1;

            }
        }
        if(minLength==Int32.MaxValue){
            return 0;
        }else{
            return minLength;
        }
    }
}