using MatVec.Matrices.Drawers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices.Visitors
{
    internal class VisitorDrawer : IVisitor
    {
        private IDrawer _drawer;
        private delegate bool Provide(int r, int c);
        public IndexMask Mask { get; }

        public VisitorDrawer(IDrawer drawer, IMatrix origin) 
        {
            _drawer = drawer;
            Mask = new IndexMask(origin);
        }

        private void DrawElements(IMatrix matrix, Provide provider) 
        {
            for (int r = 0; r < matrix.Rows; r++)
                for (int c = 0; c < matrix.Columns; c++)
                {
                    var ids = Mask.GetIds(r, c);
                    if (ids == null || !provider(r, c)) continue;
                    _drawer.DrawElement(Mask.Origin, ids[0], ids[1]);
                }
        }

        public void VisitMatrix(Matrix matrix)
        {
            DrawElements(matrix, (r, c) => { return true; });
        }

        public void VisitSparseMatrix(SparseMatrix matrix)
        {
            DrawElements(matrix, (r, c) =>
            {
                return Mask[r, c] != 0;
            });
        }
    }
}
