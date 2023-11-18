using MatVec.Matrices.Drawers;
using MatVec.Vectors;

namespace MatVec.Matrices
{
    public class Matrix : AMatrix
    {
        public Matrix(int rows, int columns) : base(rows, columns)
        {

        }

        protected override IVector CreateVector()
        {
            return new Vector(Rows);
        }
    }
}
