using AutoMapper;
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
    public class ProductsController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly IMapper _mapper;
        public ProductsController(ProductApiService productApiService, IMapper mapper)
        {
            _productApiService = productApiService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productApiService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<ProductDTO>>(products));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            await _productApiService.AddAsync(productDTO);
            

            return RedirectToAction("Index");
        }
        [ServiceFilter(typeof(GenericNotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);
            return View(_mapper.Map<ProductDTO>(product));
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDTO productDTO)
        {
            await _productApiService.Update(productDTO);
            return RedirectToAction("Index");
        }
        [ServiceFilter(typeof(GenericNotFoundFilter<Product>))]
        public async Task<IActionResult> Delete(int id)
        {
           // var product = await _productApiService.GetByIdAsync(id);
          await _productApiService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
