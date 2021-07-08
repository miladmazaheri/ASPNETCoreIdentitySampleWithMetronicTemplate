using System.Collections.Generic;
using System.Threading.Tasks;
using Pars.Entities;
using Pars.ViewModels;
using Pars.ViewModels.Products;

namespace Pars.Services.Contracts
{
    public interface IProductService
    {
        Task InsertOrUpdateAsync(ProductUpdateInput input);
        Task BatchInsertOrUpdateAsync(List<ProductUpdateInput> inputs);
        Task UpdateProductWarehousesAsync(ProductWarehouseUpdateInput input);
        Task BatchUpdateProductWarehousesAsync(List<ProductWarehouseUpdateInput> input);
        Task DeleteAsync(string id);
        Task BatchDeleteAsync(List<string> ids);
        Task<ProductViewModel> GetProductAsync(string id);
        Task<PagedListViewModel<ProductListItemViewModel>> GetAllProductsAsync(SearchProductsViewModel model);
    }
}