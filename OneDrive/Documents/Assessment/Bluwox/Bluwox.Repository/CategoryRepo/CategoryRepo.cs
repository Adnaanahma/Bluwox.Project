using Bluwox.Migrations;
using Bluwox.Model.Dtos;
using Bluwox.Model.Entities;
using Bluwox.Model.ViewModels;
using Bluwox.Repository.Cache;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Bluwox.Repository.CategoryRepo
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICacheService _cache;

        public CategoryRepo(ApplicationDbContext dbContext, ICacheService cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        // add category repository
        public async Task<bool> Add(string name)
        {
            try
            {
                Category category = new Category
                {
                    Name = name
                };

                await _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();

                await _cache.RemoveItemFromCache("category_list_");

                return true;
            }
            catch (Exception ex)
            {
                //log
                return false;
            }
        }

        //update category repository
        public async Task<bool> Update(Category category)
        {
            try
            {
                _dbContext.Categories.Update(category);
                await _dbContext.SaveChangesAsync();

                await _cache.RemoveItemFromCache("category_list_");

                return true;
            }
            catch (Exception ex)
            {
                //log
                return false;
            }
        }

        // get category repository
        public async Task<Category> Get(long id)
        {
            try
            {
                return await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                //log
                return null;
            }
        }

        // get-all category repository
        public async Task<List<Category>> GetAll()
        {
            try
            {
                var categories = new List<Category>();

                var cachedString = await _cache.GetValue("category_list_");
                if (!string.IsNullOrEmpty(cachedString))
                {
                    categories = JsonConvert.DeserializeObject<List<Category>>(cachedString);
                }
                else
                {
                    categories = _dbContext.Categories.ToList();
                    if(categories.Count > 0)
                    {
                        await _cache.SetValue("category_list_", JsonConvert.SerializeObject(categories), 2592000000);
                    }
                }  

                return categories;
            }
            catch (Exception ex)
            {
                // log exception here
                throw;
            }
        }
    }
}
