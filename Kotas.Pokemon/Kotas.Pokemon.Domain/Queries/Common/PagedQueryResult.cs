namespace Kotas.Pokemon.Domain.Queries.Common
{
    public class PagedQueryResult<T> where T : class
    {
        public int TotalItems { get; set; }
        public int QuantityByPage { get; set; }
        public int TotalActualPage { get => Data.Count(); }
        public IEnumerable<T> Data { get; set; } = new List<T>();
    }
}
