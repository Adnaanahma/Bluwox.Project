using System.ComponentModel.DataAnnotations;
using Bluwox.Core.Enums;

namespace Bluwox.Model.ViewModels
{
    public class ServiceManagementRequest
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public long CategoryId { get; set; }

        public decimal BaseFare {  get; set; }
    }

    public class ServiceManagementUpdateRequest: ServiceManagementRequest
    {
        public long Id { get; set; }
    }

    public class ServiceManagementStatusRequest
    {
        public long Id { get; set; }
        public Status Status { get; set; }
    }
}
