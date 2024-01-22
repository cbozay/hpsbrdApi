using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.Bases;
using YoutubeApp.Application.Features.Products.Exceptions;
using YoutubeApp.Domain.Entities;

namespace YoutubeApp.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<Product> products,string requestTitle)
        {
            if (products.Any(p=>p.Title==requestTitle)) throw new ProductTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
