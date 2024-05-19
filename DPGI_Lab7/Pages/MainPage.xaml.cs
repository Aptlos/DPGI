using System.Linq;
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
        new EditForm(_context).Show();
    }
    
    private void SaveCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
        e.CanExecute = true;
    }
    private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
        
    }
}