using CommandsLib.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Elements
{
    internal abstract class AMementableElement : IMementable
    {
        public AMementableElement() 
        {
            MementableSystem.Instance.Registry(this);
        }

        public abstract IMemento CreateMemento();

        ~AMementableElement() 
        {
            MementableSystem.Instance.Unregistry(this);
        }
    }
}
