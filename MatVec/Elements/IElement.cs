using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatVec.Elements
{
    public interface IElement : IEquatable<IElement>
    {
        double Value { get; set; }
        IElementDrawStrategy Strategy { get; }
        IElement Copy();
    }
}
