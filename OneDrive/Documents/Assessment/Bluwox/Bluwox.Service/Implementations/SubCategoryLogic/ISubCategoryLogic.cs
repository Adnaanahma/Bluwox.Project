using Bluwox.Model.ViewModels;

namespace Bluwox.Service.Implementations.SubCategoryLogic
{
    public interface ISubCategoryLogic
    {
        Task<BaseResponse> Add(SubCategoryRequest request);
    }
}
