
using System.Windows;

using DPGI_Lab4.Data;

namespace DPGI_Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var myTable= new AdoAssistant();
            MainListBox.SelectedIndex = 0;
            MainListBox.Focus();
            
            MainListBox.DataContext = myTable.FillDT();
        }

    }
}