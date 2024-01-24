using Azure.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.DTOs;
using YoutubeApp.Application.Features.Products.Rules;
using YoutubeApp.Application.Interfaces.Services;
using YoutubeApp.Application.Interfaces.UnitOfWorks;
using YoutubeApp.Domain.Entities;

namespace YoutubeApp.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ProductRules productRules;

        public ProductService(IUnitOfWork unitOfWork, ProductRules productRules)
        {
            this.unitOfWork = unitOfWork;
            this.productRules = productRules;
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

            await productRules.ProductTitleMustNotBeSame(products, createProductDto.Title);

            Product product = new(createProductDto.Title, createProductDto.Description, createProductDto.BrandId, createProductDto.Price, createProductDto.Discount);

            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);

            if (await unitOfWork.SaveAsync() > 0)
            {
                foreach (var categoryId in createProductDto.CategoryIds)
                {
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    });
                    await unitOfWork.SaveAsync();
                }
            }
        }
    }
}
