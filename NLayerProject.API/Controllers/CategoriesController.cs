using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Filters;
using NLayerProject.API.DTOs;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();


            return Ok(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
        }
        [ServiceFilter(typeof(GenericNotFoundFilter<Category>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            return Ok(_mapper.Map<CategoryDTO>(category));
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Category>))]
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductsById(int id)
        {
            var category = await _categoryService.GetWithProductsByIdAsync(id);

            return Ok(_mapper.Map<CategoryWithProductDTO>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDTO categoryDTO)
        {
            var newCategory = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDTO));

            return Created(string.Empty, _mapper.Map<CategoryDTO>(newCategory));
        }

        [HttpPut]
        public IActionResult Update(CategoryDTO categoryDTO)
        {
            var category = _categoryService.Update(_mapper.Map<Category>(categoryDTO));

            return NoContent();
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Category>))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;

            _categoryService.Remove(category);
            return NoContent();
        }


    }
}
