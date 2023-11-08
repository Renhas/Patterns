using MatVec.Matrices;
using MatVec.Matrices.Drawers;
using System.Drawing;
using System.Windows.Forms;


namespace GUIApp
{
    internal class PictureBoxDrawer : ADrawer
    {
        private PictureBox _box;
        private Brush _brush;
        private Image? _img;
        private Graphics _gr;
        private int _scaleX = 15;
        private int _scaleY = 30;
        private int _startX = 5;
        private int _startY = 5;

        public PictureBoxDrawer(PictureBox panel, bool border = true)
            : base(border) 
        {
            _box = panel;
            _brush = new SolidBrush(Color.Black);
            _gr = panel.CreateGraphics();
        }

        public override void MakeCanvas(IMatrix matrix) 
        {
            int cellSize = FindCellSize(matrix);
            _img = new Bitmap(
                (cellSize + 1) * matrix.Columns * _scaleX + 10,
                matrix.Rows* _scaleY + 10);
            _gr = Graphics.FromImage(_img);
        }

        public override void DrawBorder(IMatrix matrix)
        {
            if (!Border || _img == null) return;

            int left = _startX - 3, right = left + _img.Width - 4;
            int top = _startY - 3, bottom = top + _img.Height - 4;
            Pen pen = new Pen(_brush);
            _gr.DrawLine(pen, new Point(left, top), new Point(right, top));
            _gr.DrawLine(pen, new Point(left, top), new Point(left, bottom));
            _gr.DrawLine(pen, new Point(left, bottom), new Point(right, bottom));
            _gr.DrawLine(pen, new Point(right, bottom), new Point(right, top));

        }

        public override void DrawElement(IMatrix matrix, int row, int column)
        {
            int cellSize = FindCellSize(matrix);
            int left = _startX + column * (cellSize + 1) * _scaleX;
            int top = _startY + row * _scaleY;
            Font font = new Font("Consolas", 16);
            _gr.DrawString(TrimDouble(matrix[row, column], cellSize), font, _brush, new PointF(left, top));

        }

        public override void Flush()
        {
            _box.Image = _img;
            _box.Refresh();
        }

        public override void Clear()
        {
            _gr.Clear(_box.BackColor);
        }
    }
}
