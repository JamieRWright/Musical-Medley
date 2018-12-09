using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Staves_Version_2
{
    public class TQueue<T>
    {
        protected const int MAX = 50;
        public string[] Queue = new string[MAX];
        private int _FrontPointer, _RearPointer, _Count;
        private string _Output;
        public TQueue()
        {
            RearPointer = -1;
            FrontPointer = 0;
            _Count = 0;
            _Output = "";
        }
        virtual public int Size
        {
            get { return (RearPointer - FrontPointer) + 1; }
        }
        virtual public string CompileString()
        {
            CompileSong(_Output, _Count);
            return _Output;
        }
        private void CompileSong(string Output, int Count)
        {
            if (Queue[Count] != null && Count < MAX)
            {
                Output = string.Concat(Output, Queue[Count]);
                Count++;
                CompileSong(Output, Count);
            }
            if (Queue[Count] == null || Count == MAX)
            {
                _Output = Output;
                Count = 0;
            }
        }
        public string Pop()
        {
            return Queue[FrontPointer++];
        }
        public string Peek
        {
            get
            {
                try { return Queue[FrontPointer]; }
                catch { throw new Exception(); }
            }
        }
        virtual public void Add(string Item)
        {
            Queue[++RearPointer] = Item;
        }
        public bool IsEmpty
        {
            get
            {
                if (Size == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        virtual public bool IsFull
        {
            get
            {
                if (RearPointer < MAX - 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public int RearPointer
        {
            get { return _RearPointer; }
            set { _RearPointer = value; }
        }
        public int FrontPointer
        {
            get { return _FrontPointer; }
            set { _FrontPointer = value; }
        }
    }
    public class TCircularQueue<T> : TQueue<T>
    {
        private int _Size;
        public TCircularQueue() : base()
        {
            FrontPointer = 0;
            RearPointer = -1;
            _Size = 0;
        }
        public override int Size
        {
            get
            {
                //if (RearPointer < FrontPointer && RearPointer > -1)
                //    _Size = MAX - (FrontPointer - RearPointer);
                //else
                    _Size = base.Size;
                return _Size;
            }
        }
        public override void Add(string Item)
        {
            RearPointer++;
            RearPointer = RearPointer % MAX;
            Queue[RearPointer] = Item;
        }
        public override bool IsFull
        {
            get
            {
                if (Size == MAX)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
