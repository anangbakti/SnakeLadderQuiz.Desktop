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

        private FormPilihGroup _frmPilihGroup = new FormPilihGroup();
        public List<GroupSoal> GroupTerpilih = new List<GroupSoal>();

        public FormEntrySoal()
        {
            InitializeComponent();
            
        }

        private void LoadGroupTerpilih() {
            gvGroup.DataSource = null;
            gvGroup.DataSource = GroupTerpilih;
            SetGridGroupProp();
        }

        private void SetGridGroupProp() {
            gvGroup.Columns["gs_id"].Visible = false;
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
            _frmPilihGroup.ShowDialog(this);
            if (_frmPilihGroup.DialogResult == DialogResult.OK) {
                if (_frmPilihGroup.GroupTerpilih.Count > 0)
                {
                    if (GroupTerpilih.Count == 0)
                    {
                        GroupTerpilih.AddRange(_frmPilihGroup.GroupTerpilih);
                    }
                    else
                    {
                        List<GroupSoal> newGs = new List<GroupSoal>();

                        foreach (var item in _frmPilihGroup.GroupTerpilih)
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

                    LoadGroupTerpilih();
                }
            }
        }
    }
        
}
