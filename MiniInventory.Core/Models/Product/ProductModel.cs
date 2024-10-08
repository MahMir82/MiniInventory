
namespace MiniInventory.Core.Domain.Model;

public class ProductModel
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

}
