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
using System.Windows.Forms;


namespace Staves_Version_2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private List<PlayNote> _KeyList;
        private Note.TOctaveIndex _OctaveVariation;
        private KeyboardState _PriorKey, _CurrentKey;
        private Form _MyGameForm;
        private PlayNote A, B, C, C1, D, E, F, G;
        private Texture2D Image, CurrentNoteBox, PauseButton, DifficultyBar, DifficultySlider, Bar, UpArrow, DownArrow, Ticker;
        private GraphicsDeviceManager graphics;
        private PlayNote[] CurrentKeyImage;
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private Rectangle StaveRec, PauseButtonRec, UpArrowRec, DownArrowRec, Metronome;
        private Vector2 BoxCoords;
        private int Counter, Temp;
        private string SongString, ToBePlayed, Value;
        private MouseState CurrentButton, PriorButton;
        private bool Pause;
        public TValidation Validation;
        public TDatabase Database;
        public string PressedNotes;
        public bool Restart, IsGameActive;
        public int Index;
        public Composition TSong;
        public Game1(Composition inSong, TDatabase inDatabase)
        {
            TSong = inSong;
            Database = inDatabase;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            Restart = false;
            base.Initialize();
            _KeyList = new List<PlayNote>();
            CurrentKeyImage = new PlayNote[9];
            string DictionaryIndex = "";
            string SoundFile = "";
            _MyGameForm = (Form)Form.FromHandle(this.Window.Handle);
            Sound.TVariation Variation = (Sound.TVariation)5;
            for (Sound.TNote Note = Sound.TNote.A; Note < (Sound.TNote)8; Note++)
            {
                for (Sound.TOctaveIndex Octave = Sound.TOctaveIndex.Octave_1; Octave < (Sound.TOctaveIndex)6; Octave++)
                {
                    DictionaryIndex = string.Concat((int)Note, (int)Octave, (int)Variation);
                    SoundFile = string.Concat(Note, (int)Octave, Variation);
                    try
                    {
                        SoundEffect Temp = Content.Load<SoundEffect>(SoundFile);
                        Sound.Sound_Library.Add(DictionaryIndex, Temp);
                    }
                    catch
                    {
                        Sound.Sound_Library.Add(DictionaryIndex, null);//Not every octave can be filled. Not appropriate to abort the process
                    }
                }
            }
            Image = Content.Load<Texture2D>("Quaver - Copy");
            Note.NoteImages.Add(Image);
            Image = Content.Load<Texture2D>("Quaver");
            Note.NoteImages.Add(Image);
            Image = Content.Load<Texture2D>("Crotchet");
            Note.NoteImages.Add(Image);
            Image = Content.Load<Texture2D>("Minim");
            Note.NoteImages.Add(Image);
            Image = Content.Load<Texture2D>("Semibreve");
            Note.NoteImages.Add(Image);
            Image = Content.Load<Texture2D>("A note");
            PlayNote.KeyImages.Add("A", Image);
            Image = Content.Load<Texture2D>("B note");
            PlayNote.KeyImages.Add("B", Image);
            Image = Content.Load<Texture2D>("C note");
            PlayNote.KeyImages.Add("C", Image);
            Image = Content.Load<Texture2D>("D note");
            PlayNote.KeyImages.Add("D", Image);
            Image = Content.Load<Texture2D>("E note");
            PlayNote.KeyImages.Add("E", Image);
            Image = Content.Load<Texture2D>("F note");
            PlayNote.KeyImages.Add("F", Image);
            Image = Content.Load<Texture2D>("G note");
            PlayNote.KeyImages.Add("G", Image);
            C = new PlayNote("335", 1);
            D = new PlayNote("435", 2);
            E = new PlayNote("535", 3);
            F = new PlayNote("635", 4);
            G = new PlayNote("735", 5);
            A = new PlayNote("145", 6);
            B = new PlayNote("245", 7);
            C1 = new PlayNote("345", 8);
            _KeyList.Add(C);
            _KeyList.Add(D);
            _KeyList.Add(E);
            _KeyList.Add(F);
            _KeyList.Add(G);
            _KeyList.Add(A);
            _KeyList.Add(B);
            _KeyList.Add(C1);
            PauseButton = Content.Load<Texture2D>("PauseButton");
            Ticker = Content.Load<Texture2D>("Ticker");
            CurrentNoteBox = Content.Load<Texture2D>("CurrentNoteBox");
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");
            Image = Content.Load<Texture2D>("staves");
            DifficultyBar = Content.Load<Texture2D>("DifficultyBar");
            DifficultySlider = Content.Load<Texture2D>("DifficultyBarSlider");
            Bar = Content.Load<Texture2D>("Bar");
            UpArrow = Content.Load<Texture2D>("Up Arrow");
            DownArrow = Content.Load<Texture2D>("Down Arrow");
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            StaveRec = new Rectangle(10, 10, 1000, 200);
            PauseButtonRec = new Rectangle(500, 300, 70, 45);
            Metronome = new Rectangle(500, 400, 70, 45);
            UpArrowRec = new Rectangle(1, 1, 30, 20);
            DownArrowRec = new Rectangle(1, 25, 30, 20);
            Index = 0;
            Counter = 0;
            PressedNotes = "";
            _OctaveVariation = Note.TOctaveIndex.Octave_3;
            IsGameActive = true;
        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Dispose();
            this.Exit();
            this.Dispose(true);
        }
        public void NoteFunction()
        {
            C.NoteFunction(_CurrentKey, _PriorKey, 'A', _OctaveVariation);
            D.NoteFunction(_CurrentKey, _PriorKey, 'S', _OctaveVariation);
            E.NoteFunction(_CurrentKey, _PriorKey, 'D', _OctaveVariation);
            F.NoteFunction(_CurrentKey, _PriorKey, 'F', _OctaveVariation);
            G.NoteFunction(_CurrentKey, _PriorKey, 'G', _OctaveVariation);
            A.NoteFunction(_CurrentKey, _PriorKey, 'H', _OctaveVariation + 1);
            B.NoteFunction(_CurrentKey, _PriorKey, 'J', _OctaveVariation + 1);
            C1.NoteFunction(_CurrentKey, _PriorKey, 'K', _OctaveVariation + 1);
        }
        public void OctaveToggle()
        {
            bool OctavesUp = _CurrentKey.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up) && _PriorKey.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.Up);
            bool OctavesDown = _CurrentKey.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down) && _PriorKey.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.Down);
            bool OctaveClick = CurrentButton.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && PriorButton.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released;
            _OctaveVariation = (Note.TOctaveIndex)((int)_OctaveVariation % 9);
            if (OctavesUp || (OctaveClick && UpArrowRec.Contains(CurrentButton.X, CurrentButton.Y)))
            {
                _OctaveVariation++;
            }
            if (OctavesDown || (OctaveClick && DownArrowRec.Contains(CurrentButton.X, CurrentButton.Y)))
            {
                if (_OctaveVariation == 0)
                {
                    _OctaveVariation = Note.TOctaveIndex.Octave_8;
                }
                else
                {
                    _OctaveVariation--;
                }
            }
        }
        public void NotesInput(ref string PressedNotes, PlayNote Temp)
        {
            if (Temp.IsPressed)
                PressedNotes = PressedNotes + Temp.ReturnNote;
        }
        public void FormLoad()
        {
            if (IsGameActive)
            {
                Form Feedback = new FeedbackScreen(Database, Validation, TSong, this);
                Feedback.Show();
                this.SuppressDraw();
                MediaPlayer.IsMuted = true;
                _MyGameForm.Hide();
                _MyGameForm.Enabled = false;
            }
            IsGameActive = false;
        }
        public void PauseScreen()
        {
            if (Pause)
            {
                Form Paused = new PauseScreen(this, Database);
                Paused.Show();
                this.SuppressDraw();
                MediaPlayer.IsMuted = true;
                _MyGameForm.Hide();
                _MyGameForm.Enabled = false;
            }
            Pause = false;
        }
        public int LastNoteIndex()
        {
            int Length = (ToBePlayed.Length / 2)-1, HighestIndex;
            HighestIndex = Length * (int)TSong.Difficulty;
            return HighestIndex;
        }
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                this.Exit();
            // TODO: Add your update logic here
            if (Restart)
            {
                this.BeginDraw();
                _MyGameForm.Show();
                _CurrentKey = Keyboard.GetState();
                _PriorKey = _CurrentKey;
                _MyGameForm.Enabled = true;
                MediaPlayer.IsMuted = false;
                this.LoadContent();
                Restart = false;
            }
            Counter++;
            if (this.IsActive)
            {
                base.Update(gameTime);
            }
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            _PriorKey = _CurrentKey;
            _CurrentKey = Keyboard.GetState();
            PriorButton = CurrentButton;
            CurrentButton = Mouse.GetState();
            NoteFunction();
            OctaveToggle();
            bool DifficultyUp = _CurrentKey.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right) && _PriorKey.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.Right);
            bool DifficultyDown = _CurrentKey.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left) && _PriorKey.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.Left);
            int XBar, OctaveIndex;
            SongString = TSong.Song;
            OctaveIndex = (int)_OctaveVariation;
            PlayNote.OctaveIndex = OctaveIndex.ToString()[0];
            Note.TNote KeyToScreen = Note.TNote.C;
            Rectangle SliderRectangle = new Rectangle(400 - (50 * (int)TSong.Difficulty), 14, 15, 25);
            bool ButtonPressed = CurrentButton.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && PriorButton.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released;
            bool ButtonUnpressed = CurrentButton.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && PriorButton.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;
            for (int i = 1; i < 9; i++) //Prints Keyboard
            {
                KeyToScreen = (Note.TNote)((int)KeyToScreen % 8);
                if (KeyToScreen == 0)
                {
                    KeyToScreen++;
                }
                Value = KeyToScreen.ToString();
                CurrentKeyImage[i] = new PlayNote(Value[0], i);
                KeyToScreen++;
            }
            GraphicsDevice.Clear(Color.White);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (PressedNotes == "")
            {
                if (DifficultyUp && TSong.Difficulty != Composition.TDifficulty.Hard)
                {
                    TSong.Difficulty--;
                }
                if (DifficultyDown && TSong.Difficulty != Composition.TDifficulty.SuperEasy)
                {
                    TSong.Difficulty++;
                }
            }
            ToBePlayed = TSong.DifficultyModification(SongString, TSong.Difficulty);
            if (Index != ToBePlayed.Length)
            {
                if (ButtonPressed && PauseButtonRec.Contains(CurrentButton.X, CurrentButton.Y))
                {
                    Pause = true;
                    PauseScreen();
                }
                spriteBatch.Draw(Image, StaveRec, Color.White);
                spriteBatch.Draw(PauseButton, PauseButtonRec, Color.Red);
                spriteBatch.DrawString(spriteFont, "Current Octave Index:" + PlayNote.OctaveIndex, new Vector2(500, 210), Color.Blue);
                spriteBatch.Draw(DifficultyBar, new Vector2(150, 20), Color.Red);
                spriteBatch.Draw(DifficultySlider, SliderRectangle, Color.Black);
                spriteBatch.Draw(UpArrow, UpArrowRec, Color.White);
                spriteBatch.Draw(DownArrow, DownArrowRec, Color.White);
                spriteBatch.DrawString(spriteFont, TSong.TimeSignature.Numerator.ToString(), new Vector2(150, 45), Color.Black);
                spriteBatch.DrawString(spriteFont, TSong.TimeSignature.Numerator.ToString(), new Vector2(150, 125), Color.Black);
                spriteBatch.DrawString(spriteFont, TSong.TimeSignature.Denominator.ToString(), new Vector2(150, 73), Color.Black);
                spriteBatch.DrawString(spriteFont, TSong.TimeSignature.Denominator.ToString(), new Vector2(150, 153), Color.Black);
                int MaxNotesOnScreen = (20 / (int)TSong.Difficulty);
                if (TSong.Difficulty == Composition.TDifficulty.Medium)
                {
                    MaxNotesOnScreen++;
                }
                if (Index / 2 < MaxNotesOnScreen)
                {
                    if (ToBePlayed.Length / 2 == MaxNotesOnScreen)
                    {
                        XBar = Composition.NotesToScreen.ElementAt(LastNoteIndex()).XValue + 30;
                        spriteBatch.Draw(Bar, new Vector2(XBar, 48), Color.Black);
                        spriteBatch.Draw(Bar, new Vector2(XBar + 5, 48), Color.Black);
                        spriteBatch.Draw(Bar, new Vector2(XBar, 125), Color.Black);
                        spriteBatch.Draw(Bar, new Vector2(XBar + 5, 125), Color.Black);
                    }
                    if (ToBePlayed.Length / 2 >= MaxNotesOnScreen)
                    {
                        for (int i = 0; i < MaxNotesOnScreen; i++)//Creates a bar
                        {
                            Temp = i * (int)TSong.Difficulty;
                            spriteBatch.Draw(Composition.NotesToScreen.ElementAt(Temp).NoteImage, Composition.NotesToScreen.ElementAt(Temp).Coordinates, Color.White);
                            BoxCoords = new Vector2(Composition.NotesToScreen.ElementAt(Temp).XValue, Composition.NotesToScreen.ElementAt(Temp).YValue - 20);
                            if (TSong.IsBar(i) == true && i + 1 < Composition.NotesToScreen.Count)
                            {
                                XBar = Composition.NotesToScreen.ElementAt(Temp).XValue + 30;
                                spriteBatch.Draw(Bar, new Vector2(XBar, 48), Color.Black);
                                spriteBatch.Draw(Bar, new Vector2(XBar, 125), Color.Black);
                            }
                            if (Index / 2 == i)
                            {
                                spriteBatch.Draw(CurrentNoteBox, BoxCoords, Color.White);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < ToBePlayed.Length / 2; i++)//Creates a bar
                        {
                            Temp = i * (int)TSong.Difficulty;
                            spriteBatch.Draw(Composition.NotesToScreen.ElementAt(Temp).NoteImage, Composition.NotesToScreen.ElementAt(Temp).Coordinates, Color.White);
                            BoxCoords = new Vector2(Composition.NotesToScreen.ElementAt(Temp).XValue, Composition.NotesToScreen.ElementAt(Temp).YValue - 20);
                            if (TSong.IsBar(i) == true && i + 1 < Composition.NotesToScreen.Count)
                            {
                                XBar = Composition.NotesToScreen.ElementAt(Temp).XValue + 30;
                                spriteBatch.Draw(Bar, new Vector2(XBar, 48), Color.Black);
                                spriteBatch.Draw(Bar, new Vector2(XBar, 125), Color.Black);
                            }
                            if (Index / 2 == i)
                            {
                                spriteBatch.Draw(CurrentNoteBox, BoxCoords, Color.White);
                            }
                            XBar = Composition.NotesToScreen.ElementAt(LastNoteIndex()).XValue + 30;
                            spriteBatch.Draw(Bar, new Vector2(XBar, 48), Color.Black);
                            spriteBatch.Draw(Bar, new Vector2(XBar + 5, 48), Color.Black);
                            spriteBatch.Draw(Bar, new Vector2(XBar, 125), Color.Black);
                            spriteBatch.Draw(Bar, new Vector2(XBar + 5, 125), Color.Black);
                        }
                    }
                }
                else
                {
                    for (int i = MaxNotesOnScreen; i < ToBePlayed.Length/2; i++)//Adds Note
                    {
                        Temp = i * (int)TSong.Difficulty;
                        spriteBatch.Draw(Composition.NotesToScreen.ElementAt(Temp).NoteImage, Composition.NotesToScreen.ElementAt(Temp).Coordinates, Color.White);
                        BoxCoords = new Vector2(Composition.NotesToScreen.ElementAt(Temp).XValue, Composition.NotesToScreen.ElementAt(Temp).YValue - 20);
                        if (Index / 2 == i)
                        {
                            spriteBatch.Draw(CurrentNoteBox, BoxCoords, Color.White);
                        }
                        if (TSong.IsBar(i) == true && i + 1 < ToBePlayed.Length / 2)
                        {
                            XBar = Composition.NotesToScreen.ElementAt(i).XValue + 30;
                            spriteBatch.Draw(Bar, new Vector2(XBar, 48), Color.Black);
                            spriteBatch.Draw(Bar, new Vector2(XBar, 125), Color.Black);
                        }
                        XBar = Composition.NotesToScreen.ElementAt((ToBePlayed.Length / 2) - 1).XValue + 30;
                        spriteBatch.Draw(Bar, new Vector2(XBar, 48), Color.Black);
                        spriteBatch.Draw(Bar, new Vector2(XBar + 5, 48), Color.Black);
                        spriteBatch.Draw(Bar, new Vector2(XBar, 125), Color.Black);
                        spriteBatch.Draw(Bar, new Vector2(XBar + 5, 125), Color.Black);
                    }
                }
                for (int i = 1; i < 9; i++)//Adds Piano Keys
                {
                    if (i == 6)
                    {
                        PlayNote.OctaveIndex++;
                    }
                    else if (i == 0)
                    {
                        PlayNote.OctaveIndex--;
                    }
                    PlayNote Temp = _KeyList.ElementAt(i - 1);
                    spriteBatch.Draw(CurrentKeyImage[i].ReturnCurrentTexture, CurrentKeyImage[i].ReturnCurrentKey, CurrentKeyImage[i].ToBePressed(ref ToBePlayed, ref Index, Temp, false));
                    NotesInput(ref PressedNotes, Temp);
                    Temp.IsPressed = false;
                    CurrentKeyImage[i].IsPressed = false;
                }
                if (Counter > TSong.TimeBetweenBeats-10 || Counter < 10)
                {
                    spriteBatch.Draw(Ticker, Metronome, Color.Red);
                    if (Counter == TSong.TimeBetweenBeats)
                        Counter = 0;
                }
            }
            else
            {
                Validation = new TValidation(ToBePlayed, PressedNotes);
                Validation.Feedback();
                FormLoad();
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
//bool StringValidation;
//string CurrentNote = string.Concat(ToBePlayed[Index], ToBePlayed[Index + 1]);
//                if (ToBePlayed == "")
//                {
//                    return Color.White;
//                }
//                StringValidation = CurrentNote == NoteButton.ReturnNote;
//                if (StringValidation && !NoteButton.IsPressed)
//                {
//                    if (Index + 2 >= ToBePlayed.Length)
//                        Index = 0;
//                    else
//                        Index = Index + 2;
//                    return Color.Red;
//                }
//                if (!StringValidation && NoteButton.IsPressed)
//                {
//                    if (Index + 2 >= ToBePlayed.Length)
//                        Index = 0;
//                    else
//                        Index = Index + 2;
//                    return Color.White;
//                }