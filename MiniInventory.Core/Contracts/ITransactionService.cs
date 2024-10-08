using MiniInventory.Core.Domain.Model;

namespace MiniInventory.Core.Domain;
public interface ITransactionService
{
    Task<List<TransactionModel>> Get(CancellationToken cancellationToken);
    Task<List<TransactionModel>> GetTransactionByTypeName(string typeName, CancellationToken cancellationToken);
    Task Insert(NewTransactionModel model, CancellationToken cancellationToken);
}