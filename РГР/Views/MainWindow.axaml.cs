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

        public async void OpenFile(object sender, RoutedEventArgs args)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.AllowMultiple = true;

            string[]? result = await openFileDialog.ShowAsync(this);

            if(DataContext is MainWindowViewModel mainWindowViewModel)
            {
                if (result != null)
                {
                    mainWindowViewModel.Path = string.Join(';', result);
                }
                else
                {
                    mainWindowViewModel.Path = "Window was canceled";
                }
            }

            //string currentpath = result;
            //XDocument document = XDocument.Load(result);
            //IEnumerable<Full_Elements>? files = document.Element("files")?.Elements("file").Where(file =>
            //{

            //});

        }

        //public async void SaveFile(object sender, RoutedEventArgs args)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();

        //    string? result = await saveFileDialog.ShowAsync(this);

        //    if (DataContext is MainWindowViewModel mainWindowViewModel)
        //    {
        //        if (result != null)
        //        {
        //            mainWindowViewModel.Path = string.Join(';', result);
        //        }
        //        else
        //        {
        //            mainWindowViewModel.Path = "Window was canceled";
        //        }
        //    }
        //}
    }
}
