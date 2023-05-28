using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РГР.Models
{
    public class Class_And : Full_Elements
    {
        public override void Meaning()
        {
            Outputs[0] = 1;
            Value_El = 0;

            for (int i = 0; i < 8; i++)
            {
                if (Ins[i] != null)
                {
                    if (Ins[i].Element_of_Collection.Value_El != 0)
                    {
                        Outputs[0] &= Ins[i].Element_of_Collection.Outputs[Ins[i].Number];
                        Value_El = 1;
                    }
                }
            }

            if (Value_El == 0)
            {
                Outputs[0] = 0;
            }
        }

    }
}
