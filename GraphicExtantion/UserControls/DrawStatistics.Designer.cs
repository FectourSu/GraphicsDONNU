namespace WindowsFormsApp1.GraphicExtantion.UserControls
{
    partial class DrawStatistics
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
            this.DrawStatistic = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dragControl1 = new Project_1PCS_16_.DragControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(3, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "DRAW STATISTIC";
            // 
            // DrawStatistic
            // 
            this.DrawStatistic.BackColor = System.Drawing.Color.Transparent;
            this.DrawStatistic.FlatAppearance.BorderSize = 0;
            this.DrawStatistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DrawStatistic.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DrawStatistic.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DrawStatistic.Location = new System.Drawing.Point(8, 452);
            this.DrawStatistic.Margin = new System.Windows.Forms.Padding(4);
            this.DrawStatistic.Name = "DrawStatistic";
            this.DrawStatistic.Size = new System.Drawing.Size(758, 62);
            this.DrawStatistic.TabIndex = 17;
            this.DrawStatistic.Text = "Draw";
            this.DrawStatistic.UseVisualStyleBackColor = false;
            this.DrawStatistic.Click += new System.EventHandler(this.DrawStatistic_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 62);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(760, 362);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // dragControl1
            // 
            this.dragControl1.SelectControl = this;
            // 
            // DrawStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DrawStatistic);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DrawStatistics";
            this.Size = new System.Drawing.Size(770, 516);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DrawStatistic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Project_1PCS_16_.DragControl dragControl1;
    }
}
