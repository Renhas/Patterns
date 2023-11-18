using MatVec.Matrices.Drawers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices.Imaginators.Strategies
{
    public class DefaultStrategy : IElementDrawStrategy
    {

        public virtual void Draw(IMatrix matrix, int row, int col, IDrawer drawer)
        {
            drawer.DrawElement(matrix, row, col);
        }
    }
}
