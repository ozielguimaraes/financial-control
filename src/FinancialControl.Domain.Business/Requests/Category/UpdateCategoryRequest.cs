namespace FinancialControl.Domain.Business.Requests.Category
{
    public class UpdateCategoryRequest
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public long? SubCategoryId { get; set; }
    }
}
