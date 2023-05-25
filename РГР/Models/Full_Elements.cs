using Avalonia;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РГР.Models
{
    public class Full_Elements : AbstractNotifyPropertyChanged
    {
        protected Avalonia.Point main_point;
        private int output1, output2;
        private string name;
        public Avalonia.Point Main_Point
        {
            get => main_point;
            set
            {
                Point oldPoint = Main_Point;
                SetAndRaise(ref main_point, value);
                if(ChangeMainPoint != null)
                {
                    Class_CheckChanges args = new Class_CheckChanges
                    {
                        OldStartPoint = oldPoint,
                        NewStartPoint = Main_Point,
                    };
                    ChangeMainPoint(this, args);
                }

            }
        }

        public string Name
        {
            get => name;
            set => SetAndRaise(ref name, value);
        }

        public int Output1 //S
        {
            get => output1;
            set=> SetAndRaise(ref output1, value);
        }
        public int Output2 //P0
        {
            get => output2;
            set => SetAndRaise(ref output2, value);
        }

        public event EventHandler<Class_CheckChanges> ChangeMainPoint;
    }
}
