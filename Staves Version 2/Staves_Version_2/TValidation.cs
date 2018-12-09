using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Staves_Version_2
{
    public class TValidation
    {
        enum TGrade : int { U = 2, F, E, D, C, B, A }

        private string _CurrentSongNote, _InputNote, _Output;
        private string _CurrentSong, _Composition, _Improvements;
        private string _Input, _Grade;
        private int _CurrentCharIndex;
        private double _Percentage;

        public TValidation(string CurrentSongStr, string InputStr)
        {
            CurrentSong = CurrentSongStr;
            _Composition = CurrentSongStr;
            Input = InputStr;
            _Improvements = "";
        }
        //Properties
        public string GetGrade { get { return _Grade; } }
        private int CharLocation
        {
            get { return _CurrentCharIndex; }
            set { _CurrentCharIndex = value; }
        }
        private string Output { get { return _Output; } set { _Output = value; } }
        private string CurrentSongNote
        {
            get { return _CurrentSongNote; }
            set { _CurrentSongNote = value; }
        }
        private string InputNote
        {
            get { return _InputNote; }
            set { _InputNote = value; }
        }
        public string CurrentSong
        {
            get { return _CurrentSong; }
            set { _CurrentSong = value; }
        }
        public string Input
        {
            get { return _Input; }
            set { _Input = value; }
        }
        public bool IsPassed
        {
            get
            {
                if (PercentageReturn > 60)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
        }
        public double PercentageReturn
        {
            get { return _Percentage; }
        }
        public string Improvements { get { return _Improvements; } set { _Improvements = value; } }
        //Validation Properties
        private bool OutOfSequence
        {
            get
            {
                bool Valid = false;
                string SubstringInput;
                SubstringInput = _Input.Substring(CharLocation);
                if (_CurrentSong.Contains(SubstringInput) && _Input != _CurrentSong)
                {
                    Valid = true;
                }
                return Valid;
            }

        }
        private bool ValidateOutOfRange
        {
            get
            {
                bool OutOfRange = false;
                if (Input.Length > CurrentSong.Length)
                {
                    OutOfRange = true;
                }
                else if (Input.Length != CurrentSong.Length)
                {
                    OutOfRange = true;
                }
                return OutOfRange;
            }
        }
        private bool ValidateDoublePress
        {
            get
            {
                bool DoublePress = false;
                if (CharLocation - 2 < 0)
                {
                    DoublePress = false;
                }
                else if (CurrentSong.Substring(CharLocation-2, 2) == CurrentSongNote && Input.Substring(CharLocation-2,2) == CurrentSongNote)
                {
                    DoublePress = true;
                }
                return DoublePress;
            }
        }
        //Methods
        private int OutputMaxElement(int[] Array)
        {
            int largest_number = Array[0];
            int Element = 0;
            for (int count_2 = 0; count_2 < 5; count_2++)
            {
                if (Array[count_2] > largest_number)
                {
                    largest_number = Array[count_2];
                    Element = count_2;
                }
                else
                {
                    largest_number = Array[0];
                }
            }
            return Element;
        }
        private string BestAdvice(int Advice)
        {
            if (Advice == 1)
            {
                Improvements = "Double Pressing!";
            }
            else if (Advice == 2)
            {
                Improvements = "Out of Sequence";
            }
            else if (Advice == 3)
            {
                Improvements = "Offputting Input";
            }
            else
            {
                Improvements = "No Advice, keep practising!";
            }
            return Improvements;
        }
        private void Grade(double AmountCorrect)
        {
            int PercentageGrade;
            _Percentage = (AmountCorrect / ((double)Input.Length/2)) * 100.0;
            PercentageGrade = (int)_Percentage / 10;
            if (PercentageGrade >= 9)
            {
                _Grade = "A*";
            }
            else if (PercentageGrade == 0)
            {
                _Grade = "U";
            }
            else
            {
                TGrade Grade = (TGrade)PercentageGrade;
                _Grade = Grade.ToString();
            }
        }
        private int ValidateAdvice()
        {
            int Index, DoublePress = 0, OutOfSeq = 0, OffPut = 0, Unsure = 0;
            int BestAdvice;
            if (ValidateDoublePress == true)
            {
                DoublePress++;
            }
            else if (OutOfSequence == true)
            {
                OutOfSeq++;
            }
            else if (ContainsCorrectLetter(out Index) == true)
            {
                OffPut++;
            }
            else
            {
                Unsure++;
            }
            BestAdvice = AverageAccumulator(DoublePress, OutOfSeq, OffPut, Unsure);
            return BestAdvice;
        }
        private string ValidateErrors()
        {
            int Index;
            string Output = "";
            if (ValidateDoublePress == true)
            {
                Output = "Double Press!";
            }
            else if (OutOfSequence == true)
            {
                Output = "Out of sequence!";
            }
            else if (ContainsCorrectLetter(out Index) == true)
            {
                Output = string.Concat("It contains the correct letter but is not in the right place, offputted by ", Index / 2);
            }
            else
            {
                Output = "unknown error";
            }
            return Output;
        }
        private int IndexDifference(int AlphaLocation)
        {
            int Index;
            Index = CharLocation - AlphaLocation;
            return Index;
        }
        private bool ContainsCorrectLetter(out int Index)
        {
            Index = 0;
            bool CorrectLetterPresent = false;
            for (int x = 0; x < CurrentSong.Length; x = x+2)
            {
                if (CurrentSongNote == string.Concat(CurrentSong[x],CurrentSong[x+1]))
                {
                    CorrectLetterPresent = true;
                    Index = IndexDifference(x);
                }
            }
            return CorrectLetterPresent;
        }
        private int AverageAccumulator(int DoublePress, int OutOfSeq, int OffPut, int Unsure)
        {
            int HighestElement;
            int[] Array = new int[5];
            Array[1] = DoublePress;
            Array[2] = OutOfSeq;
            Array[3] = OffPut;
            Array[4] = Unsure;
            HighestElement = OutputMaxElement(Array);
            return HighestElement;
        }
        public void Feedback()
        {
            double AmountCorrect = 0;
            int Advice = 0;
            if (Input == CurrentSong)
            {
                Grade(CurrentSong.Length/2);
                Improvements = "No Improvements!";
            }
            else
            {
                for (int x = 0; x < Input.Length; x = x+2)
                {
                    CurrentSongNote = string.Concat(Input[x],Input[x+1]);
                    InputNote = string.Concat(CurrentSong[x],CurrentSong[x+1]);
                    CharLocation = x;
                    if (InputNote == CurrentSongNote)
                    {
                        AmountCorrect++;
                    }
                    else
                    {
                        Advice = ValidateAdvice();
                    }
                }
                BestAdvice(Advice);
                Grade(AmountCorrect);
            }
        }
    }
}
