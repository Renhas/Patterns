using CommandsLib.Memento;
using MatVec.Matrices.Drawers;
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

        public override int Rows { get { return Matrix.Rows; } }

        public override int Columns { get { return Matrix.Columns; } }

        public RenumberDecorator(IMatrix matrix) : base(matrix)
        {
            _rowsId = new int[Matrix.Rows];
            _colsId = new int[Matrix.Columns];
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
                return Matrix[ids[0], ids[1]];
            }
            set 
            {
                var ids = GetIds(row, col);
                Matrix[_rowsId[row], _colsId[col]] = value;
            }
        }

        #region Memento
        class MementoRenumberDecorator : MementoAMatrixDecorator
        {
            private int[] _rows;
            private int[] _cols;
            public MementoRenumberDecorator(RenumberDecorator owner) : base(owner)
            {
                _rows = new int[owner.Rows];
                _cols = new int[owner.Columns];
                owner._rowsId.CopyTo(_rows, 0);
                owner._colsId.CopyTo(_cols, 0);
            }
            public override void Restore()
            {
                base.Restore();
                var temp = (RenumberDecorator)_owner;
                temp._rowsId = new int[_rows.Length];
                temp._colsId = new int[_cols.Length];
                _rows.CopyTo(temp._rowsId, 0);
                _cols.CopyTo(temp._colsId, 0);
            }
        }
        public override IMemento CreateMemento()
        {
            return new MementoRenumberDecorator(this);
        }
        #endregion
    }
}
