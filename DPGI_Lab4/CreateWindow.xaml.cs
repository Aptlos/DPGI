using System.Windows;
using DPGI_Lab4.Data;

namespace DPGI_Lab4;

public partial class CreateWindow : Window
{
    private MainWindow _mainWindow;
    private AdoAssistant _assistant;
    
    public CreateWindow(MainWindow window)
    {
        InitializeComponent();
        _assistant = new AdoAssistant();
        _mainWindow = window;
    }

    private void OkButton_OnClick(object sender, RoutedEventArgs e)
    {
        string name = "-";
        string phone = "-";
        string address = "-";
        int gains = 0, spends = 0;
        if (NameBox.Text.Trim() != "")
        {
            name = NameBox.Text.Trim();
        }
        if (PhoneBox.Text.Trim() != "")
        {
            phone = PhoneBox.Text.Trim();
        }

        if (AddressBox.Text.Trim() != "")
        {
            address = AddressBox.Text.Trim();
        }
        string query = @$"INSERT INTO Users(UserName,UserPhone,UserAddress,UserGains,UserSpends)
                        VALUES ('{name}',
                            '{phone}',
                            '{address}',
                            '{GainsBox.Text.Trim()}',
                            '{SpendsBox.Text.Trim()}')";
        _assistant.ExecuteNonQuery(query);
        _mainWindow.MainListBox_OnLoaded();
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        Hide();
    }
}