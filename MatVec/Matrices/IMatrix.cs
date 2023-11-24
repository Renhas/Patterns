using CommandsLib.Memento;
using MatVec.Elements;

namespace MatVec.Matrices
{
    public interface IMatrix : IDrawable, IMementable
    {
        int Rows { get; }
        int Columns { get; }
        double this[int row, int col] { get; set; }
        IMatrix Undecorate();
        IElement GetElement(int row, int col);
    }
}
