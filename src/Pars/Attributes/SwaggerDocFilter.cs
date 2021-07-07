using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Pars.Attributes
{
    public class SwaggerDocFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var unwanteds = swaggerDoc.Paths.Where(x => x.Key.Contains("CspReport") || x.Key.Contains("DNTCaptchaImage")).ToList();

            unwanteds.ForEach(x => { swaggerDoc.Paths.Remove(x.Key); });
        }
    }
}
