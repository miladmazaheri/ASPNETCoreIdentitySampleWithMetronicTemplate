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
        [HttpPut]
        public async Task UpdateAsync([FromHeader]string ApiKey,[FromBody] ProductUpdateInput input)
        {

        }
    }
}
