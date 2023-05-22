using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РГР.Models
{
    public class Class_CheckChanges : EventArgs
    {
        public Point OldStartPoint 
        { 
            get; 
            set; 
        }
        public Point NewStartPoint 
        {
            get; 
            set; 
        }
    }
}
