using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using DPGI_Lab7.Models;
using LinqKit;

namespace DPGI_Lab7.Forms;

public partial class FindForm : Window
{
    private DPGIDbContext _context;
    
    public FindForm(DPGIDbContext context)
    {
        InitializeComponent();
        _context = context;
    }

    private void SerchTabTextChanged(object sender, RoutedEventArgs e)
    {

        var id = Convert.ToInt32(IfEmptyThenZero(IdBox.Text.Trim()));
        var name = NameBox.Text.Trim();
        var phone = PhoneBox.Text.Trim();
        var company = CompanyBox.Text.Trim();
        var gains = Convert.ToDouble(IfEmptyThenZero(GainsBox.Text.Trim()));
        var spends = Convert.ToDouble(IfEmptyThenZero(SpendsBox.Text.Trim()));
        
        var predicate = PredicateBuilder.New<Client>();
        var predicateComp = PredicateBuilder.New<Client>();

        if (id != 0) predicate.And(b => b.ClientId == id);
        if (!string.IsNullOrEmpty(name)) predicate.And(b => b.ClientName.Contains(name));
        if (!string.IsNullOrEmpty(phone)) predicate.And(b => b.ClientPhone.Contains(phone));
        if (gains != 0) predicate.And(b => b.ClientGains == gains);
        if (spends != 0) predicate.And(b => b.ClientSpends == spends);
        
        var searchResult = _context.Clients.Where(predicate).ToList();
        
        if (!company.Equals(""))
        {
            var companies = _context.Comapnies.Where(b => b.CompanyName.Contains(company));
            foreach (var x in companies)
            {
                predicateComp.Or(b => b.Company == x.CompanyId);
            }

            if (companies.ToList().Count == 0) predicate.And(b => b.Company == 0);
            
            if (searchResult.Count==0)
            {
               searchResult= _context.Clients.Where(predicateComp).ToList();
            }
            else searchResult = searchResult.Where(predicateComp ).ToList();
        }
        
       
        
        var joined = searchResult.Join(_context.Comapnies,
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
        SearchClientsGrid.DataContext = joined.ToList();
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