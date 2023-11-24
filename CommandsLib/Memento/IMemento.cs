using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsLib.Memento
{
    public interface IMemento
    {
        void Restore();
    }
}
