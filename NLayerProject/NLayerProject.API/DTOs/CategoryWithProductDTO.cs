using NLayerProject.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_LayerProject.DTOs
{
    public class CategoryWithProductDTO : CategoryDTO
    {
        public ICollection<ProductDTO> Products { get; set; }
    }
}
