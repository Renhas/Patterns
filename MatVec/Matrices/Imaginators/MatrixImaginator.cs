using CommandsLib.Memento;
using MatVec.Matrices.Drawers;
using MatVec.Matrices.Imaginators.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices.Imaginators
{
    public class MatrixImaginator : AMementableImaginator, IMatrixImaginator
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
        #region Mementable
        class MementoMatrixImaginator : IMemento 
        {
            private IDrawer _state;
            private MatrixImaginator _owner;
            public MementoMatrixImaginator(MatrixImaginator owner) 
            {
                _owner = owner;
                _state = _owner.Drawer;
            }

            public void Restore()
            {
                _owner.Drawer = _state;
            }
        }
        public override IMemento CreateMemento()
        {
            return new MementoMatrixImaginator(this);
        }
        #endregion
    }
}
