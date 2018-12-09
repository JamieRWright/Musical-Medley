using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Staves_Version_2
{
    abstract public class Note
    {
        //Types
        public enum TNote : int
        {
            A = 1, B, C, D, E, F, G
        }
        public enum TOctaveIndex : int
        {
            Octave_0 = 0, Octave_1, Octave_2, Octave_3, Octave_4, Octave_5, Octave_6, Octave_7, Octave_8
        }
        public enum TVariation : int
        {
            DoubleFlat = 3, Flat, Natural, Sharp, DoubleSharp
        }
        //Attributes
        private const double DOT = 1.5;
        private double[] _NoteValues = new double[5];
        private string[] _NoteNames = new string[5]; //Parallel arrays which contains the Note name and duration 
        private string _NoteType;
        private double _CurrentNoteLength;
        private int _ArrayRef;
        static public List<Texture2D> NoteImages = new List<Texture2D>();//Allows to initialise from outside the class (Is a list as there is potential for more notes)
        //Constructor
        public Note(string NoteTypeString)
        {
            ArrayAssignment();
            _NoteType = NoteTypeString.Substring(2);
            _CurrentNoteLength = NoteLength;
        }
        //Methods
        private void ArrayAssignment()
        {
            //Note Duration Assigned
            double Duration = 0.25;
            for (int i = 0; i < 5; i++)
            {
                _NoteValues[i] = Duration;
                Duration = Duration * 2;
            }
            //Note Values assigned
            _NoteNames[0] = "SQ";
            _NoteNames[1] = "Q";
            _NoteNames[2] = "C";
            _NoteNames[3] = "M";
            _NoteNames[4] = "SB";
        }//Fills Arrays
        private double DottedFunction()
        {
            if (Regex.IsMatch(_NoteType, "[D]"))
            {
                _CurrentNoteLength = DOT * _CurrentNoteLength;
                return _CurrentNoteLength;
            }
                else
                {
                    return _CurrentNoteLength;
                }
        }
        virtual public void ToEnum(string DictionaryIndex)
        {
            int Index1, Index2;

            Index1 = int.Parse(DictionaryIndex[0].ToString());
            Index2 = int.Parse(DictionaryIndex[1].ToString());
        }//Converts string into the given enumerated types
        //Properties
        public double NoteLength
        {
            get
            {
                string Pattern = Regex.Replace(_NoteType, "[D]", "");//Identifies a dotted note
                for (int i = 0; i < 5; i++)
                {
                    if (Pattern == _NoteNames[i])
                    {
                        _CurrentNoteLength = _NoteValues[i];//Searches the array and matches the parallel arrays
                        _ArrayRef = i;
                    }
                }
                _CurrentNoteLength = DottedFunction();//Times the note by 1.5 if dotted
                return _CurrentNoteLength;
            }
        }
        public int FindArrayReference
        {
            get
            {
                string Pattern = Regex.Replace(_NoteType, "[D]", "");//Identifies a dotted note
                for (int i = 0; i < 5; i++)
                {
                    if (Pattern == _NoteNames[i])
                    {
                        _ArrayRef = i;
                    }
                }
                return _ArrayRef;
             }
        }
    }
}
