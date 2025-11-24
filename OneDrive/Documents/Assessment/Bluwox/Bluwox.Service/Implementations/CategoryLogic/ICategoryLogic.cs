using Bluwox.Model.Dtos;
using Bluwox.Model.ViewModels;

namespace Bluwox.Service.Implementations.CategoryLogic
{
    public interface ICategoryLogic
    {
        Task<BaseResponse> Add(CategoryRequest request);
        Task<BaseResponse<List<CategoryDto>>> GetAll();

    }
}
