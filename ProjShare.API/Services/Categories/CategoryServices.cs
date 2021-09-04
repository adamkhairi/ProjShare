using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProjShare.API.Data;
using ProjShare.Shared.Models;

namespace ProjShare.API.Services.Categories
{
    public class CategoryServices : ICategoryServices
    {
        private readonly SqlDbContext _db;

        public CategoryServices(SqlDbContext db)
        {
            _db = db;
        }

        public async Task Delete(string id)
        {
            var delCategory = await _db.Categories.FindAsync(id);
            _db.Categories.Remove(delCategory);
            await _db.SaveChangesAsync();
        }

        public async Task<Category> Get(string id)
        {
            var find = await _db.Categories.FindAsync(id);
            return find;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _db.Categories.ToListAsync();
            //var getItems = (Category)_db.Categories.OrderBy(i => i.Id);
            ////var getItems = await _db.Categories.ToListAsync();
            //string img = Convert.ToBase64String(getItems.Img);
            //string imageDataURL = string.Format("data:image/jpg;base64,{0}", img);
            ////var results = new Category()
            ////{
            ////    Id = getItems.Id,
            ////    Description = getItems.Description,
            ////    Name = getItems.Name,
            ////    Img = imageDataURL;
            ////}
            //return imageDataURL.ToList();
        }

        public async Task<Category> Post(Category category, List<IFormFile> image)
        {
            if (image.Count > 0)
            {
                foreach (var file in image)
                {
                    MemoryStream ms = new();
                    await file.CopyToAsync(ms);
                    category.Img = ms.ToArray();
                    _db.Categories.Add(category);
                    await _db.SaveChangesAsync();
                }
            }
            else
            {
                _db.Categories.Add(category);
                await _db.SaveChangesAsync();
            }

            //MemoryStream ms = new();
            //await image.CopyToAsync(ms);
            //category.Img = ms.ToArray();

            //_db.Categories.Add(category);
            //await _db.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Put(Category category, List<IFormFile> image)
        {
            //MemoryStream ms = new();
            //await image.CopyToAsync(ms);
            //category.Img = ms.ToArray();

            foreach (var file in image)
            {
                MemoryStream ms = new();
                await file.CopyToAsync(ms);
                category.Img = ms.ToArray();
                _db.Categories.Update(category);
                await _db.SaveChangesAsync();
            }

            return category;
            //_db.Entry(category).State = EntityState.Modified;
            //await _db.SaveChangesAsync();
        }
    }
}