using System;

namespace MatVec.Matrices
{
    public static class MatrixInitializer
    {
        public static void FillMatrix(IMatrix matrix, int notNullNumber, double maxValue)
        {
            int totalCount = matrix.Rows * matrix.Columns;
            if (notNullNumber > totalCount || notNullNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(notNullNumber));
            }
            Random rand = new Random();
            int range = (int)Math.Floor(maxValue);
            for (int col = 0; col < matrix.Columns; col++)
                for (int row = 0; row < matrix.Rows; row++)
                {
                    if (col * matrix.Rows + row >= notNullNumber) return;
                    var new_number = maxValue - rand.NextDouble() - rand.Next(0, 2 * range);
                    matrix[row, col] = new_number;
                }
        }
    }
}
