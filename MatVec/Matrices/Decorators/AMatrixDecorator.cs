using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatVec.Matrices.Drawers;
using MatVec.Matrices.Imaginators;

namespace MatVec.Matrices.Decorators
{
    public abstract class AMatrixDecorator : IMatrix
    {
        protected IMatrix _matrix;

        public abstract int Rows { get; }
        public abstract int Columns { get; }

        public AMatrixDecorator(IMatrix matrix)
        {
            _matrix = matrix;
        }
        public abstract int[] GetIds(int row, int col);
        public IMatrix GetMatrix() 
        {
            return _matrix;
        }

        public IMatrix Undecorate() 
        {
            return _matrix.Undecorate();
        }

        public virtual void Draw(IMatrixImaginator imaginator) 
        {
            imaginator.DrawMatrix(this);
        }

        public abstract double this[int row, int col] { get; set; }
    }
}
