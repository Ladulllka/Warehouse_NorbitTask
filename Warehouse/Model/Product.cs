using System;
using System.Collections.Generic;

namespace Warehouse.Model;

public partial class Product
{
    public int IdProduct { get; set; }

    public string NameProduct { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int? IdCategory { get; set; }

    public virtual ICollection<Carryng> Carryngs { get; set; } = new List<Carryng>();

    public virtual ICollection<Sales> Saleses { get; set; } = new List<Sales>();

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
