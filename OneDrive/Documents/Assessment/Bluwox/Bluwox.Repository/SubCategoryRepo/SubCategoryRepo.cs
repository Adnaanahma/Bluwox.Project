using Bluwox.Migrations;
using Bluwox.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bluwox.Repository.SubCategoryRepo
{
    public class SubCategoryRepo: ISubCategoryRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public SubCategoryRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// "add sub-category repository"
        /// </summary>
        /// <param name="name"></param>
        /// <param name="catId"></param>
        /// <returns></returns>
        public async Task<bool> Add(string name, long catId)
        {
            try
            {
                SubCategory subCategory = new SubCategory
                {
                    Name = name,
                    CategoryId = catId
                };

                await _dbContext.SubCategories.AddAsync(subCategory);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                //log
                throw;
            }
        }

        /// <summary>
        /// "update sub-category repo"
        /// </summary>
        /// <param name="subCategory"></param>
        /// <returns></returns>
        public async Task<bool> Update(SubCategory subCategory)
        {
            try
            {
                _dbContext.SubCategories.Update(subCategory);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                //log
                throw;
            }
        }

        /// <summary>
        /// "get sub-category repo"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SubCategory> Get(long id)
        {
            try
            {
                return await _dbContext.SubCategories.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                //log
                throw;
            }
        }
    }
}
