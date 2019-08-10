using System.Collections.Generic;
using System.Threading.Tasks;
using ProductBoundedContext.Data.Context;
using ProductBoundedContext.Domain.EntityDomain;
using ProductBoundedContext.Domain.IRepositories;
using Dapper;
using Dapper.Contrib.Extensions;
using ProductBoundedContext.Data.EntityData;
using System.Linq;

namespace ProductBoundedContext.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductSqlDataContext _productSqlDataContext;

        public ProductRepository(ProductSqlDataContext productSqlDataContext)
        {
            _productSqlDataContext = productSqlDataContext;
        }


        public async Task<ProductEntityDomain> CreateProductAsync(ProductEntityDomain product)
        {
            await _productSqlDataContext.Connection.OpenAsync();
            using (var trans = _productSqlDataContext.Connection.BeginTransaction())
            {
                try
                {
                    await _productSqlDataContext.Connection.InsertAsync(ProductEntityData.ToEntityData(product), trans);

                    trans.Commit();
                    _productSqlDataContext.Connection.Close();
                }
                catch (System.Exception)
                {
                    trans.Rollback();
                    _productSqlDataContext.Connection.Close();
                }

            }

            return product;

        }
        public async Task<List<ProductEntityDomain>> GetAllProductsAsync()
        {
            var resultData = await _productSqlDataContext.Connection.GetAllAsync<ProductEntityData>();

            return resultData.Select(r => ProductEntityData.ToEntityDomain(r)).ToList();

        }
        public async Task<ProductEntityDomain> GetProductAsync(string id)
        {
            var resultData = await _productSqlDataContext.Connection.GetAsync<ProductEntityData>(id);

            return ProductEntityData.ToEntityDomain(resultData);
        }

        public async Task<bool> RemoveProductAsync(string id)
        {
            var resultRemove = await _productSqlDataContext.Connection.ExecuteAsync("Delete From Product Where Id = @Id", new { Id = id });

            return resultRemove == 1;

        }

        public async Task<bool> UpdateProductAsync(ProductEntityDomain product)
        {
            var resultUpdate = await _productSqlDataContext.Connection.UpdateAsync<ProductEntityData>(ProductEntityData.ToEntityData(product));

            return resultUpdate;
        }
    }
}