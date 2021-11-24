using System.ComponentModel.DataAnnotations;

namespace NLayerProject.API.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
