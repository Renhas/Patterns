using MatVec.Matrices.Compositors;
using MatVec.Matrices.Decorators;
using MatVec.Matrices.Drawers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices.Visitors
{
    internal class VisitorDrawer : IVisitor
    {
        private IMatrix _origin;
        private IDrawer _drawer;
        private int[] _trueIds;
        public int Row { get; private set; }
        public int Column { get; private set; }
        public VisitorDrawer(IMatrix matrix, int row, int column, IDrawer drawer) 
        {
            _origin = matrix;
            _drawer = drawer;
            _trueIds = new int[] { row, column };
            Row = row;
            Column = column;
        }
        public void SetIds(int row, int column)
        {
            Row = row;
            Column = column;
        }

        private bool CheckInfo(IMatrix matrix) 
        {
            if (Row >= 0 && Row < matrix.Rows ||
                Column >= 0 && Column < matrix.Columns) 
            {
                return true;
            }
            return false;
        }

        public void VisitMatrix(Matrix matrix)
        {
            if (!CheckInfo(matrix)) 
            {
                return;
            }
            _drawer.DrawElement(_origin, _trueIds[0], _trueIds[1]);
        }

        public void VisitSparseMatrix(SparseMatrix matrix)
        {
            if (!CheckInfo(matrix) || _origin[_trueIds[0], _trueIds[1]] == 0)
            {
                return;
            }
            _drawer.DrawElement(_origin, _trueIds[0], _trueIds[1]);
        }
    }
}
