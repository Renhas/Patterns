using CommandsLib.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsLib.Memento
{
    internal class MementoCompositor : IMemento, ICommand
    {
        private List<IMemento> _items;
        public MementoCompositor() 
        {
            _items = new List<IMemento>();
        }

        public void Add(IMemento item) 
        {
            _items.Add(item);
        }

        public void Execute()
        {
            Restore();
        }

        public void Restore()
        {
            foreach (var memento in _items) 
            {
                memento.Restore();
            }
        }
    }
}
