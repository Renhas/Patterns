using CommandsLib.Memento;
using System;

namespace MatVec.Matrices.Drawers
{
    public abstract class ADrawer : AMementableDrawer, IDrawer
    {
        public bool Border { get; set; }
        
        public ADrawer(bool border=true)
        {
            Border = border;
        }

        protected static string TrimDouble(double number, int cellSize) 
        {
            var element = number.ToString();
            if (element.Length < cellSize)
            {
                int count = cellSize - element.Length;
                element = element.Insert(0, new string(' ', count));
            }
            else if (element.Length > cellSize)
            {
                element = element.Remove(cellSize);
            }
            return element;
        }

        protected static int FindCellSize(IMatrix matrix)
        {
            MatrixStats stats = new MatrixStats(matrix);
            string strMax = stats.MaxValue.ToString().Split(',')[0];
            string strMin = stats.MinValue.ToString().Split(",")[0];

            return Math.Max(strMax.Length, strMin.Length) + 3;
        }

        public abstract void DrawElement(IMatrix matrix, int row, int column);
        public abstract void MakeCanvas(IMatrix matrix);
        public abstract void Clear();
        public abstract void Flush();
        public abstract void DrawBorder(IMatrix matrix);

        #region Mementable
        protected class MementoADrawer : IMemento 
        {
            private bool _state;
            private ADrawer _owner;
            public MementoADrawer(ADrawer owner) 
            {
                _owner = owner;
                _state = _owner.Border;
            }

            public void Restore()
            {
                _owner.Border = _state;
            }
        }
        public override IMemento CreateMemento()
        {
            return new MementoADrawer(this);
        }
        #endregion
    }
}
