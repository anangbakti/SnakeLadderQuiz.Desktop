using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeLadderQuiz.Data.Entities;

namespace SnakeLadderQuiz.Desktop
{
    public partial class FormShowQuiz : Form
    {
        private Group_Soal _group;
        private Soal _soal;
        private List<Soal_Pilihan_Multiple> _soalPilihanMultiples;
        private bool answered = false;

        public FormShowQuiz(Group_Soal group,Soal soal, List<Soal_Pilihan_Multiple> multiples)
        {
            InitializeComponent();

            this.DialogResult = DialogResult.No;
            this.FormClosing += FormShowQuiz_FormClosing;
            _group = group;
            _soal = soal;
            _soalPilihanMultiples = multiples;

            Fill();
        }

        private void FormShowQuiz_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!answered) {
                e.Cancel = true;
            }           
        }

        private void Fill() {
            lblGroup.Text = _group.gs_name;
            txtSoal.Text = _soal.Soal_Tanya;
            if (_soal.Soal_Jenis == "MULTIPLE") {
                layoutPanelJawab.ColumnStyles[0].SizeType = SizeType.Absolute;
                layoutPanelJawab.ColumnStyles[0].Width = 0;
            } else {
                layoutPanelJawab.ColumnStyles[1].SizeType = SizeType.Absolute;
                layoutPanelJawab.ColumnStyles[1].Width = 0;
            }
            IsiListBox();
        }

        private void IsiListBox() {
            lbJawabGanda.DataSource = _soalPilihanMultiples;
            lbJawabGanda.DisplayMember = "spm_pilihan";
        }

        private void cmdJawab_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Lock this answer?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            answered = true;

            if (_soal.Soal_Jenis == "MULTIPLE")
            {
                Soal_Pilihan_Multiple spm = (Soal_Pilihan_Multiple)lbJawabGanda.SelectedItem;
                if (spm.spm_pilihanbenar)
                {
                    this.DialogResult = DialogResult.Yes;                  
                    MessageBox.Show("Correct!");
                }
            }
            else
            {
                if (_soal.Soal_Jawab.Trim() == txtJawab.Text.Trim())
                {
                    this.DialogResult = DialogResult.Yes;
                    MessageBox.Show("Correct!");                    
                }
            }
            if (this.DialogResult == DialogResult.None) {
                MessageBox.Show("Wrong answer!");
            }
            Close();
        }
    }
}
