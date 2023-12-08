using CommandsLib.Memento;
using MatVec.Matrices;
using MatVec.Matrices.Drawers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Elements
{
    internal class ExclusiveElement : AElement
    {
        class ExclusiveStrategy : IElementDrawStrategy
        {
            private ExclusiveElement _owner;
            public ExclusiveStrategy(ExclusiveElement owner)
            {
                _owner = owner;
            }

            public void Draw(IMatrix matrix, int row, int col, IDrawer drawer)
            {
                if (matrix[row, col] == _owner._exclusive) return;
                drawer.DrawElement(matrix, row, col);
            }
        }
        private double _exclusive;
        public ExclusiveElement(double value = 0, double exclusiveValue = 0) : base(value) 
        {
            _exclusive = exclusiveValue;
        }
        public ExclusiveElement(ExclusiveElement other) : base(other) 
        {
            _exclusive = other._exclusive;
        }

        public override IElementDrawStrategy Strategy 
        {
            get { return new ExclusiveStrategy(this); }
        }

        public override IElement Copy()
        {
            return new ExclusiveElement(this);
        }

        #region Mementable
        class MementoExclusiveElement : MementoAElement 
        {
            private double _exclusive;
            public MementoExclusiveElement(ExclusiveElement owner) : base(owner) 
            {
                _exclusive = owner._exclusive;
            }

            public override void Restore()
            {
                base.Restore();
                (_owner as ExclusiveElement)._exclusive = _exclusive;
            }
        }

        public override IMemento CreateMemento()
        {
            return new MementoExclusiveElement(this);
        }
        #endregion
    }
}
