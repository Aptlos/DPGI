using System;
using System.Collections.Generic;
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
using DPGI_Lab6.Models;

namespace DPGI_Lab6
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
            Combo1.DataContext= context.Values.ToList();
            Combo2.DataContext = context.Values.ToList();
        }
        
        private void Butto_Click(object sender, RoutedEventArgs e)
        {
            using var context = new DPGIDbContext();
            double v1=0, v2=0;
            var sb = new StringBuilder();
            var sb1 = new StringBuilder();
            var value1 = (Value)Combo1.SelectedItem;
            var value2 = (Value)Combo2.SelectedItem;
            if (double.TryParse(TextBox_Value1.Text, out v1))
            {
                v1 /= value1.ExchangeRate;
                v2 = v1 * value2.ExchangeRate;
                sb.Append(string.Format("{0:F3}", v2));
                
            }
            sb1.Append(string.Format("{0:F3}", value2.ExchangeRate / value1.ExchangeRate));
            TextBox_Value2.Text = sb.ToString();
            TextBox_Exchange.Text = sb1.ToString();
        }
        
        private void Exchange_Click(object sender, RoutedEventArgs e)
        {
            new ExchangeWindow().Show();
        }
    }
}