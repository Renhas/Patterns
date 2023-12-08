using MatVec.Matrices;
using MatVec.Matrices.Drawers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Elements
{
    internal class DefaultElement : AElement
    {
        class DefaultStrategy : IElementDrawStrategy
        {
            public void Draw(IMatrix matrix, int row, int col, IDrawer drawer)
            {
                drawer.DrawElement(matrix, row, col);
            }
        }
        public DefaultElement(double value = 0) : base(value) { }
        public DefaultElement(DefaultElement other) : base(other) { }

        public override IElementDrawStrategy Strategy 
        {
            get { return new DefaultStrategy(); }
        }

        public override IElement Copy()
        {
            return new DefaultElement(this);
        }
    }
}
