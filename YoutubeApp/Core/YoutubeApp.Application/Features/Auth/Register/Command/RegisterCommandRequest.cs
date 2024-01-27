using MediatR;

namespace YoutubeApp.Application.Features.Auth.Register.Command
{
    public class RegisterCommandRequest:IRequest<Unit>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}