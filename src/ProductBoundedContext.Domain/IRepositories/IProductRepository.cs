using System.Collections.Generic;
using System.Threading.Tasks;
using ProductBoundedContext.Domain.EntityDomain;

namespace ProductBoundedContext.Domain.IRepositories
{
    public interface IProductRepository
    {
         Task<ProductEntityDomain> CreateProductAsync(ProductEntityDomain product);
         Task<bool> UpdateProductAsync(ProductEntityDomain product);
         Task<bool> RemoveProductAsync(string id);
         Task<List<ProductEntityDomain>> GetAllProductsAsync();
         Task<ProductEntityDomain> GetProductAsync(string id);
    }
}