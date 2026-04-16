namespace Library
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbBooks = new System.Windows.Forms.RadioButton();
            this.rbBorrowings = new System.Windows.Forms.RadioButton();
            this.rbEvents = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.rbEvents);
            this.groupBox1.Controls.Add(this.rbBorrowings);
            this.groupBox1.Controls.Add(this.rbBooks);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // rbBooks
            // 
            this.rbBooks.AutoSize = true;
            this.rbBooks.Location = new System.Drawing.Point(3, 18);
            this.rbBooks.Name = "rbBooks";
            this.rbBooks.Size = new System.Drawing.Size(67, 20);
            this.rbBooks.TabIndex = 0;
            this.rbBooks.TabStop = true;
            this.rbBooks.Text = "Books";
            this.rbBooks.UseVisualStyleBackColor = true;
            this.rbBooks.CheckedChanged += new System.EventHandler(this.rbBooks_CheckedChanged);
            // 
            // rbBorrowings
            // 
            this.rbBorrowings.AutoSize = true;
            this.rbBorrowings.Location = new System.Drawing.Point(44, 44);
            this.rbBorrowings.Name = "rbBorrowings";
            this.rbBorrowings.Size = new System.Drawing.Size(103, 20);
            this.rbBorrowings.TabIndex = 1;
            this.rbBorrowings.TabStop = true;
            this.rbBorrowings.Text = "radioButton2";
            this.rbBorrowings.UseVisualStyleBackColor = true;
            this.rbBorrowings.CheckedChanged += new System.EventHandler(this.rbBorrowings_CheckedChanged);
            // 
            // rbEvents
            // 
            this.rbEvents.AutoSize = true;
            this.rbEvents.Location = new System.Drawing.Point(154, 18);
            this.rbEvents.Name = "rbEvents";
            this.rbEvents.Size = new System.Drawing.Size(103, 20);
            this.rbEvents.TabIndex = 2;
            this.rbEvents.TabStop = true;
            this.rbEvents.Text = "radioButton3";
            this.rbEvents.UseVisualStyleBackColor = true;
            this.rbEvents.CheckedChanged += new System.EventHandler(this.rbEvents_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(284, 12);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(93, 20);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "rbReaders";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton rbEvents;
        private System.Windows.Forms.RadioButton rbBorrowings;
        private System.Windows.Forms.RadioButton rbBooks;
    }
}

