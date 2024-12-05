/*
Longest substring without repeating characters

Given a string s, find the length of the longest 
substring
 without repeating characters.

 

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 

Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
*/

public class StrLongestSubstring
{
    public static void Run()
    {
        string s = "abcabcbb";

        //Console.WriteLine(LongestSubstring(s));

        Console.WriteLine(LongestSubstringUsingDictionary(s));
        Console.WriteLine("------");
        Console.WriteLine(LongestSubstringUsingDictionary("bbbbb"));
        Console.WriteLine("------");
        Console.WriteLine(LongestSubstringUsingDictionary("pwwkew"));
    }
    public static int LongestSubstring(string s)
    {
        int maxLength = 0;
        string result = "";
        for (int i = 0; i < s.Length; i++)
        {
            Console.WriteLine("result " + result);
            Console.WriteLine("loop for char s[i] " + s[i]);
            if (result.Contains(s[i]))
            {
                int index = result.IndexOf(s[i]);
                Console.WriteLine("duplicate found at index " + index);
                result = result.Substring(index + 1) + s[i];
                Console.WriteLine("new result " + result);
            }
            else
            {
                result += s[i];
                Console.WriteLine("char appended to result " + result);
            }
            maxLength = Math.Max(maxLength, result.Length);
            Console.WriteLine();
        }
        return maxLength;
    }


    public static int LongestSubstringUsingDictionary(string s)
    {
        int maxLength = 0;
        int left = 0;
        HashSet<char> charSet = new HashSet<char>();

        for (int i = 0; i < s.Length; i++)
        {
            Print(charSet);
            Console.WriteLine("loop for char s[i] " + s[i]);
            //check for our new character in the set 
            //and remove that character including all characters of the left side
            //'abc' next char is 'b' , so remove 'a' and remove 'b' 
            while (charSet.Contains(s[i]))
            {
                charSet.Remove(s[left]);
                left++;
            }
            charSet.Add(s[i]);
            maxLength = Math.Max(maxLength, i - left + 1);
        }
        return maxLength;
    }

    static void Print(HashSet<char> set)
    {
        Console.WriteLine(String.Join(", ", set));
    }

}