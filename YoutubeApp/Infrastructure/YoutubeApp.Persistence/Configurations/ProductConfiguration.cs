using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Domain.Entities;

namespace YoutubeApp.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker = new("tr");

            Product product1 = new()
            {
                Id = 1,
                BrandId = 1,
                CreatedTime = DateTime.Now,
                Description = faker.Commerce.ProductDescription(),
                Discount = faker.Random.Decimal(0, 10),
                Price = faker.Finance.Amount(10, 1000),
                IsDeleted = false,
                Title = faker.Commerce.ProductName(),
            };

            Product product2 = new()
            {
                Id = 2,
                BrandId = 3,
                CreatedTime = DateTime.Now,
                Description = faker.Commerce.ProductDescription(),
                Discount = faker.Random.Decimal(0, 10),
                Price = faker.Finance.Amount(10, 1000),
                IsDeleted = false,
                Title = faker.Commerce.ProductName(),
            };

            builder.HasData(product1, product2);
        }
    }
}
