using MatVec.Elements;
using MatVec.Matrices.Drawers;
using MatVec.Vectors;

namespace MatVec.Matrices
{
    public class SparseMatrix : AMatrix
    {
        public SparseMatrix(int rows, int columns) : base(rows, columns)
        {
        }

        protected override IVector CreateVector()
        {
            return new SparseVector(Rows, new ExclusiveElement());
        }
    }
}
