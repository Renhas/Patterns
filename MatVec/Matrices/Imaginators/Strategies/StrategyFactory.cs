using MatVec.Matrices.Compositors;
using MatVec.Matrices.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices.Imaginators.Strategies
{
    public class StrategyFactory
    {
        private static StrategyFactory? _instance;
        public static StrategyFactory Instance {
            get
            {
                if(_instance == null)
                    _instance = new StrategyFactory();
                return _instance;
            } 
        }
        private StrategyFactory() { }
        

        public virtual IElementDrawStrategy CreateStrategy(IMatrix matrix) 
        {
            var trueMatrix = matrix.Undecorate();
            if (trueMatrix is SparseMatrix) return new SparseStrategy();
            if (trueMatrix is IMatrixCompositor compositor) return new CompositorStrategy(compositor, matrix);
            return new DefaultStrategy();
        }
    }
}
