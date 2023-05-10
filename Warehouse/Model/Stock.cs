using System;
using System.Collections.Generic;

namespace Warehouse.Model;

public partial class Stock
{
    public int IdProduct { get; set; }

    public int IdWarehouse { get; set; }

    public int? Quanity { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Warehouse IdWarehouseNavigation { get; set; } = null!;
}
