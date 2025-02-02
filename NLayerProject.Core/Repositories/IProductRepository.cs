﻿using NLayerProject.Core.Models;
using System.Threading.Tasks;

namespace NLayerProject.Core.Repositories
{
  public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
