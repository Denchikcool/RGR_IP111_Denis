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
        private int[] inputs = new int[8];
        private int[] outputs = new int[8];
        private int value_el;
        private int output;
        private Class_Elements[] ins = new Class_Elements[8];
        private Class_Elements[] outs = new Class_Elements[8];
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

        public virtual void Meaning() { }

        public int[] Inputs
        {
            get => inputs;
        }

        public int[] Outputs
        {
            get => outputs;
        }

        public int Value_El
        {
            get => value_el;
            set => SetAndRaise(ref value_el, value);
        }

        public int Output
        {
            get => output;
            set => SetAndRaise(ref output, value);
        }

        public Class_Elements[] Ins
        {
            get => ins;
        }

        public Class_Elements[] Outs
        {
            get => outs;
        }

        public event EventHandler<Class_CheckChanges> ChangeMainPoint;
    }
}
