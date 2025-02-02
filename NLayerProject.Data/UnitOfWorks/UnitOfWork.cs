﻿using NLayerProject.Core.Repositories;
using NLayerProject.Core.UnitOfWorks;
using NLayerProject.Data.Repositories;
using System.Threading.Tasks;

namespace NLayerProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public ICategoryRepository categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public IProductRepository products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}