using MediatR;
using System.ComponentModel;

namespace YoutubeApp.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest:IRequest<LoginCommandResponse>
    {
        [DefaultValue("string@hotmail.com")]//Uygulamayı test etmek için default username atadık
        public string Email { get; set; }// ="string@hotmail.com" olarak da kullanabilirdik
        [DefaultValue("string")]//Uygulamayı test etmek için default password atadık
        public string Password { get; set; }// ="string" olarak da kullanabilirdik
    }
}