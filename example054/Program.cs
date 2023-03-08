// Задача 54: Задайте двумерный массив. 
// Напишите программу, которая упорядочит по убыванию элементы 
// каждой строки двумерного массива.

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
            matrix[i, j] = new Random().Next(1, 11);
        }
    }
}

void ShowMatrix(int[,] matrix) // Вывод матрицы в терминал.
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[,] GetOrderedMatrix(int[,] matrix) // Упорядок в меньшую.
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                int maxIndex = j;
                if(matrix[i, k] < matrix[i, maxIndex]) maxIndex = k;
                int temp = matrix[i,j];
                matrix[i, j] = matrix[i, maxIndex];
                matrix[i, maxIndex] = temp;
            }
        }
    }
    return matrix;
    // Я не знаю, как у меня получилось, но оно работает...
}

int lines = GetSizeMatrixFromUser("Введите кол-во строк матрицы: ");
int columns = GetSizeMatrixFromUser("Введите кол-во столбцов: ");
int[,] matrix = new int[lines, columns];

PhillRandomMatrix(matrix);
ShowMatrix(matrix);
GetOrderedMatrix(matrix);

Console.WriteLine("Получена матрица: ");
ShowMatrix(matrix);