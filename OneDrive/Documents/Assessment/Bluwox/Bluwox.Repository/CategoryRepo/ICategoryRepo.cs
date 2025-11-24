using Bluwox.Model.Dtos;
using Bluwox.Model.Entities;
using Bluwox.Model.ViewModels;

namespace Bluwox.Repository.CategoryRepo
{
    public interface ICategoryRepo
    {
        Task<bool> Add(string name);
        Task<bool> Update(Category category);
        Task<Category> Get(long id);
        Task<List<Category>> GetAll();
    }
}
