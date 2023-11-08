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
        void Visit(Matrix matrix);
        void Visit(SparseMatrix matrix);
        void Visit(AMatrixDecorator matrix);
        void Visit(HCompositorMatrix matrix);
        void SetInfo(int row, int column, double element);
    }
}
