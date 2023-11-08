using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatVec.Matrices.Drawers;
using MatVec.Matrices.Imaginators;
using MatVec.Matrices.Visitors;

namespace MatVec.Matrices.Compositors
{
    public class HCompositorMatrix : IMatrix
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

        public IMatrix? GetMatrix(int row, int column) 
        {
            FindMatrix(row, column);
            if (_currentId < 0) return null;
            return _matrices[_currentId];
        }

        public int[] GetIds(int row, int column) 
        {
            return new int[2] { row, FindMatrix(row, column) };
        }
        public void Add(IMatrix matrix)
        {
            _matrices.Add(matrix);
        }

        //public void Draw()
        //{
        //    MakeCanvas(Identity);
        //    DrawBorder(Identity);
        //    for (int i = 0; i < _matrices.Count; i++)
        //    {
        //        _currentId = -1;
        //        _index = i;
        //        IMatrix mtx = _matrices[i];
        //        ConfigureMatrix(mtx);
        //        mtx.Identity = Identity;
        //        mtx.Draw();
        //        mtx.Identity = mtx;
        //    }
        //    _index = -1;
        //    Flush();
        //}

        //public void DrawBorder(IMatrix matrix)
        //{
        //    if (_index == -1)
        //    {
        //        Drawer.DrawBorder(Identity);
        //    }
        //}

        //public void MakeCanvas(IMatrix matrix)
        //{
        //    if (_index == -1)
        //    {
        //        Drawer.MakeCanvas(Identity);
        //    }
        //}

        //public void DrawElement(IMatrix matrix, int row, int column)
        //{
        //    _ = matrix[row, column];
        //    if (_currentId != _index) return;
        //    Drawer.DrawElement(Identity, row, column);
        //    _currentId = -1;
        //}

        //public void Flush()
        //{
        //    if (_index == -1)
        //    {
        //        Drawer.Flush();
        //    }
        //}

        //public void Clear()
        //{
        //    Drawer.Clear();
        //}

        public IMatrix GetElement()
        {
            return this;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Draw(IMatrixImaginator imaginator)
        {
            imaginator.DrawMatrix(this);
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
