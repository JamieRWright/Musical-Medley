﻿using System;
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
    public class TDatabase
    {
        private OleDbCommandBuilder _cbS, _cbSA, _cbSL, _cbT;
        protected OleDbDataAdapter _daTblStudents, _daTblTeachers, _daTblStudentAttempts, _daTblSongList;
        private const string CONNECTION = "Provider=SQLOLEDB;Data Source=.\\SQLOLEDB;Initial Catalog=StudentRecords;User ID=SA;Password=Pa$$w0rd;";
        private DataTable _tblStudentAttempts, _tblTeachers, _tblStudents, _tblSongList;
        private string _SQLTeacher, _SQLStudentAttempts, _SQLStudents, _SQLSongList, _Username, _Password;

        public TDatabase()
        {
            _tblTeachers = new DataTable();
            _tblStudentAttempts = new DataTable();
            _tblStudents = new DataTable();
            _tblSongList = new DataTable();
            _SQLSongList = "SELECT * FROM SongList;";
            _SQLTeacher = "SELECT TeacherID, Passwords from Teachers;";
            _SQLStudents = "SELECT * FROM Students;";
            _SQLStudentAttempts = "SELECT SongPlayed, Grade, Difficulty from SongAttempts";
            _daTblStudents = new OleDbDataAdapter(_SQLStudents, CONNECTION);
            _daTblStudentAttempts = new OleDbDataAdapter(_SQLStudentAttempts, CONNECTION);
            _daTblTeachers = new OleDbDataAdapter(_SQLTeacher, CONNECTION);
            _daTblSongList = new OleDbDataAdapter(_SQLSongList, CONNECTION);
            FillStudentsTbl();
            FillTeachersTbl();
            FillStudentAttemptsTbl();
            FillSongListTbl();
            _cbS = new OleDbCommandBuilder(_daTblStudents);
            _cbSA = new OleDbCommandBuilder(_daTblStudentAttempts);
            _cbSL = new OleDbCommandBuilder(_daTblSongList);
            _cbT = new OleDbCommandBuilder(_daTblTeachers);

        }
        private void SearchFullTable(string TableName, ref OleDbDataAdapter DataAdapter, ref OleDbCommandBuilder CMD)
        {
            string Command = string.Concat("SELECT * FROM ", TableName);
            DataAdapter = new OleDbDataAdapter(Command, CONNECTION);
            CMD = new OleDbCommandBuilder(DataAdapter);
        }
        public void SearchSongListTable()
        {
            string Command = string.Concat("SELECT * FROM SongList");
            _daTblSongList = new OleDbDataAdapter(Command, CONNECTION);
            _cbSL = new OleDbCommandBuilder(_daTblSongList);
            FillSongListTbl();
        }
        public void SearchSongListTable(string Song)
        {
            string Command = string.Concat("SELECT * FROM SongList WHERE SongList.Song = '", Song, "'");
            _daTblSongList = new OleDbDataAdapter(Command, CONNECTION);
            _cbSL = new OleDbCommandBuilder(_daTblSongList);
            FillSongListTbl();
        }
        public void SearchTeacher(string Name)
        {
            string Command = string.Concat("SELECT * FROM Teachers WHERE TeacherName = '", Name, "';");
            _daTblTeachers = new OleDbDataAdapter(Command, CONNECTION);
            _cbT = new OleDbCommandBuilder(_daTblTeachers);
            FillTeachersTbl();
        }
        public bool PreviousHistory(string Song)
        {
            try { _SQLStudentAttempts = string.Concat("SELECT * FROM SongAttempts WHERE StudentID = '", GetStudentID() ,"'AND SongPlayed = '", Song, "';"); }
            catch { }
            try
            {
                _daTblStudentAttempts = new OleDbDataAdapter(_SQLStudentAttempts, CONNECTION);
                _cbSA = new OleDbCommandBuilder(_daTblStudentAttempts);
                UpdateStudentAttemptsTbl();
            }
            catch { }
            if (_tblStudentAttempts.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void StudentHistory()
        {
            try { _SQLStudentAttempts = string.Concat("SELECT * FROM SongAttempts WHERE StudentID = '", GetStudentID(), "';"); }
            catch { }
            try
            {
                _daTblStudentAttempts = new OleDbDataAdapter(_SQLStudentAttempts, CONNECTION);
                _cbSA = new OleDbCommandBuilder(_daTblStudentAttempts);
                UpdateStudentAttemptsTbl();
            }
            catch { }
        }
        private void SongUsage(string Song)
        {
            try { _SQLStudentAttempts = string.Concat("SELECT * FROM Songattempts WHERE SongPlayed = '", Song, "';"); }
            catch { }
            try
            {
                _daTblStudentAttempts = new OleDbDataAdapter(_SQLStudentAttempts, CONNECTION);
                _cbSA = new OleDbCommandBuilder(_daTblStudentAttempts);
                UpdateStudentAttemptsTbl();
            }
            catch { }
        }
        public void StudentList()
        {
            try { _SQLStudents = string.Concat("SELECT * FROM Students WHERE TeacherID = '", Username, "';"); }
            catch { }
            try
            {
                _daTblStudents = new OleDbDataAdapter(_SQLStudents, CONNECTION);
                _cbS = new OleDbCommandBuilder(_daTblStudents);
                UpdateStudentsTbl();
            }
            catch { }
        }
        public bool ComparisonStudents()
        {
            if (_tblStudents.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void UpdateSong(string Song)
        {
            _SQLSongList = string.Concat("SELECT * FROM SongList WHERE SongList.Song = '", Song, "';");
            try
            {
                _daTblSongList = new OleDbDataAdapter(_SQLSongList, CONNECTION);
                UpdateSongListTbl();
            }
            catch { }
        }
        public void UpdateLoginCredentials(string User, string Pass)
        {
            bool IsNumeric = false;
            try { IsNumeric = !User[0].ToString().Contains("0123456789"); }
            catch
            {
                Username = "-1";
                Password = "-1";
            }
            if (User == ""  ||Pass == "")
            {
                Username = "-1";
                Password = "-1";
            }

            else
            {
                Username = User;
                Password = Pass;
            }
            _SQLTeacher = string.Concat("SELECT TeacherID, Passwords from Teachers WHERE TeacherID= '", Username[0], "' and Passwords= '", Password, "';");
            _SQLStudents = string.Concat("SELECT * from Students WHERE Username= '", Username, "' and Passwords= '", Password, "';");
            try
            {
                _daTblStudents = new OleDbDataAdapter(_SQLStudents, CONNECTION);
                _cbS = new OleDbCommandBuilder(_daTblStudents);
                UpdateStudentsTbl();
            }
            catch { }
            try
            {
                _daTblTeachers = new OleDbDataAdapter(_SQLTeacher, CONNECTION);
                _cbT = new OleDbCommandBuilder(_daTblTeachers);
                UpdateTeachersTbl();
            }
            catch { }
        }
        public bool ComparisonTeachers()
        {
            if (_tblTeachers.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void FillSongListTbl()
        {
            _tblSongList.Clear();
            _daTblSongList.Fill(_tblSongList);
        }
        public void FillTeachersTbl()
        {
            _tblTeachers.Clear();
            _daTblTeachers.Fill(_tblTeachers);
        }
        public void FillStudentsTbl()
        {
            _tblStudents.Clear();
            _daTblStudents.Fill(_tblStudents);
        }
        public void FillStudentAttemptsTbl()
        {
            _tblStudentAttempts.Clear();
            _daTblStudentAttempts.Fill(_tblStudentAttempts);
        }
        public string Username { get { return _Username; } set { _Username = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }
        public DataTable tblStudents { get { return _tblStudents; } }
        public DataTable tblSongList { get { return _tblSongList; } }
        public DataTable tblTeachers { get { return _tblTeachers; } }
        public DataTable tblStudentAttempts { get { return _tblStudentAttempts; } }
        private void UpdateStudentAttemptsTbl()
        {
            _daTblStudentAttempts.Update(_tblStudentAttempts);
            _tblStudentAttempts.Clear();
            _daTblStudentAttempts.Fill(_tblStudentAttempts);
        }
        private void UpdateStudentsTbl()
        {
            _daTblStudents.Update(_tblStudents);
            _tblStudents.Clear();
            _daTblStudents.Fill(_tblStudents);
        }
        private void UpdateSongListTbl()
        {
            _daTblSongList.Update(_tblSongList);
            _tblSongList.Clear();
            _daTblSongList.Fill(_tblSongList);
        }
        private void UpdateTeachersTbl()
        {
            _daTblTeachers.Update(_tblTeachers);
            _tblTeachers.Clear();
            _daTblTeachers.Fill(_tblTeachers);
        }
        private int GetStudentID()
        {
            DataRow CurrentRow;
            string _TEMPSQLStudents = "";
            OleDbDataAdapter _TEMPdaTblStudents;
            DataTable _TEMPtbl = new DataTable();
            try { _TEMPSQLStudents = string.Concat("SELECT StudentID FROM Students WHERE Username = '", Username, "'"); }
            catch { }
            try
            {
                _TEMPdaTblStudents = new OleDbDataAdapter(_TEMPSQLStudents, CONNECTION);
                _TEMPdaTblStudents.Fill(_TEMPtbl);
            }
            catch { }
            CurrentRow = _TEMPtbl.Rows[0];
            return (int)CurrentRow["StudentID"];
        }
        public void AddSong(string Song, string FilePath)
        {
            DataRow NewSong;
            FillSongListTbl();
            NewSong = _tblSongList.NewRow();
            NewSong["Song"] = Song;
            NewSong["FilePath"] = FilePath;
            _tblSongList.Rows.Add(NewSong);
            _daTblSongList.UpdateCommand = _cbSL.GetInsertCommand();
            UpdateSongListTbl();
        }
        public void DeleteTeacher()
        {
            StudentList();
            if (_tblStudents.Rows.Count != 0)
            {
                for (int r = 0; r < _tblStudents.Rows.Count; r++)
                {
                    _tblStudents.Rows[r].Delete();
                    _daTblStudents.DeleteCommand = _cbS.GetDeleteCommand();
                    UpdateStudentsTbl();
                }
            }
            _tblTeachers.Rows[0].Delete();
            _daTblTeachers.DeleteCommand = _cbT.GetDeleteCommand();
            UpdateTeachersTbl();

        }
        public void DeleteSong(string Song)
        {
            SongUsage(Song);
            if (_tblStudentAttempts.Rows.Count != 0)
            {
                for (int r = 0; r < _tblStudentAttempts.Rows.Count; r++)
                {
                    _tblStudentAttempts.Rows[r].Delete();
                    _daTblStudentAttempts.DeleteCommand = _cbSA.GetDeleteCommand();
                    UpdateStudentAttemptsTbl();
                }
            }
            SearchSongListTable(Song);
            _tblSongList.Rows[0].Delete();
            _daTblSongList.DeleteCommand = _cbSL.GetDeleteCommand();
            UpdateSongListTbl();

        }
        public void DeleteStudent()
        {
            StudentHistory();
            if (_tblStudentAttempts.Rows.Count != 0)
            {
                for (int r = 0; r < _tblStudentAttempts.Rows.Count; r++)
                {
                    _tblStudentAttempts.Rows[r].Delete();
                    _daTblStudentAttempts.DeleteCommand = _cbSA.GetDeleteCommand();
                    UpdateStudentAttemptsTbl();
                }
            }
            _tblStudents.Rows[0].Delete();
            _daTblStudents.DeleteCommand = _cbS.GetDeleteCommand();
            UpdateStudentsTbl();
        }
        public void AddSongAttempt(string Song, string Difficulty, int Percentage, string Grade)
        {
            DataRow NewSong;
            if (PreviousHistory(Song))
            {
                _tblStudentAttempts.Rows[0].Delete();
                _daTblStudentAttempts.DeleteCommand = _cbSA.GetDeleteCommand();
                UpdateStudentAttemptsTbl();
            }
            SearchFullTable("SongAttempts", ref _daTblStudentAttempts, ref _cbSA);
            FillStudentAttemptsTbl();
            NewSong = _tblStudentAttempts.NewRow();
            NewSong["SongPlayed"] = Song;
            NewSong["StudentID"] = GetStudentID();
            NewSong["Difficulty"] = Difficulty;
            NewSong["Progress"] = Percentage;
            NewSong["Grade"] = Grade[0];
            _tblStudentAttempts.Rows.Add(NewSong);
            _daTblStudentAttempts.UpdateCommand = _cbSA.GetInsertCommand();
            UpdateStudentAttemptsTbl();
        }
        public void AddStudent(string FirstName, string Username, string Password, string TeacherID)
        {
            DataRow NewStudent;
            _daTblStudents = new OleDbDataAdapter("SELECT * FROM Students", CONNECTION);
            _cbS = new OleDbCommandBuilder(_daTblStudents);
            FillStudentsTbl();
            NewStudent = _tblStudents.NewRow();
            NewStudent["FirstName"] = FirstName;
            NewStudent["Username"] = Username;
            NewStudent["Passwords"] = Password;
            NewStudent["TeacherID"] = TeacherID;
            NewStudent["Levels"] = 1;
            _tblStudents.Rows.Add(NewStudent);
            _daTblStudents.UpdateCommand = _cbS.GetUpdateCommand();
            UpdateStudentsTbl();
        }
        public void AddTeacher(string TeacherName, string Password)
        {
            DataRow NewTeacher;
            SearchFullTable("Teachers", ref _daTblTeachers, ref _cbT);
            FillTeachersTbl();
            NewTeacher = _tblTeachers.NewRow();
            NewTeacher["TeacherName"] = TeacherName;
            NewTeacher["Passwords"] = Password;
            _tblTeachers.Rows.Add(NewTeacher);
            _daTblTeachers.UpdateCommand = _cbT.GetUpdateCommand();
            UpdateTeachersTbl();
        }
    }
}
