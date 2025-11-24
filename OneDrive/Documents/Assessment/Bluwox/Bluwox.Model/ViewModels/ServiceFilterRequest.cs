namespace Bluwox.Model.ViewModels
{
    public class ServiceFilterRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string ServiceName { get; set; }
        public int Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
