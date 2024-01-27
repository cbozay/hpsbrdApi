using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.Bases;
using YoutubeApp.Application.Features.Auth.Register.Exceptions;
using YoutubeApp.Domain.Entities;

namespace YoutubeApp.Application.Features.Auth.Register.Rules
{
    public class AuthRules:BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user != null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }
    }
}
