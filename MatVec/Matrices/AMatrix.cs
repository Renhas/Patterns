using System;
using MatVec.Matrices.Drawers;
using MatVec.Matrices.Imaginators;
using MatVec.Matrices.Visitors;
using MatVec.Vectors;

namespace MatVec.Matrices
{
    public abstract class AMatrix : IMatrix
    {
        private IVector[] _vectors;
        public int Rows { get; }
        public int Columns { get; }

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

        public IMatrix GetElement()
        {
            return this;
        }


        public void Draw(IMatrixImaginator imaginator) 
        {
            imaginator.DrawMatrix(this);
        }

        public abstract void Accept(IVisitor visitor);

        public double this[int row, int col]
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


    }
}
