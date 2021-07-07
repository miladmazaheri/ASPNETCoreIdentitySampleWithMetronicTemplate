using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pars.Entities.Identity;

namespace Pars.Services.Contracts.Identity
{
    public interface IApiKeyService
    {
        public Task<User> FindUserByApiKeyAsync(string apiKey);
    }
}
