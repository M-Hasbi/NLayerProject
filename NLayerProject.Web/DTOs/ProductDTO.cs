using System;
using System.ComponentModel.DataAnnotations;

namespace NLayerProject.Web.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} field must be filled")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} field must be greater than 1")]
        public int Stock { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "{0} field must be greater than 1")]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="{0} must be filled")]
        public int CategoryId { get; set; }
    }
}
