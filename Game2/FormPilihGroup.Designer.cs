namespace SnakeLadderQuiz.Desktop
{
    partial class FormPilihGroup
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
            this.txtPilihGroup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gvGroupSoal = new System.Windows.Forms.DataGridView();
            this.ColumnCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmdPilihGroup = new System.Windows.Forms.Button();
            this.cmdAddGroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvGroupSoal)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPilihGroup
            // 
            this.txtPilihGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPilihGroup.Location = new System.Drawing.Point(143, 13);
            this.txtPilihGroup.Name = "txtPilihGroup";
            this.txtPilihGroup.Size = new System.Drawing.Size(332, 22);
            this.txtPilihGroup.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ketik Group";
            // 
            // gvGroupSoal
            // 
            this.gvGroupSoal.AllowUserToAddRows = false;
            this.gvGroupSoal.AllowUserToDeleteRows = false;
            this.gvGroupSoal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvGroupSoal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheckBox});
            this.gvGroupSoal.Location = new System.Drawing.Point(17, 41);
            this.gvGroupSoal.Name = "gvGroupSoal";
            this.gvGroupSoal.Size = new System.Drawing.Size(458, 150);
            this.gvGroupSoal.TabIndex = 2;
            // 
            // ColumnCheckBox
            // 
            this.ColumnCheckBox.HeaderText = "Pilih";
            this.ColumnCheckBox.Name = "ColumnCheckBox";
            // 
            // cmdPilihGroup
            // 
            this.cmdPilihGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPilihGroup.Location = new System.Drawing.Point(17, 200);
            this.cmdPilihGroup.Name = "cmdPilihGroup";
            this.cmdPilihGroup.Size = new System.Drawing.Size(139, 60);
            this.cmdPilihGroup.TabIndex = 4;
            this.cmdPilihGroup.Text = "Pilih Group";
            this.cmdPilihGroup.UseVisualStyleBackColor = true;
            // 
            // cmdAddGroup
            // 
            this.cmdAddGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddGroup.Location = new System.Drawing.Point(312, 200);
            this.cmdAddGroup.Name = "cmdAddGroup";
            this.cmdAddGroup.Size = new System.Drawing.Size(163, 60);
            this.cmdAddGroup.TabIndex = 5;
            this.cmdAddGroup.Text = "Tambah Group";
            this.cmdAddGroup.UseVisualStyleBackColor = true;
            this.cmdAddGroup.Click += new System.EventHandler(this.cmdAddGroup_Click);
            // 
            // FormPilihGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 269);
            this.Controls.Add(this.cmdAddGroup);
            this.Controls.Add(this.cmdPilihGroup);
            this.Controls.Add(this.gvGroupSoal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPilihGroup);
            this.MaximizeBox = false;
            this.Name = "FormPilihGroup";
            this.ShowIcon = false;
            this.Text = "Pilih Group";
            ((System.ComponentModel.ISupportInitialize)(this.gvGroupSoal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPilihGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvGroupSoal;
        private System.Windows.Forms.Button cmdPilihGroup;
        private System.Windows.Forms.Button cmdAddGroup;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheckBox;
    }
}