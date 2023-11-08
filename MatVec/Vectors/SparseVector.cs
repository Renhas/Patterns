using System;
using System.Collections.Generic;

namespace MatVec.Vectors
{
    public class SparseVector : IVector
    {
        private Dictionary<int, double> values;
        public int Dimension { get; }
        public SparseVector(int dimension)
        {
            if (dimension <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dimension), "Dimension must be positive");
            }
            Dimension = dimension;
            values = new Dictionary<int, double>();
        }

        private void IndexCheck(int index)
        {
            if (index >= Dimension || index < 0)
                throw new IndexOutOfRangeException(nameof(index));
        }

        public double this[int index]
        {
            get
            {
                IndexCheck(index);
                if (values.ContainsKey(index))
                {
                    return values[index];
                }
                return 0.0;
            }
            set
            {
                IndexCheck(index);
                if (value == 0.0) return;
                if (values.ContainsKey(index))
                {
                    values[index] = value;
                }
                else
                {
                    values.Add(index, value);
                }
            }
        }
    }
}
