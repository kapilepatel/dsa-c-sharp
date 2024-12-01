/*
Sort Colors
Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue.

We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.

You must solve this problem without using the library's sort function.

 

Example 1:

Input: nums = [2,0,2,1,1,0]
Output: [0,0,1,1,2,2]
Example 2:

Input: nums = [2,0,1]
Output: [0,1,2]
 

Constraints:

n == nums.length
1 <= n <= 300
nums[i] is either 0, 1, or 2.
 

Follow up: Could you come up with a one-pass algorithm using only constant extra space?

*/

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;

internal class ArrSortColors
{
    public static void Run()
    {
        int[] nums1 = [2, 0, 2, 1, 1, 0];
        Print(nums1);
        SortColors(nums1);
        Print(nums1);
        Console.WriteLine(Environment.NewLine);

        int[] nums2 = [2, 0, 1];
        Print(nums2);
        SortColors(nums2);
        Print(nums2);
        Console.WriteLine(Environment.NewLine);


        int[] nums3 = [2, 0, 2, 1, 1, 0];
        Print(nums3);
        SortColors3Pointer(nums3);
        Print(nums3);
        Console.WriteLine(Environment.NewLine);


        int[] nums4 = [2, 0, 1];
        Print(nums4);
        SortColors3Pointer(nums4);
        Print(nums4);

    }

    static void Print(IEnumerable<int> data)
    {
        Console.WriteLine(String.Join(",", data));
    }

    public static void SortColors(int[] nums)
    {
        int low = 0;
        int current = 0;
        int high = nums.Length - 1;

        while (current <= high)
        {
            //Console.WriteLine(low + " " + current + " " + high);

            if (nums[current] == 0)
            {
                // Swap current with low
                int temp = nums[current];
                nums[current] = nums[low];
                nums[low] = temp;

                low++;
                current++;
            }
            else if (nums[current] == 2)
            {
                // Swap current with high
                int temp = nums[current];
                nums[current] = nums[high];
                nums[high] = temp;

                high--;
            }
            else
            {
                // If nums[current] == 1, just move forward
                current++;
            }
            //Console.WriteLine(String.Join(",", nums));

        }
    }

    public static void SortColors3Pointer(int[] nums)
    {
        int zeroBoundary = 0, inspector = 0, twoBoundary = nums.Length - 1;
        // Process the array until the inspector crosses the twoBoundary
        while (inspector <= twoBoundary)
        {
            switch (nums[inspector])
            {
                case 0:
                    // Place 0 in the correct position
                    swap(inspector, zeroBoundary);
                    zeroBoundary++;
                    inspector++;
                    break;

                case 1:
                    // 1 is already in the correct place
                    inspector++;
                    break;

                case 2:
                    // Place 2 in the correct position
                    swap(inspector, twoBoundary);
                    twoBoundary--;
                    break;
            }
        }

        // Helper function to swap two elements in the array
        void swap(int a, int b)
        {
            (nums[a], nums[b]) = (nums[b], nums[a]);
        }
    }
}