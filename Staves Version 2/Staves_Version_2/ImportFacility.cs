using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Data;

namespace Staves_Version_2
{
    class ImportFacility
    {
        private string _File;
        private StreamReader rFile;
        static public List<DisplayNote> NotesToScreen;
        public ImportFacility(string SongFile)
        {
            _File = SongFile;
        }
        public bool IsFileValid()
        {
            int Count = 1;
            string Line = "", RegExpression = "([A-G][0-8](D?(SQ|Q|C|M|SB)))+";
            bool Valid = true, IsEnd = false;
            try
            {
                rFile = new StreamReader(_File);
                do
                {
                    Line = rFile.ReadLine();
                    if (Line == null)
                    {
                        IsEnd = true;
                    }
                    else if (!Regex.IsMatch(Line, RegExpression))
                    {
                        Valid = false;
                    }
                    Count++;
                }
                while (!IsEnd);
            }
            catch { Valid = false; }
            return Valid;
        }
    }
}
