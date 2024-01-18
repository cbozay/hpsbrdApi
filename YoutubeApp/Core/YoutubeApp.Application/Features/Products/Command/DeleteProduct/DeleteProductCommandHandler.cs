using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.Interfaces.UnitOfWorks;
using YoutubeApp.Domain.Entities;

namespace YoutubeApp.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(p => p.Id == request.Id && !p.IsDeleted);

            product.IsDeleted = true;

            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);

            await unitOfWork.SaveAsync();
        }
    }
}
