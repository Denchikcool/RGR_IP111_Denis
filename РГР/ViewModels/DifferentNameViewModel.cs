using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using РГР.Models;

namespace РГР.ViewModels
{
    public class DifferentNameViewModel : ViewModelBase
    {
        private string scheme_name = string.Empty;
        private Class_Scheme? scheme;
        private Class_Projects? project;

        public DifferentNameViewModel()
        {
            scheme = null;
            project = null;
        }

        public DifferentNameViewModel(Class_Scheme changeElement)
        {
            scheme = changeElement;
            project = null;
        }

        public DifferentNameViewModel(Class_Projects changeElement)
        {
            scheme = null;
            project = changeElement;
        }

        public string Scheme_Name
        {
            get => scheme_name;
            set => this.RaiseAndSetIfChanged(ref scheme_name, value);
        }

        public void ButtonSave()
        {
            if (scheme != null)
            {
                if (string.IsNullOrWhiteSpace(Scheme_Name) == false)
                {
                    scheme.Scheme_Name = Scheme_Name;
                }
            }
            else if (project != null)
            {
                if (string.IsNullOrWhiteSpace(Scheme_Name))
                {
                    project.Project_Name = Scheme_Name;
                }
            }
        }

        public void ButtonClear()
        {
            Scheme_Name = string.Empty;
        }
    }
}
