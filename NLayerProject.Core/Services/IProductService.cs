using NLayerProject.Core.Models;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
   public interface IProductService : IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId); // Instead of using the database, we will create our methods if necessery in here 
    }
}
