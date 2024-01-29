using MediatR;

namespace YoutubeApp.Application.Features.Brands.Command.CreateBrand
{
    public class CreateBrandCommandRequest:IRequest<Unit>
    {
        public string Name { get; set; }
    }
}