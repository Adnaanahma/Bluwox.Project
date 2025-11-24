using System.Collections.Generic;
using AutoMapper;
using Bluwox.Model.Dtos;
using Bluwox.Model.ViewModels;
using Bluwox.Repository.CategoryRepo;
using Microsoft.EntityFrameworkCore;

namespace Bluwox.Service.Implementations.CategoryLogic
{
    public class CategoryLogic: ICategoryLogic
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryLogic(ICategoryRepo categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// "add category logic"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Add(CategoryRequest request)
        {
            var repoResponse = await _categoryRepo.Add(request.Name);

            return repoResponse ? BaseResponse.Success("Category created succesfully") : BaseResponse.Failure("Adding new category failed.");
        }

        /// <summary>
        /// "update category logic"
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponse<List<CategoryDto>>> GetAll()
        {
            try
            {
                var repoResponse = await _categoryRepo.GetAll();
                var mappedResponse = _mapper.Map<List<CategoryDto>>(repoResponse);

                return BaseResponse<List<CategoryDto>>.Success(mappedResponse, "Recore retrieved successfully");
            }
            catch (Exception ex)
            {
                return BaseResponse<List<CategoryDto>>.Failure(null, $"Error: {ex.Message}");
            }
        }
    }
}
