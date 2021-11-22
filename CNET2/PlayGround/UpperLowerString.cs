using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround
{
    public class UpperLowerString
    {
        private string hodnota;
        public UpperLowerString(string hodnota)
        {
            this.hodnota = hodnota; 
        }

        public string UpperCase { get { return hodnota.ToUpper(); } }
        public string LowerCase { get { return hodnota.ToUpper(); } }

    }
}
