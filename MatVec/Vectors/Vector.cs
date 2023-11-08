namespace MatVec.Vectors
{
    public class Vector : IVector
    {
        private double[] values;
        public int Dimension { get; }

        public Vector(int dimension)
        {
            Dimension = dimension;
            values = new double[Dimension];
            ValuesInit();
        }

        private void ValuesInit()
        {
            for (int i = 0; i < Dimension; i++)
            {
                values[i] = 0.0;
            }
        }

        public double this[int index]
        {
            get
            {
                return values[index];
            }
            set
            {
                values[index] = value;
            }
        }


    }
}
