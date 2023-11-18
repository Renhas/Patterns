using MatVec.Matrices;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using MatVec.Matrices.Decorators;
using MatVec.Matrices.Drawers;
using MatVec.Matrices.Imaginators;

namespace GUIApp
{
    public partial class MainForm : Form
    {
        private IMatrix? _matrix;
        private IDrawer _drawer;
        private IMatrixImaginator _imaginator;
        private Random _random;
        private bool _dragging;
        private int _xPos;
        private int _yPos;

        public MainForm()
        {
            InitializeComponent();
            _random = new Random();
            _drawer = new DrawerCompositor(new List<IDrawer>() 
            {
                new TextBoxDrawer(console),
                new PictureBoxDrawer(pictureBox)
            });
            _imaginator = new MatrixImaginator(_drawer);
            _matrix = null;
            _dragging = false;
            _xPos = _yPos = 0;
        }

        private void DrawMatrix()
        {
            if (_matrix == null) return;
            _drawer.Border = borderCheckBox.Checked;
            _drawer.Clear();
            _matrix.Draw(_imaginator);
        }

        private int[] GetTwoRandoms(int min, int max) 
        {
            var first = _random.Next(min, max);
            var second = first;
            while (first == second) 
            {
                second = _random.Next(min, max);
            }
            return new int[2] { first, second };
        }

        private void borderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DrawMatrix();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _dragging = true;
                _xPos = e.X;
                _yPos = e.Y;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_dragging) return;
            if(sender is Control c)            
            {
                c.Top = e.Y + c.Top - _yPos;
                c.Left = e.X + c.Left - _xPos;
            }
        }

        private void renumberBtn_Click(object sender, EventArgs e)
        {
            if (_matrix == null)
            {
                return;
            }
            if (_matrix is not RenumberDecorator) 
            {
                _matrix = new RenumberDecorator(_matrix);
            }
            if (_matrix.Rows != 1) 
            {
                var dec = (RenumberDecorator)_matrix;
                var ids = GetTwoRandoms(0, dec.Rows);
                dec.SwapRows(ids[0], ids[1]);
            }
            if (_matrix.Columns != 1) 
            {
                var dec = (RenumberDecorator)_matrix;
                var ids = GetTwoRandoms(0, dec.Columns);
                dec.SwapColumns(ids[0], ids[1]);
            }
            DrawMatrix();
        }

        private void restoreBtn_Click(object sender, EventArgs e)
        {
            if (_matrix == null) return;
            _matrix = _matrix.Undecorate();
            DrawMatrix();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var constructor = new MatrixConstructor();
            if (constructor.ShowDialog() == DialogResult.OK) 
            {
                _matrix = constructor.Matrix;
                DrawMatrix();
            }

        }
    }
}