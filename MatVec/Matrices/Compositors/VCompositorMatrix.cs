using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatVec.Matrices.Decorators;
using MatVec.Matrices.Drawers;
using MatVec.Matrices.Imaginators;
using MatVec.Matrices.Visitors;

namespace MatVec.Matrices.Compositors
{
    public class VCompositorMatrix : IMatrix
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

        public void Add(IMatrix matrix)
        {
            _compositor.Add(new TransposeDecorator(matrix));
        }

        public void Draw(IMatrixImaginator imaginator)
        {
            imaginator.DrawMatrix(_decorator);
        }

        public IMatrix GetElement()
        {
            return this;
        }

        public void Accept(IVisitor visitor)
        {
            _decorator.Accept(visitor);
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
