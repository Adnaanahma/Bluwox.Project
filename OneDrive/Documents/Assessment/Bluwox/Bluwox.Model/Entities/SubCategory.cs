using System.ComponentModel.DataAnnotations;

namespace Bluwox.Model.Entities
{
    public class SubCategory:  BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public long CategoryId {  get; set; }

        public Category Category { get; set; }
    }
}
