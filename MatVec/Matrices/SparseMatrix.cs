using MatVec.Matrices.Drawers;
using MatVec.Matrices.Visitors;
using MatVec.Vectors;

namespace MatVec.Matrices
{
    public class SparseMatrix : AMatrix
    {
        public SparseMatrix(int rows, int columns) : base(rows, columns)
        {
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        protected override IVector CreateVector()
        {
            return new SparseVector(Rows);
        }
    }
}
