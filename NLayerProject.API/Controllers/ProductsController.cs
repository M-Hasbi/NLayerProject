using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Filters;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using NLayerProject.API.DTOs;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDTO>>(products));
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDTO>(product));
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Product>))]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryId(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);

            return Ok(_mapper.Map<ProductWithCategoryDTO>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDTO)
        {
            var newProduct = await _productService.AddAsync(_mapper.Map<Product>(productDTO));
            return Created(string.Empty, _mapper.Map<ProductDTO>(newProduct));
        }

        [HttpPut]
        public IActionResult Update(ProductDTO productDTO)
        {
            var product = _productService.Update(_mapper.Map<Product>(productDTO));

            return NoContent();
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Product>))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.Remove(product);
            return NoContent();
        }



    }
}
