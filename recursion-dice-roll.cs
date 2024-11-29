/*

Dice roll related stuff


*/


public class RecursionDiceRoll
{

    public static void Run(){
        //DiceRoll(3, new List<int>());
        
        Console.WriteLine();
        //DiceRollBetter(3, new List<int>());

        Console.WriteLine();
        //3 dices, desired sum 5
        DiceRollSum(3, 7, new List<int>());
    }


    public static void DiceRoll(int dice , List<int> chosen){
        //Console.WriteLine($"dice {dice} "+ string.Join(", ",chosen) );
        //base case
        if(dice == 0){
            Console.WriteLine(string.Join(", ",chosen));
            return;
        }
        chosen.Add(1);
        DiceRoll(dice -1, chosen);
        chosen.Remove(1);

        chosen.Add(2);
        DiceRoll(dice -1, chosen);
        chosen.Remove(2);

        chosen.Add(3);
        DiceRoll(dice -1, chosen);
        chosen.Remove(3);

        chosen.Add(4);
        DiceRoll(dice -1, chosen);
        chosen.Remove(4);

        chosen.Add(5);
        DiceRoll(dice -1, chosen);
        chosen.Remove(5);

        chosen.Add(6);
        DiceRoll(dice -1, chosen);
        chosen.Remove(6);
    
    }


    public static void DiceRollBetter(int dice , List<int> chosen){
        //Console.WriteLine($"dice {dice} "+ string.Join(", ",chosen) );
        //base case
        if(dice == 0){
            Console.WriteLine(string.Join(", ",chosen));
            return;
        }
        for(int i = 1; i <= 6; i++)
        {
            chosen.Add(i);
            DiceRollBetter(dice -1, chosen);
            chosen.RemoveAt(chosen.Count - 1);
        }
    
    }

    public static void DiceRollSum(int dice ,int sum,  List<int> chosen){
        //Console.WriteLine($"dice {dice} "+ string.Join(", ",chosen) );
        //base case
        if(dice == 0){
            if(sum == chosen.Sum() ){
                Console.WriteLine(string.Join(", ",chosen));
            }
            return;
        }
        for(int i = 1; i <= 6; i++)
        {
            chosen.Add(i);
            DiceRollSum(dice -1,sum, chosen);
            chosen.RemoveAt(chosen.Count - 1);
        }    
    }

    public static void DiceRollSumBetter(int dice ,int sum,  List<int> chosen){
        //Console.WriteLine($"dice {dice} "+ string.Join(", ",chosen) );
        //base case
        if(dice == 0){
            Console.WriteLine(string.Join(", ",chosen));
            return;
        }
        for(int i = 1; i <= 6; i++)
        {
            chosen.Add(i);
            if(chosen.Sum() <= sum){
                DiceRollSum(dice -1,sum, chosen);
            }            
            chosen.RemoveAt(chosen.Count - 1);
        }    
    }

}