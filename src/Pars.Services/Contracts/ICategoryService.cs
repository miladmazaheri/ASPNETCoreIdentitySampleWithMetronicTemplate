using System.Collections.Generic;
using System.Threading.Tasks;
using Pars.Entities;
using Pars.ViewModels;
using Pars.ViewModels.Categories;

namespace Pars.Services.Contracts
{
    public interface ICategoryService
    {
        Task InsertOrUpdateAsync(CategoryUpdateInput input);
        Task BatchInsertOrUpdateAsync(List<CategoryUpdateInput> inputs);
        Task DeleteAsync(string id);
        Task BatchDeleteAsync(List<string> ids);
        Task<CategoryViewModel> GetAsync(string id);
        Task<PagedListViewModel<CategoryViewModel>> GetAllAsync(SearchCategoriesViewModel model);
        Task<List<CategoryViewModel>> GetAllAsync();
    }
}