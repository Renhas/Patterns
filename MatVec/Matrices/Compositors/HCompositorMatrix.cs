using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatVec.Matrices.Drawers;
using MatVec.Matrices.Imaginators;

namespace MatVec.Matrices.Compositors
{
    public class HCompositorMatrix : IMatrixCompositor
    {
        private List<IMatrix> _matrices;
        private int _currentId = -1;

        public int Rows
        {
            get
            {
                return _matrices.Max(x => x.Rows);
            }
        }

        public int Columns
        {
            get
            {
                return _matrices.Sum(x => x.Columns);
            }
        }

        public HCompositorMatrix()
        {
            _matrices = new List<IMatrix>();
        }

        private int FindMatrix(int row, int col)
        {
            try
            {
                IndexCheck(row, col);
            }
            catch 
            {
                _currentId = -1;
                return -1; 
            }
            _currentId = 0;
            foreach (var mtx in _matrices)
            {
                if (col < mtx.Columns)
                {
                    break;
                }
                _currentId++;
                col -= mtx.Columns;
            }
            if (row >= _matrices[_currentId].Rows)
            {
                _currentId = -1;
            }
            return col;
        }

        private void IndexCheck(int row, int col)
        {
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException(nameof(row));
            if (col < 0 || col >= Columns)
                throw new ArgumentOutOfRangeException(nameof(col));
        }

        public int[] GetIds(int row, int column) 
        {
            return new int[2] { row, FindMatrix(row, column) };
        }

        public IMatrix Undecorate()
        {
            return this;
        }

        public void Draw(IMatrixImaginator imaginator)
        {
            imaginator.DrawMatrix(this);
        }

        public void Add(IMatrix matrix)
        {
            _matrices.Add(matrix);
        }

        public void Remove(IMatrix matrix)
        {
            _matrices.Remove(matrix);
        }

        public IMatrix Get(int id)
        {
            return _matrices[id];
        }

        public IMatrix Get(int row, int col)
        {
            IndexCheck(row, col);
            FindMatrix(row, col);
            if (_currentId < 0) return null;
            return _matrices[_currentId];
        }

        public double this[int row, int col]
        {
            get
            {
                IndexCheck(row, col);
                col = FindMatrix(row, col);
                if (_currentId == -1)
                {
                    return 0;
                }
                IMatrix temp = _matrices[_currentId];
                return temp[row, col];

            }
            set
            {
                IndexCheck(row, col);
                col = FindMatrix(row, col);
                if (_currentId == -1)
                {
                    return;
                }
                IMatrix temp = _matrices[_currentId];
                temp[row, col] = value;
            }
        }
    }
}
