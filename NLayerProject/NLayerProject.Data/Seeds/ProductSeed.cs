using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;

namespace NLayerProject.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Needle Pen", Price = 12.50m, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 2, Name = "Pen", Price = 20m, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 3, Name = "Fountain Pen", Price = 11m, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 4, Name = "Small Size Notebook", Stock = 100, Price = 30m, CategoryId = _ids[1] },
                new Product { Id = 5, Name = "Midle Size Notebook", Stock = 100, Price = 32m, CategoryId = _ids[1] },
                new Product { Id = 6, Name = "Large Size Notebook", Stock = 100, Price = 35m, CategoryId = _ids[1] }
                );
        }
    }
}
