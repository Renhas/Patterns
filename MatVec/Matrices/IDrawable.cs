using MatVec.Matrices.Drawers;
using MatVec.Matrices.Imaginators;

namespace MatVec.Matrices
{
    public interface IDrawable
    {
        public void Draw(IMatrixImaginator imaginator);
    }
}
