using System.Collections.Generic;

namespace NLayerProject.Web.DTOs
{
    public class CategoryWithProductDTO : CategoryDTO
    {
        public ICollection<ProductDTO> Products { get; set; }
    }
}
