using MatVec.Matrices.Compositors;
using MatVec.Matrices.Decorators;
using MatVec.Matrices.Drawers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices.Imaginators.Strategies
{
    public class CompositorStrategy : DefaultStrategy
    {
        private IElementDrawStrategy?[,] mask;
        public CompositorStrategy(IMatrixCompositor compositor, IMatrix origin) 
        {
            mask = new IElementDrawStrategy[origin.Rows, origin.Columns];
            CreateMask(compositor, origin);
        }

        private void CreateMask(IMatrixCompositor compositor, IMatrix origin) 
        {
            Dictionary<IMatrix, IElementDrawStrategy> dict = new Dictionary<IMatrix, IElementDrawStrategy>();
            for (int r = 0; r < origin.Rows; r++)
                for (int c = 0; c < origin.Columns; c++) 
                {
                    var ids = GetTrueIds(origin, r, c);
                    var mtx = compositor.Get(ids[0], ids[1]);
                    if (mtx == null) 
                    {
                        mask[r, c] = null;
                        continue;
                    }
                    if (!dict.ContainsKey(mtx)) 
                    {
                        dict.Add(mtx, StrategyFactory.Instance.CreateStrategy(mtx));
                    }
                    ids = compositor.GetIds(ids[0], ids[1]);
                    var strategy = dict[mtx];
                    if (strategy is CompositorStrategy compositorStrategy) 
                    {
                        strategy = compositorStrategy.mask[ids[0], ids[1]];
                    }
                    mask[r, c] = strategy;
                }
        }

        private int[] GetTrueIds(IMatrix matrix, int row, int column) 
        {
            var ids = new int[] { row, column };
            while (matrix is AMatrixDecorator decorator) 
            {
                ids = decorator.GetIds(ids[0], ids[1]);
                matrix = decorator.GetMatrix();
            }
            return ids;
        }

        public override void Draw(IMatrix matrix, int row, int col, IDrawer drawer)
        {
            mask[row, col]?.Draw(matrix, row, col, drawer);
        }
    }
}
