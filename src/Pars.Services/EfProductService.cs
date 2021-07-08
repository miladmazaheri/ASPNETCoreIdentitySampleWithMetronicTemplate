using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pars.DataLayer.Context;
using Pars.Entities;
using Pars.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Pars.ViewModels;
using Pars.ViewModels.Products;

namespace Pars.Services
{
    public class EfProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Product> _products;

        public EfProductService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _products = _uow.Set<Product>();
        }

       

        public async Task InsertOrUpdateAsync(ProductUpdateInput input)
        {
            var item = await _products.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (item == null)
            {
                item = new Product();
                MapToEntity(input, item);
                await _products.AddAsync(item);
            }
            else
            {
                MapToEntity(input, item);
                _products.Update(item);
            }
            await _uow.SaveChangesAsync();
        }

        public async Task BatchInsertOrUpdateAsync(List<ProductUpdateInput> inputs)
        {
            foreach (var input in inputs)
            {
                var item = await _products.FirstOrDefaultAsync(x => x.Id == input.Id);
                if (item == null)
                {
                    item = new Product();
                    MapToEntity(input, item);
                    await _products.AddAsync(item);
                }
                else
                {
                    MapToEntity(input, item);
                    _products.Update(item);
                }
            }
            await _uow.SaveChangesAsync();
        }

        public async Task UpdateProductWarehousesAsync(ProductWarehouseUpdateInput input)
        {
            var product = await _products.Include(x => x.ProductWarehouses).FirstOrDefaultAsync(x => x.Id == input.ProductId);
            foreach (var stock in input.WarehouseStocks)
            {
                var item = product.ProductWarehouses.FirstOrDefault(x => x.WarehouseId == stock.WarehouseId);
                if (item == null)
                {
                    product.ProductWarehouses.Add(new ProductWarehouse
                    {
                        ProductId = product.Id,
                        WarehouseId = stock.WarehouseId,
                        Count = stock.Count
                    });
                }
                else
                {
                    item.Count = stock.Count;
                }
            }

            _products.Update(product);
            await _uow.SaveChangesAsync();
        }

        public async Task BatchUpdateProductWarehousesAsync(List<ProductWarehouseUpdateInput> inputs)
        {
            foreach (var input in inputs)
            {
                var product = await _products.Include(x => x.ProductWarehouses).FirstOrDefaultAsync(x => x.Id == input.ProductId);
                foreach (var stock in input.WarehouseStocks)
                {
                    var item = product.ProductWarehouses.FirstOrDefault(x => x.WarehouseId == stock.WarehouseId);
                    if (item == null)
                    {
                        product.ProductWarehouses.Add(new ProductWarehouse
                        {
                            ProductId = product.Id,
                            WarehouseId = stock.WarehouseId,
                            Count = stock.Count
                        });
                    }
                    else
                    {
                        item.Count = stock.Count;
                    }
                }

                _products.Update(product);
            }
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            await _products.DeleteByKeyAsync(id);
        }

        public async Task BatchDeleteAsync(List<string> ids)
        {
            foreach (var id in ids)
            {
                await DeleteAsync(id);
            }
        }

        private void MapToEntity(ProductUpdateInput model, Product item)
        {

            item.Id = model.Id;
            item.BoxWeight = model.BoxWeight;
            item.BranchSize = model.BranchSize;
            item.CategoryId = model.CategoryId;
            item.Code = model.Code;
            item.Color = model.Color;
            item.CountInBox = model.CountInBox;
            item.Description = model.Description;
            item.InstallationMethod = model.InstallationMethod;
            item.Material = model.Material;
            item.Name = model.Name;
            item.Picture = model.Picture;
            item.Price = model.Price;
            item.Size = model.Size;
            item.Specification = model.Specification;
            item.Thickness = model.Thickness;
            item.Usage = model.Usage;

        }

        private void MapToModel(ProductViewModel model, Product item)
        {

            model.Id = item.Id;
            model.BoxWeight = item.BoxWeight;
            model.BranchSize = item.BranchSize;
            model.CategoryId = item.CategoryId;
            model.Code = item.Code;
            model.Color = item.Color;
            model.CountInBox = item.CountInBox;
            model.Description = item.Description;
            model.InstallationMethod = item.InstallationMethod;
            model.Material = item.Material;
            model.Name = item.Name;
            model.Picture = item.Picture;
            model.Price = item.Price;
            model.Size = item.Size;
            model.Specification = item.Specification;
            model.Thickness = item.Thickness;
            model.Usage = item.Usage;
            model.CategoryName = item.Category?.Name ?? string.Empty;
            model.Stock = item.ProductWarehouses?.Sum(x => x.Count) ?? 0;
        }

        public async Task<ProductViewModel> GetProductAsync(string id)
        {
            var item =await _products.Include(x => x.Category).Include(x => x.ProductWarehouses)
                .FirstAsync(x => x.Id == id);
            var res= new ProductViewModel();
            MapToModel(res,item);
            return res;
        }

        public async Task<PagedListViewModel<ProductListItemViewModel>> GetAllProductsAsync(SearchProductsViewModel model)
        {
            var skipRecords = model.PageNumber * model.MaxNumberOfRows;
            var query = _products.Include(x => x.ProductWarehouses).AsQueryable();
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                query = query.Where(x => x.Name.Contains(model.Name));
            }
            if (!string.IsNullOrWhiteSpace(model.CategoryId))
            {
                query = query.Where(x => x.CategoryId == model.CategoryId);
            }
            if (!string.IsNullOrWhiteSpace(model.Size))
            {
                query = query.Where(x => x.Size == model.Size);
            }
            query = query.OrderBy(x => x.Id);
            return new PagedListViewModel<ProductListItemViewModel>
            {
                Paging =
                {
                    TotalItems = await query.CountAsync(),
                    CurrentPage = model.PageNumber,
                    ItemsPerPage = model.MaxNumberOfRows,
                },
                Items = await query.Skip(skipRecords).Take(model.MaxNumberOfRows).Select(x => new ProductListItemViewModel
                {
                    Id = x.Id,
                    Size = x.Size,
                    Code = x.Code,
                    CountInBox = x.CountInBox,
                    Name = x.Name,
                    Price = x.Price,
                    Stock = x.ProductWarehouses.Sum(x => x.Count)
                }).ToListAsync(),
            };
        }
    }
}
