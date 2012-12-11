namespace iPaint
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
            this.radioCross = new System.Windows.Forms.RadioButton();
            this.radioLine = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioCross
            // 
            this.radioCross.AutoSize = true;
            this.radioCross.Location = new System.Drawing.Point(15, 19);
            this.radioCross.Name = "radioCross";
            this.radioCross.Size = new System.Drawing.Size(51, 17);
            this.radioCross.TabIndex = 0;
            this.radioCross.TabStop = true;
            this.radioCross.Text = "Cross";
            this.radioCross.UseVisualStyleBackColor = true;
            this.radioCross.CheckedChanged += new System.EventHandler(this.radioCross_CheckedChanged);
            // 
            // radioLine
            // 
            this.radioLine.AutoSize = true;
            this.radioLine.Location = new System.Drawing.Point(15, 42);
            this.radioLine.Name = "radioLine";
            this.radioLine.Size = new System.Drawing.Size(45, 17);
            this.radioLine.TabIndex = 1;
            this.radioLine.TabStop = true;
            this.radioLine.Text = "Line";
            this.radioLine.UseVisualStyleBackColor = true;
            this.radioLine.CheckedChanged += new System.EventHandler(this.radioLine_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioCross);
            this.groupBox1.Controls.Add(this.radioLine);
            this.groupBox1.Location = new System.Drawing.Point(12, 325);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 103);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tools";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 440);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioCross;
        private System.Windows.Forms.RadioButton radioLine;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

