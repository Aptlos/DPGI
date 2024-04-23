
using System.Windows;

using DPGI_Lab4.Data;

namespace DPGI_Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AdoAssistant _assistant;
        public MainWindow()
        {
            InitializeComponent();

            _assistant = new AdoAssistant();
        }
        
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            MainListBox_OnLoaded();
        }
        
        public void MainListBox_OnLoaded()
        {
            MainListBox.SelectedIndex = 0;
            MainListBox.Focus();
            
            MainListBox.DataContext = _assistant.FillDT();
        }
        
        private void ButtonCreate_OnClick(object sender, RoutedEventArgs e)
        {
            new CreateWindow(this).Show();
        }
        
        private void ButtonUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            var id = int.Parse(IdBox.Text);
            string query=@$"UPDATE Users
                        SET UserId = '{IdBox.Text.Trim()}',
                            UserName = '{NameBox.Text.Trim()}',
                            UserPhone = '{PhoneBox.Text.Trim()}',
                            UserAddress = '{AddressBox.Text.Trim()}',
                            UserGains = '{GainsBox.Text.Trim()}',
                            UserSpends= '{SpendsBox.Text.Trim()}'
                        WHERE UserId = '{id}'";
            _assistant.ExecuteNonQuery(query);
            MainListBox_OnLoaded();
        }
        
        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var id = int.Parse(IdBox.Text);
            string query=@$"DELETE FROM Users WHERE UserId = '{id}'";
            _assistant.ExecuteNonQuery(query);
            MainListBox_OnLoaded();
        }
        
        

    }
}