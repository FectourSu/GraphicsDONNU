namespace WindowsFormsApp1.GraphicExtantion.UserControls
{
    partial class DrawGraphicsTemperatures
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DrawGraphics = new System.Windows.Forms.Button();
            this.dragControl1 = new Project_1PCS_16_.DragControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "DRAW GRAPHIC TEMPERATURES";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(4, 60);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(760, 392);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // DrawGraphics
            // 
            this.DrawGraphics.BackColor = System.Drawing.Color.Transparent;
            this.DrawGraphics.FlatAppearance.BorderSize = 0;
            this.DrawGraphics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DrawGraphics.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DrawGraphics.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DrawGraphics.Location = new System.Drawing.Point(9, 454);
            this.DrawGraphics.Margin = new System.Windows.Forms.Padding(4);
            this.DrawGraphics.Name = "DrawGraphics";
            this.DrawGraphics.Size = new System.Drawing.Size(757, 62);
            this.DrawGraphics.TabIndex = 20;
            this.DrawGraphics.Text = "Draw";
            this.DrawGraphics.UseVisualStyleBackColor = false;
            this.DrawGraphics.Click += new System.EventHandler(this.DrawGraphics_Click);
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this;
            // 
            // DrawGraphicsTemperatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DrawGraphics);
            this.Name = "DrawGraphicsTemperatures";
            this.Size = new System.Drawing.Size(770, 516);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button DrawGraphics;
        private Project_1PCS_16_.DragControl dragControl1;
    }
}
