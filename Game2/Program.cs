using System;
using System.Windows.Forms;

namespace SnakeLadderQuiz.Desktop
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
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
