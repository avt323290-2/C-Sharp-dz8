/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/



(int, int, int, int) GetValues()
{
    (int, int, int, int) result = (0, 0, 0, 0);

    while (true)
    {
        Console.Write("Введите число строк первой матрицы: ");
        int stringsNumber1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите число столбцов первой матрицы: ");
        int columnsNumber1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите число строк второй матрицы: ");
        int stringsNumber2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите число столбцов второй матрицы: ");
        int columnsNumber2 = Convert.ToInt32(Console.ReadLine());

        result = (stringsNumber1, columnsNumber1, stringsNumber2, columnsNumber2);
        if (CheckArray(a: columnsNumber1, b: stringsNumber2) == true) break;
    }

    return result;
}

bool CheckArray(int a, int b)
{
    if (a == b)
    {
        return true;
    }
    else
    {
        Console.WriteLine("Произведение матриц невозможно выполнить, так-как число столбцов первой матрицы не равно числу строк второй матрицы)\n");
        return false;
    }
}

int[,] InitArray(int arrayStrings, int arrayColumns)
{
    int[,] tempArray = new int[arrayStrings, arrayColumns];
    Random rnd = new Random();
    for (int i = 0; i < tempArray.GetLength(0); i++)
    {
        for (int j = 0; j < tempArray.GetLength(1); j++)
        {
            tempArray[i, j] = rnd.Next(0, 10);
        }
    }

    return tempArray;
}

void PrintMultivariateArray(int[,] tempArray, int number)
{
    if (number <= 2)
        Console.WriteLine($"Матрица {number}: ");
    else
        Console.WriteLine($"В результате получим матрицу: ");

    for (int i = 0; i < tempArray.GetLength(0); i++)
    {
        for (int j = 0; j < tempArray.GetLength(1); j++)
        {
            Console.Write($"{tempArray[i, j]} ");
        }
        Console.WriteLine();
    }
}

int MatrixCount(int number)
{
    int result = new int();
    result = number + 1;
    return result;
}

int[,] MatrixMultiplication(int[,] tempArray1, int[,] tempArray2)
{
    int[,] result = new int[tempArray1.GetLength(0), tempArray2.GetLength(1)];
    for (int i = 0; i < tempArray1.GetLength(0); i++)
    {
        for (int j = 0; j < tempArray2.GetLength(1); j++)
        {
            for (int k = 0; k < tempArray1.GetLength(1); k++)
            {
                result[i, j] += tempArray1[i, k] * tempArray2[k, j];
            }
        }
    }

    return result;
}

(int, int, int, int) arrayParameters = GetValues();
Console.WriteLine();
int matrixNumber = 0;
int[,] matrix1 = InitArray(arrayStrings: arrayParameters.Item1, arrayColumns: arrayParameters.Item2);
matrixNumber = MatrixCount(number: matrixNumber);
PrintMultivariateArray(tempArray: matrix1, number: matrixNumber);
Console.WriteLine();
int[,] matrix2 = InitArray(arrayStrings: arrayParameters.Item3, arrayColumns: arrayParameters.Item4);
matrixNumber = MatrixCount(number: matrixNumber);
PrintMultivariateArray(tempArray: matrix2, number: matrixNumber);
Console.WriteLine();
int[,] matrix3 = MatrixMultiplication(tempArray1: matrix1, tempArray2: matrix2);
matrixNumber = MatrixCount(number: matrixNumber);
PrintMultivariateArray(tempArray: matrix3, number: matrixNumber);