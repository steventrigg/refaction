using System;
using System.Collections.Generic;
using refactor_me.Models;
using refactor_me.DataModel;

namespace refactor_me.ViewModel
{
    public class ProductsViewModel : IProductsViewModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductOptionRepository _productOptionRepository;

        public ProductsViewModel(ProductRepository productRepository, ProductOptionRepository productOptionRepository)
        {
            _productRepository = productRepository;
            _productOptionRepository = productOptionRepository;
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Product GetProduct(Guid id)
        {
            return _productRepository.GetProduct(id);
        }
        
        public List<Product> GetProducts(string name)
        {
            return _productRepository.GetProducts(name);
        }

        public void AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            _productRepository.AddProduct(product);
        }

        public void UpdateProduct(Guid id, Product product)
        {
            product.Id = id;
            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(Guid id)
        {
            _productRepository.DeleteProduct(id);
        }

        public IList<ProductOption> GetProductOptions(Guid productId)
        {
            return _productOptionRepository.GetProductOptions(productId);
        }

        public ProductOption getProductOption(Guid productId, Guid id)
        {
            return _productOptionRepository.getProductOption(productId, id);
        }

        public void AddOption(Guid productId, ProductOption option)
        {
            option.Id = Guid.NewGuid();
            option.ProductId = productId;
            _productOptionRepository.AddOption(option);
        }

        public void UpdateOption(Guid id, Guid productId, ProductOption option)
        {
            option.Id = id;
            option.ProductId = productId;
            _productOptionRepository.UpdateOption(option);
        }

        public void DeleteOption(Guid id)
        {
            _productOptionRepository.DeleteOption(id);
        }
    }
}