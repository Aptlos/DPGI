using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using DPGI_Lab5.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace DPGI_Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            using var context = new DPGIDbContext();
            ClientsGrid.DataContext = context.Clients.ToList();
            CompaniesGrid.DataContext = context.Comapnies.ToList();
            
            JoinTableTab();
        }
        
        private void JoinTableTab()
        {
            using var context = new DPGIDbContext();
            
            var joined = context.Clients.Join(context.Comapnies,
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

            JoinTableGrid.DataContext = joined.ToList();
        }

        private void SerchTabTextChanged(object sender, RoutedEventArgs e)
        {
            using var context = new DPGIDbContext();
            
            var id = Convert.ToInt32(IfEmptyThenZero(IdBox.Text.Trim()));
            var name = NameBox.Text.Trim();
            var phone = PhoneBox.Text.Trim();
            var company = Convert.ToInt32(IfEmptyThenZero(CompanyBox.Text.Trim()));
            var gains = Convert.ToDouble(IfEmptyThenZero(GainsBox.Text.Trim()));
            var spends = Convert.ToDouble(IfEmptyThenZero(SpendsBox.Text.Trim()));
        
            var predicate = PredicateBuilder.New<Client>();

            if (id!= 0) predicate.And(b => b.ClientId==id);
            if (!string.IsNullOrEmpty(name)) predicate.And(b => b.ClientName.Contains(name));
            if (!string.IsNullOrEmpty(phone)) predicate.And(b => b.ClientPhone.Contains(phone));
            if (company!=0) predicate.And(b => b.Company==company);
            if (gains != 0) predicate.And(b => b.ClientGains == gains);
            if (spends != 0) predicate.And(b => b.ClientSpends == spends);
        
            SearchClientsGrid.DataContext = context.Clients.Where(predicate).ToList();
        }

        private void SearchByCompany(object sender, RoutedEventArgs e)
        {
            using var context = new DPGIDbContext();
        
            var company = CompanySearchBox.Text.Trim();
        
            var joined = context.Clients.Join(context.Comapnies,
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


            SearchByCompanyGrid.DataContext = joined
                .Where(b => b.Company.Contains(company))
                .ToList();
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
}