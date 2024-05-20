using System.Linq;
using System.Windows.Controls;
using DPGI_Lab7.Models;

namespace DPGI_Lab7.Pages;

public partial class CompaniesPage : Page
{
    private DPGIDbContext _context;
    public CompaniesPage(DPGIDbContext context)
    {
        InitializeComponent();
        _context = context;

        MainTableGrid.DataContext = _context.Comapnies.ToList();
    }
}