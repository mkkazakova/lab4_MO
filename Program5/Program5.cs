// Метод анализа иерархий
using System.Data.Common;

class Program5
{
    static void Main()
    {
        Program(initialdata.matrix0, initialdata.matrix01);
    }
    static void Program(int[,] matrix, int[] matrix0)
    {
        // Общая матрица
        double coef = 0;
        double[,] matrix1 = new double[4, 4];
        for (int j = 0; j < 4; j++)
        {
            Console.WriteLine("\nНормированный " + (j+1) + " столбец");
            double[] column = new double[4];
            for (int i = 0; i < 4; i++)
            {
                column[i] = matrix[i, j];
            }
            Methods.PairwiseComparison(column);
            coef = Methods.ConsistencyCoefficient(column, matrix0);
            Methods.NormalizeColumns(column);
            Console.WriteLine("нормированная сумма");
            Methods.PrintMatrix(column);
            for (int i = 0; i < 4; i++)
            {
                matrix1[i, j] = column[i];
            }
            Console.WriteLine("коэффициент согласованности: {0: 0.000}", coef);
        }

        // Матрица весов
        double[] matrix2 = new double[4];
        Array.Copy(matrix0, matrix2, matrix0.Length);
        Console.WriteLine("\nМатрица весов");
        Methods.PairwiseComparison(matrix2);
        coef = Methods.ConsistencyCoefficient(matrix2, matrix0);
        Methods.NormalizeColumns(matrix2);
        Console.WriteLine("нормированная сумма");
        Methods.PrintMatrix(matrix2);
        Console.WriteLine("коэффициент согласованности: " + coef);

        // Результат
        double[,] matrix3 = new double[4, 1];
        for (int i = 0; i < 4; i++)
            matrix3[i, 0] = Methods.MatrixMultiplication(matrix1, matrix2)[i];
        Console.WriteLine();
        Methods.PrintMatrix(matrix3);
        Console.WriteLine();
        
        Methods.WriteCountry(Methods.IndexMaxStr(matrix3, 0));

    }

}