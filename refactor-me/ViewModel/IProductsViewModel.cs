using System;
using System.Collections.Generic;
using refactor_me.Models;

namespace refactor_me.ViewModel
{
    public interface IProductsViewModel
    {
        void AddProduct(Product product);
        void DeleteProduct(Guid id);
        Product GetProduct(Guid id);
        List<Product> GetProducts(string name);
        List<Product> GetProducts();
        void UpdateProduct(Guid id, Product product);
        IList<ProductOption> GetProductOptions(Guid productId);
        ProductOption getProductOption(Guid productId, Guid id);
        void AddOption(Guid productId, ProductOption option);
        void UpdateOption(Guid id, Guid productId, ProductOption option);
        void DeleteOption(Guid id);
    }
}