using CommandsLib.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Matrices.Drawers
{
    public abstract class AMementableDrawer : IMementable
    {
        public AMementableDrawer() 
        {
            MementableSystem.Instance.Registry(this);
        }
        public abstract IMemento CreateMemento();

        ~AMementableDrawer() 
        {
            MementableSystem.Instance.Unregistry(this);
        }
    }
}
