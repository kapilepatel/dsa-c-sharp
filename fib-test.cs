
public static class test1{

    //Fiboinacci 100-200

//1 2 3 5

public static void fibonacci()
{
    
    int a  = 1;
    int b = 2;

    while(b <= 200){
        
        //if()
        Console.WriteLine(a+b);
        
        int temp = a;
        a = b;
        b = temp+b;
    }

}


}