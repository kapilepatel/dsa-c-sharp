/*

Asked in an interview
reverse each word in a given string,
example:


input: ABC 123
output: CBA 321

*/

using System.Text;
public class StrReverseWord
{


    public static void Run()
    {
        string name = "Kapil Patel";
        Console.WriteLine(ReverseWord(name));
    }

    public static string ReverseWord(string s)
    {
        //do not use in-built functions like string split and reverse

        List<string> words =[];
        StringBuilder runningWord = new StringBuilder();
        foreach (char c in s)
        {
            if (c.Equals(' '))
            {
                if (runningWord.Length >0)
                {
                    words.Add(runningWord.ToString());
                    runningWord.Clear();
                }
            }
            else
            {
                runningWord.Append(c);
            }
        }
        words.Add(runningWord.ToString());

        for (int k = 0; k < words.Count; k++)
        {
            string temp = "";
            string word = words[k];
            for (int i = word.Length - 1; i >= 0; i--)
            {
                temp += word[i]; 
            }
            words[k] = temp;
        }
        return string.Join(' ', words);
    }
}