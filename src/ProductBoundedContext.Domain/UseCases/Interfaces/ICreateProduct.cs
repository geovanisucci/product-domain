using System.Threading.Tasks;
using ProductBoundedContext.Domain.EntityDomain;

namespace ProductBoundedContext.Domain.UseCases.Interfaces
{
    public interface ICreateProduct
    {
         Task<ResponseResult<ProductEntityDomain>> InvokeAsync(ProductEntityDomain productEntityDomain);
    }
}