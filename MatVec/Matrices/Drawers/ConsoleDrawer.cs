using System;
using System.Collections.Generic;

namespace MatVec.Matrices.Drawers
{
    public class ConsoleDrawer : ADrawer
    {
        private List<string> _matrixImage;

        public ConsoleDrawer(bool border = true) 
            : base(border)
        {
            _matrixImage = new List<string>();
        }

        protected virtual void PrintLine(string str)
        {
            Console.WriteLine(str);
        }

        public override void MakeCanvas(IMatrix matrix)
        {
            Clear();
            int width = matrix.Columns * (FindCellSize(matrix) + 1);
            for (int r = 0; r < matrix.Rows; r++)
            {
                _matrixImage.Add(new string(' ', width));
            }
        }
        public override void DrawElement(IMatrix matrix, int row, int column)
        {
            int cellSize = FindCellSize(matrix);
            int offset = Border ? 1 : 0;
            int id = offset + column * (cellSize + 1);
            int rowId = row + offset;
            var currentRow = _matrixImage[rowId];
            currentRow = currentRow.Remove(id, cellSize);
            currentRow = currentRow.Insert(id, TrimDouble(matrix[row, column], cellSize));
            _matrixImage[rowId] = currentRow;
        }

        public override void DrawBorder(IMatrix matrix)
        {
            if (!Border) return;
            int width = matrix.Columns * (FindCellSize(matrix) + 1);
            string topBottom = " " + new string('-', width);

            for (int r = 0; r < matrix.Rows; r++) 
            {
                var str = _matrixImage[r];
                str = str.Insert(0, "|") + "|";
                _matrixImage[r] = str;
            }
            _matrixImage.Insert(0, topBottom);
            _matrixImage.Add(topBottom);
        }

        public override void Clear()
        {
            _matrixImage.Clear();
        }

        public override void Flush()
        {
            foreach (var str in _matrixImage) 
            {
                PrintLine(str);
            }
            
        }
    }
}
