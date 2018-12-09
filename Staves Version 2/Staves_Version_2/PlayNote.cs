using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Staves_Version_2
{
    public class PlayNote
    {
        //Types
        private enum TToggle { Keys, Click };
        public static Dictionary<string, Texture2D> KeyImages = new Dictionary<string, Texture2D>();
        public static char OctaveIndex;
        //Attributes
        private const int KEY_WIDTH = 50;
        private const int KEY_HEIGHT = 250;
        private SoundEffectInstance[] _Instance;
        private Sound _WAVFile;
        private bool _Pressed;
        private Rectangle _AreaOfClick;
        private Note.TNote _LetterValue;
        private Texture2D _CurrentTexture;
        //Constructor
        public PlayNote(string DictionaryIndex, int Index)
        {
            OctaveIndex = DictionaryIndex[1];
            _Pressed = false;
            _WAVFile = new Sound(DictionaryIndex);
            _Instance = new SoundEffectInstance[9];
            for (int i = 0; i < 9; i++)
            {
                _Instance[i] = _WAVFile.SoundFileRequest(i);
            }
            _LetterValue = (Note.TNote)Enum.Parse(typeof(Note.TNote), DictionaryIndex[0].ToString());//Converts int to letter value
            _AreaOfClick = new Rectangle(Index * 50, 225, KEY_WIDTH, KEY_HEIGHT);
            KeyImages.TryGetValue(_LetterValue.ToString(), out _CurrentTexture);
        }
        public PlayNote(char Key, int Index)
        {
            _AreaOfClick = new Rectangle(Index * 50, 225, KEY_WIDTH, KEY_HEIGHT);
            KeyImages.TryGetValue(Key.ToString(), out _CurrentTexture);
        }
        //Methods
        public void NoteFucntion(MouseState CurrentButton, MouseState PriorButton, Sound.TOctaveIndex Octave)
        {
            int CurrentOctave;
            CurrentButton = Mouse.GetState();
            CurrentOctave = (int)Octave;
            bool PlayNoteC = CurrentButton.LeftButton == ButtonState.Pressed && PriorButton.LeftButton == ButtonState.Released;
            bool StopNoteC = CurrentButton.LeftButton == ButtonState.Released && PriorButton.LeftButton == ButtonState.Pressed;
            if (PlayNoteC && _AreaOfClick.Contains(CurrentButton.X, CurrentButton.Y))
            {
                _Pressed = true;
                _Instance[CurrentOctave].Play();
            }
            if (StopNoteC)
            {
                _Instance[CurrentOctave].Stop();
            }
                
        } // Works the click function
        public void NoteFunction(KeyboardState Current, KeyboardState Prior, char Key, Sound.TOctaveIndex Octave)
        {
            int CurrentOctave = (int)Octave;        
            Keys AsKey = (Keys)Key;
            bool PlayNoteK = Current.IsKeyDown(AsKey) && Prior.IsKeyUp(AsKey);
            bool StopNoteK = Current.IsKeyUp(AsKey) && Prior.IsKeyDown(AsKey);
            if (PlayNoteK)
            {
                _Pressed = true;
                try
                {
                    _Instance[CurrentOctave].Play();
                }
                catch
                { }
            }
            if (StopNoteK)
            {
                try
                {
                    _Instance[CurrentOctave].Stop();
                }
                catch
                { }
            }
        } // Works the key function

        //Properties
        public Rectangle ReturnCurrentKey
        {
            get { return _AreaOfClick; }
        }
        public Texture2D ReturnCurrentTexture
        {
            get { return _CurrentTexture; }
        }
        public bool IsPressed
        {
            get { return _Pressed; }
            set { _Pressed = value; }
        }
        public char CurrentOctave
        {
            set { OctaveIndex = value; }
        }
        public string ReturnNote
        {
            get { return string.Concat((_LetterValue.ToString())[0],OctaveIndex); }
        }
        public Color ToBePressed(ref string ToBePlayed, ref int Index, PlayNote NoteButton, bool UserHelp)
        {
            if (!UserHelp)
            {
                bool StringValidation;
                string CurrentNote = "";
                try
                {
                    CurrentNote = string.Concat(ToBePlayed[Index], ToBePlayed[Index + 1]);
                }
                catch
                {               
                    return Color.White;
                }
                StringValidation = CurrentNote == NoteButton.ReturnNote;
                if (ToBePlayed == "")
                {
                    return Color.White;
                }
                if (StringValidation && !NoteButton.IsPressed)
                {                 
                    return Color.Red;
                }
                if (StringValidation && NoteButton.IsPressed)
                {
                    Index = Index + 2;
                }
                if (!StringValidation && NoteButton.IsPressed)
                {
                    if (Index + 1 >= ToBePlayed.Length)
                        Index = 0;
                    else
                        Index = Index + 2;
                    return Color.White;
                }
                else
                {
                    return Color.White;
                }
            }
            else
            {
                bool StringValidation;
                string CurrentNote = string.Concat(ToBePlayed[Index], ToBePlayed[Index + 1]);
                if (ToBePlayed == "")
                {
                    return Color.White;
                }
                StringValidation = CurrentNote == NoteButton.ReturnNote;
                if (StringValidation && !NoteButton.IsPressed)
                {
                    if (Index + 2 >= ToBePlayed.Length)
                        Index = 0;
                    else
                        Index = Index + 2;
                    return Color.Red;
                }
                if (!StringValidation && NoteButton.IsPressed)
                {
                    if (Index + 2 >= ToBePlayed.Length)
                        Index = 0;
                    else
                        Index = Index + 2;
                    return Color.White;
                }
                else
                {
                    return Color.White;
                }
            }
        }
    }
}
//private void ValidateToggle()
//{
//    KeyboardState Toggle;
//    Toggle = Keyboard.GetState();
//    if (Toggle.IsKeyDown(Keys.F1)) Toggles = TToggle.Click;
//    else if (Toggle.IsKeyDown(Keys.F2)) Toggles = TToggle.Keys;
//} // Validates Toggle between F1 and F2
//public void NoteFunction(MouseState PriorButton, MouseState CurrentButton, KeyboardState Current, KeyboardState Prior, char Key)
//{
//    ValidateToggle();
//    if (Toggles == TToggle.Click)
//        PlayByClick(CurrentButton, PriorButton);
//    if (Toggles == TToggle.Keys)
//        KeyOut(Current, Prior, Key);
//} //F1 to use Click, F2 to use Keys