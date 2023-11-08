namespace GUIApp
{
    partial class MatrixConstructor
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
            this.matrixView = new System.Windows.Forms.RichTextBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupDirection = new System.Windows.Forms.GroupBox();
            this.panelDirection = new System.Windows.Forms.FlowLayoutPanel();
            this.radioRight = new System.Windows.Forms.RadioButton();
            this.radioDown = new System.Windows.Forms.RadioButton();
            this.groupType = new System.Windows.Forms.GroupBox();
            this.panelType = new System.Windows.Forms.FlowLayoutPanel();
            this.radioSimple = new System.Windows.Forms.RadioButton();
            this.radioSparse = new System.Windows.Forms.RadioButton();
            this.radioComplex = new System.Windows.Forms.RadioButton();
            this.panelMenu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupDirection.SuspendLayout();
            this.panelDirection.SuspendLayout();
            this.groupType.SuspendLayout();
            this.panelType.SuspendLayout();
            this.SuspendLayout();
            // 
            // matrixView
            // 
            this.matrixView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matrixView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrixView.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.matrixView.Location = new System.Drawing.Point(0, 110);
            this.matrixView.Name = "matrixView";
            this.matrixView.Size = new System.Drawing.Size(730, 407);
            this.matrixView.TabIndex = 1;
            this.matrixView.Text = "";
            this.matrixView.WordWrap = false;
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.flowLayoutPanel1);
            this.panelMenu.Controls.Add(this.groupDirection);
            this.panelMenu.Controls.Add(this.groupType);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(730, 110);
            this.panelMenu.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonAdd);
            this.flowLayoutPanel1.Controls.Add(this.buttonSave);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(646, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(84, 110);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(3, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 30);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(3, 39);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 30);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(3, 75);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 30);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupDirection
            // 
            this.groupDirection.Controls.Add(this.panelDirection);
            this.groupDirection.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupDirection.Enabled = false;
            this.groupDirection.Location = new System.Drawing.Point(109, 0);
            this.groupDirection.Name = "groupDirection";
            this.groupDirection.Size = new System.Drawing.Size(95, 110);
            this.groupDirection.TabIndex = 1;
            this.groupDirection.TabStop = false;
            this.groupDirection.Text = "Направление";
            this.groupDirection.Visible = false;
            // 
            // panelDirection
            // 
            this.panelDirection.Controls.Add(this.radioRight);
            this.panelDirection.Controls.Add(this.radioDown);
            this.panelDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDirection.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelDirection.Location = new System.Drawing.Point(3, 19);
            this.panelDirection.Name = "panelDirection";
            this.panelDirection.Size = new System.Drawing.Size(89, 88);
            this.panelDirection.TabIndex = 0;
            // 
            // radioRight
            // 
            this.radioRight.AutoSize = true;
            this.radioRight.Checked = true;
            this.radioRight.Location = new System.Drawing.Point(3, 3);
            this.radioRight.Name = "radioRight";
            this.radioRight.Size = new System.Drawing.Size(65, 19);
            this.radioRight.TabIndex = 0;
            this.radioRight.TabStop = true;
            this.radioRight.Text = "Вправо";
            this.radioRight.UseVisualStyleBackColor = true;
            // 
            // radioDown
            // 
            this.radioDown.AutoSize = true;
            this.radioDown.Location = new System.Drawing.Point(3, 28);
            this.radioDown.Name = "radioDown";
            this.radioDown.Size = new System.Drawing.Size(51, 19);
            this.radioDown.TabIndex = 1;
            this.radioDown.Text = "Вниз";
            this.radioDown.UseVisualStyleBackColor = true;
            // 
            // groupType
            // 
            this.groupType.Controls.Add(this.panelType);
            this.groupType.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupType.Location = new System.Drawing.Point(0, 0);
            this.groupType.Name = "groupType";
            this.groupType.Size = new System.Drawing.Size(109, 110);
            this.groupType.TabIndex = 0;
            this.groupType.TabStop = false;
            this.groupType.Text = "Тип матрицы";
            // 
            // panelType
            // 
            this.panelType.Controls.Add(this.radioSimple);
            this.panelType.Controls.Add(this.radioSparse);
            this.panelType.Controls.Add(this.radioComplex);
            this.panelType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelType.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelType.Location = new System.Drawing.Point(3, 19);
            this.panelType.Name = "panelType";
            this.panelType.Size = new System.Drawing.Size(103, 88);
            this.panelType.TabIndex = 0;
            // 
            // radioSimple
            // 
            this.radioSimple.AutoSize = true;
            this.radioSimple.Checked = true;
            this.radioSimple.Location = new System.Drawing.Point(3, 3);
            this.radioSimple.Name = "radioSimple";
            this.radioSimple.Size = new System.Drawing.Size(76, 19);
            this.radioSimple.TabIndex = 0;
            this.radioSimple.TabStop = true;
            this.radioSimple.Text = "Обычная";
            this.radioSimple.UseVisualStyleBackColor = true;
            // 
            // radioSparse
            // 
            this.radioSparse.AutoSize = true;
            this.radioSparse.Location = new System.Drawing.Point(3, 28);
            this.radioSparse.Name = "radioSparse";
            this.radioSparse.Size = new System.Drawing.Size(97, 19);
            this.radioSparse.TabIndex = 1;
            this.radioSparse.Text = "Разреженная";
            this.radioSparse.UseVisualStyleBackColor = true;
            // 
            // radioComplex
            // 
            this.radioComplex.AutoSize = true;
            this.radioComplex.Enabled = false;
            this.radioComplex.Location = new System.Drawing.Point(3, 53);
            this.radioComplex.Name = "radioComplex";
            this.radioComplex.Size = new System.Drawing.Size(82, 19);
            this.radioComplex.TabIndex = 2;
            this.radioComplex.Text = "Составная";
            this.radioComplex.UseVisualStyleBackColor = true;
            this.radioComplex.Visible = false;
            // 
            // MatrixConstructor
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(730, 517);
            this.Controls.Add(this.matrixView);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(315, 300);
            this.Name = "MatrixConstructor";
            this.ShowIcon = false;
            this.Text = "Создание матрицы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MatrixConstructor_FormClosing);
            this.panelMenu.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupDirection.ResumeLayout(false);
            this.panelDirection.ResumeLayout(false);
            this.panelDirection.PerformLayout();
            this.groupType.ResumeLayout(false);
            this.panelType.ResumeLayout(false);
            this.panelType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox matrixView;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.GroupBox groupDirection;
        private System.Windows.Forms.GroupBox groupType;
        private System.Windows.Forms.FlowLayoutPanel panelType;
        private System.Windows.Forms.FlowLayoutPanel panelDirection;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.RadioButton radioRight;
        private System.Windows.Forms.RadioButton radioDown;
        private System.Windows.Forms.RadioButton radioSimple;
        private System.Windows.Forms.RadioButton radioSparse;
        private System.Windows.Forms.RadioButton radioComplex;
    }
}