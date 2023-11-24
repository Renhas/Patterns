using CommandsLib.Memento;
using MatVec.Matrices.Imaginators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices
{
    public abstract class AMementableMatrix : IMatrix
    {
        #region Matrix
        public abstract int Rows { get; }
        public abstract int Columns { get; }
        public abstract double this[int row, int col] { get; set; }
        public abstract IMatrix Undecorate();
        public abstract void Draw(IMatrixImaginator imaginator);
        #endregion
        #region Mementable
        public AMementableMatrix()
        {
            MementableSystem.Instance.Registry(this);
        }

        public abstract IMemento CreateMemento();

        ~AMementableMatrix()
        {
            MementableSystem.Instance.Unregistry(this);
        }
        #endregion
    }
}
