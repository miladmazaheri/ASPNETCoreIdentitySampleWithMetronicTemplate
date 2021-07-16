using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pars.Entities;
using Pars.ViewModels.Orders;

namespace Pars.Services.Contracts
{
    public interface IOrderBasketService
    {
        Task AddAsync(int userId, string productId, int count = 1);
        Task SubtractAsync(int userId, string productId, int count = 1);
        Task RemoveAsync(int userId, Guid id);
        Task ClearAsync(int userId);
        Task<List<OrderBasket>> GetAllAsync(int userId);
        Task<List<SubmitOrderItemDto>> GetAllForSubmitAsync(int userId);
        Task SubmitAsync(int userId);
    }
}
