/*
Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.

 

Example 1:

Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
Output: [[1,6],[8,10],[15,18]]
Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].
Example 2:

Input: intervals = [[1,4],[4,5]]
Output: [[1,5]]
Explanation: Intervals [1,4] and [4,5] are considered overlapping.
 

Constraints:

1 <= intervals.length <= 104
intervals[i].length == 2
0 <= starti <= endi <= 104
*/

using System.Runtime.InteropServices;

public class SolutionArrMerge
{

    public static void Run()
    {
        int[][] intervals = [[1, 3], [2, 6], [8, 10], [15, 18]];
        var result = Merge(intervals);
        Print(result);

        intervals = [[1,4],[0,0]];
        result = Merge(intervals);
        Print(result);

    }

    public static void Print(int[][] jaggedArr)
    {   
        foreach (var item in jaggedArr)
        {
            Console.WriteLine(String.Join(",", item));
        }
    }
    static int comparer(int[] a, int[] b)
    {
        return a[0].CompareTo(b[0]);
    }

    public static int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, comparer);

        bool findOverlap = true;
        List<List<int>> list = new List<List<int>>();
        for (int i = 0; i < intervals.Length; i++)
        {
            List<int> tempList = new List<int>();
            for (int j = 0; j < intervals[i].Length; j++)
            {
                tempList.Add(intervals[i][j]);
            }
            list.Add(tempList);
        }
        while (findOverlap)
        {
            findOverlap = false;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1][1] >= list[i][0])
                {
                    findOverlap = true;
                    list[i - 1][0] = Math.Min(list[i - 1][0], list[i][0]);
                    list[i - 1][1] = Math.Max(list[i - 1][1], list[i][1]);
                    list.RemoveAt(i);
                    break;
                }
            }
        }
        int rowCount = list.Count;
        int colCount = list[0].Count;
        int[][] arr = new int[rowCount][];
        for (int i = 0; i < list.Count; i++)
        {
            arr[i] = new int[colCount];
            for (int j = 0; j < colCount; j++)
            {
                arr[i][j] = list[i][j];
            }
        }
        return arr;
    }
}