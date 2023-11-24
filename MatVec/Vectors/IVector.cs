using CommandsLib.Memento;
using MatVec.Elements;

namespace MatVec.Vectors
{
    public interface IVector : IMementable
    {
        IElement GetElement(int index);
        int Dimension { get; }
        double this[int index] { get; set; }
    }
}