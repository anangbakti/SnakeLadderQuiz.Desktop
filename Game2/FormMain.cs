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
        private int _startPlayerId = 0;
        private int _nextPlayerId = 0;

        //public FormMain(Game1 game1)
        public FormMain()
        {
            InitializeComponent();

            _game1 = new Game1();
            _game1.FinishWalk += FinishWalk;

            this.Load += new EventHandler(FormMain_Load);
        }

        private void FinishWalk() {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    cmdStart.Enabled = true;
                    SetPositionValue();
                });
            }
            catch (Exception)
            {                
            }                            
        }

        private void SetPositionValue() {
            try
            {
                lblPositionPlayer1.Text = (_game1.players[0].Position + 1).ToString();
                lblPositionPlayer2.Text = (_game1.players[1].Position + 1).ToString();
                lblPositionPlayer3.Text = (_game1.players[2].Position + 1).ToString();
                lblPositionPlayer4.Text = (_game1.players[3].Position + 1).ToString();
                lblPositionPlayer5.Text = (_game1.players[4].Position + 1).ToString();
            }
            catch (Exception)
            {
            }         
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            Task.Run(() => _game1.Run());
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            if (_game1 != null)
            {
                ResetBackColorTextPlayerName();
                var namePlayer = "";
               
                if (_game1.players.All(i => i.Position == 0))
                {
                    _startPlayerId = new Random().Next(0, 5);
                    
                    SetTextBoxBackColorTomatoByPlayerId(_startPlayerId, out namePlayer);

                    _game1.StartPlayerId = _startPlayerId;
                    _game1.RaiseReset = true;
                    MessageBox.Show("Player " + (_startPlayerId + 1) + " " + namePlayer + " first");
                    _game1.RaiseReset = false;

                    _nextPlayerId = _startPlayerId;
                }
                else {
                    _nextPlayerId += 1;
                    if (_nextPlayerId == 5) _nextPlayerId = 0;
                    SetTextBoxBackColorTomatoByPlayerId(_nextPlayerId, out namePlayer);
                }              

                lblDiceNumber.Text = new Random().Next(1, 13).ToString();
                _game1.RollTheDice = int.Parse(lblDiceNumber.Text);

                _game1.RaiseStart = true;
                cmdStart.Enabled = false;
            }
        }

        private void SetTextBoxBackColorTomato(TextBox txtBox, out string name) {
            txtBox.BackColor = Color.Tomato;
            name = txtBox.Text;
        }

        private void SetTextBoxBackColorTomatoByPlayerId(int playerId, out string name) {
            name = "";          
            if (playerId == 0)
            {
                SetTextBoxBackColorTomato(txtPlayer1Name, out name);
            }
            else if (playerId == 1)
            {
                SetTextBoxBackColorTomato(txtPlayer2Name, out name);
            }
            else if (playerId == 2)
            {
                SetTextBoxBackColorTomato(txtPlayer3Name, out name);
            }
            else if (playerId == 3)
            {
                SetTextBoxBackColorTomato(txtPlayer4Name, out name);
            }
            else if (playerId == 4)
            {
                SetTextBoxBackColorTomato(txtPlayer5Name, out name);
            }
        }

        private void ResetBackColorTextPlayerName() {
            txtPlayer1Name.BackColor = Color.White;
            txtPlayer2Name.BackColor = Color.White;
            txtPlayer3Name.BackColor = Color.White;
            txtPlayer4Name.BackColor = Color.White;
            txtPlayer5Name.BackColor = Color.White;

        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            if (_game1 != null)
            {
                ResetBackColorTextPlayerName();
                _game1.RaiseReset = true;
            }
        }
    }
}
