
namespace MiniInventory.Core.Domain.Model;

public  class TransactionModel
{
    public int TransactionId { get; set; }

    public int ProductId { get; set; }

    public int WarehouseId { get; set; }

    public string TransactionTypeName { get; set; }

    public int Multiplier { get; set; }

    public int Quantity { get; set; }

    public DateTime TransactionDate { get; set; }
}
