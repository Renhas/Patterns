using CommandsLib.Memento;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatVec.Vectors
{
    public class SparseVector : AMementableVector
    {
        #region Vector
        private Dictionary<int, double> values;
        public override int Dimension { get; }
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

        public override double this[int index]
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
        #endregion
        #region Memento
        class MementoSparseVector : IMemento 
        {
            private Dictionary<int, double> _values;
            private SparseVector _owner;
            public MementoSparseVector(SparseVector owner)
            {

                _values = owner.values.ToDictionary(entry => entry.Key, entry => entry.Value);
                _owner = owner;
            }

            public void Restore()
            {
                _owner.values = _values.ToDictionary(entry => entry.Key, entry => entry.Value);
            }
        }
        public override IMemento CreateMemento()
        {
            return new MementoSparseVector(this);
        }
        #endregion
    }
}
