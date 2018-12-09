using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Staves_Version_2
{
    public partial class PauseScreen : Form
    {
        Game1 Game;
        TDatabase Database;
        public PauseScreen(Game1 inGame, TDatabase inData)
        {
            InitializeComponent();
            Game = inGame;
            Database = inData;
        }

        private void BTN_Continue_Click(object sender, EventArgs e)
        {
            Game.Restart = true;
            this.Dispose();
        }

        private void BTN_Help_Click(object sender, EventArgs e)
        {
            Form Help = new HelpScreen(this);
            this.Enabled = false;
            Help.Show();
        }
        private void BTN_Exit_Click(object sender, EventArgs e)
        {
            Form Menu = new SongMenu(Database, Game);
            Menu.Show();
            this.Dispose();
        }

        private void PauseScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Game.Restart = true;
            this.Dispose();
        }
    }
}
