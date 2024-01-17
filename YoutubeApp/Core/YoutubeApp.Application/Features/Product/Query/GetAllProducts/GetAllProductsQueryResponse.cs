using YoutubeApp.Domain.Entities;

namespace YoutubeApp.Application.Features.Product.Query.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}