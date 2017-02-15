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
using SnakeLadderQuiz.Data.Entities;

namespace SnakeLadderQuiz.Desktop
{
    public partial class FormMain : Form
    {
        private Game1 _game1;
        private int _startPlayerId = 0;
        private int _nextPlayerId = 0;
        private int? _lastGroupId = 0;
        private int? _lastSoalId = 0;

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
                    CheckWinner();
                });
            }
            catch (Exception)
            {                
            }                            
        }

        private void CheckWinner() {
            var playerWin = _game1.players.Find(i => i.Position == 99);
            if (playerWin != null)
            {
                var playerName = "";
                if (playerWin.Id == 0)
                {
                    playerName = txtPlayer1Name.Text;
                }
                else if (playerWin.Id == 1)
                {
                    playerName = txtPlayer2Name.Text;
                }
                else if (playerWin.Id == 2)
                {
                    playerName = txtPlayer3Name.Text;
                }
                else if (playerWin.Id == 3)
                {
                    playerName = txtPlayer4Name.Text;
                }
                else if (playerWin.Id == 4)
                {
                    playerName = txtPlayer5Name.Text;
                }

                MessageBox.Show("Congratulation Player " + (playerWin.Id + 1) + " " +  playerName+ " WIN !!!");
                cmdStart_Click(null, null);
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
            if (_game1 == null) return;
          
            ResetBackColorTextPlayerName();            
            SetNextPlayerId();

            if (PlayerAnsweredCorrect())
            {
                lblDiceNumber.Text = new Random().Next(1, 13).ToString();
                _game1.RollTheDice = int.Parse(lblDiceNumber.Text);
            }
            else {
                //wrong answer, no move
                lblDiceNumber.Text = "0";
                _game1.RollTheDice = 0;
            }         

            _game1.RaiseStart = true;
            cmdStart.Enabled = false;        
        }

        private int RandomSoalId(List<Soal> soals)
        {
            int result = 0;
            int jmlSoal = soals.Count;

            int randSoal = new Random().Next(1, jmlSoal + 1);
            randSoal = soals[randSoal - 1].Soal_Id;

            if (randSoal == _lastSoalId.Value)
            {
                if (jmlSoal == 1)
                {
                    result = randSoal;
                }
                else if (jmlSoal > 1)
                {
                    result = RandomSoalId(soals);
                }
            }
            else {
                result = randSoal;
                _lastSoalId = randSoal;
            }
            return result;
        }

        private int RandomGroupId(List<Group_Soal> groups) {
            int result = 0;
            int jmlGroup = groups.Count;

            int randGroup = new Random().Next(1, jmlGroup + 1);
            randGroup = groups[randGroup - 1].gs_id;

            if (randGroup == _lastGroupId.Value)
            {
                if (jmlGroup == 1)
                {
                    result = randGroup;
                }
                else if (jmlGroup > 1)
                {
                    result = RandomGroupId(groups);
                }
            }
            else {
                result = randGroup;
                _lastGroupId = randGroup;
            }

            return result;
        }

        private bool PlayerAnsweredCorrect() {
            // jika group > 0
            List<Group_Soal> groups = Program.factory.GetGroupSoal().GetAll();
            if (groups.Count > 0)
            {
                int randGroupId = RandomGroupId(groups);

                // count soal by group_id
                List<Soal> soals = Program.factory.GetSoal().GetByGroupId(randGroupId);
                // jika soal > 0
                if (soals.Count > 0)
                {
                    int randSoalId = RandomSoalId(soals);

                    //show dialog soal
                    var groupSoal = Program.factory.GetGroupSoal().GetBySoalId(randSoalId)[0];
                    var soal = Program.factory.GetSoal().GetById(randSoalId);
                    var multiples = Program.factory.GetSoalPilihanMultiple().GetBySoalId(randSoalId);

                    var frmShowQuiz = new FormShowQuiz(groupSoal, soal, multiples);
                    frmShowQuiz.ShowDialog(this);

                    if (frmShowQuiz.DialogResult == DialogResult.Yes)
                    {
                        return true;
                    }
                    else { return false; }
                }
                else {
                    // else jika soal = 0 
                    MessageBox.Show("No question on database, player permit to continue");
                    return true;
                }
            }
            else {
                // else jika group = 0
                MessageBox.Show("No question group tag on database, player permit to continue");
                return true;
            }
        }

        private bool SoalAda() {

            return false;
        }

        private void SetNextPlayerId() {
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
            else
            {
                _nextPlayerId += 1;
                if (_nextPlayerId == 5) _nextPlayerId = 0;
                SetTextBoxBackColorTomatoByPlayerId(_nextPlayerId, out namePlayer);
                MessageBox.Show("Next is Player " + (_nextPlayerId + 1) + " " + namePlayer );
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

        private void cmdDaftarSoal_Click(object sender, EventArgs e)
        {
            if (_frmDaftarSoal == null) {
                _frmDaftarSoal = new FormDaftarSoal();
            }
            _frmDaftarSoal.ShowDialog(this);
        }

        private FormDaftarSoal _frmDaftarSoal;
    }
}
