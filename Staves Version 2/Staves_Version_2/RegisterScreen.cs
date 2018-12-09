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
    public partial class RegisterScreen : Form
    {
        TDatabase Database;
        public RegisterScreen(TDatabase inDatabase)
        {
            Database = inDatabase;
            InitializeComponent();
        }
        private void RegisterScreen_Load(object sender, EventArgs e)
        {
        }
        private void PasswordJokes(string Password) 
        {
            DialogResult MsgResult;
            Password = Password.ToLower();
            switch (Password)
            {
                case "beefstew": 
                    MsgResult = MessageBox.Show("Your password is not stroganoff!", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    if (MsgResult == DialogResult.OK)
                    {
                        TXT_Password.Clear();
                        TXT_PassReEnter.Clear();
                    }
                    break;
                case "1forest1":
                    MsgResult = MessageBox.Show("You are not forest gump", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    if (MsgResult == DialogResult.OK)
                    {
                        TXT_Password.Clear();
                        TXT_PassReEnter.Clear();
                    }
                    break;
            }
        }
        private void BTN_Register_Click(object sender, EventArgs e)
        {
            DialogResult MsgResult;
            PasswordJokes(TXT_Password.Text);
            bool IsValid = TXT_Password.Text != "" && TXT_FirstName.Text != "";
            if (IsValid || (!CHC_IsTeacher.Checked && IsValid && TXT_Username.Text != ""))
            {
                if (TXT_Password.Text == TXT_PassReEnter.Text)
                {
                    Database.UpdateLoginCredentials(TXT_TeacherID.Text, TXT_TeacherPass.Text);
                    if (Database.ComparisonTeachers())
                    {
                        if (CHC_IsTeacher.Checked)
                        {
                            Database.AddTeacher(TXT_FirstName.Text, TXT_Password.Text);
                            MsgResult = MessageBox.Show("Teacher Added Sucessfully", "Teacher Added", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            Form StudentDetails = new NewStudentDetails(Database, TXT_FirstName.Text, true);
                            StudentDetails.Show();
                            this.Hide();
                        }
                        else
                        {
                            Database.AddStudent(TXT_FirstName.Text, TXT_Username.Text, TXT_Password.Text, TXT_TeacherID.Text);
                            MsgResult = MessageBox.Show("Student Added Sucessfully", "Student Added", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            Database.UpdateLoginCredentials(TXT_Username.Text, TXT_Password.Text);
                            Form StudentDetails = new NewStudentDetails(Database, TXT_FirstName.Text, false);
                            StudentDetails.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MsgResult = MessageBox.Show("You must have your teachers correct details!", "Incorrect Teacher!!!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
                else
                {
                    MsgResult = MessageBox.Show("Your password is not the same!", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    if (MsgResult == DialogResult.OK)
                    {
                        TXT_Password.Clear();
                        TXT_PassReEnter.Clear();
                    }
                }
            }
            else
            {
                MsgResult = MessageBox.Show("There is blank fields!", "Credentials Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (MsgResult == DialogResult.OK)
                {
                    TXT_Password.Clear();
                    TXT_PassReEnter.Clear();
                }
            }
        }
        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            Form Loadup = new LoginScreen(Database);
            Loadup.Show();
            this.Dispose();
        }

        private void BTN_Delete_Click(object sender, EventArgs e)
        {
            DialogResult MsgResult;
            Database.UpdateLoginCredentials(TXT_TeacherID.Text, TXT_TeacherPass.Text);
            if (Database.ComparisonTeachers())
            {
                Database.UpdateLoginCredentials(TXT_Username.Text, TXT_Password.Text);
                if (Database.ComparisonStudents())
                {
                    MsgResult = MessageBox.Show("Would you like to delete this student?", "Deleting Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (MsgResult == DialogResult.Yes)
                    {
                        Database.DeleteStudent();
                        MessageBox.Show("Student Deleted!");
                        Form Loadup = new LoginScreen(Database);
                        Loadup.Show();
                        this.Dispose();
                    }
                }
                else
                {
                    Database.SearchTeacher(TXT_FirstName.Text);
                    MsgResult = MessageBox.Show("Would you like to delete this teacher?", "Deleting Teacher", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (MsgResult == DialogResult.Yes)
                    {
                        Database.DeleteTeacher();
                        MessageBox.Show("Teacher Deleted!");
                        Form Loadup = new LoginScreen(Database);
                        Loadup.Show();
                        this.Dispose();
                    }


                }
            }
            else
            {
                MsgResult = MessageBox.Show("Invalid Teacher Credentials", "Invalid Details", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (MsgResult == DialogResult.Yes)
                {
                    TXT_TeacherID.Clear();
                    TXT_TeacherPass.Clear();
                }
            }
        }

        private void CHC_IsTeacher_CheckedChanged(object sender, EventArgs e)
        {
            if (CHC_IsTeacher.Checked)
            {
                TXT_Username.Hide();
                LBL_Username.Hide();
                LBL_Help.Text = "*To delete a teacher use these fields";
                LBL_FirstName.Text = "Teacher Name";
                LBL_Password.Text = "Teacher Password";
            }
            else
            {
                TXT_Username.Show();
                LBL_Username.Show();
                LBL_Help.Text = "*You need a teacher to help you with this step!";
                LBL_FirstName.Text = "First Name";
                LBL_Password.Text = "Password";
            }
        }
    }
}
