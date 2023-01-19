using FinancialControl.Domain.Business.Requests.Category;
using FinancialControl.Domain.Business.Responses.Category;

namespace FinancialControl.Domain.Business.Interfaces
{
    public interface ICategoryBusiness
    {
        Task<CreateCategoryResponse> Create(CreateCategoryRequest request);
        Task<UpdateCategoryResponse> Update(UpdateCategoryRequest request);
        Task<CategoryResponse?> GetById(long cashierId);
        Task<IEnumerable<CategoryResponse>> Filter(string search);
    }
}
