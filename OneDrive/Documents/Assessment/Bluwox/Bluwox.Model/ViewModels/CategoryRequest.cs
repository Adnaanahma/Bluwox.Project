using System.ComponentModel.DataAnnotations;

namespace Bluwox.Model.ViewModels
{
    public class CategoryRequest
    {
        [MaxLength(50)]
        public string Name {  get; set; }
    }
}
