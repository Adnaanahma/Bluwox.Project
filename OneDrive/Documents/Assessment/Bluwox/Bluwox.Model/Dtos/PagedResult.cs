namespace Bluwox.Model.Dtos
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public bool HasNextPage { get; set; }
        public int TotalRecordInStore { get; set; }

    }
}
