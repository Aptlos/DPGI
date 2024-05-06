using System.Linq;
using System.Windows;
using DPGI_Lab6.Models;

namespace DPGI_Lab6;

public partial class ExchangeWindow : Window
{
    public ExchangeWindow()
    {
        InitializeComponent();
        
        using var context = new DPGIDbContext();
        List1.DataContext= context.Values.ToList();
    }
}