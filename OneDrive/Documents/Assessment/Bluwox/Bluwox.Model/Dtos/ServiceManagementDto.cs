using Bluwox.Core.Enums;

namespace Bluwox.Model.Dtos
{
    public class ServiceManagementDto: BaseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long CategoryId { get; set; }

        public decimal BaseFare { get; set; }

        public Status Status { get; set; }

        public CategoryDto Category { get; set; }
    }
}
