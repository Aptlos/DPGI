using System;
using System.Collections.Generic;

namespace DPGI_Lab6.Models;

public partial class Value
{
    public long ValId { get; set; }

    public string ValName { get; set; } = null!;

    public string ValCode { get; set; } = null!;

    public double ExchangeRate { get; set; }
}
