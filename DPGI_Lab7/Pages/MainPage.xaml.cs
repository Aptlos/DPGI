using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DPGI_Lab7.Forms;
using DPGI_Lab7.Models;

namespace DPGI_Lab7.Pages;

public partial class MainPage : Page
{
    private bool isDirty;
    private DPGIDbContext _context;
    public MainPage()
    {
        InitializeComponent();

        _context = new DPGIDbContext();

        JoinTableTab();
        CompanyBox.DataContext = _context.Comapnies.ToList();
    }
        
    private void JoinTableTab()
    {

        var joined = _context.Clients.Join(_context.Comapnies,
            x => x.Company,
            y => y.CompanyId,
            (x, y) => new
            {
                x.ClientId,
                x.ClientName,
                x.ClientPhone,
                Company = y.CompanyName,
                x.ClientGains,
                x.ClientSpends
            });

        MainTableGrid.DataContext = joined.ToList();
    }
    
    private void MainTableGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (MainTableGrid.SelectedIndex>-1)
        {
            dynamic selectedClient = MainTableGrid.SelectedItem;
            string selectedCompany = selectedClient.Company;
            var company = _context.Comapnies.First(b => b.CompanyName == selectedCompany);
            CompanyBox.SelectedIndex = (int)company.CompanyId-1;
        }

    }
    
    private void CreateCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
        e.CanExecute = true;
    }
    private void CreateCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
        new CreateForm(_context).Show();
    }
    
    private void DeleteCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
        e.CanExecute = true;
    }
    private void DeleteCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
        int selectedId = Int32.Parse(IdBox.Text);
        var client = _context.Clients.Find((long)selectedId);

        _context.Clients.Remove(client);
    }
    
    private void FindCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
        e.CanExecute = true;
    }
    private void FindCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
        new FindForm(_context).Show();
    }
    
    private void EditCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
        e.CanExecute = true;
    }
    private void EditCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
        int selectedId = Int32.Parse(IdBox.Text);
        var client = _context.Clients.Find((long)selectedId);
        
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
        
        client.ClientName = name;
        client.ClientPhone = phone;
        client.Company = company+1;
        client.ClientGains = gains;
        client.ClientSpends = spends;

        _context.Clients.Update(client);


    }
    
    private void SaveCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
        e.CanExecute = true;
    }
    private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        _context.SaveChanges();
        MainTableGrid.SelectedIndex = -1;
    }
    
    private void ReloadCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
        e.CanExecute = true;
    }
    private void ReloadCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        JoinTableTab();
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
    
    private void ButtonHyper_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ClientsPage(_context));
    }
    
    private void ButtonHyper1_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new CompaniesPage(_context));
    }
    
}