/*

A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.

 

Example 1:

Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.
Example 2:

Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.
Example 3:

Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.
Since an empty string reads the same forward and backward, it is a palindrome.
 

Constraints:

1 <= s.length <= 2 * 105
s consists only of printable ASCII characters.

*/


public class StrValidPalindrome {

    public static void Run(){
        string s = "A man, a plan, a canal: Panama";
        var result = IsPalindrome(s);
        Console.WriteLine(result);
    }

    public static bool IsPalindrome(string s) {
        int start = 0;
        int end = s.Length - 1; 
        while(start < end)
        {
            if(!isAlphaNumeric(s[start]))
            {
                start++;
                continue;
            }
            if(!isAlphaNumeric(s[end]))
            {
                end--;
                continue;
            }
            if(Char.ToLower(s[start]) != Char.ToLower(s[end]) )
            {
                return false;
            }
            start++;
            end--;
        }
        return true;

        bool isAlphaNumeric(char c)
        {
            //48 57, 65 90, 97 122
            int ASCIICode = (int)c;
            if( ASCIICode >=(int)'A' && ASCIICode<=(int)'Z' ||
            ASCIICode >=(int)'a' && ASCIICode<=(int)'z' ||
            ASCIICode >=(int)'0' && ASCIICode<=(int)'9' ){
                return true;
            }
            return false;            
        }
    }
}