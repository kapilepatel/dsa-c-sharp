/*
Combination Sum

Given an array of distinct integers candidates and a target integer target, 
return a list of all unique combinations of candidates where the chosen numbers sum to target. 
You may return the combinations in any order.

The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the 
frequency
 of at least one of the chosen numbers is different.

The test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.

 

Example 1:

Input: candidates = [2,3,6,7], target = 7
Output: [[2,2,3],[7]]
Explanation:
2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
7 is a candidate, and 7 = 7.
These are the only two combinations.
Example 2:

Input: candidates = [2,3,5], target = 8
Output: [[2,2,2,2],[2,3,3],[3,5]]
Example 3:

Input: candidates = [2], target = 1
Output: []
 

Constraints:

1 <= candidates.length <= 30
2 <= candidates[i] <= 40
All elements of candidates are distinct.
1 <= target <= 40


*/


public class ArrCombinationSum
{
    public static void Run()
    {
        
        int[] candidates = new int[] { 2, 3, 6, 7 };
        int target = 7;
        int index = 0;
        List<int> ds = new List<int>();
        List<List<int>> result = new List<List<int>>();
        FindCombinations(candidates, target, index, ds, result);

        Console.WriteLine("Problem input "+ string.Join(",", candidates));
        Print(result);

        
        ds = new List<int>();
        result = new List<List<int>>();
        candidates = new int[] { 2, 3, 5 };
        target = 8;
        index = 0;
        FindCombinations(candidates, target, index, ds, result);
        Console.WriteLine("Problem input "+string.Join(",", candidates));
         Print(result);
    }



    public static void FindCombinations(int[] candidates, int target, int index, List<int> combination, List<List<int>> result)
    {
        //Console.WriteLine($"target {target} index {index} combinations {string.Join(", ", combination)} ");
        //Console.WriteLine("Result");
        //Print(result);
        //base case
        if (index >= candidates.Length)
        {
            if (target == 0)
            {
                //result.Add(combination);
                result.Add(new List<int>(combination));//Adding a new copy
                //Console.WriteLine("Combinations:");
                //Print(combination);
            }
            return;
        }
        else
        {
            //choose
            //explore 
            //un-choose
            if (candidates[index] <= target)
            {
                combination.Add(candidates[index]);
                FindCombinations(candidates, target - candidates[index], index, combination, result);
                combination.RemoveAt(combination.Count - 1);
            }

            FindCombinations(candidates, target, index + 1, combination, result);
        }
    }

    public static void Print(List<List<int>> lst)
    {
        if (lst == null)
        {
            return;
        }
        foreach (var innerList in lst)
        {
            Console.WriteLine(string.Join(",", innerList));
        }
    }

    public static void Print(List<int> arr)
    {
        foreach (var item in arr)
        {
            Console.Write($"{item} , ");
        }
        Console.WriteLine();

    }




}