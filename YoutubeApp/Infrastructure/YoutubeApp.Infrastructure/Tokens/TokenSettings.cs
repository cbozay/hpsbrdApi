using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApp.Infrastructure.Tokens
{
    //Bu class ı Token datalarını appSettings den almak için kullanıyor oluyoruz.
    //Yani her seferinde configuration["JWT:Audience"] vs verilere tek tek ulaşmak yerine 
    //bir kez customize edilmiş sınıfı kullanıyor olucaz...
    //Burada refreshToken ın bir önemi olmadığından, diğer verileri elde etmem yeterlidir.
    public class TokenSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int TokenValidityInMinutes { get; set; }

    }
}
