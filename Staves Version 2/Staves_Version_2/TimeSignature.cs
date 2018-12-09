using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Staves_Version_2
{
    public class TTimeSignature
    {
        int _Numerator, _Denominator;
        public TTimeSignature(string TimeStr = "4/4")
        {
            Numerator = int.Parse(TimeStr[0].ToString());
            Denominator = int.Parse(TimeStr[2].ToString());
        }
        public int Numerator
        {
            get { return _Numerator; }
            set
            {
                _Numerator = value;
            }
        }
        public int Denominator
        {
            get { return _Denominator; }
            set
            {
                _Denominator = value;
            }
        }
    }
}
