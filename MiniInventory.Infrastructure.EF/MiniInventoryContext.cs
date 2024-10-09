
using Microsoft.EntityFrameworkCore;
using MiniInventory.Core.Domain;

namespace MiniInventory.Infrastructure.EF;
public class MiniInventoryContext : DbContext
{
    public MiniInventoryContext(DbContextOptions<MiniInventoryContext> options) : base(options)
    {

    }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
    public virtual DbSet<TransactionType> TransactionTypes { get; set; }
    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

}

