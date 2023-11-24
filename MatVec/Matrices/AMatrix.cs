using System;
using CommandsLib.Memento;
using MatVec.Elements;
using MatVec.Matrices.Drawers;
using MatVec.Matrices.Imaginators;
using MatVec.Vectors;

namespace MatVec.Matrices
{
    public abstract class AMatrix : AMementableMatrix
    {
        private IVector[] _vectors;
        public override int Rows { get; }
        public override int Columns { get; }

        public AMatrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _vectors = new IVector[Columns];
            VectorsInit();
        }

        private void VectorsInit()
        {
            for (int i = 0; i < Columns; i++)
            {
                IVector newVector = CreateVector();
                CheckVector(newVector);
                _vectors[i] = newVector;
            }
        }

        private void CheckVector(IVector vector)
        {
            if (vector.Dimension != Rows)
                throw new ArgumentException($"Vector dimension must be {Rows}");
        }
        protected abstract IVector CreateVector();

        public override IMatrix Undecorate()
        {
            return this;
        }
        public override IElement GetElement(int row, int col)
        {
            return _vectors[col].GetElement(row);
        }
        public override void Draw(IMatrixImaginator imaginator) 
        {
            imaginator.DrawMatrix(this);
        }

        public override double this[int row, int col]
        {
            get
            {
                return _vectors[col][row];
            }
            set
            {
                _vectors[col][row] = value;
            }
        }

        #region Memento
        class MementoAMatrix : IMemento
        {
            private IVector[] _state;
            private AMatrix _owner;
            public MementoAMatrix(AMatrix owner)
            {
                _owner = owner;
                _state = new IVector[_owner._vectors.Length];
                _owner._vectors.CopyTo(_state, 0);
            }

            public void Restore()
            {
                _owner._vectors = new IVector[_state.Length];
                _state.CopyTo(_owner._vectors, 0);
            }
        }
        public override IMemento CreateMemento()
        {
            return new MementoAMatrix(this);
        }
        #endregion
    }
}
