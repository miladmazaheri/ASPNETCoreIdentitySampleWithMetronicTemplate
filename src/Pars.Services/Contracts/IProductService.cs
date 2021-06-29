using System.Collections.Generic;
using Pars.Entities;

namespace Pars.Services.Contracts
{
    public interface IProductService
    {
        void AddNewProduct(Product product);
        IList<Product> GetAllProducts();
    }
}