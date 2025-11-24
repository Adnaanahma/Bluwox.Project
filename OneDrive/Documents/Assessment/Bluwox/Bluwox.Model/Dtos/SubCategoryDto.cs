namespace Bluwox.Model.Dtos
{
    public class SubCategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long CategoryId { get; set; }

        public CategoryDto Category { get; set; }
    }
}
