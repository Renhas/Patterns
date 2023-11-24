using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandsLib.Memento;
using MatVec.Elements;
using MatVec.Matrices.Drawers;
using MatVec.Matrices.Imaginators;

namespace MatVec.Matrices.Decorators
{
    public abstract class AMatrixDecorator : AMementableMatrix
    {
        protected IMatrix Matrix { get; private set; }

        public AMatrixDecorator(IMatrix matrix)
        {
            Matrix = matrix;
        }
        public abstract int[] GetIds(int row, int col);
        public IMatrix GetMatrix() 
        {
            return Matrix;
        }

        public override IMatrix Undecorate() 
        {
            return Matrix.Undecorate();
        }

        public override IElement GetElement(int row, int col)
        {
            var ids = GetIds(row, col);
            return Matrix.GetElement(ids[0], ids[1]);
        }

        public override void Draw(IMatrixImaginator imaginator) 
        {
            imaginator.DrawMatrix(this);
        }

        #region Memento
        protected class MementoAMatrixDecorator : IMemento 
        {
            private IMatrix _state;
            protected AMatrixDecorator _owner { get; private set; }
            public MementoAMatrixDecorator(AMatrixDecorator owner) 
            {
                _owner = owner;
                _state = _owner.Matrix;
            }

            public virtual void Restore()
            {
                _owner.Matrix = _state;
            }
        }
        #endregion
    }
}
