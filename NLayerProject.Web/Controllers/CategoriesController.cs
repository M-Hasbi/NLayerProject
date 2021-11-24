using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;
using NLayerProject.Web.DTOs;
using NLayerProject.Web.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryDTO));
            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Category>))]
        //update/5 --> Brings 5th number of id category then with post method which located below, is 
        //gonna take new categoryDto item, update it and return to the Index. 
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDTO>(category));
        }

        [HttpPost]
        public IActionResult Update(CategoryDTO categoryDTO)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDTO));

            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Category>))]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(category);
            return RedirectToAction("Index");
        }

    }
}
