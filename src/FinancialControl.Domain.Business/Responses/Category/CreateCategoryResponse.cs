namespace FinancialControl.Domain.Business.Responses.Category
{
    public class CreateCategoryResponse : BaseResponse
    {
        public CreateCategoryResponse(long categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }

        public long CategoryId { get; private set; }
        public string Name { get; private set; }
    }
}
