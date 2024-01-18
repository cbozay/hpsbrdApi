using MediatR;

namespace YoutubeApp.Application.Features.Products.Query.GetAllProducts
{
    public class GetAllProductsQueryRequest:IRequest<IList<GetAllProductsQueryResponse>>
    {
    }
}