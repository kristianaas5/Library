namespace Library
{
    partial class Library
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Library));
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.rbReaders = new System.Windows.Forms.RadioButton();
            this.rbBorrowings = new System.Windows.Forms.RadioButton();
            this.rbBooks = new System.Windows.Forms.RadioButton();
            this.rbEvents = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbDescending = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // rbReaders
            // 
            this.rbReaders.AutoSize = true;
            this.rbReaders.Location = new System.Drawing.Point(6, 36);
            this.rbReaders.Name = "rbReaders";
            this.rbReaders.Size = new System.Drawing.Size(81, 20);
            this.rbReaders.TabIndex = 0;
            this.rbReaders.TabStop = true;
            this.rbReaders.Text = "Readers";
            this.rbReaders.UseVisualStyleBackColor = true;
            this.rbReaders.CheckedChanged += new System.EventHandler(this.rbReaders_CheckedChanged);
            // 
            // rbBorrowings
            // 
            this.rbBorrowings.AutoSize = true;
            this.rbBorrowings.Location = new System.Drawing.Point(93, 36);
            this.rbBorrowings.Name = "rbBorrowings";
            this.rbBorrowings.Size = new System.Drawing.Size(95, 20);
            this.rbBorrowings.TabIndex = 1;
            this.rbBorrowings.TabStop = true;
            this.rbBorrowings.Text = "Borrowings";
            this.rbBorrowings.UseVisualStyleBackColor = true;
            this.rbBorrowings.CheckedChanged += new System.EventHandler(this.rbBorrowings_CheckedChanged);
            // 
            // rbBooks
            // 
            this.rbBooks.AutoSize = true;
            this.rbBooks.Location = new System.Drawing.Point(194, 36);
            this.rbBooks.Name = "rbBooks";
            this.rbBooks.Size = new System.Drawing.Size(67, 20);
            this.rbBooks.TabIndex = 2;
            this.rbBooks.TabStop = true;
            this.rbBooks.Text = "Books";
            this.rbBooks.UseVisualStyleBackColor = true;
            this.rbBooks.CheckedChanged += new System.EventHandler(this.rbBooks_CheckedChanged);
            // 
            // rbEvents
            // 
            this.rbEvents.AutoSize = true;
            this.rbEvents.Location = new System.Drawing.Point(267, 36);
            this.rbEvents.Name = "rbEvents";
            this.rbEvents.Size = new System.Drawing.Size(69, 20);
            this.rbEvents.TabIndex = 3;
            this.rbEvents.TabStop = true;
            this.rbEvents.Text = "Events";
            this.rbEvents.UseVisualStyleBackColor = true;
            this.rbEvents.CheckedChanged += new System.EventHandler(this.rbEvents_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox1.Controls.Add(this.rbReaders);
            this.groupBox1.Controls.Add(this.rbEvents);
            this.groupBox1.Controls.Add(this.rbBorrowings);
            this.groupBox1.Controls.Add(this.rbBooks);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 75);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Изберете таблица";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(25, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(25, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(25, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(25, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(25, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(130, 180);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 12;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(130, 230);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 13;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(130, 280);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 14;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(130, 330);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 15;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(130, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 16;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(270, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(802, 299);
            this.dataGridView1.TabIndex = 17;
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnInsert.Location = new System.Drawing.Point(25, 430);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 18;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnSort
            // 
            this.btnSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSort.Location = new System.Drawing.Point(120, 430);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 21;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click_1);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(1024, 452);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(81, 29);
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFilter.Location = new System.Drawing.Point(520, 430);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 23;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cbFilter
            // 
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(370, 410);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 24);
            this.cbFilter.TabIndex = 24;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(370, 450);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(100, 22);
            this.txtFilter.TabIndex = 25;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnUpdate.Location = new System.Drawing.Point(215, 430);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 26;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // cbDescending
            // 
            this.cbDescending.AutoSize = true;
            this.cbDescending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cbDescending.Location = new System.Drawing.Point(120, 404);
            this.cbDescending.Name = "cbDescending";
            this.cbDescending.Size = new System.Drawing.Size(107, 20);
            this.cbDescending.TabIndex = 28;
            this.cbDescending.Text = "descending?";
            this.cbDescending.UseVisualStyleBackColor = false;
            // 
            // Library
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1165, 493);
            this.Controls.Add(this.cbDescending);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Library";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.RadioButton rbReaders;
        private System.Windows.Forms.RadioButton rbBorrowings;
        private System.Windows.Forms.RadioButton rbBooks;
        private System.Windows.Forms.RadioButton rbEvents;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox cbDescending;
    }
}

