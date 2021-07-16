using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pars.ViewModels;
using Pars.ViewModels.Orders;

namespace Pars.Services.Contracts
{
    public interface IOrderService
    {
        Task<OrderDto> GetAsync(long orderId);
        Task<List<OrderDto>> GetAllAsync(SearchOrderViewModel input);
        Task<PagedListViewModel<OrderListItemViewModel>> GetAllForListAsync(SearchOrderViewModel input);
    }
}
