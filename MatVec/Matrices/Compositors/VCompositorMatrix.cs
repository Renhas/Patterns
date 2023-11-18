using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatVec.Matrices.Decorators;
using MatVec.Matrices.Drawers;
using MatVec.Matrices.Imaginators;

namespace MatVec.Matrices.Compositors
{
    public class VCompositorMatrix : IMatrixCompositor
    {
        private HCompositorMatrix _compositor;
        private TransposeDecorator _decorator;

        public int Rows
        {
            get
            {
                return _decorator.Rows;
            }
        }

        public int Columns
        {
            get
            {
                return _decorator.Columns;
            }
        }

        public VCompositorMatrix()
        {
            _compositor = new HCompositorMatrix();
            _decorator = new TransposeDecorator(_compositor);
        }

        public void Draw(IMatrixImaginator imaginator)
        {
            imaginator.DrawMatrix(_decorator);
        }

        public IMatrix Undecorate()
        {
            return this;
        }

        public void Add(IMatrix matrix)
        {
            _compositor.Add(new TransposeDecorator(matrix));
        }

        public void Remove(IMatrix matrix)
        {
            _compositor.Remove(matrix);
        }

        public IMatrix Get(int id)
        {
            return _compositor.Get(id);
        }

        public IMatrix Get(int row, int col)
        {
            return _compositor.Get(col, row);
        }

        public int[] GetIds(int row, int col)
        {
            return _compositor.GetIds(col, row);
        }

        public double this[int row, int col]
        {
            get
            {
                return _decorator[row, col];
            }
            set
            {
                _decorator[row, col] = value;
            }
        }
    }
}
