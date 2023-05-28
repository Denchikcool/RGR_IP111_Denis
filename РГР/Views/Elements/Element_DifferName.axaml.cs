using Avalonia.Controls;
using РГР.Models;
using РГР.ViewModels;

namespace РГР.Views.Elements
{
    public partial class Element_DifferName : Window
    {
        public Element_DifferName()
        {
            InitializeComponent();
            DataContext = new DifferentNameViewModel();
        }

        public Element_DifferName(Class_Scheme changeElement)
        {
            InitializeComponent();
            DataContext = new DifferentNameViewModel(changeElement);
        }

        public Element_DifferName(Class_Projects changeElement)
        {
            InitializeComponent();
            DataContext = new DifferentNameViewModel(changeElement);
        }
    }
}
