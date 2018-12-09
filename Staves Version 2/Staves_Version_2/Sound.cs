using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace Staves_Version_2
{
    public interface ISound
    {
        void ToEnum(string DictionaryIndex);
        SoundEffectInstance SoundFileRequest(int OctaveIndex);
    }
    class Sound : Note, ISound
    {
        //Dictionary
        static public Dictionary<string, SoundEffect> Sound_Library = new Dictionary<string, SoundEffect>();
        //Attributes
        private SoundEffect _WAV;
        private SoundEffectInstance _Instance;
        private TNote _Note;
        private TOctaveIndex _OctaveIndex;
        private TVariation _Variation;
        //Constructor
        public Sound(string DictionaryIndex) : base (DictionaryIndex)
        {
            try
            {
                ToEnum(DictionaryIndex);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }

        }
        //Methods
        
        override public void ToEnum(string DictionaryIndex)
        {
            int Index1, Index2;

            Index1 = int.Parse(DictionaryIndex[0].ToString());
            Index2 = int.Parse(DictionaryIndex[1].ToString());
            _Note = (TNote)Index1;
            _OctaveIndex = (TOctaveIndex)Index2;
            _Variation = TVariation.Natural;
        }//Converts string into the given enumerated types
        public SoundEffectInstance SoundFileRequest(int OctaveIndex)
        {
            string DictionaryIndex;
            DictionaryIndex = string.Concat((int)_Note, OctaveIndex, (int)_Variation);//Brings together the three enumerated types to form 3 digit code
            try
            {
                Sound_Library.TryGetValue(DictionaryIndex, out _WAV);//Searches the Dictionary with the given key
                _Instance = _WAV.CreateInstance();
                return _Instance;
            }
            catch (Exception)
            {
                _Instance = null;
                return _Instance;
                throw;
            }
            //Find the SoundFile by searching with the index
        }// Gets a Wav file that is requested
    }
}


