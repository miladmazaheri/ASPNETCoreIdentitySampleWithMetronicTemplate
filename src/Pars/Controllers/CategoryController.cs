using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pars.Attributes;
using Pars.Services.Contracts;
using Pars.ViewModels.Categories;

namespace Pars.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiKey]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
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
