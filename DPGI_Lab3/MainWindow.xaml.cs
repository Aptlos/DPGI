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

namespace DPGI_Lab3
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
        
        private void Butto_Click(object sender, RoutedEventArgs e)
        {
            double v1=0, v2=0;
            var sb = new StringBuilder();
            var sb1 = new StringBuilder();
            var value1 = (Currency)Combo1.SelectedItem;
            var value2 = (Currency)Combo2.SelectedItem;
            if (double.TryParse(TextBox_Value1.Text, out v1))
            {
                v1 /= value1.Exchange;
                v2 = v1 * value2.Exchange;
                sb.Append(string.Format("{0:F3}", v2));
                
            }
            sb1.Append(string.Format("{0:F3}", value2.Exchange / value1.Exchange));
            TextBox_Value2.Text = sb.ToString();
            TextBox_Exchange.Text = sb1.ToString();

        }
    }
}