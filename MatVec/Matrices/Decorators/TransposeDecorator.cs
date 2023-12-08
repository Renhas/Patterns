using CommandsLib.Memento;
using MatVec.Matrices.Drawers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices.Decorators
{
    public class TransposeDecorator : AMatrixDecorator
    {

        public override int Rows { get { return Matrix.Columns; } }

        public override int Columns { get { return Matrix.Rows; } }

        public TransposeDecorator(IMatrix matrix) : base(matrix)
        {
        }

        public override int[] GetIds(int row, int col) 
        {
            return new int[2] { col, row };
        }

        public override double this[int row, int col] 
        {
            get 
            {
                return Matrix[col, row];
            } set 
            {
                Matrix[col, row] = value;
            }
        }

        #region Memento
        public override IMemento CreateMemento()
        {
            return new MementoAMatrixDecorator(this);
        }
        #endregion
    }
}
