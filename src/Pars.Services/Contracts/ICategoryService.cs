using System.Collections.Generic;
using Pars.Entities;

namespace Pars.Services.Contracts
{
    public interface ICategoryService
    {
        void AddNewCategory(Category category);
        IList<Category> GetAllCategories();
    }
}