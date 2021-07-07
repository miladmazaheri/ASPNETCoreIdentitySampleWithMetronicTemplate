using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pars.Attributes;
using Pars.ViewModels.Categories;

namespace Pars.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiKey]
    public class CategoryController : ControllerBase
    {

        [HttpPut]
        public async Task InsertOrUpdateAsync([FromBody] CategoryUpdateInput input)
        {
            //TODO
        }

        [HttpPut]
        public async Task BatchInsertOrUpdateAsync([FromBody] List<CategoryUpdateInput> input)
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
