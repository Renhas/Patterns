using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandsLib.Memento;
using MatVec.Matrices.Decorators;
using MatVec.Matrices.Drawers;
using MatVec.Matrices.Imaginators;

namespace MatVec.Matrices.Compositors
{
    public class VCompositorMatrix : AMementableMatrix, IMatrixCompositor
    {
        #region Matrix
        public override int Rows
        {
            get
            {
                return _decorator.Rows;
            }
        }

        public override int Columns
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

        public override void Draw(IMatrixImaginator imaginator)
        {
            imaginator.DrawMatrix(_decorator);
        }

        public override IMatrix Undecorate()
        {
            return this;
        }

        public override double this[int row, int col]
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
        #endregion
        #region Compositor
        private HCompositorMatrix _compositor;
        private TransposeDecorator _decorator;
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
        #endregion
        #region Mementable
        class MementoVCompositorMatrix : IMemento 
        {
            private HCompositorMatrix _compositor;
            private TransposeDecorator _decorator;
            private VCompositorMatrix _owner;
            public MementoVCompositorMatrix(VCompositorMatrix owner) 
            {
                _owner = owner;
                _compositor = _owner._compositor;
                _decorator = _owner._decorator;
            }

            public void Restore()
            {
                _owner._compositor = _compositor;
                _owner._decorator = _decorator;
            }
        }
        public override IMemento CreateMemento()
        {
            return new MementoVCompositorMatrix(this);
        }
        #endregion

    }
}
