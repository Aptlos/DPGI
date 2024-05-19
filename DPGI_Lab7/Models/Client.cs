using System;
using System.Collections.Generic;

namespace DPGI_Lab7.Models;

public partial class Client
{
    public long ClientId { get; set; }

    public string ClientName { get; set; } = null!;

    public string? ClientPhone { get; set; }

    public long Company { get; set; }

    public double? ClientGains { get; set; }

    public double? ClientSpends { get; set; }
}
