using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeApp.Application.Features.Auth.Command.Login;
using YoutubeApp.Application.Features.Auth.Command.RefreshToken;
using YoutubeApp.Application.Features.Auth.Command.Register;
using YoutubeApp.Application.Features.Auth.Command.Revoke;
using YoutubeApp.Application.Features.Auth.Command.RevokeAll;

namespace YoutubeApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response=await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK,response);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeToken(RevokeCommandRequest request)//Bununla RefreshToken değerini null yapıyoruz.Böylece kullanıcı Logout olmuş oluyor.
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeAllToken(RevokeAllCommandRequest request)//Bununla bütün RefreshToken değerlerini null yapıyoruz.Böylece bütün kullanıcılar Logout olmuş oluyor.
        {
            await mediator.Send(new RevokeAllCommandRequest());//Herhangi bir request almadığımızdan dolayı böyle yaptık...
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
