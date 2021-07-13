﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pars.DataLayer.Context;
using Pars.Entities;
using Pars.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Pars.ViewModels;
using Pars.ViewModels.Categories;
using Pars.ViewModels.Public;

namespace Pars.Services
{
    public class EfCategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Category> _categories;

        public EfCategoryService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));

            _categories = _uow.Set<Category>();
        }


        public async Task InsertOrUpdateAsync(CategoryUpdateInput input)
        {
            var item = await _categories.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (item == null)
            {
                item = new Category();
                MapToEntity(input, item);
                await _categories.AddAsync(item);
            }
            else
            {
                MapToEntity(input, item);
                _categories.Update(item);
            }
            await _uow.SaveChangesAsync();
        }

        public async Task BatchInsertOrUpdateAsync(List<CategoryUpdateInput> inputs)
        {
            foreach (var input in inputs)
            {
                var item = await _categories.FirstOrDefaultAsync(x => x.Id == input.Id);
                if (item == null)
                {
                    item = new Category();
                    MapToEntity(input, item);
                    await _categories.AddAsync(item);
                }
                else
                {
                    MapToEntity(input, item);
                    _categories.Update(item);
                }
            }
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            await _categories.DeleteByKeyAsync(id);
        }

        public async Task BatchDeleteAsync(List<string> ids)
        {
            foreach (var id in ids)
            {
                await DeleteAsync(id);
            }
        }

        private void MapToEntity(CategoryUpdateInput model, Category item)
        {
            item.Id = model.Id;
            item.Name = model.Name;
            item.Picture = model.Picture;
            item.Title = model.Title;
        }

        private void MapToModel(CategoryViewModel model, Category item)
        {
            model.Id = item.Id;
            model.Name = item.Name;
            model.Picture = item.Picture;
            model.Title = item.Title;
        }

        public async Task<CategoryViewModel> GetAsync(string id)
        {
            var item = await _categories.FirstAsync(x => x.Id == id);
            var res = new CategoryViewModel();
            MapToModel(res, item);
            return res;
        }

        public async Task<PagedListViewModel<CategoryViewModel>> GetAllAsync(SearchCategoriesViewModel model)
        {
            var skipRecords = model.PageNumber * model.MaxNumberOfRows;
            var query = _categories.AsQueryable();
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                query = query.Where(x => x.Name.Contains(model.Name));
            }

            query = query.OrderBy(x => x.Id);
            return new PagedListViewModel<CategoryViewModel>
            {
                Paging =
                {
                    TotalItems = await query.CountAsync(),
                    CurrentPage = model.PageNumber,
                    ItemsPerPage = model.MaxNumberOfRows,
                },
                Items = await query.Skip(skipRecords).Take(model.MaxNumberOfRows).Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Title = x.Title,
                    Picture = x.Picture,
                }).ToListAsync(),
            };
        }

        public Task<List<NameIdViewModel<string>>> GetAllForDropDownAsync()
        {
            return _categories.OrderBy(x => x.Name).Select(x =>
                new NameIdViewModel<string>(x.Id, x.Name)).ToListAsync();
        }

        public Task<List<CategoryViewModel>> GetAllAsync()
        {
            return _categories.OrderBy(x => x.Name).Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Title = x.Title,
                Picture = x.Picture,
            }).ToListAsync();
        }
    }
}