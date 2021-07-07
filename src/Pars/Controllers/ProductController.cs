using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pars.Attributes;
using Pars.ViewModels.Products;

namespace Pars.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiKey]
    public class ProductController : ControllerBase
    {
        [HttpPut]
        public async Task InsertOrUpdateAsync([FromBody] ProductUpdateInput input)
        {
            //TODO
        }

        [HttpPut]
        public async Task BatchInsertOrUpdateAsync([FromBody] List<ProductUpdateInput> input)
        {
            //TODO
        }

        [HttpPut]
        public async Task UpdateProductWarehousesAsync([FromBody] ProductWarehouseUpdateInput input)
        {
            //TODO
        }

        [HttpPut]
        public async Task BatchUpdateProductWarehousesAsync([FromBody] List<ProductWarehouseUpdateInput> input)
        {
            //TODO
        }
    }
}
