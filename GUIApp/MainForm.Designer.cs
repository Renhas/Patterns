using System.Windows.Forms;

namespace GUIApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.groupRenumber = new System.Windows.Forms.GroupBox();
            this.panelRenumber = new System.Windows.Forms.FlowLayoutPanel();
            this.renumberBtn = new System.Windows.Forms.Button();
            this.restoreBtn = new System.Windows.Forms.Button();
            this.buttonChangeValue = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.borderCheckBox = new System.Windows.Forms.CheckBox();
            this.console = new System.Windows.Forms.RichTextBox();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.groupRenumber.SuspendLayout();
            this.panelRenumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.pictureBox);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(764, 305);
            this.panel.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(100, 50);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.buttonCreate);
            this.panelMenu.Controls.Add(this.groupRenumber);
            this.panelMenu.Controls.Add(this.buttonChangeValue);
            this.panelMenu.Controls.Add(this.buttonUndo);
            this.panelMenu.Controls.Add(this.borderCheckBox);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelMenu.Location = new System.Drawing.Point(764, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(261, 569);
            this.panelMenu.TabIndex = 1;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(9, 3);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(234, 40);
            this.buttonCreate.TabIndex = 7;
            this.buttonCreate.Text = "Создать матрицу";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // groupRenumber
            // 
            this.groupRenumber.Controls.Add(this.panelRenumber);
            this.groupRenumber.Location = new System.Drawing.Point(3, 49);
            this.groupRenumber.Name = "groupRenumber";
            this.groupRenumber.Size = new System.Drawing.Size(248, 114);
            this.groupRenumber.TabIndex = 8;
            this.groupRenumber.TabStop = false;
            this.groupRenumber.Text = "Перенумеровщик";
            // 
            // panelRenumber
            // 
            this.panelRenumber.Controls.Add(this.renumberBtn);
            this.panelRenumber.Controls.Add(this.restoreBtn);
            this.panelRenumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRenumber.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelRenumber.Location = new System.Drawing.Point(3, 19);
            this.panelRenumber.Name = "panelRenumber";
            this.panelRenumber.Size = new System.Drawing.Size(242, 92);
            this.panelRenumber.TabIndex = 0;
            // 
            // renumberBtn
            // 
            this.renumberBtn.Location = new System.Drawing.Point(3, 3);
            this.renumberBtn.Name = "renumberBtn";
            this.renumberBtn.Size = new System.Drawing.Size(234, 40);
            this.renumberBtn.TabIndex = 4;
            this.renumberBtn.Text = "Перенумеровать";
            this.renumberBtn.UseVisualStyleBackColor = true;
            this.renumberBtn.Click += new System.EventHandler(this.renumberBtn_Click);
            // 
            // restoreBtn
            // 
            this.restoreBtn.Location = new System.Drawing.Point(3, 49);
            this.restoreBtn.Name = "restoreBtn";
            this.restoreBtn.Size = new System.Drawing.Size(234, 40);
            this.restoreBtn.TabIndex = 5;
            this.restoreBtn.Text = "Восстановить";
            this.restoreBtn.UseVisualStyleBackColor = true;
            this.restoreBtn.Click += new System.EventHandler(this.restoreBtn_Click);
            // 
            // buttonChangeValue
            // 
            this.buttonChangeValue.Location = new System.Drawing.Point(3, 169);
            this.buttonChangeValue.Name = "buttonChangeValue";
            this.buttonChangeValue.Size = new System.Drawing.Size(234, 40);
            this.buttonChangeValue.TabIndex = 0;
            this.buttonChangeValue.Text = "Изменить случайное значение";
            this.buttonChangeValue.UseVisualStyleBackColor = true;
            this.buttonChangeValue.Click += new System.EventHandler(this.buttonChangeValue_Click);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Location = new System.Drawing.Point(3, 215);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(234, 40);
            this.buttonUndo.TabIndex = 1;
            this.buttonUndo.Text = "Отменить";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // borderCheckBox
            // 
            this.borderCheckBox.AutoSize = true;
            this.borderCheckBox.Checked = true;
            this.borderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.borderCheckBox.Location = new System.Drawing.Point(3, 261);
            this.borderCheckBox.Name = "borderCheckBox";
            this.borderCheckBox.Size = new System.Drawing.Size(72, 19);
            this.borderCheckBox.TabIndex = 2;
            this.borderCheckBox.Text = "Граница";
            this.borderCheckBox.UseVisualStyleBackColor = true;
            this.borderCheckBox.CheckedChanged += new System.EventHandler(this.borderCheckBox_CheckedChanged);
            // 
            // console
            // 
            this.console.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.console.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.console.Location = new System.Drawing.Point(0, 305);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(764, 264);
            this.console.TabIndex = 2;
            this.console.Text = "";
            this.console.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 569);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.console);
            this.Controls.Add(this.panelMenu);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Красивые матрицы";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.groupRenumber.ResumeLayout(false);
            this.panelRenumber.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel;
        private FlowLayoutPanel panelMenu;
        private CheckBox borderCheckBox;
        private RichTextBox console;
        private PictureBox pictureBox;
        private Button renumberBtn;
        private Button restoreBtn;
        private Button buttonCreate;
        private GroupBox groupRenumber;
        private FlowLayoutPanel panelRenumber;
        private Button buttonChangeValue;
        private Button buttonUndo;
    }
}