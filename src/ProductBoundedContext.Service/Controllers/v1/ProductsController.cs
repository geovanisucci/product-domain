using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductBoundedContext.Domain;
using ProductBoundedContext.Domain.EntityDomain;
using ProductBoundedContext.Domain.UseCases.Interfaces;
using ProductBoundedContext.Service.Controllers.v1.ValueObjects;

namespace ProductBoundedContext.Service.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")] //https://rrsantos.com.br/api/products/v1/<endpoint>
    public class ProductsController : ControllerBase
    {
        //Inserção, Criação, etc. -> HTTP POST 
        //Atualização --> HTTP PUT
        //Delete, exclusão --> HTTP DELETE
        //Seleção, retorno de dados, select, etc --> HTTP GET

       /// <summary>
       ///  Este enpoint cria um produto.
       /// </summary>
       /// <remarks>
       /// Exemplo de requisição:
       ///         POST /api/products/v1
       /// </remarks>
       /// <param name="createProductRequest"></param>
       /// <param name="createProduct"></param>
       /// <returns>Produto criado.</returns>
       /// <response code="201">Produto criado</response>
       /// <response code="400">Requisição precisa ser analisada</response>
       /// <response code="500">Requisição com erro interno</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseResult<ProductEntityDomain>), 201)] // Pode retornar 201 created
        [ProducesResponseType(typeof(ResponseResult<ProductEntityDomain>), 400)] // Pode retornar 400 Bad Request
        public async Task<IActionResult> Post([FromBody]CreateProductRequest createProductRequest, [FromServices]ICreateProduct createProduct)
        {
            try
            {
                var resultadoDomain = await createProduct.InvokeAsync(new ProductEntityDomain()
                {
                    Description = createProductRequest.Description,
                    BarCode = createProductRequest.BarCode,
                    UnitMeasurementId = createProductRequest.UnitMeasurementId
                });

                if(!resultadoDomain.Success)
                {
                    return BadRequest(resultadoDomain); //Retorna 400 BadRequest
                }

                return Created("Product", resultadoDomain); //Retorna 201 Sucesso criação.

            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex);
                return StatusCode(500); //retorna Internal Server Error.
            }
        }
        
    }
}