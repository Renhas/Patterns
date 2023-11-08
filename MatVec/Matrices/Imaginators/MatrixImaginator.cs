using MatVec.Matrices.Drawers;
using MatVec.Matrices.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices.Imaginators
{
    public class MatrixImaginator : IMatrixImaginator
    {
        public IDrawer Drawer { private get; set; }

        public MatrixImaginator(IDrawer drawer) 
        {
            Drawer = drawer;
        }

        private void DrawElements(IMatrix matrix)
        {
            VisitorProvider visitor = new VisitorProvider();
            for (int r = 0; r < matrix.Rows; r++)
                for (int c = 0; c < matrix.Columns; c++)
                {
                    visitor.SetInfo(r, c, matrix[r, c]);
                    matrix.Accept(visitor);
                    if (visitor.Provide)
                    {
                        DrawElement(matrix, r, c);
                    }
                }
        }

        protected void DrawBorder(IMatrix matrix)
        {
            Drawer.DrawBorder(matrix);
        }

        protected void DrawElement(IMatrix matrix, int row, int column)
        {
            Drawer.DrawElement(matrix, row, column);
        }

        protected void MakeCanvas(IMatrix matrix)
        {
            Drawer.MakeCanvas(matrix);
        }

        protected void Flush()
        {
            Drawer.Flush();
        }

        public void DrawMatrix(IMatrix matrix)
        {
            MakeCanvas(matrix);
            DrawBorder(matrix);
            DrawElements(matrix);
            Flush();
        }
    }
}
