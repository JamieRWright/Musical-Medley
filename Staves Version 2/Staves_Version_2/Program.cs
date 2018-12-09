using System;
using System.Windows.Forms;

namespace Staves_Version_2
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form Load = new SongMenu();
            SongMenu.OriginalForm = Load;//Saves the original form to dispose at the end
            Application.Run(Load);
            if (SongMenu.IsSongSelected)
            {
                Composition TSong = SongMenu.TSong;
                TDatabase Database = SongMenu.Data;
                using (Game1 game = new Game1(TSong, Database))
                {
                    game.Run();
                }
            }
        }
#endif
    }
}



