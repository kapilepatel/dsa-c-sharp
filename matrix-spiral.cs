/*
Given an m x n matrix, return all elements of the matrix in spiral order.

 

Example 1:


Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,2,3,6,9,8,7,4,5]
Example 2:


Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]
 

Constraints:

m == matrix.length
n == matrix[i].length
1 <= m, n <= 10
-100 <= matrix[i][j] <= 100
*/

public class MatrixSpiral {
    public static void Run(){
        int[][] matrix = [[1,2,3],[4,5,6],[7,8,9]];
        Console.WriteLine( String.Join(",", SpiralOrder(matrix)));

        int[][] matrix2 = [[1,2,3,4],[5,6,7,8],[9,10,11,12]];
        Console.WriteLine( String.Join(",", SpiralOrder(matrix2)));


    }
    public static IList<int> SpiralOrder(int[][] matrix) {
        
        int top =0;
        int left=0;
        int right = matrix[0].Length-1;
        int bottom = matrix.Length-1;
        List<int> result = new List<int>();

       // Console.WriteLine($"left {left} right {right}");
        //Console.WriteLine($"top {top } bottom {bottom}");
        
        while(top <= bottom && left <= right){
            //l -> r
            
            for(int i = left; i<=right;i++ ){
                result.Add(matrix[top][i]);
              //  Console.Write(matrix[top][i] +" ");
            }
            top++;
          //  Console.WriteLine();

            for(int i = top; i<=bottom;i++ ){
                result.Add(matrix[i][right]);

               // Console.Write(matrix[i][right]+" ");
            }
            right--;
            //Console.WriteLine();
            if (top <= bottom) {
                for(int i = right; i>=left ;i-- ){
                    result.Add(matrix[bottom][i]);

                   // Console.Write(matrix[bottom][i]+" ");
                }
                bottom--;
                //Console.WriteLine();
            }
            if(left <= right){
                for(int i = bottom; i>=top ;i-- ){
                    result.Add(matrix[i][left]);

                    //Console.Write(matrix[i][left]+" ");
                }
                left++;
                //Console.WriteLine();
            }
            //Console.WriteLine($"left {left} right {right}");
            //Console.WriteLine($"top {top } bottom {bottom}");


        }

        return result.ToArray();

    }
}