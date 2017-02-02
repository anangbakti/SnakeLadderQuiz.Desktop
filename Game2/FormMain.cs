using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
                SetPositionValue();
            });                
        }

        private void SetPositionValue() {
            lblPositionPlayer1.Text = (_game1.players[0].Position + 1).ToString();
            lblPositionPlayer2.Text = (_game1.players[1].Position + 1).ToString();
            lblPositionPlayer3.Text = (_game1.players[2].Position + 1).ToString();
            lblPositionPlayer4.Text = (_game1.players[3].Position + 1).ToString();
            lblPositionPlayer5.Text = (_game1.players[4].Position + 1).ToString();
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            Task.Run(() => _game1.Run());
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            if (_game1 != null)
            {
                lblDiceNumber.Text = new Random().Next(1, 13).ToString();
                _game1.RollTheDice = int.Parse(lblDiceNumber.Text);

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
