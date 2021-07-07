using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pars.Attributes;
using Pars.ViewModels.Products;
using Pars.ViewModels.Warehouses;

namespace Pars.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiKey]
    public class WarehouseController : ControllerBase
    {
        [HttpPut]
        public async Task InsertOrUpdateAsync([FromBody] WarehouseUpdateInput input)
        {
            //TODO
        }

        [HttpPut]
        public async Task BatchInsertOrUpdateAsync([FromBody] List<WarehouseUpdateInput> input)
        {
            //TODO
        }

        [HttpPut]
        public async Task UpdateWarehouseProductsAsync([FromBody] WarehouseProductUpdateInput input)
        {
            //TODO
        }

        [HttpPut]
        public async Task BatchUpdateWarehouseProductsAsync([FromBody] List<WarehouseProductUpdateInput> input)
        {
            //TODO
        }

        [HttpDelete]
        public async Task DeleteAsync([FromBody] string id)
        {
            //TODO
        }

        [HttpDelete]
        public async Task BatchDeleteAsync([FromBody] List<string> ids)
        {
            //TODO
        }
    }
}
