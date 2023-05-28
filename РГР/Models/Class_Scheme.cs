using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РГР.Models
{
    public class Class_Scheme : AbstractNotifyPropertyChanged
    {
        private string scheme_name;
        private ObservableCollection<Full_Elements> elements;

        public string Scheme_Name
        {
            get => scheme_name;
            set => SetAndRaise(ref scheme_name, value);
        }

        public ObservableCollection<Full_Elements> Elements
        {
            get => elements;
            set => SetAndRaise(ref elements, value);
        }

        public Class_Scheme()
        {
            Scheme_Name = "Добавьте название";
            Elements = new ObservableCollection<Full_Elements>();
        }
    }
}
