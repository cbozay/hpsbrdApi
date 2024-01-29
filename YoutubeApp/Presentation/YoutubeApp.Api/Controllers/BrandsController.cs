using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeApp.Application.Features.Brands.Command.CreateBrand;
using YoutubeApp.Application.Features.Brands.Query.GetAllBrands;

namespace YoutubeApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator mediator;

        public BrandsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var response=await mediator.Send(new GetAllBrandsQueryRequest());
            return Ok(response);
        }
    }
}
