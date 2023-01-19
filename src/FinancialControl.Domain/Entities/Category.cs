namespace FinancialControl.Domain.Entities
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }

        public long? SubCategoryId { get; set; }
        public Category? SubCategory { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }

        internal void Update(Category categoryUpdated)
        {
            Name = categoryUpdated.Name;
        }
    }
}
