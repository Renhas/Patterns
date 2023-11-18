﻿using MatVec.Matrices.Drawers;
using MatVec.Matrices.Imaginators.Strategies;
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

        private void DrawElements(IMatrix matrix, IElementDrawStrategy strategy)
        {
            for (int r = 0; r < matrix.Rows; r++)
                for (int c = 0; c < matrix.Columns; c++)
                {
                    strategy.Draw(matrix, r, c, Drawer);
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
            DrawElements(matrix, StrategyFactory.Instance.CreateStrategy(matrix));
            Flush();
        }
    }
}
