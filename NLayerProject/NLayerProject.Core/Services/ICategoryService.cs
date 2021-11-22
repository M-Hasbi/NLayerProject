using NLayerProject.Core.Models;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
   public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);  //this interface contains methods (if necessary) for category class
    }
}
