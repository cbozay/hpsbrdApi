using MediatR;

namespace YoutubeApp.Application.Features.Product.Query.GetAllProducts
{
    public class GetAllProductsQueryRequest:IRequest<IList<GetAllProductsQueryResponse>>
    {
    }
}