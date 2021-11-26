﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;
using NLayerProject.Web.Api_Services;
using NLayerProject.Web.DTOs;
using NLayerProject.Web.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper, CategoryApiService categoryApiService)

        {
            _categoryService = categoryService;
            _mapper = mapper;
            _categoryApiService = categoryApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            await _categoryApiService.AddAsync(categoryDTO);
            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Category>))]
        //update/5 --> Brings 5th number of id category then with post method which located below, is 
        //gonna take new categoryDto item, update it and return to the Index. 
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDTO>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDTO categoryDTO)
        {
           await _categoryApiService.Update(categoryDTO);

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
