using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsLib.Memento
{
    public class MementableSystem : IMementable
    {
        #region Singleton
        private static MementableSystem? _instance;
        private MementableSystem() 
        {
            _items = new List<IMementable>();
        }
        public static MementableSystem Instance { 
            get 
            {
                if (_instance == null) 
                    _instance = new MementableSystem();
                return _instance;
            }
        }
        #endregion
        private List<IMementable> _items;
        public void Registry(IMementable item) 
        {
            _items.Add(item);
        }

        public void Unregistry(IMementable item) 
        {
            _items.Remove(item);
        }
        class MementoMementableSystem : IMemento 
        {
            private List<IMementable> _state;

            public MementoMementableSystem() 
            {
                _state = new List<IMementable>(Instance._items);
            }

            public void Restore()
            {
                Instance._items = new List<IMementable>(_state);
            }
        }
        public IMemento CreateMemento()
        {
            var memento = new MementoCompositor();
            memento.Add(new MementoMementableSystem());
            foreach(var item in _items) 
            {
                memento.Add(item.CreateMemento());
            }
            return memento;
        }
    }
}
