
/*
Insert Interval
You are given an array of non-overlapping intervals intervals 
where intervals[i] = [starti, endi] represent the start and the end of the ith interval 
and intervals is sorted in ascending order by starti. 
You are also given an interval newInterval = [start, end] that represents the start and end of another interval.

Insert newInterval into intervals such that intervals is still sorted in ascending order by starti 
and intervals still does not have any overlapping intervals (merge overlapping intervals if necessary).

Return intervals after the insertion.

Note that you don't need to modify intervals in-place. You can make a new array and return it.

 

Example 1:

Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
Output: [[1,5],[6,9]]
Example 2:

Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
Output: [[1,2],[3,10],[12,16]]
Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].
 

Constraints:

0 <= intervals.length <= 104
intervals[i].length == 2
0 <= starti <= endi <= 105
intervals is sorted by starti in ascending order.
newInterval.length == 2
0 <= start <= end <= 105

*/

using System.Runtime.CompilerServices;

public class ArrInsertInterval
{
    public static void Run()
    {
        int[][] intervals = new int[][] { [1, 3], [6, 9] };
        int[] newInterval = new int[] { 2, 5 };
        var result = InsertInterval(intervals, newInterval);
        Print2DArray(intervals);
        Console.WriteLine();

        Print2DArray(result);

        Console.WriteLine("\n\n");

        intervals = new int[][] { [1,2],[3,5],[6,7],[8,10],[12,16] };
        newInterval = new int[] { 4,8 };
        result = InsertInterval(intervals, newInterval);
        Print2DArray(intervals);
        Console.WriteLine();
        Print2DArray(result);

    }

    public static void Print2DArray(int[][] twoDArr)
    {
        if (twoDArr == null)
        {
            return;
        }
        foreach (var oneDArr in twoDArr)
        {
            foreach (var item in oneDArr)
            {
                Console.Write($"{item} , ");
            }
            Console.WriteLine();
        }
    }

    //[1,2],[3,5],[6,7],[8,10],[12,16]....[4,8]
    public static int[][] InsertInterval(int[][] intervals, int[] newInterval)
    {
        List<int[]> result = new List<int[]>();

        int i = 0;
        //Step 1: Add intervals that come before newInterval

        while( i < intervals.Length && intervals[i][1] < newInterval[0])
        {
            result.Add(intervals[i]);
            i++;
        }

    // Step 2: Merge overlapping intervals with newInterval
        while(i < intervals.Length && intervals[i][0] <= newInterval[1] )
        {
            //can use Math.Min(intervals[i][0] , newInterval[0])
            if( intervals[i][0] < newInterval[0]  ){
                newInterval[0] = intervals[i][0] ;
            }

            if( intervals[i][1] > newInterval[1] ){
                newInterval[1] = intervals[i][1]; 
            }
            i++;
        }

        result.Add(newInterval);// Add the merged interval

        // Step 3: Add intervals that come after newInterval
        while( i < intervals.Length)
        {
            result.Add(intervals[i]);
            i++;
        }


        return result.ToArray();
    }


}