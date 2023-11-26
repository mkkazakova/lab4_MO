//  Методом взвешивания и объединения критериев
class Program4
{
    static void Main()
    {
        Program(initialdata.matrix0, initialdata.matrix01);
    }
    static void Program(int[,] matrix, int[] matrix0)
    {
        // Общая матрица
        double[,] matrix1 = new double[4, 4];
        Array.Copy(matrix, matrix1, matrix.Length);
        Methods.NormalizeColumns(matrix1);
        Console.WriteLine("Нормированная матрица");
        Methods.PrintMatrix(matrix1);

        // Матрица весов
        double[] matrixAlfa = new double[4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (i == j)
                    matrixAlfa[i] += 0;
                else
                {
                    if (matrix0[i] > matrix0[j])
                        matrixAlfa[i] += 1;
                    if (matrix0[i] < matrix0[j])
                        matrixAlfa[i] += 0;
                    if (matrix0[i] == matrix0[j])
                        matrixAlfa[i] += 0.5;
                }
            }
        }
        Methods.NormalizeColumns(matrixAlfa);
        Console.WriteLine("\nMatrixAlfa:");
        Methods.PrintMatrix(matrixAlfa);

        // Запись в столбик реультата перемножения матриц
        double[,] matrix2 = new double[4, 1];
        for (int i = 0; i < 4; i++)
            matrix2[i, 0] = Methods.MatrixMultiplication(matrix1, matrixAlfa)[i];
        Console.WriteLine("\nРезультат перемножения");
        Methods.PrintMatrix(matrix2);

        Console.WriteLine();
        Methods.WriteCountry(Methods.IndexMaxStr(matrix2, 0));
    }
}