/*

Print all combinations of binary 0 and 1 for n digits


given n=2
00
01
10
11

given n=1
0
1

given n=3
000
001
010
011
100
101
110
111
*/

public class RecursionPrintBinary
{

    public static void Run(){
        PrintBinary(2);
        Console.WriteLine();
        Console.WriteLine();

        PrintBinary(3);
    }

    public static void PrintBinary(int n, string prefix = ""){
        Console.WriteLine($"n {n} prefix {prefix}");
        //base case
        if(n == 0){
            Console.WriteLine(prefix);
            return;
        }
        PrintBinary(n-1, prefix+"0");
        PrintBinary(n-1, prefix+"1");

    }

}