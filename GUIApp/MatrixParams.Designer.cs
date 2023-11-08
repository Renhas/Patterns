using System.Windows.Forms;

namespace GUIApp
{
    partial class MatrixParams
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBase = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelColumn = new System.Windows.Forms.Label();
            this.numericColumn = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelRows = new System.Windows.Forms.Label();
            this.numericRow = new System.Windows.Forms.NumericUpDown();
            this.groupParams = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelMax = new System.Windows.Forms.Label();
            this.numericMax = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelNotNull = new System.Windows.Forms.Label();
            this.numericNotNull = new System.Windows.Forms.NumericUpDown();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBase.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericColumn)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRow)).BeginInit();
            this.groupParams.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMax)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNotNull)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBase
            // 
            this.groupBase.Controls.Add(this.flowLayoutPanel2);
            this.groupBase.Controls.Add(this.flowLayoutPanel1);
            this.groupBase.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBase.Location = new System.Drawing.Point(0, 0);
            this.groupBase.Name = "groupBase";
            this.groupBase.Size = new System.Drawing.Size(205, 78);
            this.groupBase.TabIndex = 0;
            this.groupBase.TabStop = false;
            this.groupBase.Text = "Размерность матрицы";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.labelColumn);
            this.flowLayoutPanel2.Controls.Add(this.numericColumn);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 49);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(199, 30);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // labelColumn
            // 
            this.labelColumn.AutoSize = true;
            this.labelColumn.Location = new System.Drawing.Point(3, 6);
            this.labelColumn.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.labelColumn.Name = "labelColumn";
            this.labelColumn.Size = new System.Drawing.Size(57, 15);
            this.labelColumn.TabIndex = 0;
            this.labelColumn.Text = "Столбцы";
            // 
            // numericColumn
            // 
            this.numericColumn.Location = new System.Drawing.Point(66, 3);
            this.numericColumn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericColumn.Name = "numericColumn";
            this.numericColumn.Size = new System.Drawing.Size(120, 23);
            this.numericColumn.TabIndex = 1;
            this.numericColumn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericColumn.ValueChanged += new System.EventHandler(this.numericColumn_ValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelRows);
            this.flowLayoutPanel1.Controls.Add(this.numericRow);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(199, 30);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // labelRows
            // 
            this.labelRows.AutoSize = true;
            this.labelRows.Location = new System.Drawing.Point(3, 6);
            this.labelRows.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(56, 15);
            this.labelRows.TabIndex = 0;
            this.labelRows.Text = "Строки   ";
            // 
            // numericRow
            // 
            this.numericRow.Location = new System.Drawing.Point(65, 3);
            this.numericRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericRow.Name = "numericRow";
            this.numericRow.Size = new System.Drawing.Size(120, 23);
            this.numericRow.TabIndex = 1;
            this.numericRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericRow.ValueChanged += new System.EventHandler(this.numericRow_ValueChanged);
            // 
            // groupParams
            // 
            this.groupParams.Controls.Add(this.flowLayoutPanel4);
            this.groupParams.Controls.Add(this.flowLayoutPanel3);
            this.groupParams.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupParams.Location = new System.Drawing.Point(205, 0);
            this.groupParams.Name = "groupParams";
            this.groupParams.Size = new System.Drawing.Size(314, 78);
            this.groupParams.TabIndex = 1;
            this.groupParams.TabStop = false;
            this.groupParams.Text = "Характеристики";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.labelMax);
            this.flowLayoutPanel4.Controls.Add(this.numericMax);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 49);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(308, 30);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(3, 6);
            this.labelMax.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.labelMax.Name = "labelMax";
            this.labelMax.Padding = new System.Windows.Forms.Padding(0, 0, 26, 0);
            this.labelMax.Size = new System.Drawing.Size(171, 15);
            this.labelMax.TabIndex = 0;
            this.labelMax.Text = "Максимальное значение";
            // 
            // numericMax
            // 
            this.numericMax.DecimalPlaces = 1;
            this.numericMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericMax.Location = new System.Drawing.Point(180, 3);
            this.numericMax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericMax.Name = "numericMax";
            this.numericMax.Size = new System.Drawing.Size(120, 23);
            this.numericMax.TabIndex = 1;
            this.numericMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.labelNotNull);
            this.flowLayoutPanel3.Controls.Add(this.numericNotNull);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(308, 30);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // labelNotNull
            // 
            this.labelNotNull.AutoSize = true;
            this.labelNotNull.Location = new System.Drawing.Point(3, 6);
            this.labelNotNull.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.labelNotNull.Name = "labelNotNull";
            this.labelNotNull.Size = new System.Drawing.Size(171, 15);
            this.labelNotNull.TabIndex = 0;
            this.labelNotNull.Text = "Кол-во ненулевых элементов";
            // 
            // numericNotNull
            // 
            this.numericNotNull.Location = new System.Drawing.Point(180, 3);
            this.numericNotNull.Name = "numericNotNull";
            this.numericNotNull.Size = new System.Drawing.Size(120, 23);
            this.numericNotNull.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.LightGreen;
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonSave.Location = new System.Drawing.Point(519, 48);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(90, 30);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Salmon;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonCancel.Location = new System.Drawing.Point(519, 18);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 30);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // MatrixParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 78);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupParams);
            this.Controls.Add(this.groupBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MatrixParams";
            this.ShowIcon = false;
            this.Text = "Параметры матрицы";
            this.groupBase.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericColumn)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRow)).EndInit();
            this.groupParams.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMax)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNotNull)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBase;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label labelRows;
        private NumericUpDown numericRow;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label labelColumn;
        private NumericUpDown numericColumn;
        private GroupBox groupParams;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label labelNotNull;
        private NumericUpDown numericNotNull;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label labelMax;
        private NumericUpDown numericMax;
        private Button buttonSave;
        private Button buttonCancel;
    }
}