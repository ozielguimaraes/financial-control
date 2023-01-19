namespace FinancialControl.Domain.Business.Responses.Category
{
    public class UpdateCategoryResponse : BaseResponse
    {
        public UpdateCategoryResponse(long categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }

        public long CategoryId { get; private set; }
        public string Name { get; private set; }
    }
}
