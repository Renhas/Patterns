using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices.Visitors
{
    public class IndexMask
    {
        public int[,][] Mask { get; set; }
        public readonly IMatrix Origin;
        
        public IndexMask(IMatrix matrix) 
        {
            Origin = matrix;
            Mask = CreateMask(matrix);
        }

        public static int[,][] CreateMask(IMatrix matrix) 
        {
            var mask = new int[matrix.Rows, matrix.Columns][];
            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                {
                    mask[i, j] = new int[2] { i, j };
                }
            return mask;
        }

        public int[,][] GetSubMask(int shiftRow, int shiftCol) 
        {
            if (shiftRow >= Mask.GetLength(0) || shiftCol >= Mask.GetLength(1))
                throw new ArgumentOutOfRangeException();
            var rows = Mask.GetLength(0) - shiftRow;
            var cols = Mask.GetLength(1) - shiftCol;
            int[,][] mask = new int[rows, cols][];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++) 
                {
                    mask[r, c] = Mask[r + shiftRow, c + shiftCol];
                }
            return mask;
        }

        public void SetIds(int[] maskIds, int[] newIds) 
        {
            var arr = Mask[maskIds[0], maskIds[1]];
            arr[0] = newIds[0];
            arr[1] = newIds[1];
        }

        public int[] GetIds(int row, int col) 
        {
            return Mask[row, col];
        }

        public double this[int row, int col] 
        {
            get 
            {
                var ids = GetIds(row, col);
                return Origin[ids[0], ids[1]];
            }
        }

    }
}
