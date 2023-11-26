// Нормирование матрицы
class Program1
{
    static void Main()
    {
        Program(initialdata.matrix01);
    }

    static void Program(int[] matrix)
    {
        Console.WriteLine("таблица весов");
        Methods.PrintMatrix(matrix);

        double[] matrix1 = new double[4];
        Array.Copy(matrix, matrix1, matrix.Length);

        double sum = matrix.Sum();
        for (int i = 0; i < 4; i++)
        {
            matrix1[i] = matrix[i] / sum;
        }
        Console.WriteLine("нормированная таблица весов");
        Methods.PrintMatrix(matrix1);
    }
}