using MatVec.Matrices.Drawers;
using MatVec.Matrices.Visitors;
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

        public override int Rows { get { return _matrix.Columns; } }

        public override int Columns { get { return _matrix.Rows; } }

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
                return _matrix[col, row];
            } set 
            {
                _matrix[col, row] = value;
            }
        }
    }
}
