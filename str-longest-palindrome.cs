/*

Given a string s which consists of lowercase or uppercase letters, return the length of the longest 
palindrome
 that can be built with those letters.

Letters are case sensitive, for example, "Aa" is not considered a palindrome.

 

Example 1:

Input: s = "abccccdd"
Output: 7
Explanation: One longest palindrome that can be built is "dccaccd", whose length is 7.
Example 2:

Input: s = "a"
Output: 1
Explanation: The longest palindrome that can be built is "a", whose length is 1.
 

Constraints:

1 <= s.length <= 2000
s consists of lowercase and/or uppercase English letters only.
*/


public class StrLongestPalindrome
{

    public static void Run()
    {
        string s = "abccccdd";
        var result = LongestPalindromeWithCounts(s);
        Console.WriteLine(result);

        result = LongestPalindromeGreedy(s);
        Console.WriteLine(result);

        result = LongestPalindromeUsingHashSet(s);
        Console.WriteLine(result);

    }

    public static int LongestPalindromeWithCounts(string s)
    {
        Dictionary<char, int> chars = [];

        foreach (char c in s)
        {
            if (chars.TryGetValue(c, out int count))
            {
                chars[c] = count + 1;
            }
            else
            {
                chars.Add(c, 1);
            }
        }

        int total = 0;
        bool oddFound = false;
        foreach (var item in chars)
        {
            int count = item.Value;
            if (count % 2 == 0)
            {
                total += count;
            }
            else
            {
                total += count - 1;
                oddFound = true;
            }
        }
        if (oddFound)
        {
            total += 1;
        }
        return total;
    }

    public static int LongestPalindromeGreedy(string s)
    {
        Dictionary<char, int> chars = [];
        int result = 0;
        foreach (char c in s)
        {
            if (chars.TryGetValue(c, out int count))
            {
                chars[c] = count + 1;
                if (chars[c] % 2 == 0)
                {
                    result += 2;
                }
            }
            else
            {
                chars.Add(c, 1);
            }
        }

        foreach (var item in chars)
        {
            if (item.Value % 2 == 0)
            {
                result += 1;
                break;
            }
        }
        return result;
    }

    public static int LongestPalindromeUsingHashSet(string s)
    {
        HashSet<char> chars = new HashSet<char>();
        int result = 0;
        foreach (char c in s)
        {
            if (chars.Contains(c))
            {
                chars.Remove(c);
                result += 2;
            }
            else
            {
                chars.Add(c);
            }
        }

        if (chars.Count > 0)
        {
            result += 1;
        }
        return result;
    }
}