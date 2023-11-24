using CommandsLib.Memento;

namespace MatVec.Vectors
{
    public class Vector : AMementableVector
    {
        private double[] values;
        public override int Dimension { get; }

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

        public override double this[int index]
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

        #region Memento
        class MementoVector : IMemento 
        {
            private double[] _values;
            private Vector _owner;
            public MementoVector(Vector owner)
            {
                _values = new double[owner.values.Length];
                owner.values.CopyTo(_values, 0);
                _owner = owner;
            }

            public void Restore()
            {
                _values.CopyTo(_owner.values, 0);
            }
        }

        public override IMemento CreateMemento()
        {
            return new MementoVector(this);
        }
        #endregion
    }
}
