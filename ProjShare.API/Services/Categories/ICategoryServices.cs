using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProjShare.Shared.Models;

namespace ProjShare.API.Services.Categories
{
    public interface ICategoryServices
    {
        Task<List<Category>> GetAll();
        Task<Category> Get(string categoryId);
        Task<Category> Post(Category category, List<IFormFile> image);
        Task<Category> Put(Category category, List<IFormFile> image);
        Task Delete(string id);
    }
}