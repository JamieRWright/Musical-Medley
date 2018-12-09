using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Staves_Version_2
{
    public class DisplayNote : Note
    {
        //Attributes
        private const int NOTESPACE = 30;
        private const int STARTINGXCOORD = 150;
        private const int STARTINGYCOORD = 210;
        private int _Index, _X, _Y;
        private string _NoteString, _NoteType;
        private TNote _NoteCollection;
        //Methods
        public DisplayNote(string NoteTypeString, int NoteIndex) : base(NoteTypeString)
        {
            _NoteString = NoteTypeString;
            _NoteType = NoteTypeString.Substring(2);
            if (NoteIndex < 21)
            {
                Index = NoteIndex;
            }
            else
            {
                Index = NoteIndex - 20;
            }
            _X = XValue;
            _Y = YValue;
        }
        private int YCoordinate()
        {
            int NoteIndex, OctaveVar;

            _NoteCollection = (TNote)_NoteString[0] - 64;
            NoteIndex = (int)_NoteCollection;
            OctaveVar = int.Parse(_NoteString[1].ToString());
            return STARTINGYCOORD - (7 * (NoteIndex - 1)) - (43 * (OctaveVar));
        }//Converts string into the given enumerated types
        public Texture2D NoteImageReturn(out double OutNoteLength)
        {
            OutNoteLength = base.NoteLength;
            return NoteImage;
        }//Returns image and length (To be used in tutorials)
        //Properties
        public Texture2D NoteImage
        {
            get { return NoteImages.ElementAt(FindArrayReference); }
        }//Returns just the image (For just printing to the screen)
        public Vector2 Coordinates
        {
            get { return new Vector2(_X, _Y); }
        }
        public int Index
        {
            get { return _Index; }
            set
            {
                if (value > 0)
                    _Index = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public int XValue
        {
            get { return (_Index * NOTESPACE) + STARTINGXCOORD; }
            set
            {
                value = _X;
            }
        }
        public int YValue
        {
            get { return YCoordinate(); }
            set
            {
                value = _Y;
            }
        }
    }
}
