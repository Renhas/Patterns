using MatVec.Matrices.Drawers;
using MatVec.Matrices.Visitors;
using MatVec.Vectors;

namespace MatVec.Matrices
{
    public class Matrix : AMatrix
    {
        public Matrix(int rows, int columns) : base(rows, columns)
        {

        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitMatrix(this);
        }

        protected override IVector CreateVector()
        {
            return new Vector(Rows);
        }
    }
}
