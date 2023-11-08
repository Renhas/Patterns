using MatVec.Matrices.Compositors;
using MatVec.Matrices.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices.Visitors
{
    internal class VisitorProvider : IVisitor
    {
        public bool Provide { get; private set; }
        private double _element;
        private int _row;
        private int _column;
        public VisitorProvider() 
        {
            Provide = false;
            _row = -1;
            _column = -1;
            _element = double.NaN;
        }

        private bool CheckInfo(IMatrix matrix) 
        {
            if (_row >= 0 && _row < matrix.Rows ||
                _column >= 0 && _column < matrix.Columns ||
                _element == double.NaN) 
            {
                return true;
            }
            return false;
        }
        
        public void SetInfo(int row, int column, double element)
        {
            _row = row;
            _column = column;
            _element = element;
        }

        public void Visit(Matrix matrix)
        {
            if (!CheckInfo(matrix)) 
            {
                Provide = false;
                return;
            }
            Provide = true;
        }

        public void Visit(SparseMatrix matrix)
        {
            if (!CheckInfo(matrix))
            {
                Provide = false;
                return;
            }
            Provide = _element != 0;
        }

        public void Visit(AMatrixDecorator matrix) 
        {
            if (!CheckInfo(matrix)) 
            {
                Provide = false;
                return;
            }
            var ids = matrix.GetIds(_row, _column);
            _row = ids[0];
            _column = ids[1];
            matrix.GetMatrix().Accept(this);
        }

        public void Visit(HCompositorMatrix matrix) 
        {
            if (!CheckInfo(matrix))
            {
                Provide = false;
                return;
            }
            var ids = matrix.GetIds(_row, _column);
            var inner = matrix.GetMatrix(_row, _column);
            if (ids[1] < 0 || inner == null) 
            {
                Provide = false;
                return;
            }
            _row = ids[0];
            _column = ids[1];
            inner.Accept(this);
        }
    }
}
