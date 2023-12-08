using MatVec.Matrices;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using MatVec.Matrices.Decorators;
using MatVec.Matrices.Drawers;
using MatVec.Matrices.Imaginators;
using CommandsLib.Commands;
using CommandsLib.Memento;

namespace GUIApp
{
    public partial class MainForm : AMementableForm
    {
        private IMatrix? _matrix;
        private IDrawer _drawer;
        private IMatrixImaginator _imaginator;
        private RestorableRandom _random;
        private bool _dragging;
        private int _xPos;
        private int _yPos;

        public MainForm()
        {
            InitializeComponent();
            _random = new RestorableRandom();
            _drawer = new DrawerCompositor(new List<IDrawer>() 
            {
                new TextBoxDrawer(console),
                new PictureBoxDrawer(pictureBox)
            });
            _imaginator = new MatrixImaginator(_drawer);
            _matrix = null;
            _dragging = false;
            _xPos = _yPos = 0;
            _ = CM.Instance;
        }

        private void DrawMatrix()
        {
            _drawer.Clear();
            pictureBox.Image = null;
            pictureBox.Update();
            if (_matrix == null) 
            {
                return; 
            }
            _drawer.Border = borderCheckBox.Checked;
            _matrix.Draw(_imaginator);
        }

        private int[] GetTwoRandoms(int min, int max) 
        {
            var first = _random.Generator.Next(min, max);
            var second = first;
            while (first == second) 
            {
                second = _random.Generator.Next(min, max);
            }
            return new int[2] { first, second };
        }

        private double CreateValue(double maxValue, Random rand)
        {
            int range = (int)Math.Floor(maxValue);
            return maxValue - rand.NextDouble() - rand.Next(0, 2 * range);
        }
        #region Events
        #region MatrixBase
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var constructor = new MatrixConstructor();
            if (constructor.ShowDialog() == DialogResult.OK)
            {
                new CommandSaveMatrix(this, constructor.Matrix).Execute();
                //_matrix = constructor.Matrix;
                //DrawMatrix();
                CM.Instance.Backup();
            }

        }
        private void borderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DrawMatrix();
        }
        #endregion
        #region PictureDragging
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
        #endregion
        #region RenumberEvents
        private void renumberBtn_Click(object sender, EventArgs e)
        {
            if (_matrix == null)
            {
                return;
            }
            int[] rows, columns;
            if (_matrix.Rows != 1)
            {
                rows = GetTwoRandoms(0, _matrix.Rows);
            }
            else 
            {
                rows = new int[] { 0, 0 };
            }
            if (_matrix.Columns != 1)
            {
                columns = GetTwoRandoms(0, _matrix.Columns);
            }
            else 
            {
                columns = new int[] { 0, 0 };
            }
            new CommandRenumber(this, rows, columns).Execute();
            DrawMatrix();
        }
        private void restoreBtn_Click(object sender, EventArgs e)
        {
            if (_matrix == null) return;
            new CommandRestore(this).Execute();
            DrawMatrix();
        }
        #endregion
        #region ChangeValueEvents
        private void buttonChangeValue_Click(object sender, EventArgs e)
        {
            if (_matrix == null) return;
            var rand = _random.Generator;
            var row = rand.Next(0, _matrix.Rows);
            var col = rand.Next(0, _matrix.Columns);
            var stats = new MatrixStats(_matrix);
            var value = CreateValue(Math.Abs(stats.MaxValue), rand);
            new CommandChangeValue(this, new int[] {row, col }, value).Execute();
            DrawMatrix();
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            CM.Instance.Undo();
            DrawMatrix();
        }
        #endregion
        #endregion
        #region Mementable
        class MementoMainForm : IMemento 
        {
            private IMatrix? _matrix;
            private IDrawer _drawer;
            private IMatrixImaginator _imaginator;
            private MainForm _owner;
            public MementoMainForm(MainForm owner) 
            {
                _owner = owner;
                _matrix = owner._matrix;
                _drawer = owner._drawer;
                _imaginator = owner._imaginator;
            }

            public void Restore()
            {
                _owner._matrix = _matrix;
                _owner._drawer = _drawer;
                _owner._imaginator = _imaginator;
            }
        }
        public override IMemento CreateMemento()
        {
            return new MementoMainForm(this);
        }
        #endregion
        #region Commands
        class CommandSaveMatrix : ACommand 
        {
            private MainForm _owner;
            private IMatrix _matrix;
            public CommandSaveMatrix(MainForm owner, IMatrix matrix)
            {
                _owner = owner;
                _matrix = matrix;
            }

            protected override void DoExecute()
            {
                _owner._matrix = _matrix;
                _owner.DrawMatrix();
            }
        }
        class CommandChangeValue : ACommand 
        {
            private MainForm _owner;
            private int[] _ids;
            private double _value;
            public CommandChangeValue(MainForm owner, int[] ids, double value)
            {
                _ids = new int[2];
                ids.CopyTo(this._ids, 0);
                _value = value;
                _owner = owner;
            }

            protected override void DoExecute()
            {
                var mtx = _owner._matrix;
                if (mtx == null) return;
                mtx[_ids[0], _ids[1]] = _value;
            }
            
        }

        class CommandRenumber : ACommand 
        {
            private MainForm _owner;
            private int[] _rows;
            private int[] _columns;
            public CommandRenumber(MainForm owner, int[] rows, int[] columns) 
            {
                _owner = owner;
                _rows = new int[2];
                _columns = new int[2];
                rows.CopyTo(this._rows, 0);
                columns.CopyTo(this._columns, 0);
            }

            protected override void DoExecute()
            {
                if (_owner._matrix is not RenumberDecorator)
                {
                    _owner._matrix = new RenumberDecorator(_owner._matrix);
                }
                if (_owner._matrix.Rows != 1)
                {
                    var dec = (RenumberDecorator)_owner._matrix;
                    dec.SwapRows(_rows[0], _rows[1]);
                }
                if (_owner._matrix.Columns != 1)
                {
                    var dec = (RenumberDecorator)_owner._matrix;
                    dec.SwapColumns(_columns[0], _columns[1]);
                }
            }
        }

        class CommandRestore : ACommand 
        {
            private MainForm _owner;
            public CommandRestore(MainForm owner) 
            {
                _owner = owner;
            }

            protected override void DoExecute()
            {
                _owner._matrix = _owner._matrix.Undecorate();
            }
        }
        #endregion
    }
}