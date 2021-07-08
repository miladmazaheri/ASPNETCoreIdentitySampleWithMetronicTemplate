using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pars.Attributes;
using Pars.Services.Contracts;
using Pars.ViewModels.Products;

namespace Pars.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiKey]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
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
