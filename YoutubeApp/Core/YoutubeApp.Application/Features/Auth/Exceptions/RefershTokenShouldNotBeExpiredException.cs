using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.Bases;

namespace YoutubeApp.Application.Features.Auth.Exceptions
{
    public class RefershTokenShouldNotBeExpiredException : BaseException
    {
        public RefershTokenShouldNotBeExpiredException(): base("Oturum süresi sona ermiştir. Lütfen tekrar giriş yapın!!")
        {
        }
    }
}
