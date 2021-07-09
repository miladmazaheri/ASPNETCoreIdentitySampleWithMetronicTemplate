using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pars.Attributes;
using Pars.Services.Contracts;
using Pars.ViewModels.Warehouses;

namespace Pars.Controllers.API
{
    [Route("api/Warehouse/[action]")]
    [ApiController]
    [ApiKey]
    public class WarehouseApiController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseApiController(IWarehouseService warehouseService)
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
