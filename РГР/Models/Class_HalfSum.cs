using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РГР.Models
{
    public class Class_HalfSum : Full_Elements
    {
        public override void Meaning()
        {
            for (int i = 0; i < 8; i++)
            {
                Outputs[i] = 0;
            }
            Value_El = 0;

            if (Ins[0] != null && Ins[1] != null)
            {
                if (Ins[0].Element_of_Collection.Outputs[Ins[0].Number] == 0 && Ins[1].Element_of_Collection.Outputs[Ins[1].Number] == 1)
                {
                    Outputs[0] = 1;
                }
                else if (Ins[0].Element_of_Collection.Outputs[Ins[0].Number] == 1 && Ins[1].Element_of_Collection.Outputs[Ins[1].Number] == 0)
                {
                    Outputs[0] = 1;
                }
                else if (Ins[0].Element_of_Collection.Outputs[Ins[0].Number] == 1 && Ins[1].Element_of_Collection.Outputs[Ins[1].Number] == 1)
                {
                    Outputs[1] = 1;
                }

                Value_El = 1;
            }
        }
    }
}
