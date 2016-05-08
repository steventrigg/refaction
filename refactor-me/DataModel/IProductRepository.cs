using System;
using System.Collections.Generic;
using refactor_me.Models;

namespace refactor_me.DataModel
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Guid id);
        Product GetProduct(Guid id);
        List<Product> GetProducts();
        List<Product> GetProducts(string name);
        void UpdateProduct(Product product);
    }
}