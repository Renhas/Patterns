using CommandsLib.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices.Imaginators
{
    public abstract class AMementableImaginator : IMementable
    {
        public AMementableImaginator() 
        {
            MementableSystem.Instance.Registry(this);
        }
        public abstract IMemento CreateMemento();

        ~AMementableImaginator() 
        {
            MementableSystem.Instance.Unregistry(this);
        }
    }
}
