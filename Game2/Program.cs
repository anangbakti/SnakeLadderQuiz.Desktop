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
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    factory = new Factory(ConfigurationManager.ConnectionStrings["sqlite"].ConnectionString);
                    Form frm = new FormMain();
                    Application.Run(frm);
                }
                catch (Exception)
                {

                    throw;
                }
               
                //game.Run();
                
            //}
                
        }
    }
#endif
}
