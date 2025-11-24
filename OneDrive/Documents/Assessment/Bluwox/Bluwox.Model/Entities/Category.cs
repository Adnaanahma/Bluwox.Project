using System.ComponentModel.DataAnnotations;

namespace Bluwox.Model.Entities
{
    public class Category: BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
        public ICollection<ServiceManagement> ServiceManagements { get; set; }
    }
}
