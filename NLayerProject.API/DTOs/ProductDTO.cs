﻿using System;
using System.ComponentModel.DataAnnotations;

namespace NLayerProject.API.DTOs
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
        public int CategoryId { get; set; }
    }
}
