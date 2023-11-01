namespace СSharpLabs;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Задание 1.1:");
        Random random = new Random();
        // Задание 1.1 одномерный массив (16 вар)

        int[] array = new int[25];

        for (int i = 0; i < array.Length; i++) array[i] = random.Next(-100, 100);
        int sum = 0;
        int sum2 = 0;
        bool zeroInArray = false;
        foreach (int i in array)
        {
            if (i > 0)
            {
                sum = sum + 1;
            }
            if (i == 0)
            {
                sum2 = 0;
                zeroInArray = true;
            }
            sum2 += i;
        }
        if (!zeroInArray)
            sum2 = 0;
        Console.WriteLine($"{sum} положительных элементов");
        Console.WriteLine($"сумма элементов после последнего нуля = {sum2} ");

        for (int i = 0; i < array.Length; i++)
        {// -6 1 3 -5 4 -9
            if (array[i] < 1)
                continue;
            int j;
            for (j = i + 1; j < array.Length; j++)
            {
                if (array[j] < 1)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    break;
                }
            }
            if (j == array.Length)
            {
                break;
            }

        }
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.ReadLine();

        // Задание 1.2 Матрицы (вар. 16)

        Console.WriteLine("Задание 1.2:");
        double[][] matrix = new double[4][];
        for (int i = 0; i < matrix.Length; i++) matrix[i] = new double[4];

        HashSet<double> values = new HashSet<double>();

        foreach (var line in matrix)
        {
            for (int j = 0; j < line.Length; j++)
            {
                line[j] = random.Next(-999, 999) / 10.0;
                values.Add(line[j]);
            }
        }
        PrintMatrix(matrix);

        int position = 0;
        foreach (var line in matrix)
        {
            line[position] = values.Max();
            values.Remove(line[position++]);
        }
        PrintMatrix(matrix);

        position = 0;
        foreach (var line in matrix)
        {
            if (line.Any(e => e > 0))
            {
                position++;
                continue;
            }
            Console.WriteLine(position);
            break;
        }

    }

    public static void PrintMatrix(double[][] matrix)
    {
        foreach (var line in matrix)
        {
            Console.WriteLine(string.Join(" ", line.Select(x => x.ToString())));
        }
        Console.WriteLine("------------------------------------------");
    }
}