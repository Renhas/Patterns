using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices.Compositors
{
    public interface IMatrixCompositor : IMatrix
    {
        void Add(IMatrix matrix);
        void Remove(IMatrix matrix);
        IMatrix Get(int id);
        IMatrix Get(int row, int col);
        int[] GetIds(int row, int col);
    }
}
