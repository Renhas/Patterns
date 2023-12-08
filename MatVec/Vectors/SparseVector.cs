using CommandsLib.Memento;
using MatVec.Elements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatVec.Vectors
{
    public class SparseVector : AMementableVector
    {
        #region Vector
        private Dictionary<int, IElement> values;
        private readonly IElement _default;
        public override int Dimension { get; }
        public SparseVector(int dimension, IElement defaultElement)
        {
            if (dimension <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dimension), "Dimension must be positive");
            }
            _default = defaultElement;
            Dimension = dimension;
            values = new Dictionary<int, IElement>();
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
                    return values[index].Value;
                }
                return _default.Value;
            }
            set
            {
                IndexCheck(index);
                if (value == _default.Value) return;
                if (values.ContainsKey(index))
                {
                    values[index].Value = value;
                }
                else
                {
                    var element = _default.Copy();
                    element.Value = value;
                    values.Add(index, element);
                }
            }
        }
        public override IElement GetElement(int index)
        {
            if (values.ContainsKey(index))
            {
                return values[index];
            }
            return _default.Copy();
        }
        #endregion
        #region Memento
        class MementoSparseVector : IMemento 
        {
            private Dictionary<int, IElement> _values;
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
