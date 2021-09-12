
namespace LR7
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Coord_label = new System.Windows.Forms.Label();
            this.buttonLine = new System.Windows.Forms.Button();
            this.buttonCircle = new System.Windows.Forms.Button();
            this.buttonTriangle = new System.Windows.Forms.Button();
            this.buttonSquare = new System.Windows.Forms.Button();
            this.buttonCGroup = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ShowColor_button = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.Coord_label);
            this.panel1.Location = new System.Drawing.Point(114, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 565);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown_1);
            // 
            // Coord_label
            // 
            this.Coord_label.AutoSize = true;
            this.Coord_label.Location = new System.Drawing.Point(3, 9);
            this.Coord_label.Name = "Coord_label";
            this.Coord_label.Size = new System.Drawing.Size(94, 20);
            this.Coord_label.TabIndex = 1;
            this.Coord_label.Text = "Coord_label";
            // 
            // buttonLine
            // 
            this.buttonLine.Location = new System.Drawing.Point(13, 393);
            this.buttonLine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLine.Name = "buttonLine";
            this.buttonLine.Size = new System.Drawing.Size(94, 54);
            this.buttonLine.TabIndex = 12;
            this.buttonLine.Text = "линия";
            this.buttonLine.UseVisualStyleBackColor = true;
            this.buttonLine.Click += new System.EventHandler(this.buttonLine_Click);
            // 
            // buttonCircle
            // 
            this.buttonCircle.Location = new System.Drawing.Point(13, 203);
            this.buttonCircle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(94, 54);
            this.buttonCircle.TabIndex = 9;
            this.buttonCircle.Text = "круг";
            this.buttonCircle.UseVisualStyleBackColor = true;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            // 
            // buttonTriangle
            // 
            this.buttonTriangle.Location = new System.Drawing.Point(13, 330);
            this.buttonTriangle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonTriangle.Name = "buttonTriangle";
            this.buttonTriangle.Size = new System.Drawing.Size(94, 54);
            this.buttonTriangle.TabIndex = 11;
            this.buttonTriangle.Text = "треугольник";
            this.buttonTriangle.UseVisualStyleBackColor = true;
            this.buttonTriangle.Click += new System.EventHandler(this.buttonTriangle_Click);
            // 
            // buttonSquare
            // 
            this.buttonSquare.Location = new System.Drawing.Point(13, 267);
            this.buttonSquare.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSquare.Name = "buttonSquare";
            this.buttonSquare.Size = new System.Drawing.Size(94, 54);
            this.buttonSquare.TabIndex = 10;
            this.buttonSquare.Text = "квадрат";
            this.buttonSquare.UseVisualStyleBackColor = true;
            this.buttonSquare.Click += new System.EventHandler(this.buttonSquare_Click);
            // 
            // buttonCGroup
            // 
            this.buttonCGroup.Location = new System.Drawing.Point(280, 572);
            this.buttonCGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCGroup.Name = "buttonCGroup";
            this.buttonCGroup.Size = new System.Drawing.Size(126, 54);
            this.buttonCGroup.TabIndex = 15;
            this.buttonCGroup.Text = "группировать";
            this.buttonCGroup.UseVisualStyleBackColor = true;
            this.buttonCGroup.Click += new System.EventHandler(this.buttonCGroup_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(146, 572);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 54);
            this.button2.TabIndex = 14;
            this.button2.Text = "выделить\r\n";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ShowColor_button
            // 
            this.ShowColor_button.Location = new System.Drawing.Point(13, 572);
            this.ShowColor_button.Name = "ShowColor_button";
            this.ShowColor_button.Size = new System.Drawing.Size(126, 54);
            this.ShowColor_button.TabIndex = 13;
            this.ShowColor_button.Text = "выбрать цвет";
            this.ShowColor_button.UseVisualStyleBackColor = true;
            this.ShowColor_button.Click += new System.EventHandler(this.ShowColor_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 628);
            this.Controls.Add(this.buttonCGroup);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ShowColor_button);
            this.Controls.Add(this.buttonLine);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCircle);
            this.Controls.Add(this.buttonTriangle);
            this.Controls.Add(this.buttonSquare);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Coord_label;
        private System.Windows.Forms.Button buttonLine;
        private System.Windows.Forms.Button buttonCircle;
        private System.Windows.Forms.Button buttonTriangle;
        private System.Windows.Forms.Button buttonSquare;
        private System.Windows.Forms.Button buttonCGroup;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ShowColor_button;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

