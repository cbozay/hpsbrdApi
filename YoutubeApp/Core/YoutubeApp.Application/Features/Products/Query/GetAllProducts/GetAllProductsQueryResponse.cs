using YoutubeApp.Application.DTOs;
using YoutubeApp.Domain.Entities;

namespace YoutubeApp.Application.Features.Products.Query.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public BrandDto Brand{ get; set; }
    }
}