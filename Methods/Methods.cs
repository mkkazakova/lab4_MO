public class Methods
{
    // Метод для вывода матрицы
    public static void PrintMatrix<T>(T[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] is double)
                {
                    double value = (double)(object)matrix[i, j];
                    if (value % 1 == 0)
                    {
                        if (value == 10)
                        {
                            Console.Write("10 ");
                        }
                        else
                        {
                            Console.Write(" " + value + "   ");
                        }
                    }
                    else
                    {
                        Console.Write(value.ToString("F2") + " ");                    
                    }
                }
                else
                {
                    int value = (int)(object)matrix[i, j];
                    if (value == 10)
                    {
                        Console.Write("10 ");
                    }
                    else
                        Console.Write(value + "  ");
                }
            }
            Console.WriteLine();
        }
    }

    public static void PrintMatrix<T>(T[] matrix)
    {
        int cols = matrix.GetLength(0);
        for (int j = 0; j < cols; j++)
        {
            if (matrix[j] is double)
            {
                double value = (double)(object)matrix[j];
                if (value % 1 == 0)
                {
                    if (value == 10)
                    {
                        Console.Write("10  ");
                    }
                    else
                    {
                        Console.Write(" " + value + " ");
                    }
                }
                else
                {
                    Console.Write(value.ToString("0.##") + " ");
                }
            }
            else
            {
                int value = (int)(object)matrix[j];
                if (value == 10)
                {
                    Console.Write("10 ");
                }
                else
                    Console.Write(value + "  ");
            }
        }
        Console.WriteLine();
    }


    public static double MaxinColumn(double[,] matrix, int column)
    {
        double max = 0;
        for (int i = 0; i < 4; i++)
        {
            if (matrix[i, column] > max)
                max = matrix[i, column];
        }
        return max;
    }
    public static double MininColumn(double[,] matrix, int column)
    {
        double min = 10;
        for (int i = 0; i < 4; i++)
        {
            if (matrix[i, column] < min)
                min = matrix[i, column];
        }
        return min;
    }

    public static void WriteCountry(int i)
    {
        switch (i)
        {
            case 0:
                Console.WriteLine("Испания");
                break;
            case 1:
                Console.WriteLine("Турция");
                break;
            case 2:
                Console.WriteLine("Куба");
                break;
            case 3:
                Console.WriteLine("Индонезия");
                break;
            default:
                Console.WriteLine("arror in country");
                break;
        }
    }

    // Метод для нормирования значений в столбцах
    public static void NormalizeColumns(double[,] matrix)
    {
        for (int j = 0; j < 4; j++)
        {
            double sum = 0;
            for (int i = 0; i < 4; i++)
            {
                sum += matrix[i, j];
            }
            for (int i = 0; i < 4; i++)
            {
                matrix[i, j] /= sum;
            }
        }
    }
    public static void NormalizeColumns(double[] matrix)
    {
        double sum = 0;
        for (int i = 0; i < 4; i++)
        {
            sum += matrix[i];
        }
        for (int i = 0; i < 4; i++)
        {
            matrix[i] /= sum;
        }
    }

    // Умножение матриц
    public static double[] MatrixMultiplication(double[,] matrix1, double[] matrix2)
    {
        double[] result = new double[4];
        for (int i = 0; i < 4; i++) // по строке
        {
            double sum = 0;
            for (int j = 0; j < 4; j++) // по элементам в строке
            {
                sum += matrix1[i, j] * matrix2[j];
            }
            result[i] = sum;
        }
        return result;
    }

    // Метод нахождения индекса строки, в которой максимальный элемент
    public static int IndexMaxStr(double[,] matrix, int column)
    {
        int IndexMax = 0;
        for (int i = 0; i < 4; i++)
        {
            if (matrix[i, column] > matrix[IndexMax, column])
                IndexMax = i;
        }
        return IndexMax;
    }

    // Выводит промежуточную нормированную матрицу и возвращает преобразованный столбец
    public static void PairwiseComparison(double[] matrix)
    {
        double[,] matrix1 = new double[4, 4]; // Промежуточная таблица
        for (int i = 0; i < 4; i++) // по элементам данного массива или по строке
        {
            for (int j = 0; j < 4; j++) // по столбцам
            {
                matrix1[i, j] = matrix[i] / matrix[j];
            }
        }
        PrintMatrix(matrix1);

        for (int i = 0; i < 4; i++) // по строке
        {
            for (int j = 0; j < 4; j++) // по столбцам
            {
                matrix[i] += matrix1[i, j];
            }
        }
        Console.WriteLine("\nСумма по строкам");
        PrintMatrix(matrix);
    }

    public static double ConsistencyCoefficient(double[] matrix, int[] matrixweight)
    {             
        double[,] matrix1 = new double[4, 4]; // Промежуточная таблица
        for (int i = 0; i < 4; i++) // по элементам данного массива или по строке
        {
            for (int j = 0; j < 4; j++) // по столбцам
            {
                matrix1[i, j] = matrix[i] / matrix[j];
            }
        }

        double[] matrix2 = new double[4]; // Матрица весов (нормированная)
        Array.Copy(matrixweight, matrix2, matrixweight.Length);
        double sum = matrixweight.Sum();
        for (int i = 0; i < 4; i++)
        {
            matrix2[i] = matrixweight[i] / sum;
        }

        
        double LambdaMax = 0;
        for (int j = 0; j < 4; j++) // по столбцам
        {
            double SuminColumn = 0;
            for (int i = 0; i < 4; i++)
            {
                SuminColumn += matrix1[i, j];
            }
            LambdaMax += SuminColumn * matrix2[j];
        }
        return (LambdaMax - 4) / (3 * 0.9);
    }

}

