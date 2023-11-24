using CommandsLib.Memento;
using MatVec.Elements;

namespace MatVec.Vectors
{
    public class Vector : AMementableVector
    {
        private IElement[] elements;
        public override int Dimension { get; }

        public Vector(int dimension, IElement defaultElement)
        {
            Dimension = dimension;
            elements = new IElement[Dimension];
            ValuesInit(defaultElement);
        }

        private void ValuesInit(IElement defaultElement)
        {
            for (int i = 0; i < Dimension; i++)
            {
                elements[i] = defaultElement.Copy();
            }
        }

        public override double this[int index]
        {
            get
            {
                return elements[index].Value;
            }
            set
            {
                elements[index].Value = value;
            }
        }

        public override IElement GetElement(int index)
        {
            return elements[index].Copy();
        }

        #region Memento
        class MementoVector : IMemento 
        {
            private IElement[] _values;
            private Vector _owner;
            public MementoVector(Vector owner)
            {
                _values = new IElement[owner.elements.Length];
                owner.elements.CopyTo(_values, 0);
                _owner = owner;
            }

            public void Restore()
            {
                _values.CopyTo(_owner.elements, 0);
            }
        }

        public override IMemento CreateMemento()
        {
            return new MementoVector(this);
        }
        #endregion
    }
}
