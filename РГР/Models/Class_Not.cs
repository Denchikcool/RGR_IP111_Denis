using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РГР.Models
{
    public class Class_Not : Full_Elements
    {
        public override void Meaning()
        {
            if (Ins[0] != null)
            {
                Inputs[0] = Ins[0].Element_of_Collection.Outputs[Ins[0].Number];
                Value_El = Ins[0].Element_of_Collection.Value_El;

                if (Value_El != 0)
                {
                    if (Inputs[0] == 0)
                    {
                        Outputs[0] = 1;
                    }
                    else if (Inputs[0] == 1)
                    {
                        Outputs[0] = 0;
                    }
                }
                else
                {
                    Outputs[0] = 0;
                }
            }
            else
            {
                Outputs[0] = 0;
                Value_El = 0;
            }
        }
    }
}
