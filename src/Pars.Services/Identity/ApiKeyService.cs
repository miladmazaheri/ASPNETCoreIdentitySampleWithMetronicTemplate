using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pars.DataLayer.Context;
using Pars.Entities.Identity;
using Pars.Services.Contracts.Identity;

namespace Pars.Services.Identity
{
    public class ApiKeyService : IApiKeyService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<User> _users;

        public ApiKeyService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _users = _uow.Set<User>();
        }

        public async Task<User> FindUserByApiKeyAsync(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey)) return null;
            return await _users.FirstOrDefaultAsync(x => x.ApiKey == apiKey);
        }
    }
}
