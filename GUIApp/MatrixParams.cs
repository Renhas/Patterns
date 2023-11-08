using System;
using System.Windows.Forms;

namespace GUIApp
{
    public partial class MatrixParams : Form
    {
        public Parameters Parameters 
        {
            get 
            {
                return new Parameters(
                    (int)numericRow.Value,
                    (int)numericColumn.Value,
                    (int)numericNotNull.Value,
                    (double)numericMax.Value);
            }
        }
        public MatrixParams()
        {
            InitializeComponent();
            CalculateMax();
        }

        public MatrixParams(Parameters parameters) 
            : this() 
        {
            InitParams(parameters);
        }

        private void InitParams(Parameters parameters) 
        {
            numericRow.Value = parameters.Rows;
            numericColumn.Value = parameters.Columns;
            numericNotNull.Value = parameters.NotNull;
            numericMax.Value = (decimal)parameters.Max;
            CalculateMax();
        }

        private void numericRow_ValueChanged(object sender, EventArgs e)
        {
            CalculateMax();
        }
        
        private void numericColumn_ValueChanged(object sender, EventArgs e)
        {
            CalculateMax();
        }

        private void CalculateMax()
        {
            numericNotNull.Maximum = numericRow.Value * numericColumn.Value;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            CloseWithStatus(DialogResult.OK);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CloseWithStatus(DialogResult.Cancel);
        }

        private void CloseWithStatus(DialogResult result) 
        {
            this.DialogResult = result;
            this.Close();
        }
    }
}
