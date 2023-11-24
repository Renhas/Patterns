using CommandsLib.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Vectors
{
    public abstract class AMementableVector : IVector
    {
        #region Vector
        public abstract int Dimension { get; }
        public abstract double this[int index] { get; set; }
        #endregion
        #region Mementable
        public AMementableVector() 
        {
            MementableSystem.Instance.Registry(this);
        }

        public abstract IMemento CreateMemento();

        ~AMementableVector() 
        {
            MementableSystem.Instance.Unregistry(this);
        }
        #endregion
    }
}
