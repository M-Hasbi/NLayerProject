using System.ComponentModel.DataAnnotations;

namespace NLayerProject.Web.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} can not be empty.")]
        public string Name { get; set; }
    }
}
