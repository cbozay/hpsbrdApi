using MediatR;
using YoutubeApp.Application.Interfaces.RedisCache;

namespace YoutubeApp.Application.Features.Brands.Query.GetAllBrands
{
    public class GetAllBrandsQueryRequest : IRequest<IList<GetAllBrandsQueryResponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllBrands";

        public double CacheTime => 5;
    }
}