namespace DSOperationEFCore.Data
{
    public class CurrencyType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public ICollection<BookPrice> lstBookPrice { get; set; }
    }
}
