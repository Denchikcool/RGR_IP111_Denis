using Avalonia.Controls;
using Avalonia.Interactivity;
using System.ComponentModel;

namespace РГР.Views
{
    public partial class MainWindow : Window
    {

        private Programm programm;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Exit_programm(object sender, RoutedEventArgs eventArgs)
        {
            this.Close();
        }

        public void Exit_programm2(object? sender, CancelEventArgs e)
        {
            this.Close();
        }

        public void Create_Programm(object sender, RoutedEventArgs eventArgs)
        {
            programm= new Programm();
            this.Hide();
            programm.Show();
            programm.Closing += Exit_programm2;
        }
    }
}
