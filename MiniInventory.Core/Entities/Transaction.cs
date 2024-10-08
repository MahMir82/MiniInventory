

namespace MiniInventory.Core.Domain;

public  class Transaction
{
    public int TransactionId { get; set; }

    public int ProductId { get; set; }

    public int WarehouseId { get; set; }

    public string TransactionTypeName { get; set; } 

    public int Multiplier { get; set; }

    public int Quantity { get; set; }

    public DateTime TransactionDate { get; set; }

    public virtual Product Product { get; set; }

    public virtual Warehouse Warehouse { get; set; }
}
