using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatVec.Matrices.Drawers;
using MatVec.Matrices.Imaginators;
using MatVec.Matrices.Visitors;

namespace MatVec.Matrices.Decorators
{
    public abstract class AMatrixDecorator : IMatrix
    {
        protected IMatrix _matrix;

        public abstract int Rows { get; }
        public abstract int Columns { get; }

        public AMatrixDecorator(IMatrix matrix)
        {
            _matrix = matrix;
        }
        public abstract int[] GetIds(int row, int col);
        public IMatrix GetMatrix() 
        {
            return _matrix;
        }

        public IMatrix GetElement() 
        {
            return _matrix.GetElement();
        }

        public virtual void Accept(IVisitor visitor) 
        {
            var mask = visitor.Mask;
            var newMask = IndexMask.CreateMask(_matrix);
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Columns; c++) 
                {
                    var ids = GetIds(r, c);
                    newMask[ids[0], ids[1]] = mask.GetIds(r, c);                    
                }
            mask.Mask = newMask;
            _matrix.Accept(visitor);
        }
        public virtual void Draw(IMatrixImaginator imaginator) 
        {
            imaginator.DrawMatrix(this);
        }

        public abstract double this[int row, int col] { get; set; }


        //public virtual void Draw() 
        //{
        //    _matrix.Identity = Identity;
        //    if (Drawer != null)
        //    {
        //        _matrix.Drawer = Drawer;
        //    }
        //    _matrix.Draw();
        //    _matrix.Identity = _matrix;
        //}
    }
}
