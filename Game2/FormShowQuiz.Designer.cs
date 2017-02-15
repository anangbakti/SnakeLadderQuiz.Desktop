namespace SnakeLadderQuiz.Desktop
{
    partial class FormShowQuiz
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
            this.lblGroup = new System.Windows.Forms.Label();
            this.layoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.txtSoal = new System.Windows.Forms.TextBox();
            this.cmdJawab = new System.Windows.Forms.Button();
            this.layoutPanelJawab = new System.Windows.Forms.TableLayoutPanel();
            this.txtJawab = new System.Windows.Forms.TextBox();
            this.lbJawabGanda = new System.Windows.Forms.ListBox();
            this.layoutPanelMain.SuspendLayout();
            this.layoutPanelJawab.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.Location = new System.Drawing.Point(3, 0);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(101, 25);
            this.lblGroup.TabIndex = 0;
            this.lblGroup.Text = "lblGroup";
            // 
            // layoutPanelMain
            // 
            this.layoutPanelMain.ColumnCount = 1;
            this.layoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanelMain.Controls.Add(this.lblGroup, 0, 0);
            this.layoutPanelMain.Controls.Add(this.txtSoal, 0, 1);
            this.layoutPanelMain.Controls.Add(this.cmdJawab, 0, 3);
            this.layoutPanelMain.Controls.Add(this.layoutPanelJawab, 0, 2);
            this.layoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.layoutPanelMain.Name = "layoutPanelMain";
            this.layoutPanelMain.RowCount = 4;
            this.layoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.layoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.layoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.layoutPanelMain.Size = new System.Drawing.Size(586, 412);
            this.layoutPanelMain.TabIndex = 2;
            // 
            // txtSoal
            // 
            this.txtSoal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoal.Location = new System.Drawing.Point(3, 33);
            this.txtSoal.Multiline = true;
            this.txtSoal.Name = "txtSoal";
            this.txtSoal.ReadOnly = true;
            this.txtSoal.Size = new System.Drawing.Size(580, 138);
            this.txtSoal.TabIndex = 1;
            this.txtSoal.Text = "txtSoal";
            // 
            // cmdJawab
            // 
            this.cmdJawab.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdJawab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdJawab.Location = new System.Drawing.Point(496, 368);
            this.cmdJawab.Name = "cmdJawab";
            this.cmdJawab.Size = new System.Drawing.Size(87, 41);
            this.cmdJawab.TabIndex = 2;
            this.cmdJawab.Text = "OK";
            this.cmdJawab.UseVisualStyleBackColor = true;
            this.cmdJawab.Click += new System.EventHandler(this.cmdJawab_Click);
            // 
            // layoutPanelJawab
            // 
            this.layoutPanelJawab.ColumnCount = 2;
            this.layoutPanelJawab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanelJawab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanelJawab.Controls.Add(this.txtJawab, 0, 0);
            this.layoutPanelJawab.Controls.Add(this.lbJawabGanda, 1, 0);
            this.layoutPanelJawab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanelJawab.Location = new System.Drawing.Point(3, 177);
            this.layoutPanelJawab.Name = "layoutPanelJawab";
            this.layoutPanelJawab.RowCount = 1;
            this.layoutPanelJawab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanelJawab.Size = new System.Drawing.Size(580, 185);
            this.layoutPanelJawab.TabIndex = 3;
            // 
            // txtJawab
            // 
            this.txtJawab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJawab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJawab.Location = new System.Drawing.Point(3, 3);
            this.txtJawab.Multiline = true;
            this.txtJawab.Name = "txtJawab";
            this.txtJawab.Size = new System.Drawing.Size(284, 179);
            this.txtJawab.TabIndex = 0;
            // 
            // lbJawabGanda
            // 
            this.lbJawabGanda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbJawabGanda.FormattingEnabled = true;
            this.lbJawabGanda.Location = new System.Drawing.Point(293, 3);
            this.lbJawabGanda.Name = "lbJawabGanda";
            this.lbJawabGanda.Size = new System.Drawing.Size(284, 179);
            this.lbJawabGanda.TabIndex = 1;
            // 
            // FormShowQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 412);
            this.Controls.Add(this.layoutPanelMain);
            this.MaximizeBox = false;
            this.Name = "FormShowQuiz";
            this.ShowIcon = false;
            this.Text = "Question";
            this.layoutPanelMain.ResumeLayout(false);
            this.layoutPanelMain.PerformLayout();
            this.layoutPanelJawab.ResumeLayout(false);
            this.layoutPanelJawab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TableLayoutPanel layoutPanelMain;
        private System.Windows.Forms.TextBox txtSoal;
        private System.Windows.Forms.Button cmdJawab;
        private System.Windows.Forms.TableLayoutPanel layoutPanelJawab;
        private System.Windows.Forms.TextBox txtJawab;
        private System.Windows.Forms.ListBox lbJawabGanda;
    }
}