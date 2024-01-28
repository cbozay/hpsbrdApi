using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.Bases;
using YoutubeApp.Application.Features.Auth.Rules;
using YoutubeApp.Application.Interfaces.AutoMapper;
using YoutubeApp.Application.Interfaces.Token;
using YoutubeApp.Application.Interfaces.UnitOfWorks;
using YoutubeApp.Domain.Entities;

namespace YoutubeApp.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : BaseHandler,IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;
        private readonly AuthRules authRules;

        public LoginCommandHandler(UserManager<User> userManager, IConfiguration configuration,ITokenService tokenService,AuthRules authRules,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.tokenService = tokenService;
            this.authRules = authRules;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User? user = await userManager.FindByEmailAsync(request.Email);
           
            bool checkPassword=await userManager.CheckPasswordAsync(user,request.Password);

            await authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

            var roles = await userManager.GetRolesAsync(user);//Rolleri alma sebibimiz, bir token oluştururken
                                                              //içerisine claims leri ve rolleri gömmek içindir.
            JwtSecurityToken token = await tokenService.CreateToken(user, roles);

            string refreshToken = tokenService.GenerateRefreshToken();

            _ = int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

            user.RefreshToken = refreshToken;

            user.RefreshTokenExpiryTime=DateTime.Now.AddDays(refreshTokenValidityInDays);

            await userManager.UpdateAsync(user);//Bunu yapma sebebimiz, atamış olduğum RefreshToken ve RefreshTokenExpiryTime
                                                //database ye kaydetmek içindir...
            await userManager.UpdateSecurityStampAsync(user);//Üstteki mantığın aynısı...

            string _token = new JwtSecurityTokenHandler().WriteToken(token);//token değerini database ye yazdırmak için string
                                                                            //dönüş değeri gerekmektedir...
            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);//token değerini database ye 
                                                                                                  //kaydettik...
            return new()
            {
                Token = _token,
                RefreshToken = refreshToken,
                Expiration = token.ValidTo,//JwtSecurityToken geçerlilik süresini token ın içerisinden direkt alır...
            };
        }
    }
}
