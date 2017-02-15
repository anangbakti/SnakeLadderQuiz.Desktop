using System;
using System.Windows.Forms;
using System.Configuration;
using SnakeLadderQuiz.Data;

namespace SnakeLadderQuiz.Desktop
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        public static Factory factory;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //using (var game = new Game1())
            //{
                try
                {
                    factory = new Factory(ConfigurationManager.ConnectionStrings["sqlite"].ConnectionString);

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Form frm = new FormMain();
                    //Form frm = new FormEntrySoal();
                    //Form frm = new FormPilihGroup();
                    //Form frm = new FormDaftarSoal();

                    ////get a soal
                    //var groupSoal = factory.GetGroupSoal().GetBySoalId(8)[0];
                    //var soal = factory.GetSoal().GetById(8);
                    //var multiples = factory.GetSoalPilihanMultiple().GetBySoalId(2);


                    //Form frm = new FormShowQuiz(groupSoal, soal, null);
                    Application.Run(frm);
            }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
               
                //game.Run();
                
            //}
                
        }

        public static DialogResult ShowInputDialog(ref string input, string caption, IWin32Window owner)
        {
            System.Drawing.Size size = new System.Drawing.Size(400, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = caption;

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog(owner);
            input = textBox.Text;
            return result;
        }

    }
#endif
}
