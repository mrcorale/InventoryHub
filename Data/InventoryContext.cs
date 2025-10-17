namespace InventoryHub.Data;

public class InventoryContext : DbContext
{
    public InventoryContext(DbContextOptions<InventoryContext> options)
        : base(options)
    {
    }

    public DbSet<InventoryItem> Items => Set<InventoryItem>();
}