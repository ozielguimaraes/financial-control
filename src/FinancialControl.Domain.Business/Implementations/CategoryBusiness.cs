using FinancialControl.Domain.Business.Interfaces;
using FinancialControl.Domain.Business.Requests.Category;
using FinancialControl.Domain.Business.Responses.Category;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces.Services;
using FluentValidation;

namespace FinancialControl.Domain.Business.Implementations
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly ICategoryService _categoryService;

        public CategoryBusiness(ICategoryService CategoryService)
        {
            _categoryService = CategoryService;
        }

        public async Task<CreateCategoryResponse> Create(CreateCategoryRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ValidationException("Campo Nome é obrigatório.");

            var result = await _categoryService.Add(new Category
            {
                Name = request.Name
            });

            return new CreateCategoryResponse(result.CategoryId, result.Name);
        }

        public async Task<UpdateCategoryResponse> Update(UpdateCategoryRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ValidationException("Campo Nome é obrigatório.");

            if (await _categoryService.HasAny(x => x.Name.ToLower().Equals(request.Name.ToLower())))
                throw new ValidationException("Campo Nome é obrigatório.");

            var result = await _categoryService.Update(new Category
            {
                Name = request.Name,
                CategoryId = request.CategoryId,
                SubCategoryId = request.SubCategoryId
            });
            return new UpdateCategoryResponse(result.CategoryId, result.Name);
        }

        public async Task<CategoryResponse?> GetById(long categoryId)
        {
            var result = await _categoryService.GetById(categoryId);
            if (result is null) return default;

            return new CategoryResponse(result.CategoryId, result.Name);
        }

        public async Task<IEnumerable<CategoryResponse>> Filter(string search)
        {
            var result = await _categoryService.Filter(x => x.Name.Contains(search));
            return result.Select(s => new CategoryResponse(s.CategoryId, s.Name));
        }
    }
}
