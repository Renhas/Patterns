using MatVec.Matrices.Drawers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices.Imaginators.Strategies
{
    public class SparseStrategy : DefaultStrategy
    {
        public override void Draw(IMatrix matrix, int row, int col, IDrawer drawer)
        {
            if (matrix[row, col] == 0) return;
            base.Draw(matrix, row, col, drawer);
        }
    }
}
