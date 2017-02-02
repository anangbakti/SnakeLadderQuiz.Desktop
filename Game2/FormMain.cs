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
    public partial class FormMain : Form
    {
        private Game1 _game1;

        //public FormMain(Game1 game1)
        public FormMain()
        {
            InitializeComponent();

            _game1 = new Game1();
            _game1.FinishWalk += FinishWalk;

            this.Load += new EventHandler(FormMain_Load);
        }

        private void FinishWalk() {
            this.Invoke((MethodInvoker)delegate
            {
                cmdStart.Enabled = true;
            });                
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            Task.Run(() => _game1.Run());
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            if (_game1 != null)
            {
                _game1.RaiseStart = true;
                cmdStart.Enabled = false;
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            if (_game1 != null)
            {

                _game1.RaiseReset = true;
            }
        }
    }
}
