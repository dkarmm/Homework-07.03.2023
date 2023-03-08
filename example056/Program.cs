// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.


int GetSizeMatrixFromUser(string text) // Запрос размера матрицы.
{
    bool flag = false;
    int value = 0;
    while (!flag)
    {
        Console.Write(text);
        flag = int.TryParse(Console.ReadLine(), out value);
        if (value < 1)
        {
            Console.WriteLine("Используйте целые числа больше 0.");
            flag = false;
        }
    }
    return value;
}

void PhillRandomMatrix(int[,] matrix) // Заполнение матрицы рандомом.
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(1, 5);
        }
    }
}

void ShowMatrix(int[,] matrix) // Вывод матрицы в терминал.
{
    Console.WriteLine("Получена матрица: ");
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

int GetIndexLowerSumFromMatrix(int[,] matrix) // Метод решения
{
    int[] arrayWithSums = new int[matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int lineSum = 0;
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            lineSum += matrix[i, j];
        }
        arrayWithSums[i] = lineSum;
    }
    int minSumIndex = 0;
    for (int i = 0; i < arrayWithSums.Length; i++)
    {
        if (arrayWithSums[i] < arrayWithSums[minSumIndex]) minSumIndex = i;
    }
    return minSumIndex;
}


int matrixSize = GetSizeMatrixFromUser("Введите размер матрицы: ");
int[,] matrix = new int[matrixSize, matrixSize];

PhillRandomMatrix(matrix);
ShowMatrix(matrix);
Console.WriteLine($"Индекс строки с меньшей суммой равен: {GetIndexLowerSumFromMatrix(matrix)}");