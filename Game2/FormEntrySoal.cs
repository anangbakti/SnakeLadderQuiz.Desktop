using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using SnakeLadderQuiz.Data.Entities;

namespace SnakeLadderQuiz.Desktop
{
    public partial class FormEntrySoal : Form
    {

        private FormPilihGroup FrmPilihGroup = new FormPilihGroup();
        public List<GroupSoal> GroupTerpilih = new List<GroupSoal>();
        public List<SoalPilihanMultiple> Pilihans = new List<SoalPilihanMultiple>();

        public FormEntrySoal()
        {
            InitializeComponent();

            gvGroup.KeyDown += GvGroup_KeyDown;
            gvJawabanMultiple.CellClick += GvJawabanMultiple_CellClick;
            
        }
             
        private void GvJawabanMultiple_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gvJawabanMultiple.Columns["spm_pilihanbenar"].Index)
            {
                if (e.RowIndex < 0) return;

                // update Pilihans
                Pilihans[e.RowIndex].spm_pilihanbenar = !Pilihans[e.RowIndex].spm_pilihanbenar;
                
                if (Pilihans[e.RowIndex].spm_pilihanbenar)
                {
                    foreach (DataGridViewRow row in gvJawabanMultiple.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            row.Cells[e.ColumnIndex].Value = !Pilihans[e.RowIndex].spm_pilihanbenar;
                        }
                        else {
                            row.Cells[e.ColumnIndex].Value = Pilihans[e.RowIndex].spm_pilihanbenar;
                        }
                    }
                }
            }
            gvJawabanMultiple.RefreshEdit();
        }
        
        private void GvGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (gvGroup.Rows.Count == 0) return;
                var gsId = int.Parse(gvGroup.SelectedCells[0].OwningRow.Cells["gs_id"].Value.ToString());
                GroupTerpilih.Remove(GroupTerpilih.Find(i => i.gs_id == gsId));
                LoadGridGroupTerpilih();
            }
        }

        private void LoadGridGroupTerpilih() {
            gvGroup.DataSource = null;
            gvGroup.DataSource = GroupTerpilih;
            SetGridGroupProp();
        }

        private void LoadGridPilihan() {
            gvJawabanMultiple.DataSource = null;
            gvJawabanMultiple.DataSource = Pilihans;
            SetGridMultiple();
        }

        private void SetGridGroupProp() {
            gvGroup.Columns["gs_id"].Visible = false;
        }

        private void SetGridMultiple()
        {
            gvJawabanMultiple.Columns["spm_id"].Visible = false;
            gvJawabanMultiple.Columns["soal_id"].Visible = false;
            gvJawabanMultiple.Columns["spm_pilihan"].HeaderText = "Pilihan";
            gvJawabanMultiple.Columns["spm_pilihan"].Width = 373;
            gvJawabanMultiple.Columns["spm_pilihanbenar"].HeaderText = "Jawaban Benar";           
        }

        public void Edit(int soalId)
        {
            var soal = Program.factory.GetSoal().GetById(soalId);
            if (soal != null)
            {
                txtPertanyaan.Text = soal.Soal_Tanya;
            }
        }

        private void cmdAddGroup_Click(object sender, EventArgs e)
        {
            FrmPilihGroup.ShowDialog(this);
            if (FrmPilihGroup.DialogResult == DialogResult.OK) {
                if (FrmPilihGroup.GroupTerpilih.Count > 0)
                {
                    if (GroupTerpilih.Count == 0)
                    {
                        GroupTerpilih.AddRange(FrmPilihGroup.GroupTerpilih);
                    }
                    else
                    {
                        List<GroupSoal> newGs = new List<GroupSoal>();

                        foreach (var item in FrmPilihGroup.GroupTerpilih)
                        {
                            var itemCheck = GroupTerpilih.Find(i => i.gs_id == item.gs_id);
                            if (itemCheck == null)
                            {
                                newGs.Add(item);
                            }
                        }
                        if (newGs.Count > 0)
                        {
                            GroupTerpilih.AddRange(newGs);
                        }
                    }

                    LoadGridGroupTerpilih();
                }
            }
        }

        private void cmdAddMultiple_Click(object sender, EventArgs e)
        {
            string entryItemMultiple = Interaction.InputBox("Isi pilihan Multiple", "Isi pilihan Multiple");
            if (Pilihans.Count == 0)
            {
                Pilihans.Add(new SoalPilihanMultiple() { spm_pilihan = entryItemMultiple, spm_pilihanbenar =true });
            }
            else {
                Pilihans.Add(new SoalPilihanMultiple() { spm_pilihan = entryItemMultiple });
            }
            LoadGridPilihan();
        }
    }
        
}
