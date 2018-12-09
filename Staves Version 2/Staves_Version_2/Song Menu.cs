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
    public partial class SongMenu : Form
    {
        TDatabase Database;
        public static Game1 Game;
        public static Composition TSong;
        public static bool Loadup;
        public static TDatabase Data;
        public static Form OriginalForm;
        public SongMenu(TDatabase inDatabase)
        {
            Loadup = false;
            Database = inDatabase;
            InitializeComponent();
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }
        public SongMenu(TDatabase inDatabase, Game1 inGame)
        {
            Loadup = true;
            Database = inDatabase;
            Game = inGame;
            InitializeComponent();
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }
        public SongMenu()
        {
            Loadup = false;
            Database = new TDatabase();
            Form Load = new LoginScreen(Database);
            Load.Show();
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
        }
        public static bool IsSongSelected { get { return Loadup; } set { Loadup = value; } }
        private void BTN_Launch_Click(object sender, EventArgs e)
        {
            string Song = CMB_SongList.Text;
            DialogResult MsgResult;
            string Output = "File Path not found, has the location changed?";
            string ExitMsg = "File Error";
            Database.UpdateSong(Song);
            LBL_File.DataBindings.Add("Text", Database.tblSongList, "FilePath");
            if (Database.PreviousHistory(Song))
            {
                LBL_Difficulty.DataBindings.Add("Text", Database.tblStudentAttempts, "Difficulty");
                try { TSong = new Composition("4/4", 107, LBL_File.Text, LBL_Difficulty.Text, Song); }
                catch
                {
                    MsgResult = MessageBox.Show(Output, ExitMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                try { TSong = new Composition("4/4", 107, LBL_File.Text, "SuperEasy", Song); }
                catch
                {
                    MsgResult = MessageBox.Show(Output, ExitMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (Loadup || Game != default(Game1))
            {
                TSong.InitaliseCompositionList();
                Game.TSong = TSong;
                Game.IsGameActive = true;
                Game.Validation = null;
                Game.Index = 0;
                Game.PressedNotes = "";
                Game.Restart = true;
            }
            else
            {
                Data = Database;
                Loadup = true;
                OriginalForm.Dispose();
            }
            this.Dispose();
        }

        private void SongMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult MsgResult;
            string Output = "Are you sure you would like to exit?";
            string ExitMsg = "Exiting App";
            MsgResult = MessageBox.Show(Output, ExitMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MsgResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                try { Game.Dispose(); }
                catch { }
                this.Dispose();
            }
        }

        private void SongMenu_Load(object sender, EventArgs e)
        {
            TDatabase Songs = Database;
            Songs.SearchSongListTable();
            CMB_SongList.DataSource = Songs.tblSongList;
            CMB_SongList.DisplayMember = "Song";
        }

        private void BTN_SignOut_Click(object sender, EventArgs e)
        {
            Form Loading = new LoginScreen(new TDatabase());
            Loading.Show();
            this.Dispose();
        }

        private void BTN_Help_Click(object sender, EventArgs e)
        {
            Form Help = new HelpScreen(this);
            this.Enabled = false;
            Help.Show();
        }
    }
}

