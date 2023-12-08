using CommandsLib.Memento;

namespace MatVec.Matrices.Drawers
{
    public interface IDrawer : IMementable
    {
        public bool Border { get; set; }
        public void DrawBorder(IMatrix matrix);
        public void MakeCanvas(IMatrix matrix);
        public void DrawElement(IMatrix matrix, int row, int column);
        public void Flush();
        public void Clear();
    }
}
