using System.Collections.Generic;

namespace NLayerProject.API.DTOs
{
    public class CategoryWithProductDTO : CategoryDTO
    {
        public ICollection<ProductDTO> Products { get; set; }
    }
}
