using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.DTOs;
using YoutubeApp.Application.Features.Products.Rules;
using YoutubeApp.Application.Interfaces.AutoMapper;
using YoutubeApp.Application.Interfaces.Services;
using YoutubeApp.Application.Interfaces.UnitOfWorks;
using YoutubeApp.Domain.Entities;

namespace YoutubeApp.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest,Unit>
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(IProductService productService,IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var createProductDto=mapper.Map<CreateProductDto, CreateProductCommandRequest>(request);
            await productService.CreateProductAsync(createProductDto);

            return Unit.Value;
        }
    }
}

