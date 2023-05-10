using System;
using System.Collections.Generic;

namespace Warehouse.Model;

public partial class Warehouse
{
    public int IdWarehouse { get; set; }

    public string NameWarehouse { get; set; } = null!;

    public string AddressWarehouse { get; set; } = null!;

    public virtual ICollection<Carryng> Carryngs { get; set; } = new List<Carryng>();

    public virtual ICollection<Sales> Saleses { get; set; } = new List<Sales>();
    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
