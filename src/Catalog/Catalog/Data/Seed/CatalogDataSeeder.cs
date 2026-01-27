using Shared.Data.Seed;

namespace Catalog.Data.Seed
{
    public class CatalogDataSeeder(CatalogDbContext dbContext) : IDataSeeder
    {
        public async Task SeedAllAsync()
        {
            if (!await dbContext.Products.AnyAsync()) 
            {
                await dbContext.Products.AddRangeAsync(Products);
                await dbContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Product.Models.Product> Products => new List<Product.Models.Product>
        {
            Product.Models.Product.Create(new Guid(), "IPhone X", ["Category1"], "Description for product 1", "imagefile", 500),
            Product.Models.Product.Create(new Guid(), "Samsong 10", ["Category2"], "Description for product 1", "imagefile", 400),
            Product.Models.Product.Create(new Guid(), "Huwei Plus", ["Category3"], "Description for product 1", "imagefile", 650),
            Product.Models.Product.Create(new Guid(), "Xiaomi Mi", ["Category4"], "Description for product 1", "imagefile", 450),
        };
    }
}
