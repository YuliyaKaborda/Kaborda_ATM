using System;

namespace Matrix
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[,] array5x5 = new int[5, 5] { { 0, 2, 3, 7, 9 }, { 5, 6, 8, 8, 0 }, { 9, -19, 11, 12, 1 }, { 13, 4, 15, 16, 7 }, { 3, 6, 7, 8, 9 } };

            int[,] array4x4 = new int[4, 4] { { 0, 2, 3, 7 }, { 5, 6, 8, 8 }, { 9, -19, 11, 12 }, { 13, 4, 15, 16 } };

            int[,] array2x2 = new int[2, 2] { { 1, 2 }, { 3, 4 } };

            int[,] array3x3 = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            

            var det = GetDeterminate(array4x4);
			Console.WriteLine(det);
			Console.ReadKey();
        }

        private static double GetDeterminate(int[,] matrix)
        {
            double result = 0;

            var rows = matrix.GetLength(0);

            var columns = matrix.GetLength(1);

            for (int j = 0; j < columns; j++)
            {
                var A = matrix[0, j];

                int[,] minor = GetMinor(matrix, j);

                if (minor.GetLength(0) == 2)
                {
                    result += A * Math.Pow(-1, 0 + j) *  GetDeterminateBase(minor);
                }
                else
                {
                    result += A * Math.Pow(-1, 0 + j) *  GetDeterminate(minor);
                }
            }

            return result;
        }

        private static int[,] GetMinor(int[,] matrix, int jParent)
        {
            var rows = matrix.GetLength(0);

            var columns = matrix.GetLength(1);

            var minor = new int[rows - 1, columns - 1];

            var iminor = 0;

            for (int i = 0; i < rows; i++)
            {
                var jminor = 0;

                if (i == 0)
                    continue;
                for (int j = 0; j < columns; j++)
                {
                    if (j == jParent)
                        continue;

                    minor[iminor, jminor] = matrix[i, j];

                    jminor++;
                }
                iminor++;
            }

            return minor;
        }

        private static double GetDeterminateBase(int[,] baseMatrix)
        {
           
            var result = baseMatrix[0, 0] * baseMatrix[1, 1] - baseMatrix[0, 1] * baseMatrix[1, 0];

            return result;
        }
    }
}