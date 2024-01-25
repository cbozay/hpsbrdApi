using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Domain.Entities;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace YoutubeApp.Application.Interfaces.Token
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
