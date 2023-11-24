using CommandsLib.Memento;
using MatVec.Matrices.Drawers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices.Imaginators
{
    public interface IMatrixImaginator : IMementable
    {
        IDrawer Drawer { set; }
        void DrawMatrix(IMatrix matrix);
    }
}
