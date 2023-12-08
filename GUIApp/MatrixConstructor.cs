using CommandsLib.Commands;
using CommandsLib.Memento;
using MatVec.Matrices;
using MatVec.Matrices.Compositors;
using MatVec.Matrices.Imaginators;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUIApp
{
    public partial class MatrixConstructor : Form
    {
        public IMatrix? Matrix { get; private set; }
        private IMatrixImaginator _imaginator;
        private Parameters _params;
        public MatrixConstructor()
        {
            InitializeComponent();
            _imaginator = new MatrixImaginator(new TextBoxDrawer(matrixView));
            Matrix = null;
            _params = new Parameters(1, 1, 1, 2);
        }
        #region Creators
        private IMatrix? CreateMatrix() 
        {
            var typeId = SearchRadioBtnId(panelType);
            IMatrix? mtx = null;
            switch (typeId) 
            {
                case 0: mtx = CreateSimple(); break;
                case 1: mtx = CreateSparse(); break;
                case 2: mtx = CreateComplex(); break;
            }
            if (mtx == null) return null;
            MatrixInitializer.FillMatrix(mtx, _params.NotNull, _params.Max);
            return mtx;
        }

        private IMatrix? CreateSimple() 
        {
            if (!SetParams()) 
            {
                return null;
            }
            return new Matrix(_params.Rows, _params.Columns);
        }

        private IMatrix? CreateSparse() 
        {
            if (!SetParams())
            {
                return null;
            }
            return new SparseMatrix(_params.Rows, _params.Columns);
        }

        private IMatrix? CreateComplex() 
        {
            var constructor = new MatrixConstructor();
            if (constructor.ShowDialog() == DialogResult.OK) 
            {
                return constructor.Matrix;
            }
            return null;
        }
        #endregion
        #region Adders
        private void AddNewMatrix() 
        {
            var matrix = CreateMatrix();
            if (matrix == null) return;
            Matrix = matrix;
            radioComplex.Enabled = radioComplex.Visible = true;
            groupDirection.Enabled = groupDirection.Visible = true;
            Draw();
        }

        private void AddMatrix() 
        {
            var matrix = CreateMatrix();
            if (matrix == null) return;
            var directionId = SearchRadioBtnId(panelDirection);
            switch (directionId) 
            {
                case 0: AddHorizontal(matrix); break;
                case 1: AddVertical(matrix); break;
            }
            Draw();
        }

        private void AddHorizontal(IMatrix matrix)
        {
            if (Matrix == null) return;
            if (Matrix is not HCompositorMatrix)
            {
                var temp = new HCompositorMatrix();
                temp.Add(Matrix);
                Matrix = temp;
            }
            var compositor = (HCompositorMatrix)Matrix;
            compositor.Add(matrix);
        }

        private void AddVertical(IMatrix matrix)
        {
            if (Matrix == null) return;
            if (Matrix is not VCompositorMatrix)
            {
                var temp = new VCompositorMatrix();
                temp.Add(Matrix);
                Matrix = temp;
            }
            var compositor = (VCompositorMatrix)Matrix;
            compositor.Add(matrix);
        }
        #endregion
        #region Tools
        private bool SetParams() 
        {
            var paramsForm = new MatrixParams(_params);
            if (paramsForm.ShowDialog() == DialogResult.OK) 
            {
                _params = paramsForm.Parameters;
                return true;
            }
            return false;
        }

        private int SearchRadioBtnId(Control container) 
        {
            var btn = container.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (btn == null) 
            {
                return -1;
            }
            return btn.TabIndex;
        }

        private void Draw() 
        {
            if (Matrix == null) return;
            Matrix.Draw(_imaginator);
        }

        private void CloseWithStatus(DialogResult result)
        {
            this.DialogResult = result;
            this.Close();
        }
        #endregion
        #region Events
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (Matrix == null)
            {
                AddNewMatrix();
            }
            else 
            {
                AddMatrix();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            CloseWithStatus(DialogResult.OK);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CloseWithStatus(DialogResult.Cancel);
        }

        private void MatrixConstructor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Уверены?", "Подтверждение", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion
        //#region Mementable
        //class MementoMatrixConstructor : IMemento 
        //{
        //    private IMatrix? _matrix;
        //    private IMatrixImaginator _imaginator;
        //    private Parameters _params;
        //    private MatrixConstructor _owner;
        //    public MementoMatrixConstructor(MatrixConstructor owner) 
        //    {
        //        _owner = owner;
        //        _matrix = _owner.Matrix;
        //        _imaginator = _owner._imaginator;
        //        _params = _owner._params;
        //    }

        //    public void Restore()
        //    {
        //        _owner.Matrix = _matrix;
        //        _owner._imaginator = _imaginator;
        //        _owner._params = _params;
        //    }
        //}

        //public override IMemento CreateMemento()
        //{
        //    return new MementoMatrixConstructor(this);
        //}
        //#endregion
    }
}
