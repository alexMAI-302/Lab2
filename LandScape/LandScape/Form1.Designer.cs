namespace LandScape
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Level_1_button = new System.Windows.Forms.Button();
            this.Level_2_button = new System.Windows.Forms.Button();
            this.Level_3_button = new System.Windows.Forms.Button();
            this.Exit_button = new System.Windows.Forms.Button();
            this.Map_pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Map_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Level_1_button
            // 
            this.Level_1_button.Location = new System.Drawing.Point(13, 13);
            this.Level_1_button.Name = "Level_1_button";
            this.Level_1_button.Size = new System.Drawing.Size(140, 23);
            this.Level_1_button.TabIndex = 0;
            this.Level_1_button.Text = "Level 1";
            this.Level_1_button.UseVisualStyleBackColor = true;
            this.Level_1_button.Click += new System.EventHandler(this.Level_1_button_Click);
            // 
            // Level_2_button
            // 
            this.Level_2_button.Location = new System.Drawing.Point(13, 55);
            this.Level_2_button.Name = "Level_2_button";
            this.Level_2_button.Size = new System.Drawing.Size(140, 23);
            this.Level_2_button.TabIndex = 1;
            this.Level_2_button.Text = "Level 2";
            this.Level_2_button.UseVisualStyleBackColor = true;
            this.Level_2_button.Click += new System.EventHandler(this.Level_2_button_Click);
            // 
            // Level_3_button
            // 
            this.Level_3_button.Location = new System.Drawing.Point(13, 96);
            this.Level_3_button.Name = "Level_3_button";
            this.Level_3_button.Size = new System.Drawing.Size(140, 23);
            this.Level_3_button.TabIndex = 2;
            this.Level_3_button.Text = "Level 3";
            this.Level_3_button.UseVisualStyleBackColor = true;
            this.Level_3_button.Click += new System.EventHandler(this.Level_3_button_Click);
            // 
            // Exit_button
            // 
            this.Exit_button.Location = new System.Drawing.Point(13, 489);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(140, 23);
            this.Exit_button.TabIndex = 3;
            this.Exit_button.Text = "Exit";
            this.Exit_button.UseVisualStyleBackColor = true;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // Map_pictureBox
            // 
            this.Map_pictureBox.Location = new System.Drawing.Point(202, 13);
            this.Map_pictureBox.Name = "Map_pictureBox";
            this.Map_pictureBox.Size = new System.Drawing.Size(640, 480);
            this.Map_pictureBox.TabIndex = 4;
            this.Map_pictureBox.TabStop = false;
            this.Map_pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.Map_pictureBox_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Description:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 524);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Map_pictureBox);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.Level_3_button);
            this.Controls.Add(this.Level_2_button);
            this.Controls.Add(this.Level_1_button);
            this.Name = "Form1";
            this.Text = "Map Landscape";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.Map_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Level_1_button;
        private System.Windows.Forms.Button Level_2_button;
        private System.Windows.Forms.Button Level_3_button;
        private System.Windows.Forms.Button Exit_button;
        private System.Windows.Forms.PictureBox Map_pictureBox;
        private System.Windows.Forms.Label label1;
    }
}

