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
    public partial class FormEntrySoal : Form
    {

        private FormPilihGroup FrmPilihGroup = new FormPilihGroup();
        public List<Group_Soal> GroupTerpilih = new List<Group_Soal>();
        public List<Soal_Pilihan_Multiple> Pilihans = new List<Soal_Pilihan_Multiple>();
        private int? SoalId = null;

        public FormEntrySoal()
        {
            InitializeComponent();

            gvGroup.KeyDown += GvGroup_KeyDown;
            gvJawabanMultiple.CellClick += GvJawabanMultiple_CellClick;
            gvJawabanMultiple.KeyDown += GvJawabanMultiple_KeyDown;
            
        }

      

        public void Update(int soalId) {
            SoalId = soalId;

            //isi soal
            Soal soal = Program.factory.GetSoal().GetById(soalId);
            txtPertanyaan.Text = soal.Soal_Tanya;
            rbEssay.Checked = soal.Soal_Jenis == "ESSAY" ? true : false;
            rbMultiple.Checked = !rbEssay.Checked;

            //isi multiple jika bukan essay
            if (rbMultiple.Checked)
            {
                Pilihans = Program.factory.GetSoalPilihanMultiple().GetBySoalId(soalId);
                LoadGridPilihan();
            }
            else {
                txtJawabanEssay.Text = soal.Soal_Jawab;
            }

            //isi group
            GroupTerpilih = Program.factory.GetGroupSoal().GetBySoalId(soalId);
            LoadGridGroupTerpilih();
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

            // tricky point
            gvJawabanMultiple.RefreshEdit();
        }

        private void GvJawabanMultiple_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (gvJawabanMultiple.Rows.Count == 0) return;
                Pilihans.Remove(Pilihans.Find(i => 
                    i.spm_pilihan == gvJawabanMultiple.SelectedCells[0]
                    .OwningRow.Cells["spm_pilihan"].Value.ToString()));

                if (Pilihans.Count == 1) {
                    Pilihans[0].spm_pilihanbenar = true;
                }

                LoadGridPilihan();
            }
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
                        List<Group_Soal> newGs = new List<Group_Soal>();

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
            if (!rbMultiple.Checked) return;

            string entryItemMultiple="";
            Program.ShowInputDialog(ref entryItemMultiple, "Isi pilihan Multiple",this);
            //Interaction.InputBox("Isi pilihan Multiple", "Isi pilihan Multiple");
            if (string.IsNullOrEmpty(entryItemMultiple)) return;

            if (Pilihans.Count == 0)
            {
                Pilihans.Add(new Soal_Pilihan_Multiple() { spm_pilihan = entryItemMultiple, spm_pilihanbenar =true });
            }
            else {
                Pilihans.Add(new Soal_Pilihan_Multiple() { spm_pilihan = entryItemMultiple });
            }
            LoadGridPilihan();
        }

        private void cmdSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidateBeforeSimpan()) return;

            Soal soal = new Soal();
            soal.Soal_Jenis = rbEssay.Checked ? "ESSAY" : "MULTIPLE";
            soal.Soal_Tanya = txtPertanyaan.Text.Trim();
            soal.Soal_Jawab = rbEssay.Checked ? txtJawabanEssay.Text.Trim() : "";

            if (!SoalId.HasValue)
            {
                //Insert mode                
                Program.factory.GetSoal().Insert(soal);

                SoalId = Program.factory.GetBase().GetLastSeq("SOAL").Value;
            }
            else {
                //Update mode
                soal.Soal_Id = SoalId.Value;
                Program.factory.GetSoal().Update(soal);
            }

            //delete pilihan multi by soalid
            Program.factory.GetSoalPilihanMultiple().DeleteBySoalId(SoalId.Value);
            //insert pilihan multi by soalid
            foreach (var item in Pilihans)
            {
                item.soal_id = SoalId.Value;
                Program.factory.GetSoalPilihanMultiple().Insert(item);
            }

            //delete tag group by soalid
            Program.factory.GetSoalTagGroup().DeleteBySoalId(SoalId.Value);
            //insert tag group by soalid
            foreach (var item in GroupTerpilih)
            {
                Soal_Tag_Group stg = new Soal_Tag_Group()
                {
                    soal_id = SoalId.Value,
                    gs_id = item.gs_id
                };
                Program.factory.GetSoalTagGroup().Insert(stg);
            }
            
            Close();
        }

        private bool ValidateBeforeSimpan() {
            if (string.IsNullOrEmpty(txtPertanyaan.Text)) {
                MessageBox.Show("Silahkan isi Pertanyaan terlebih dulu.");
                txtPertanyaan.Focus();
                return false;
            }
            if (rbEssay.Checked && string.IsNullOrEmpty(txtJawabanEssay.Text))
            {
                MessageBox.Show("Silahkan isi Jawaban Essay terlebih dulu.");
                txtJawabanEssay.Focus();
                return false;
            }
            if (rbMultiple.Checked && gvJawabanMultiple.Rows.Count <= 1)
            {
                MessageBox.Show("Silahkan isi Jawaban Multiple min. > 1 terlebih dulu.");
                cmdAddMultiple_Click(null, null);
                return false;
            }
            if (gvGroup.Rows.Count == 0) {
                MessageBox.Show("Silahkan isi kategori Group dari pertanyaan ini.");
                cmdAddGroup_Click(null, null);
                return false;
            }       
            return true;
        }
    }
        
}
