using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeLadderQuiz.Desktop
{
    public partial class FormDaftarSoal : Form
    {

        private const int LIMITCONST = 2;
        private const int OFFSETCONST = 0;

        private int _limit;
        private int _offset;
        

        public FormDaftarSoal()
        {
            InitializeComponent();

            cmdFilter_Click(null, null);
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            _limit = LIMITCONST;
            _offset = OFFSETCONST;
            LoadGvDaftarSoal();
        }

        private void LoadGvDaftarSoal() {
            gvDaftarSoal.DataSource = Program.factory.GetSoal().GetAll(_limit, _offset);
            HideColumns();
            RenameColumns();
        }

        private void RenameColumns()
        {
            gvDaftarSoal.Columns[1].HeaderText = "Jenis";
            gvDaftarSoal.Columns[2].HeaderText = "Pertanyaan";
            gvDaftarSoal.Columns[3].HeaderText = "Jawaban";
            gvDaftarSoal.Columns[4].HeaderText = "Tgl. Buat";
            gvDaftarSoal.Columns[5].HeaderText = "Tgl. Last Update";
        }

        private void HideColumns() {
            gvDaftarSoal.Columns[0].Visible = false;
        }

        private void cmdPrev_Click(object sender, EventArgs e)
        {
            if (_offset == 0) return;
            _offset -= LIMITCONST;
            LoadGvDaftarSoal();
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            if (gvDaftarSoal.RowCount == 0) return;
            _offset += LIMITCONST;
            LoadGvDaftarSoal();

        }
    }
}
