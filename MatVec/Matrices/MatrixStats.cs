namespace MatVec.Matrices
{
    public class MatrixStats
    {
        public double SumValue { get; private set; }
        public double AvgValue { get; private set; }
        public double MaxValue { get; private set; }
        public double MinValue { get; private set; }
        public int NotNullCount { get; private set; }
        

        public MatrixStats(IMatrix matrix)
        {
            SumValue = AvgValue = 0;
            MaxValue = double.MinValue; 
            MinValue = double.MaxValue;
            NotNullCount = 0;
            CalculateStats(matrix);
        }

        private void Traverse(IMatrix matrix)
        {
            for (int col = 0; col < matrix.Columns; col++)
                for (int row = 0; row < matrix.Rows; row++)
                {
                    var element = matrix[row, col];
                    Sum(element);
                    Max(element);
                    Min(element);
                    NotNull(element);
                }
        }

        private void CalculateStats(IMatrix matrix) 
        {
            Traverse(matrix);
            AvgValue = SumValue / (matrix.Rows * matrix.Columns);
        }

        private void Sum(double value) 
        {
            SumValue += value;
        }

        private void Max(double value) 
        {
            if (value > MaxValue) 
            {
                MaxValue = value;
            }
        }

        private void Min(double value)
        {
            if (value < MinValue)
            {
                MinValue = value;
            }
        }

        private void NotNull(double value) 
        {
            if (value != 0.0) 
            {
                NotNullCount++;
            }
        }


    }
}
