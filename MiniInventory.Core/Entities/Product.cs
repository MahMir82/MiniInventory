

namespace MiniInventory.Core.Domain;

public class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public ICollection<Transaction> Transactions { get; set; } 
}
