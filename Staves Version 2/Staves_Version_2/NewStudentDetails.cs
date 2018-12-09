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
    public partial class NewStudentDetails : Form
    {
        TDatabase Database;
        bool _IsTeacher;
        string _FirstName, _LastName;
        public NewStudentDetails(TDatabase inDatabase, string FirstName, bool IsTeacher)
        {
            _FirstName = FirstName;
            _IsTeacher = IsTeacher;
            Database = inDatabase;
            InitializeComponent();
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            Form Loadup = new LoginScreen(Database);
            Loadup.Show();
            this.Dispose();
        }

        private void NewStudentDetails_Load(object sender, EventArgs e)
        {
            if (_IsTeacher)
            {
                Database.SearchTeacher(_FirstName);
                LBL_Title.Text = "Teacher Details";
                LBL_Username.Text = "Teacher ID";
                TXT_FirstName.Text = "Teacher Name";
                TXT_FirstName.DataBindings.Add("Text", Database.tblTeachers, "TeacherName");
                TXT_Username.DataBindings.Add("Text", Database.tblTeachers, "TeacherID");
                TXT_Pass.DataBindings.Add("Text", Database.tblTeachers, "Passwords");

            }
            else
            {
                TXT_Username.DataBindings.Add("Text", Database.tblStudents, "Username");
                TXT_Pass.DataBindings.Add("Text", Database.tblStudents, "Passwords");
                TXT_FirstName.Text = _FirstName;
            }
        }
    }
}
