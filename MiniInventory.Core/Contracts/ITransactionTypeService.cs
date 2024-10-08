using MiniInventory.Core.Domain.Model;

namespace MiniInventory.Core.Domain;
public interface ITransactionTypeService
{
    Task<List<TransactionTypeModel>> Get(CancellationToken cancellationToken);
}