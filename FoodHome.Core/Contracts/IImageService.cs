using FoodHome.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FoodHome.Core.Contracts
{
    public interface IImageService
    {
        Task<string> UploadImage(IFormFile imageFile, string nameFolder, int dishId);

        Task<string> UploadImage(IFormFile imageFile, string nameFolder, User user);
    }
}
