using Bluwox.Model.Entities;

namespace Bluwox.Repository.SubCategoryRepo
{
    public interface ISubCategoryRepo
    {
        Task<bool> Add(string name, long catId);
        Task<bool> Update(SubCategory subCategory);
        Task<SubCategory> Get(long id);
    }
}
