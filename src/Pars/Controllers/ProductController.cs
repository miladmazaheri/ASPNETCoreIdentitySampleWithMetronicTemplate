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
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class ProductController : ControllerBase
    {
        //[FromHeader] string ApiKey,
        [HttpPut]
        public async Task UpdateAsync([FromBody] ProductUpdateInput input)
        {

        }
    }
}
