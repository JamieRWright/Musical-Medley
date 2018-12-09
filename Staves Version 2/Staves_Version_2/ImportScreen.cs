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
    public partial class ImportScreen : Form
    {
        TDatabase Database;
        public ImportScreen(TDatabase inDatabase)
        {
            Database = inDatabase;
            InitializeComponent();
            OFD_FileSearch.Filter = "txt files(*.txt) | *.txt";
        }
        private void BTN_Browse_Click(object sender, EventArgs e)
        {
            OFD_FileSearch.ShowDialog();
        }

        private void OFD_FileSearch_FileOk(object sender, CancelEventArgs e)
        {
            TXT_FilePath.Text = OFD_FileSearch.FileName;
        }

        private void BTN_Continue_Click(object sender, EventArgs e)
        {
            DialogResult MsgResult;
            string OutputError = string.Concat(TXT_FilePath.Text, "\nHas failed to be loaded");
            string ExitMsgError = "File Type Error";
            string OutputLoad = string.Concat(TXT_FilePath.Text, "\nHas loaded sucessfully!");
            string ExitMsgLoad = "File Added!";
            ImportFacility Import = new ImportFacility(TXT_FilePath.Text);
            if (Import.IsFileValid())
            {
                MsgResult = MessageBox.Show(OutputLoad, ExitMsgLoad, MessageBoxButtons.OK, MessageBoxIcon.Question);
                Database.AddSong(TXT_SongName.Text ,TXT_FilePath.Text);
                if (MsgResult == DialogResult.OK)
                {
                    Form Loadup = new LoginScreen(Database);
                    Loadup.Show();
                    this.Dispose();
                }
            }
            else
            {
                MsgResult = MessageBox.Show(OutputError, ExitMsgError, MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (MsgResult == DialogResult.OK)
                {
                    TXT_FilePath.Clear();
                }
            }
        }

        private void ImportScreen_FormClosing(object sender, FormClosingEventArgs e)
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
                Form Loadup = new LoginScreen(Database);
                Loadup.Show();
                this.Dispose();
            }
        }

        private void BTN_Delete_Click(object sender, EventArgs e)
        {
            Database.DeleteSong(TXT_SongName.Text);
            DialogResult MsgResult;
            string Output = "Song Deleted!";
            string ExitMsg = "Deleted!";
            MsgResult = MessageBox.Show(Output, ExitMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form Loadup = new LoginScreen(Database);
            Loadup.Show();
            this.Dispose();
        }
    }
}