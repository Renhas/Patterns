using MatVec.Matrices.Compositors;
using MatVec.Matrices.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices.Visitors
{
    public interface IVisitor
    {
        public int Row { get; }
        public int Column { get; }
        void VisitMatrix(Matrix matrix);
        void VisitSparseMatrix(SparseMatrix matrix);
        void SetIds(int row, int column);
        void SetElement(double value);
    }
}
