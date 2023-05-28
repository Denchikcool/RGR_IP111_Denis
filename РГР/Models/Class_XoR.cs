using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РГР.Models
{
    public class Class_XoR : Full_Elements
    {
        public override void Meaning()
        {
            Outputs[0] = 0;
            Value_El = 0;


            if (Ins[0] != null && Ins[1] != null)
            {
                if (Ins[0].Element_of_Collection.Value_El != 0 && Ins[1].Element_of_Collection.Value_El != 0)
                {
                    if (Ins[0].Element_of_Collection.Outputs[Ins[0].Number] != Ins[1].Element_of_Collection.Outputs[Ins[1].Number])
                    {
                        Outputs[0] = 1;
                    }
                    else
                    {
                        Outputs[0] = 0;
                    }

                    Value_El = 1;
                }
                else if (Ins[0].Element_of_Collection.Value_El != 0 || Ins[1].Element_of_Collection.Value_El != 0)
                {
                    Outputs[0] = 1;
                    Value_El = 1;
                }
            }
            else if (Ins[0] != null)
            {
                if (Ins[0].Element_of_Collection.Value_El != 0)
                {
                    Outputs[0] = 1;
                    Value_El = 1;
                }
            }
            else if (Ins[1] != null)
            {
                if (Ins[1].Element_of_Collection.Value_El != 0)
                {
                    Outputs[0] = 1;
                    Value_El = 1;
                }
            }
        }
    }
}
