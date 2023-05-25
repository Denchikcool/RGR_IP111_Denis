using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using РГР.Models;
using РГР.ViewModels;

namespace РГР.Views
{
    public partial class MainWindow : Window
    {

        private Programm programm;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
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
            programm = new Programm();
            this.Hide();
            programm.Show();
            programm.Closing += Exit_programm2;
        }

        public async void OpenSecondWindow(object sender, RoutedEventArgs eventArgs)
        {
            programm = new Programm();
            this.Hide();
            programm.Show();
            programm.Closing += Exit_programm2;

            programm.LoadFile(null, null);

        }

        public void ButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            if (DataContext is MainWindowViewModel mainWindowViewModel)
            {
                if (sender is Button button)
                {
                    mainWindowViewModel.Check_button(button.Name);
                }
            }
        }
        
    }
}
