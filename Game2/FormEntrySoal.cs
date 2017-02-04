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
    public partial class FormEntrySoal : Form
    {       

        public FormEntrySoal()
        {
            InitializeComponent();            
        }

        public void Edit(int soalId) {
            var soal = Program.factory.GetSoal().GetById(soalId);
            if (soal != null) {
                txtPertanyaan.Text = soal.Soal_Tanya;
                //SelectJenisInCombo(soal.Soal_Jenis);
            }
        }

        //private void SelectJenisInCombo(string Jenis) {
        //    bool found = false;
        //    foreach (var item in cmbJenis.Items)
        //    {
        //        if (item.ToString() == Jenis.ToUpper()) {
        //            cmbJenis.SelectedItem = item;
        //            found = true;
        //        }
        //    }
        //    if (!found) {
        //        cmbJenis.SelectedIndex = 0;
        //    }
        //}
    }
}
