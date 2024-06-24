using System;
using System.Collections.Generic;

namespace sedra_0sman.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? Photo { get; set; }

    public virtual Cart IdNavigation { get; set; } = null!;
}
