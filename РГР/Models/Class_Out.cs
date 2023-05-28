using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РГР.Models
{
    public class Class_Out : Full_Elements
    { 
        public Class_Out() : base() 
        {
            Inputs[0] = 0;
            Output = 0;
        }

        public override void Meaning()
        {
            if (Ins[0] != null)
            {
                Inputs[0] = Ins[0].Element_of_Collection.Outputs[Ins[0].Number];
                Value_El = Ins[0].Element_of_Collection.Value_El;

                if (Value_El == 0)
                {
                    Inputs[0] = 0;
                }
            }
            else
            {
                Inputs[0] = 0;
                Value_El = 0;
            }

            Output = Inputs[0];
        }
    }
}
