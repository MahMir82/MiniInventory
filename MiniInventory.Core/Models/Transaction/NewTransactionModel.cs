
namespace MiniInventory.Core.Domain.Model;

public  class NewTransactionModel
{
    public int ProductId { get; set; }

    public int WarehouseId { get; set; }

    public string TransactionTypeName { get; set; }
       
    public int Quantity { get; set; }
}
