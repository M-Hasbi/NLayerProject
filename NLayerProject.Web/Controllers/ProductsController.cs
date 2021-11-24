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
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<ProductDTO>>(products));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            await _productService.AddAsync(_mapper.Map<Product>(productDTO));
            

            return RedirectToAction("Index");
        }
        [ServiceFilter(typeof(GenericNotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return View(_mapper.Map<ProductDTO>(product));
        }
        [HttpPost]
        public IActionResult Update(ProductDTO productDTO)
        {
            _productService.Update(_mapper.Map<Product>(productDTO));
            return RedirectToAction("Index");
        }
        [ServiceFilter(typeof(GenericNotFoundFilter<Product>))]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            _productService.Remove(product);
            return RedirectToAction("Index");
        }
    }
}
