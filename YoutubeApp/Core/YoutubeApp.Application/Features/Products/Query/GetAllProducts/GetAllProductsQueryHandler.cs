using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.DTOs;
using YoutubeApp.Application.Interfaces.AutoMapper;
using YoutubeApp.Application.Interfaces.UnitOfWorks;
using YoutubeApp.Domain.Entities;

namespace YoutubeApp.Application.Features.Products.Query.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(b => b.Brand));
            mapper.Map<BrandDto, Brand>(new Brand());
            //List<GetAllProductsQueryResponse> response = new();
            //foreach (var product in products)
            //{
            //    response.Add(new GetAllProductsQueryResponse()
            //    {
            //        Description = product.Description,
            //        Discount = product.Discount,
            //        Price = product.Price - (product.Price * product.Discount / 100),
            //        Title = product.Title,
            //    });
            //}
            var map = mapper.Map<GetAllProductsQueryResponse,Product>(products);
            foreach (var product in map) product.Price -= (product.Price * product.Discount) / 100;
            return map;
        }
    }
}
