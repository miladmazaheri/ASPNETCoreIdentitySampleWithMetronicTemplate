using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pars.ViewModels;
using Pars.ViewModels.Warehouses;

namespace Pars.Services.Contracts
{
    public interface IWarehouseService
    {
        Task InsertOrUpdateAsync(WarehouseUpdateInput input);
        Task BatchInsertOrUpdateAsync(List<WarehouseUpdateInput> inputs);
        Task UpdateWarehouseProductsAsync(WarehouseProductUpdateInput input);
        Task BatchUpdateWarehouseProductsAsync(List<WarehouseProductUpdateInput> input);
        Task DeleteAsync(string id);
        Task BatchDeleteAsync(List<string> ids);
        Task<WarehouseViewModel> GetAsync(string id);
        Task<PagedListViewModel<WarehouseViewModel>> GetAllAsync(SearchWarehousesViewModel model);
    }
}
