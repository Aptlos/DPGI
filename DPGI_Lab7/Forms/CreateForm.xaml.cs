using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using DPGI_Lab7.Models;

namespace DPGI_Lab7.Forms;

public partial class CreateForm : Window
{
    private DPGIDbContext _context;
    public CreateForm(DPGIDbContext context)
    {
        InitializeComponent();
        _context = context;
        CompanyBox.DataContext = _context.Comapnies.ToList();
    }

    private void OkButton_OnClick(object sender, RoutedEventArgs e)
    {
        string name = "-";
        string phone = "-";
        var company = CompanyBox.SelectedIndex;

        var gains = Convert.ToDouble(IfEmptyThenZero(GainsBox.Text.Trim()));
        var spends = Convert.ToDouble(IfEmptyThenZero(SpendsBox.Text.Trim()));
        if (NameBox.Text.Trim() != "")
        {
            name = NameBox.Text.Trim();
        }
        if (PhoneBox.Text.Trim() != "")
        {
            phone = PhoneBox.Text.Trim();
        }
        
        var client = new Client();
        client.ClientName = name;
        client.ClientPhone = phone;
        client.Company = company+1;
        client.ClientGains = gains;
        client.ClientSpends = spends;

        _context.Clients.Add(client);
        //_context.SaveChanges();
        Hide();
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        Hide();
    }
    
    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        var regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
    
    private static string IfEmptyThenZero(string s)
    {
        return string.IsNullOrEmpty(s) ? "0" : s;
    }
}