using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pars.DataLayer.Context;
using Pars.Entities;
using Pars.Services.Contracts;
using Pars.ViewModels;
using Pars.ViewModels.Warehouses;
using Pars.ViewModels.Warehouses;

namespace Pars.Services.Identity
{
    public class EfWarehouseService : IWarehouseService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Warehouse> _warehouses;

        public EfWarehouseService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _warehouses = _uow.Set<Warehouse>();
        }



        public async Task InsertOrUpdateAsync(WarehouseUpdateInput input)
        {
            var item = await _warehouses.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (item == null)
            {
                item = new Warehouse();
                MapToEntity(input, item);
                await _warehouses.AddAsync(item);
            }
            else
            {
                MapToEntity(input, item);
                _warehouses.Update(item);
            }
            await _uow.SaveChangesAsync();
        }

        public async Task BatchInsertOrUpdateAsync(List<WarehouseUpdateInput> inputs)
        {
            foreach (var input in inputs)
            {
                var item = await _warehouses.FirstOrDefaultAsync(x => x.Id == input.Id);
                if (item == null)
                {
                    item = new Warehouse();
                    MapToEntity(input, item);
                    await _warehouses.AddAsync(item);
                }
                else
                {
                    MapToEntity(input, item);
                    _warehouses.Update(item);
                }
            }
            await _uow.SaveChangesAsync();
        }

        public async Task UpdateWarehouseProductsAsync(WarehouseProductUpdateInput input)
        {
            var warehouse = await _warehouses.Include(x => x.ProductWarehouses).FirstOrDefaultAsync(x => x.Id == input.WarehouseId);
            foreach (var stock in input.ProductStocks)
            {
                var item = warehouse.ProductWarehouses.FirstOrDefault(x => x.ProductId == stock.ProductId);
                if (item == null)
                {
                    warehouse.ProductWarehouses.Add(new ProductWarehouse()
                    {
                        WarehouseId = warehouse.Id,
                        ProductId = stock.ProductId,
                        Count = stock.Count
                    });
                }
                else
                {
                    item.Count = stock.Count;
                }
            }

            _warehouses.Update(warehouse);
            await _uow.SaveChangesAsync();
        }

        public async Task BatchUpdateWarehouseProductsAsync(List<WarehouseProductUpdateInput> inputs)
        {
            foreach (var input in inputs)
            {
                var warehouse = await _warehouses.Include(x => x.ProductWarehouses).FirstOrDefaultAsync(x => x.Id == input.WarehouseId);
                foreach (var stock in input.ProductStocks)
                {
                    var item = warehouse.ProductWarehouses.FirstOrDefault(x => x.ProductId == stock.ProductId);
                    if (item == null)
                    {
                        warehouse.ProductWarehouses.Add(new ProductWarehouse()
                        {
                            WarehouseId = warehouse.Id,
                            ProductId = stock.ProductId,
                            Count = stock.Count
                        });
                    }
                    else
                    {
                        item.Count = stock.Count;
                    }
                }

                _warehouses.Update(warehouse);
            }
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            await _warehouses.DeleteByKeyAsync(id);
        }

        public async Task BatchDeleteAsync(List<string> ids)
        {
            foreach (var id in ids)
            {
                await DeleteAsync(id);
            }
        }

        private void MapToEntity(WarehouseUpdateInput model, Warehouse item)
        {

            item.Id = model.Id;
            item.Name = model.Name;
            item.UserId = model.UserId;

        }

        private void MapToModel(WarehouseViewModel model, Warehouse item)
        {

            model.Id = item.Id;
            model.Name = item.Name;
            model.UserId = item.UserId;
            model.UserName = item.User?.DisplayName ?? string.Empty;
        }

        public async Task<WarehouseViewModel> GetAsync(string id)
        {
            var item = await _warehouses.Include(x => x.User)
                .FirstAsync(x => x.Id == id);
            var res = new WarehouseViewModel();
            MapToModel(res, item);
            return res;
        }

        public async Task<PagedListViewModel<WarehouseViewModel>> GetAllAsync(SearchWarehousesViewModel model)
        {
            var skipRecords = model.PageNumber * model.MaxNumberOfRows;
            var query = _warehouses.Include(x => x.User).AsQueryable();
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                query = query.Where(x => x.Name.Contains(model.Name));
            }
            if (model.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == model.UserId.Value);
            }
            query = query.OrderBy(x => x.Id);
            return new PagedListViewModel<WarehouseViewModel>
            {
                Paging =
                {
                    TotalItems = await query.CountAsync(),
                    CurrentPage = model.PageNumber,
                    ItemsPerPage = model.MaxNumberOfRows,
                },
                Items = await query.Skip(skipRecords).Take(model.MaxNumberOfRows).Select(x => new WarehouseViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    UserId = x.UserId,
                    UserName = x.User != null ? x.User.DisplayName : string.Empty
                }).ToListAsync(),
            };
        }
    }
}
