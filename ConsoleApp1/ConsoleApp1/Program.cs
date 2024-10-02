using System;

namespace MatrixOperations
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Console.Write("Введiть кiлькiсть рядкiв матрицi: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Введiть кiлькiсть стовпцiв матрицi: ");
            int cols = int.Parse(Console.ReadLine());

           
            int[,] matrix = new int[rows, cols];

           
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(-100, 101);
                }
            }

          
            Console.WriteLine("Матриця:");
            PrintMatrix(matrix);

          
            Console.WriteLine($"Добуток елементiв матрицi: {CalculateProduct(matrix)}");
            Console.WriteLine($"Сума елементiв побiчної дiагоналi: {CalculateSecondaryDiagonalSum(matrix)}");
            int[] rowProductSums = CalculateRowProductSums(matrix);
            Console.WriteLine($"Суми добуткiв елементiв кожного рядка: {string.Join(", ", rowProductSums)}");
            Console.WriteLine($"Добуток сум елементiв кожного рядка: {CalculateProductOfRowProductSums(rowProductSums)}");
        }

       
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }
        }

      
        static int CalculateProduct(int[,] matrix)
        {
            int product = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    product *= matrix[i, j];
                }
            }
            return product;
        }

    
        static int CalculateSecondaryDiagonalSum(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, matrix.GetLength(1) - i - 1];
            }
            return sum;
        }


        static int[] CalculateRowProductSums(int[,] matrix)
        {
            int[] sums = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int product = 1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    product *= matrix[i, j];
                }
                sums[i] = product;
            }
            return sums;
        }

       
        static int CalculateProductOfRowProductSums(int[] sums)
        {
            int product = 1;
            foreach (int sum in sums)
            {
                product *= sum;
            }
            return product;
        }
    }
}
