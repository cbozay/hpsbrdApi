using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApp.Application.DTOs;

namespace YoutubeApp.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task CreateProductAsync(CreateProductDto createProductDto);
    }
}
