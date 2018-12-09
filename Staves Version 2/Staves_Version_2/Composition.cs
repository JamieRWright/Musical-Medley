using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Staves_Version_2
{
    public class Composition
    {

        private StreamReader _rFile;
        private TTimeSignature _TimeSignature;
        static public List<DisplayNote> NotesToScreen;
        public enum TDifficulty:int { Hard = 1, Pro, Medium, Easy, SuperEasy}
        private TDifficulty _Difficulty;
        private int _BPM;
        private string _File, _SongName, _Song;
        public Composition(string TimeSigStr, int BPM, string SongFile, string inDifficulty, string inSongName)
        {
            _SongName = inSongName;
            _Difficulty = (TDifficulty)Enum.Parse(typeof(TDifficulty), inDifficulty);
            _File = SongFile;
            TimeSignature = new TTimeSignature(TimeSigStr);
            BeatsPerMin = BPM;
            InitaliseCompositionList();
        }
        public TDifficulty Difficulty { get { return _Difficulty; } set { _Difficulty = value; } }
        public string SongName { get { return _SongName; } }
        public string Song { get { return _Song; } }
        public void InitaliseCompositionList()
        {
            int Count = 1;
            string Line = "";
            bool Valid = true;
            NotesToScreen = new List<DisplayNote>();
            TCircularQueue<string> _CompositionQueue = new TCircularQueue<string>();
            _rFile = new StreamReader(_File);
            do
            {
                Line = _rFile.ReadLine();
                if (Line == null)
                {
                    Valid = false;
                }
                else
                {
                    _CompositionQueue.Add(Line.Substring(0, 2));
                    NotesToScreen.Add(new DisplayNote(Line, Count));
                }
                Count++;
            }
            while (Valid);
            _rFile.Close();
            _Song = _CompositionQueue.CompileString();
        }
        public int TimeBetweenBeats
        {
            get { return (60 * 60) / BeatsPerMin; }//(FPS * Seconds in a minute) / Beats per min = the gap between each beat
        }
        public bool IsBar(int CurrentIndex)
        {
            double Tally = 0, NumToReach = (double)TimeSignature.Numerator;
            bool IsBar = false;
            int Temp;
            for (int i = 0; i <= CurrentIndex; i++)
            {
                Temp = i * (int)Difficulty;
                IsBar = false;
                Tally = Tally + NotesToScreen[Temp].NoteLength;
                if (Tally % NumToReach == 0)
                {
                    IsBar = true;
                    Tally = 0;
                }
            }
            return IsBar;
        }
        public string DifficultyModification(string Input, TDifficulty Difficulty)
        {
            string Output = "";
            int temp, Count = 0;
            if(Difficulty == TDifficulty.Hard)
            {
                return Input;
            }
            for (int i = 0; i < Input.Length; i = i= i+2)
            {
                temp = Count % (int)Difficulty;
                if (temp == 0)
                {
                    Output = string.Concat(Output, Input[i],Input[i+1]);
                }
                Count++;
            }

            return Output;
        }
        public TTimeSignature TimeSignature
        {
            get { return _TimeSignature; }
            set { _TimeSignature = value; }
        }
        public int BeatsPerMin
        {
            get { return _BPM; }
            set { _BPM = value; }
        }
    }
}
