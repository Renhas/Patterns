using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandsLib.Memento;
using MatVec.Elements;
using MatVec.Matrices.Drawers;
using MatVec.Matrices.Imaginators;

namespace MatVec.Matrices.Compositors
{
    public class HCompositorMatrix : AMementableMatrix, IMatrixCompositor
    {
        #region Matrix
        public override int Rows
        {
            get
            {
                return _matrices.Max(x => x.Rows);
            }
        }

        public override int Columns
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

        public override IMatrix Undecorate()
        {
            return this;
        }

        public override void Draw(IMatrixImaginator imaginator)
        {
            imaginator.DrawMatrix(this);
        }

        public override IElement GetElement(int row, int col)
        {
            var trueCol = FindMatrix(row, col);
            if (_currentId == -1)
            {
                return new ExclusiveElement();
            }
            return _matrices[_currentId].GetElement(row, trueCol);
        }
        public override double this[int row, int col]
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
        #endregion
        #region Compositor
        private List<IMatrix> _matrices;
        private int _currentId = -1;
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
        #endregion
        #region Mementable
        class MementoHCompositorMatrix : IMemento 
        {
            private List<IMatrix> _state;
            private HCompositorMatrix _owner;
            public MementoHCompositorMatrix(HCompositorMatrix owner) 
            {
                _owner = owner;
                _state = new List<IMatrix>(_owner._matrices);
            }
            public void Restore()
            {
                _owner._matrices = new List<IMatrix>(_state);
            }
        }
        public override IMemento CreateMemento()
        {
            return new MementoHCompositorMatrix(this);
        }
        #endregion
    }
}
