using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace DPGI_Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        
            var openBinding = new CommandBinding(ApplicationCommands.Open, Execute_Open, CanExecute_Open);
            var clearBinding = new CommandBinding(ApplicationCommands.Close, Execute_Clear, CanExecute_Clear);
            var saveBinding = new CommandBinding(ApplicationCommands.Save, Execute_Save, CanExecute_Save);

            CommandBindings.Add(openBinding);
            CommandBindings.Add(clearBinding);
            CommandBindings.Add(saveBinding);
        }

        private void CanExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = TextBoxMain.Text.Trim().Length > 0;
        }

        private void Execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            File.WriteAllText("Lab2.txt", TextBoxMain.Text);
            MessageBox.Show("The file was saved!");
        }
    
        private void CanExecute_Open(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            const string filter = "Text files (*.txt)|*.txt;|All files (*.*)|*.*";
        
            var openDialog = new OpenFileDialog()
            {
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
                Filter = filter
            };

            if (openDialog.ShowDialog() == true)
            {
                TextBoxMain.Text = File.ReadAllText(openDialog.FileName);
            }
        }
    
        private void CanExecute_Clear(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = TextBoxMain.Text.Length > 0;
        }

        private void Execute_Clear(object sender, ExecutedRoutedEventArgs e)
        {
            TextBoxMain.Text = "";
        }
    }
}