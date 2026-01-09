namespace Catalog.Data
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options) { }

        public DbSet<Product.Models.Product> Products => Set<Product.Models.Product>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("Catalog");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
