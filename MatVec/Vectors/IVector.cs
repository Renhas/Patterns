using CommandsLib.Memento;

namespace MatVec.Vectors
{
    public interface IVector : IMementable
    {
        public int Dimension { get; }
        public double this[int index] { get; set; }
    }
}