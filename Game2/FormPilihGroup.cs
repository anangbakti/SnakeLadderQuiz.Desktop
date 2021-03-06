﻿using System;
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
    public partial class FormPilihGroup : Form
    {
        public List<Group_Soal> GroupTerpilih = new List<Group_Soal>();

        public FormPilihGroup()
        {
            InitializeComponent();
            
            gvGroupSoal.KeyDown += GvGroupSoal_KeyDown;
            txtPilihGroup.TextChanged += TxtPilihGroup_TextChanged;
                        
            LoadData();
            SetPropGrid();
        }

        private void TxtPilihGroup_TextChanged(object sender, EventArgs e)
        {
            if (txtPilihGroup.Text.Length > 1)
            {
                gvGroupSoal.DataSource = Program.factory.GetGroupSoal().GetAllByName(txtPilihGroup.Text);
            }
            else {
                LoadData();
            }
        }

        private void GvGroupSoal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) {
                if (gvGroupSoal.Rows.Count == 0) return;
                
                var gsName = gvGroupSoal.SelectedCells[0].OwningRow.Cells["gs_name"].Value;
                var gsId = int.Parse(gvGroupSoal.SelectedCells[0].OwningRow.Cells["gs_id"].Value.ToString());
                if (MessageBox.Show("Yakin ingin menghapus " + gsName + "?", "Hapus group", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    Program.factory.GetGroupSoal().Delete(gsId);
                    LoadData();
                }
            }
        }

        private void cmdAddGroup_Click(object sender, EventArgs e)
        {
            string entryGroupName = "";
            Program.ShowInputDialog(ref entryGroupName, "Entri nama Group",this);
            if (!string.IsNullOrEmpty(entryGroupName))
            {
                if (Program.factory.GetGroupSoal().NameExist(entryGroupName))
                {
                    MessageBox.Show(entryGroupName + " sudah terdata.");
                }
                else
                {
                    Program.factory.GetGroupSoal().Insert(entryGroupName);
                    LoadData();
                }
            }
        }

        private void LoadData() {
            gvGroupSoal.DataSource = Program.factory.GetGroupSoal().GetAll();
        }

        private void SetPropGrid() {
            gvGroupSoal.Columns["gs_id"].Visible = false;
            gvGroupSoal.Columns["gs_name"].HeaderText = "Nama Group";
            foreach (DataGridViewColumn item in gvGroupSoal.Columns)
            {
                item.ReadOnly = true;
            }

            gvGroupSoal.Columns[0].ReadOnly = false;
        }

        private void cmdPilihGroup_Click(object sender, EventArgs e)
        {
            GroupTerpilih = new List<Group_Soal>();
            foreach (DataGridViewRow row in gvGroupSoal.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ColumnCheckBox"];
                if (chk.Value != null && bool.Parse(chk.Value.ToString()) == true)
                {
                    Group_Soal gs = new Group_Soal()
                    {
                        gs_id = int.Parse(chk.OwningRow.Cells["gs_id"].Value.ToString()),
                        gs_name = chk.OwningRow.Cells["gs_name"].Value.ToString()
                    };

                    GroupTerpilih.Add(gs);                 
                }
            }
           
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
