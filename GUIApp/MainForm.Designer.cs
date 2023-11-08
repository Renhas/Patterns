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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.renumberBtn = new System.Windows.Forms.Button();
            this.restoreBtn = new System.Windows.Forms.Button();
            this.borderCheckBox = new System.Windows.Forms.CheckBox();
            this.console = new System.Windows.Forms.RichTextBox();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.pictureBox);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(776, 305);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonCreate);
            this.flowLayoutPanel1.Controls.Add(this.renumberBtn);
            this.flowLayoutPanel1.Controls.Add(this.restoreBtn);
            this.flowLayoutPanel1.Controls.Add(this.borderCheckBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(776, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(249, 569);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(3, 3);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(234, 40);
            this.buttonCreate.TabIndex = 7;
            this.buttonCreate.Text = "Создать матрицу";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // renumberBtn
            // 
            this.renumberBtn.Location = new System.Drawing.Point(3, 49);
            this.renumberBtn.Name = "renumberBtn";
            this.renumberBtn.Size = new System.Drawing.Size(234, 40);
            this.renumberBtn.TabIndex = 4;
            this.renumberBtn.Text = "Перенумеровать";
            this.renumberBtn.UseVisualStyleBackColor = true;
            this.renumberBtn.Click += new System.EventHandler(this.renumberBtn_Click);
            // 
            // restoreBtn
            // 
            this.restoreBtn.Location = new System.Drawing.Point(3, 95);
            this.restoreBtn.Name = "restoreBtn";
            this.restoreBtn.Size = new System.Drawing.Size(234, 40);
            this.restoreBtn.TabIndex = 5;
            this.restoreBtn.Text = "Восстановить";
            this.restoreBtn.UseVisualStyleBackColor = true;
            this.restoreBtn.Click += new System.EventHandler(this.restoreBtn_Click);
            // 
            // borderCheckBox
            // 
            this.borderCheckBox.AutoSize = true;
            this.borderCheckBox.Checked = true;
            this.borderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.borderCheckBox.Location = new System.Drawing.Point(3, 141);
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
            this.console.Size = new System.Drawing.Size(776, 264);
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
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Красивые матрицы";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel;
        private FlowLayoutPanel flowLayoutPanel1;
        private CheckBox borderCheckBox;
        private RichTextBox console;
        private PictureBox pictureBox;
        private Button renumberBtn;
        private Button restoreBtn;
        private Button buttonCreate;
    }
}