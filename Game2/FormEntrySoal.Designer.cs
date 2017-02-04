namespace SnakeLadderQuiz.Desktop
{
    partial class FormEntrySoal
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPertanyaan = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbEssay = new System.Windows.Forms.RadioButton();
            this.txtJawabanEssay = new System.Windows.Forms.RichTextBox();
            this.rbMultiple = new System.Windows.Forms.RadioButton();
            this.gvJawabanMultiple = new System.Windows.Forms.DataGridView();
            this.cmdAddMultiple = new System.Windows.Forms.Button();
            this.cmdSimpan = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.gvGroup = new System.Windows.Forms.DataGridView();
            this.cmdAddGroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvJawabanMultiple)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pertanyaan";
            // 
            // txtPertanyaan
            // 
            this.txtPertanyaan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPertanyaan.Location = new System.Drawing.Point(128, 4);
            this.txtPertanyaan.Name = "txtPertanyaan";
            this.txtPertanyaan.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.txtPertanyaan.Size = new System.Drawing.Size(475, 92);
            this.txtPertanyaan.TabIndex = 2;
            this.txtPertanyaan.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Jawaban";
            // 
            // rbEssay
            // 
            this.rbEssay.AutoSize = true;
            this.rbEssay.Checked = true;
            this.rbEssay.Location = new System.Drawing.Point(128, 101);
            this.rbEssay.Name = "rbEssay";
            this.rbEssay.Size = new System.Drawing.Size(53, 17);
            this.rbEssay.TabIndex = 4;
            this.rbEssay.TabStop = true;
            this.rbEssay.Text = "Essay";
            this.rbEssay.UseVisualStyleBackColor = true;
            // 
            // txtJawabanEssay
            // 
            this.txtJawabanEssay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJawabanEssay.Location = new System.Drawing.Point(128, 124);
            this.txtJawabanEssay.Name = "txtJawabanEssay";
            this.txtJawabanEssay.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.txtJawabanEssay.Size = new System.Drawing.Size(475, 66);
            this.txtJawabanEssay.TabIndex = 5;
            this.txtJawabanEssay.Text = "";
            // 
            // rbMultiple
            // 
            this.rbMultiple.AutoSize = true;
            this.rbMultiple.Location = new System.Drawing.Point(128, 196);
            this.rbMultiple.Name = "rbMultiple";
            this.rbMultiple.Size = new System.Drawing.Size(61, 17);
            this.rbMultiple.TabIndex = 6;
            this.rbMultiple.Text = "Multiple";
            this.rbMultiple.UseVisualStyleBackColor = true;
            // 
            // gvJawabanMultiple
            // 
            this.gvJawabanMultiple.AllowUserToAddRows = false;
            this.gvJawabanMultiple.AllowUserToDeleteRows = false;
            this.gvJawabanMultiple.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvJawabanMultiple.Location = new System.Drawing.Point(128, 219);
            this.gvJawabanMultiple.Name = "gvJawabanMultiple";
            this.gvJawabanMultiple.RowHeadersVisible = false;
            this.gvJawabanMultiple.Size = new System.Drawing.Size(475, 129);
            this.gvJawabanMultiple.TabIndex = 7;
            // 
            // cmdAddMultiple
            // 
            this.cmdAddMultiple.Location = new System.Drawing.Point(227, 193);
            this.cmdAddMultiple.Name = "cmdAddMultiple";
            this.cmdAddMultiple.Size = new System.Drawing.Size(74, 23);
            this.cmdAddMultiple.TabIndex = 8;
            this.cmdAddMultiple.Text = "Add Pilihan";
            this.cmdAddMultiple.UseVisualStyleBackColor = true;
            this.cmdAddMultiple.Click += new System.EventHandler(this.cmdAddMultiple_Click);
            // 
            // cmdSimpan
            // 
            this.cmdSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSimpan.Location = new System.Drawing.Point(495, 412);
            this.cmdSimpan.Name = "cmdSimpan";
            this.cmdSimpan.Size = new System.Drawing.Size(108, 40);
            this.cmdSimpan.TabIndex = 9;
            this.cmdSimpan.Text = "Simpan";
            this.cmdSimpan.UseVisualStyleBackColor = true;
            this.cmdSimpan.Click += new System.EventHandler(this.cmdSimpan_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Group";
            // 
            // gvGroup
            // 
            this.gvGroup.AllowUserToAddRows = false;
            this.gvGroup.AllowUserToDeleteRows = false;
            this.gvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvGroup.ColumnHeadersVisible = false;
            this.gvGroup.Location = new System.Drawing.Point(205, 354);
            this.gvGroup.Name = "gvGroup";
            this.gvGroup.ReadOnly = true;
            this.gvGroup.RowHeadersVisible = false;
            this.gvGroup.Size = new System.Drawing.Size(169, 98);
            this.gvGroup.TabIndex = 11;
            // 
            // cmdAddGroup
            // 
            this.cmdAddGroup.Location = new System.Drawing.Point(128, 354);
            this.cmdAddGroup.Name = "cmdAddGroup";
            this.cmdAddGroup.Size = new System.Drawing.Size(71, 23);
            this.cmdAddGroup.TabIndex = 12;
            this.cmdAddGroup.Text = "Add Group";
            this.cmdAddGroup.UseVisualStyleBackColor = true;
            this.cmdAddGroup.Click += new System.EventHandler(this.cmdAddGroup_Click);
            // 
            // FormEntrySoal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 464);
            this.Controls.Add(this.cmdAddGroup);
            this.Controls.Add(this.gvGroup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdSimpan);
            this.Controls.Add(this.cmdAddMultiple);
            this.Controls.Add(this.gvJawabanMultiple);
            this.Controls.Add(this.rbMultiple);
            this.Controls.Add(this.txtJawabanEssay);
            this.Controls.Add(this.rbEssay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPertanyaan);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormEntrySoal";
            this.ShowIcon = false;
            this.Text = "Entri Soal";
            ((System.ComponentModel.ISupportInitialize)(this.gvJawabanMultiple)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtPertanyaan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbEssay;
        private System.Windows.Forms.RichTextBox txtJawabanEssay;
        private System.Windows.Forms.RadioButton rbMultiple;
        private System.Windows.Forms.DataGridView gvJawabanMultiple;
        private System.Windows.Forms.Button cmdAddMultiple;
        private System.Windows.Forms.Button cmdSimpan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gvGroup;
        private System.Windows.Forms.Button cmdAddGroup;
    }
}