using NLayerProject.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_LayerProject.DTOs
{
    public class ProductWithCategoryDTO : ProductDTO
    {
        public CategoryDTO Category { get; set; }
    }
}
