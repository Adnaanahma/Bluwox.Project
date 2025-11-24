using Bluwox.Model.ViewModels;
using Bluwox.Repository.SubCategoryRepo;

namespace Bluwox.Service.Implementations.SubCategoryLogic
{
    public class SubCategoryLogic: ISubCategoryLogic
    {
        private readonly ISubCategoryRepo _subCategoryRepo;

        public SubCategoryLogic(ISubCategoryRepo subCategoryRepo)
        {
            _subCategoryRepo = subCategoryRepo;
        }

        /// <summary>
        /// "add sub-category logic"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Add(SubCategoryRequest request)
        {
            var repoResponse = await _subCategoryRepo.Add(request.Name, request.CategoryId);

            return repoResponse ? BaseResponse.Success("Sub category created succesfully") : BaseResponse.Failure("Adding new sub category failed.");
        }
    }
}
