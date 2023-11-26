// Замена критериев ограничениями
class Program2
{
    static void Main()
    {
        Console.WriteLine("Начальная таблица");
        Methods.PrintMatrix(initialdata.matrix0);
        initialdata.Criteria();
        Program(initialdata.matrix0, 1);
    }

    static void Program(int[,] matrix, int SelectedColumn)
    {
        double[,] matrix1 = new double[4, 4];
        Array.Copy(matrix, matrix1, matrix.Length);
        for (int j = 1; j < 4; j++)
        {
            if ((SelectedColumn - 1) != j)
            {
                double Amax = Methods.MaxinColumn(matrix1, j);
                double Amin = Methods.MininColumn(matrix1, j);
                for (int i = 0; i < 4; i++)
                    matrix1[i, j] = (matrix1[i, j] - Amin) / (Amax - Amin);
            }
        }
        Console.WriteLine("нормированная матрица (кроме " + SelectedColumn + " столбца)");
        Methods.PrintMatrix(matrix1);

        double A2 = 0.3 * Methods.MaxinColumn(matrix1, 1);
        double A3 = 0.3 * Methods.MaxinColumn(matrix1, 2);
        double A4 = 0.3 * Methods.MaxinColumn(matrix1, 3);
        int IndexStr = 0;
        for (int i = 0; i < 4; i++)
        {
            if ((matrix1[i, 1] >= A2) && (matrix1[i, 2] >= A3) && (matrix1[i, 3] >= A4)) // Проверяем минимально требуемые значения
                if (matrix1[i, 0] >= matrix1[IndexStr, 0]) // Если по главному критерию результат лучше
                    IndexStr = i; // то k присваиваем значение данной строки
        }
        Console.WriteLine();
        Methods.WriteCountry(IndexStr);
    }
}
