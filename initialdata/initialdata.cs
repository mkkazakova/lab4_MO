public class initialdata
{
    public static int[] matrix01 = new int[] { 8, 1, 7, 6 };
    static int[,] GetMatrix()
    {
        int[,] matrix0 = new int[4, 4]
        {
            { 5, 6, 4, 10 },
            { 6, 7, 3, 2 },
            { 3, 2, 9, 5 },
            { 2, 1, 10, 4 }
        };

        return matrix0;
    }
    public static int[,] matrix0 = GetMatrix();

    public static void Criteria()
    {
        Console.WriteLine();
        Console.WriteLine("    Критерии");
        Console.WriteLine("1. Цена");
        Console.WriteLine("2. Удалённость");
        Console.WriteLine("3. Пляж");
        Console.WriteLine("4. Достопримечательности");
        Console.WriteLine();
    }
}