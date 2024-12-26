public class Sort
{

    public static void Run()
    {
        var res = SelectionSort([1, 3, 8, 56, 0, 7, 9]);
        Console.WriteLine(string.Join(", ", res));

        var res1 = BubbleSort([1, 3, 8, 56, 0, 7, 9]);
        Console.WriteLine(string.Join(", ", res1));

        var res2 = InsertionSort([1, 3, 8, 56, 0, 7, 9]);
        Console.WriteLine(string.Join(", ", res2));
    }

    public static int[] SelectionSort(int[] nums)
    {
        int left = 0;
        while (left < nums.Length)
        {
            int minIndex = left;
            for (int i = left; i < nums.Length; i++)
            {
                if (nums[i] < nums[minIndex])
                {
                    minIndex = i;
                }
            }
            int temp = nums[left];
            nums[left] = nums[minIndex];
            nums[minIndex] = temp;
            left++;
        }
        return nums;
    }


    public static int[] BubbleSort(int[] nums)
    {
        int end = nums.Length;
        for (int i = 0; i < end - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < end - 1 - i; j++)
            {
                if (nums[j] > nums[j + 1])
                {
                    int temp = nums[j + 1];
                    nums[j + 1] = nums[j];
                    nums[j] = temp;
                    swapped = true;
                }
            }
            if (!swapped)
            {
                break;
            }
        }
        return nums;
    }

    public static int[] InsertionSort(int[] nums)
    {
        for (int i = 1; i < nums.Length; i++)
        {
            int value = nums[i];
            int j = i - 1;
            while (j >= 0 && nums[j] > value)
            {
                nums[j + 1] = nums[j];
                j--;
            }
            nums[j + 1] = value;
        }
        return nums;
    }
}