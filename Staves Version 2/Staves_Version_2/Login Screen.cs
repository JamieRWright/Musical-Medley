using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Staves_Version_2
{
    public partial class LoginScreen : Form
    {
        TDatabase Database;
        public LoginScreen(TDatabase inDatabase)
        {
            Database = inDatabase;
            InitializeComponent();
        }
        private void BTN_Login_Click(object sender, EventArgs e)
        {
            DialogResult MsgResult;
            string Output = "Username or Password is incorrect, please try again";
            string ExitMsg = "Loadup Error";
            Database.UpdateLoginCredentials(TXT_Username.Text, TXT_Password.Text);
            Database.FillStudentsTbl();
            if (Database.ComparisonStudents())
            {
                Form Menu = new SongMenu(Database);
                Menu.Show();
                this.Dispose();
            }
            else
            {
                MsgResult = MessageBox.Show(Output, ExitMsg, MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (MsgResult == DialogResult.OK)
                {
                    TXT_Password.Clear();
                    TXT_Username.Clear();
                }
            }
        }

        private void Loadup_Screen_FormClosing(object sender, FormClosingEventArgs e)
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
                try { SongMenu.OriginalForm.Dispose(); }
                catch { }
                try { SongMenu.Game.Dispose(); }
                catch { }
                this.Dispose();
            }
        }

        private void BTN_Register_Click(object sender, EventArgs e)
        {
            Form Register = new RegisterScreen(Database);
            Register.Show();
            this.Dispose();
        }

        private void BTN_Import_Click(object sender, EventArgs e)
        {
            DialogResult MsgResult;
            Database.UpdateLoginCredentials(TXT_Username.Text, TXT_Password.Text);       
            if (Database.ComparisonTeachers())
            {
                Form Import = new ImportScreen(Database);
                Import.Show();
                this.Dispose();
            }
            else
            {
                MsgResult = MessageBox.Show("You must be a teacher to import!", "Incorrect Login!!!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (MsgResult == DialogResult.OK)
                {
                    TXT_Password.Clear();
                    TXT_Username.Clear();
                }
            }
        }

    }
}
