using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pars.Attributes;
using Pars.Services.Contracts;
using Pars.ViewModels.Categories;

namespace Pars.Controllers.API
{
    [Route("api/Category/[action]")]
    [ApiController]
    [ApiKey]
    public class CategoryApiController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryApiController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPut]
        public async Task InsertOrUpdateAsync([FromBody] CategoryUpdateInput input)
        {
            await _categoryService.InsertOrUpdateAsync(input);
        }

        [HttpPut]
        public async Task BatchInsertOrUpdateAsync([FromBody] List<CategoryUpdateInput> input)
        {
            await _categoryService.BatchInsertOrUpdateAsync(input);
        }

        [HttpDelete]
        public async Task DeleteAsync([FromBody] string id)
        {
            await _categoryService.DeleteAsync(id);
        }

        [HttpDelete]
        public async Task BatchDeleteAsync([FromBody] List<string> ids)
        {
            await _categoryService.BatchDeleteAsync(ids);
        }
    }
}
