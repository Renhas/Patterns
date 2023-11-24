using CommandsLib.Memento;

namespace MatVec.Matrices
{
    public interface IMatrix : IDrawable, IMementable
    {
        public int Rows { get; }
        public int Columns { get; }
        public double this[int row, int col] { get; set; }
        public IMatrix Undecorate();
    }
}
