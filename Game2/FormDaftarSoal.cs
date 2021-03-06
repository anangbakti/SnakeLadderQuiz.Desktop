﻿using System;
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

        private const int LIMITCONST = 10;
        private const int OFFSETCONST = 0;

        private int _limit;
        private int _offset;
        

        public FormDaftarSoal()
        {
            InitializeComponent();

            gvDaftarSoal.CellDoubleClick += GvDaftarSoal_CellDoubleClick;
            gvDaftarSoal.KeyDown += GvDaftarSoal_KeyDown;
            
            cmdFilter_Click(null, null);

            HideColumns();
            RenameColumns();
        }
        
        private void GvDaftarSoal_KeyDown(object sender, KeyEventArgs e)
        {
            if (gvDaftarSoal.Rows.Count == 0) return;

            if (MessageBox.Show("Yakin ingin menghapus soal ini?",
                "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.No) return; 

            var soalId = int.Parse(gvDaftarSoal.SelectedCells[0].OwningRow.Cells["soal_id"].Value.ToString());
            //delete pilihan multi by soalid
            Program.factory.GetSoalPilihanMultiple().DeleteBySoalId(soalId);
            //delete tag group by soalid
            Program.factory.GetSoalTagGroup().DeleteBySoalId(soalId);

            Program.factory.GetSoal().Delete(soalId);

            cmdFilter_Click(null, null);
        }

        private void GvDaftarSoal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            FormEntrySoal frmEntrySoal = new FormEntrySoal();
            frmEntrySoal.Update(int.Parse(gvDaftarSoal.Rows[e.RowIndex].Cells["soal_id"].Value.ToString()));
            frmEntrySoal.ShowDialog(this);

            cmdFilter_Click(null, null);
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            _limit = LIMITCONST;
            _offset = OFFSETCONST;
            LoadGvDaftarSoal();
        }

        private void LoadGvDaftarSoal() {
            gvDaftarSoal.DataSource = Program.factory.GetSoal().GetByPertanyaanDanNamaGroup(txtSoal.Text, 
                txtGroup.Text, _limit, _offset);
           
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

        private void cmdAddSoal_Click(object sender, EventArgs e)
        {
            FormEntrySoal frmEntrySoal = new FormEntrySoal();
            frmEntrySoal.ShowDialog(this);

            if (MessageBox.Show("Buat soal baru lagi ?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cmdAddSoal_Click(null, null);
            }
        }
    }
}
