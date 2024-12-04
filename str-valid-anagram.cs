/*
Given two strings s and t, return true if t is an 
anagram
 of s, and false otherwise.

 

Example 1:

Input: s = "anagram", t = "nagaram"

Output: true

Example 2:

Input: s = "rat", t = "car"

Output: false

 

Constraints:

1 <= s.length, t.length <= 5 * 104
s and t consist of lowercase English letters.
 

Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?
*/

public class StrValidAnagram {

    public static void Run()
    {   
        string s = "anagram";
        string t = "nagaram";
        Console.WriteLine(IsAnagramTwoDictionaries(s, t));

        string s2 = "rat";
        string t2 = "car";
        Console.WriteLine(IsAnagramTwoDictionaries(s2, t2));

        Console.WriteLine(); 
        Console.WriteLine(IsAnagramSingleDictionary(s, t));        
        Console.WriteLine(IsAnagramSingleDictionary(s2, t2));

        Console.WriteLine();
        Console.WriteLine(IsAnagramUsingArray(s, t));
        Console.WriteLine(IsAnagramUsingArray(s2, t2));

    }
    public static bool IsAnagramTwoDictionaries(string s, string t) {
        if(s.Length != t.Length){
            return false;
        }
        Dictionary<char, int> sDictionary = new Dictionary<char, int>();
        Dictionary<char, int> tDictionary = new Dictionary<char, int>();
        
        for(int i = 0; i < s.Length; i++)
        {
            var charA = s[i];
            var charB = t[i];
            if(sDictionary.ContainsKey(charA)){
                sDictionary[charA]++;
            }else{
                sDictionary.Add(charA,1);
            }
            if(tDictionary.ContainsKey(charB)){
                tDictionary[charB]++;
            }else{
                tDictionary.Add(charB,1);
            }
        }

        foreach(var item in sDictionary){
            Char charA = item.Key;
            int frequencyA = item.Value;

            int frequencyB;
            if(! ( tDictionary.TryGetValue(charA,out frequencyB) && (frequencyA == frequencyB)) )
            {   
                return false;
            }
        }
        return true;
        
    }

    
    public static bool IsAnagramSingleDictionary(string s, string t) {
        if(s.Length != t.Length){
            return false;
        }
        Dictionary<char, int> sDictionary = new Dictionary<char, int>();
        
        for(int i = 0; i < s.Length; i++)
        {
            var charA = s[i];
            var charB = t[i];
            if(sDictionary.ContainsKey(charA)){
                sDictionary[charA]++;
            }else{
                sDictionary.Add(charA,1);
            }
            if(sDictionary.ContainsKey(charB)){
                sDictionary[charB]--;
            }else{
                sDictionary.Add(charB,-1);
            }
        }

        foreach(var item in sDictionary){
            if(item.Value != 0)
            {   
                return false;
            }
        }
        return true;
    }

    public static bool IsAnagramUsingArray(string s, string t) {
        if(s.Length != t.Length){
            return false;
        }
        int[] charCount = new int[26];
        
        for(int i = 0; i < s.Length; i++)
        {
            var charA = s[i];
            var charB = t[i];

            charCount[charA-'a']++;
            charCount[charB-'a']--;
        }

        foreach(var item in charCount){
            if(item != 0)
            {   
                return false;
            }
        }
        return true;
    }
}