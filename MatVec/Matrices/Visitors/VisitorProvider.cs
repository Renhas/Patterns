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
        public double Element { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }
        public VisitorProvider(double value, int row, int column) 
        {
            Provide = false;
            Row = row;
            Column = column;
            Element = value;
        }
        public void SetIds(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public void SetElement(double value)
        {
            Element = value;
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
                Provide = false;
                return;
            }
            Provide = true;
        }

        public void VisitSparseMatrix(SparseMatrix matrix)
        {
            if (!CheckInfo(matrix))
            {
                Provide = false;
                return;
            }
            Provide = Element != 0;
        }
    }
}
