using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.Bases;
using YoutubeApp.Application.Features.Auth.Rules;
using YoutubeApp.Application.Interfaces.AutoMapper;
using YoutubeApp.Application.Interfaces.UnitOfWorks;
using YoutubeApp.Domain.Entities;

namespace YoutubeApp.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public RegisterCommandHandler(AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;//Admin in register ettiği bir kullanıcıya rol ataması yapması için roleManager i çağırdık... 
        }

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

            User user = mapper.Map<User, RegisterCommandRequest>(request);

            user.UserName = request.Email;//Tablomda bu alan boş geçilemez olduğu için bu atamayı yaptık...

            user.SecurityStamp = Guid.NewGuid().ToString();//Aynı anda aynı user bilgileri kaydedilmesi olasılığına karşın alınan 
                                                           //alınan bir önlemdir. Milisaniyelerin önemli olduğu bu karşılaştırmayı sağlayabilmek için 
                                                           //işlemi tetikleyen unsura ilk davranan(kaydet butonuna basan) buradaki değeri veritabanında 
                                                           //değiştirecektir. Bu değer değiştiğinde ise artık sistem bu değerde ikinci bir değişikliğe izin
                                                           //vermeyeceği için bu bilgilerle ikinci bir kayıt işlemi gerçekleşemeyecektir.
            IdentityResult result = await userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync("user"))
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    });

                await userManager.AddToRoleAsync(user, "user");
            }

            return Unit.Value;
        }
    }
}
