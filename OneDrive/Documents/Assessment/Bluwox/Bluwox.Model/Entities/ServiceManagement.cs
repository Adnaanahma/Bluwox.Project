using System.ComponentModel.DataAnnotations;
using Bluwox.Core.Enums;

namespace Bluwox.Model.Entities
{
    public class ServiceManagement: BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        public long CategoryId {  get; set; }

        public decimal BaseFare {  get; set; }

        public Status Status {  get; set; }

        public Category Category { get; set; }
    }
}
