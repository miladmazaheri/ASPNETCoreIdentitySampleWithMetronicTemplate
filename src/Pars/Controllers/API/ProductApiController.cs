using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pars.Attributes;
using Pars.Services.Contracts;
using Pars.ViewModels.Products;

namespace Pars.Controllers.API
{
    [Route("api/Product/[action]")]
    [ApiController]
    [ApiKey]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductApiController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPut]
        public async Task InsertOrUpdateAsync([FromBody] ProductUpdateInput input)
        {
            await _productService.InsertOrUpdateAsync(input);
        }

        [HttpPut]
        public async Task BatchInsertOrUpdateAsync([FromBody] List<ProductUpdateInput> input)
        {
            await _productService.BatchInsertOrUpdateAsync(input);
        }

        [HttpPut]
        public async Task UpdateProductWarehousesAsync([FromBody] ProductWarehouseUpdateInput input)
        {
            await _productService.UpdateProductWarehousesAsync(input);
        }

        [HttpPut]
        public async Task BatchUpdateProductWarehousesAsync([FromBody] List<ProductWarehouseUpdateInput> input)
        {
            await _productService.BatchUpdateProductWarehousesAsync(input);
        }

        [HttpDelete]
        public async Task DeleteAsync([FromBody] string id)
        {
            await _productService.DeleteAsync(id);

        }

        [HttpDelete]
        public async Task BatchDeleteAsync([FromBody] List<string> ids)
        {
            await _productService.BatchDeleteAsync(ids);

        }
    }
}
