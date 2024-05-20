using System.Linq;
using System.Windows.Controls;
using DPGI_Lab7.Models;

namespace DPGI_Lab7.Pages;

public partial class ClientsPage : Page
{
    private DPGIDbContext _context;
    public ClientsPage(DPGIDbContext context)
    {
        InitializeComponent();
        _context = context;

        MainTableGrid.DataContext = _context.Clients.ToList();
    }
}