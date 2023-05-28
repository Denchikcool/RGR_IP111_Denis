using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РГР.Models
{
    public class Class_Elements : AbstractNotifyPropertyChanged
    {
        private Full_Elements element_of_collection;
        private int number;

        public Full_Elements Element_of_Collection
        {
            get => element_of_collection;
            set => SetAndRaise(ref element_of_collection, value);
        }

        public int Number
        {
            get => number;
            set => SetAndRaise(ref number, value);
        }
    }
}
