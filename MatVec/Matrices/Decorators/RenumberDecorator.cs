using MatVec.Matrices.Drawers;
using MatVec.Matrices.Visitors;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MatVec.Matrices.Decorators
{
    public class RenumberDecorator : AMatrixDecorator
    {
        private int[] _rowsId;
        private int[] _colsId;

        public override int Rows { get { return _matrix.Rows; } }

        public override int Columns { get { return _matrix.Columns; } }

        public RenumberDecorator(IMatrix matrix) : base(matrix)
        {
            _rowsId = new int[_matrix.Rows];
            _colsId = new int[_matrix.Columns];
            InitArrays(_rowsId);
            InitArrays(_colsId);
        }

        private void InitArrays(int[] array) 
        {
            for (int i = 0; i < array.Length; i++) 
            {
                array[i] = i;
            }
        }

        public void SwapRows(int first, int second) 
        {
            (_rowsId[first], _rowsId[second]) = (_rowsId[second], _rowsId[first]);
        }

        public void SwapColumns(int first, int second)
        {
            (_colsId[first], _colsId[second]) = (_colsId[second], _colsId[first]);
        }

        public override int[] GetIds(int row, int col)
        {
            return new int[2] { _rowsId[row], _colsId[col] };
        }

        public override double this[int row, int col]
        {
            get 
            {
                var ids = GetIds(row, col);
                return _matrix[ids[0], ids[1]];
            }
            set 
            {
                var ids = GetIds(row, col);
                _matrix[_rowsId[row], _colsId[col]] = value;
            }
        }
    }
}
