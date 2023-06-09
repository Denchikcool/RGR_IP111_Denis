﻿using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РГР.Models
{
    public class Class_Projects : AbstractNotifyPropertyChanged
    {
        private string project_name;
        private string path;
        private ObservableCollection<Class_Scheme> scheme;

        public string Project_Name
        {
            get => project_name; 
            set => SetAndRaise(ref project_name, value);
        }

        public string Path
        {
            get => path;
            set => SetAndRaise(ref path, value);
        }

        public ObservableCollection<Class_Scheme> Scheme
        {
            get => scheme;
            set => SetAndRaise(ref scheme, value);
        }

        public Class_Projects()
        {
            Project_Name = " ";
            Path = " ";
            Scheme = new ObservableCollection<Class_Scheme>();
        }
    }
}
