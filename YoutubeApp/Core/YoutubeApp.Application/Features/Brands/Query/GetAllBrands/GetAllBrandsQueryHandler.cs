using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.Bases;
using YoutubeApp.Application.Interfaces.AutoMapper;
using YoutubeApp.Application.Interfaces.UnitOfWorks;
using YoutubeApp.Domain.Entities;

namespace YoutubeApp.Application.Features.Brands.Query.GetAllBrands
{
    public class GetAllBrandsQueryHandler : BaseHandler,IRequestHandler<GetAllBrandsQueryRequest, IList<GetAllBrandsQueryResponse>>
    {
        public GetAllBrandsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllBrandsQueryResponse>> Handle(GetAllBrandsQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await unitOfWork.GetReadRepository<Brand>().GetAllAsync();

            return mapper.Map<GetAllBrandsQueryResponse, Brand>(brands);
        }
    }
}
