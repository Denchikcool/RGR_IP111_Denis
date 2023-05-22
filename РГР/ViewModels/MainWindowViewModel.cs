using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace РГР.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string path;

        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref path, value);
            }
        }
    }
}
