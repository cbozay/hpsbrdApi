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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category category1 = new()
            {
                Id = 1,
                Name = "Elektrik",
                Priority = 1,
                ParentId = 0,
                CreatedTime = DateTime.Now,
                IsDeleted = false,
            };

            Category category2 = new()
            {
                Id = 2,
                Name = "Moda",
                Priority = 2,
                ParentId = 0,
                CreatedTime = DateTime.Now,
                IsDeleted = false,
            };

            Category parent1 = new()
            {
                Id = 3,
                Name = "Bilgisayar",
                Priority = 1,
                ParentId = 1,
                CreatedTime = DateTime.Now,
                IsDeleted = true,
            };

            Category parent2 = new()
            {
                Id = 4,
                Name = "Kadın",
                Priority = 1,
                ParentId = 2,
                CreatedTime = DateTime.Now,
                IsDeleted = false,
            };

            builder.HasData(category1, category2, parent1, parent2);
        }
    }
}
