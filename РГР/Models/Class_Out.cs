using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РГР.Models
{
    public class Class_Out : Full_Elements
    {
        private int input1;

        public int Input1
        {
            get => input1;
            set => SetAndRaise(ref input1, value);
        }
        public Class_Out() : base() 
        {
            Input1 = 0;
        }
    }
}
