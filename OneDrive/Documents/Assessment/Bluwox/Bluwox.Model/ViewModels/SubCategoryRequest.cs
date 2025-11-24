using System.ComponentModel.DataAnnotations;

namespace Bluwox.Model.ViewModels
{
    public class SubCategoryRequest
    {

        [MaxLength(50)]
        public string Name { get; set; }

        public long CategoryId {  get; set; }
    }
}
