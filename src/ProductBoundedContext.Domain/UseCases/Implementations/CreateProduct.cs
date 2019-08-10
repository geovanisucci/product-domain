using System;
using System.Threading.Tasks;
using ProductBoundedContext.Domain.EntityDomain;
using ProductBoundedContext.Domain.IRepositories;
using ProductBoundedContext.Domain.UseCases.Interfaces;

namespace ProductBoundedContext.Domain.UseCases.Implementations
{
    public class CreateProduct : ICreateProduct
    {
        private readonly IProductRepository _productRepository;

        public CreateProduct(IProductRepository productRepository) //Injetando a dependência de IProductRepository
        {
            _productRepository = productRepository;
        }
        public async Task<ResponseResult<ProductEntityDomain>> InvokeAsync(ProductEntityDomain productEntityDomain)
        {
            if (!productEntityDomain.Validate())
            {
                return ResponseResult<ProductEntityDomain>.Failed(400, "Existem campos inválidos", productEntityDomain.Notifications);
            }

            productEntityDomain.Id = Guid.NewGuid().ToString();
            productEntityDomain.Active = 1;
            productEntityDomain.CreatedAt = DateTime.Now;

            ProductEntityDomain resultData = await _productRepository.CreateProductAsync(productEntityDomain);

            return ResponseResult<ProductEntityDomain>.Succeeded(resultData, 201);
        }
    }
}