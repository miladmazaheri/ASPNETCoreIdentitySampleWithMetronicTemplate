using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pars.Attributes;
using Pars.Services.Contracts;
using Pars.ViewModels.Products;
using Pars.ViewModels.Warehouses;

namespace Pars.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiKey]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpPut]
        public async Task InsertOrUpdateAsync([FromBody] WarehouseUpdateInput input)
        {
            await _warehouseService.InsertOrUpdateAsync(input);
        }

        [HttpPut]
        public async Task BatchInsertOrUpdateAsync([FromBody] List<WarehouseUpdateInput> input)
        {
            await _warehouseService.BatchInsertOrUpdateAsync(input);
        }

        [HttpPut]
        public async Task UpdateWarehouseProductsAsync([FromBody] WarehouseProductUpdateInput input)
        {
            await _warehouseService.UpdateWarehouseProductsAsync(input);
        }

        [HttpPut]
        public async Task BatchUpdateWarehouseProductsAsync([FromBody] List<WarehouseProductUpdateInput> input)
        {
            await _warehouseService.BatchUpdateWarehouseProductsAsync(input);
        }

        [HttpDelete]
        public async Task DeleteAsync([FromBody] string id)
        {
            await _warehouseService.DeleteAsync(id);
        }

        [HttpDelete]
        public async Task BatchDeleteAsync([FromBody] List<string> ids)
        {
            await _warehouseService.BatchDeleteAsync(ids);
        }
    }
}
