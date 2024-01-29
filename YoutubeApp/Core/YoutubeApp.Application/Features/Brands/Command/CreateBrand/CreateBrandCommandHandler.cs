﻿using Bogus;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.Bases;
using YoutubeApp.Application.Interfaces.AutoMapper;
using YoutubeApp.Application.Interfaces.UnitOfWorks;
using YoutubeApp.Domain.Entities;

namespace YoutubeApp.Application.Features.Brands.Command.CreateBrand
{
    public class CreateBrandCommandHandler : BaseHandler,IRequestHandler<CreateBrandCommandRequest, Unit>
    {
        public CreateBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Faker faker = new("tr");

            List<Brand> brands = new();

            for (int i = 0; i < 1000000; i++)
            {
                brands.Add(new(faker.Commerce.Department(1)));
            }

            await unitOfWork.GetWriteRepository<Brand>().AddRangeAsync(brands);

            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
