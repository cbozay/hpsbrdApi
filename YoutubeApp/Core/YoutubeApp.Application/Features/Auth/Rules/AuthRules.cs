using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.Bases;
using YoutubeApp.Application.Features.Auth.Exceptions;
using YoutubeApp.Domain.Entities;

namespace YoutubeApp.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user != null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }

        public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checkPassword)
        {
            if (user == null || !checkPassword) throw new EmailOrPasswordShouldNotBeInvalidException();
            return Task.CompletedTask;
        }

        public Task RefreshTokenShouldNotBeExpired(User user)
        {
            if (user.RefreshTokenExpiryTime<=DateTime.Now) throw new RefershTokenShouldNotBeExpiredException();
            return Task.CompletedTask;
        }

        public Task EmailAddressShouldBeValid(User? user)
        {
            if (user is null) throw new EmailAddressShouldBeValidException();
            return Task.CompletedTask;  
        }
    }
}
