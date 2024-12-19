public static class MatrixRotate
{

    public static void rotate()
    {
        int[,] matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        int[,] m = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        //Console.WriteLine(matrix.GetLength(0));
        print(matrix);

        int c = 2;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                //Console.Write(matrix[i, j] + " ");
                m[j,c] = matrix[i,j];                
            }
            c--;
            //Console.WriteLine();
        }

        print(m);

    }

    private static void print(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}