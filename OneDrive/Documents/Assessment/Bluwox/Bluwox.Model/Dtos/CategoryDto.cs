namespace Bluwox.Model.Dtos
{
    public class CategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<SubCategoryDto> SubCategories { get; set; }
    }
}
