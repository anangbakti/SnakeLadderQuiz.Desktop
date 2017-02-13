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

        public FormShowQuiz()
        {
            InitializeComponent();
        }

        private void Fill() {
            lblGroup.Text = _group.gs_name;
            txtSoal.Text = _soal.Soal_Tanya;
            txtJawab.Text = _soal.Soal_Jawab;
            IsiListBox();
        }

        private void IsiListBox() {
            lbJawabGanda.DataSource = _soalPilihanMultiples;
            lbJawabGanda.DisplayMember = "spm_pilihan";
        }
    }
}
