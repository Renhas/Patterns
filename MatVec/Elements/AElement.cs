using CommandsLib.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Elements
{
    internal abstract class AElement : AMementableElement, IElement
    {
        public double Value { get; set; }
        public AElement(double value = 0) 
        {
            Value = value;
        }
        public AElement(AElement other) 
        {
            Value = other.Value;
        }
        public abstract IElementDrawStrategy Strategy { get; }

        public abstract IElement Copy();

        public bool Equals(IElement? other)
        {
            if (other == null) return false;
            return Value == other.Value;
        }

        #region Memento
        protected class MementoAElement : IMemento 
        {
            private double _value;
            protected AElement _owner;
            public MementoAElement(AElement owner) 
            {
                _owner = owner;
                _value = _owner.Value;
            }

            public virtual void Restore()
            {
                _owner.Value = _value;  
            }
        }

        public override IMemento CreateMemento()
        {
            return new MementoAElement(this);
        }
        #endregion
    }
}
