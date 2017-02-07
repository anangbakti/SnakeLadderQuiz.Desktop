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
                    //Form frm = new FormMain();
                    Form frm = new FormEntrySoal();
                    //Form frm = new FormPilihGroup();
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
    }
#endif
}
