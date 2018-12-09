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
    public partial class FeedbackScreen : Form
    {
        TDatabase Database;
        TValidation Feedback;
        Composition TSong;
        Game1 Game;
        bool IsSaved;
        public static bool TryAgain;
        public FeedbackScreen(TDatabase inDatabase, TValidation inFeedback, Composition inTSong, Game1 inGame)
        {
            InitializeComponent();
            Database = inDatabase;
            Feedback = inFeedback;
            TSong = inTSong;
            Game = inGame;
            IsSaved = false;
            TryAgain = false;
        }

        private void FeedbackScreen_Load(object sender, EventArgs e)
        {
            TXT_Grade.Text = Feedback.GetGrade;
            TXT_Improvements.Text = Feedback.Improvements;
            TXT_Percentage.Text = string.Concat(Feedback.PercentageReturn.ToString("0.##"), "%");
            CHC_Passed.Checked = Feedback.IsPassed;

        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            DialogResult MsgResult;
            IsSaved = true;
            Database.AddSongAttempt(TSong.SongName, TSong.Difficulty.ToString(), (int)Feedback.PercentageReturn, Feedback.GetGrade);
            MsgResult = MessageBox.Show("Save is sucessful!", "Attempt Saved!", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        private void BTN_TryAgain_Click(object sender, EventArgs e)
        {
            DialogResult MsgResult;
            if (!IsSaved)
            {
                MsgResult = MessageBox.Show("Would you like to save?", "Save Attempt?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (MsgResult == DialogResult.Yes)
                {
                    IsSaved = true;
                    Database.AddSongAttempt(TSong.SongName, TSong.Difficulty.ToString(), (int)Feedback.PercentageReturn, Feedback.GetGrade);
                }
            }
            TryAgain = true;
            Form Menu = new SongMenu(Database, Game);
            Menu.Show();
            this.Dispose();
        }
        private void FeedbackScreen_FormClosing(object sender, FormClosingEventArgs e)
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
                Game.Dispose();
                this.Dispose();
            }
        }
    }
}
