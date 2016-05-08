using refactor_me.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace refactor_me.DataModel
{
    public class ProductRepository : IProductRepository
    {
        private readonly RefactorMeContext _dbContext;

        public ProductRepository(RefactorMeContext refactorMeContext)
        {
            _dbContext = refactorMeContext;
        }

        public List<Product> GetProducts()
        {
            List<ProductEntity> result = _dbContext.Products.ToList();
            return result.Select(x => ProductMapper.MapProductToModel(x)).ToList();
        }

        public Product GetProduct(Guid id)
        {
            List<ProductEntity> result = _dbContext.Products.Where(x => x.id == id).ToList();
            return result.Select(x => ProductMapper.MapProductToModel(x)).FirstOrDefault();
        }

        public List<Product> GetProducts(string name)
        {
            List<ProductEntity> result = _dbContext.Products.Where(x => x.name.ToLower().Contains(name.ToLower())).ToList();
            return result.Select(x => ProductMapper.MapProductToModel(x)).ToList();
        }

        public void AddProduct(Product product)
        {
            _dbContext.Entry(ProductMapper.MapProductToEntity(product)).State = EntityState.Added;
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            ProductEntity entity = _dbContext.Products.Where(c => c.id == product.Id).AsQueryable().FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Entry(entity).CurrentValues.SetValues(ProductMapper.MapProductToEntity(product));
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }

        public void DeleteProduct(Guid id)
        {
            ProductEntity entity = _dbContext.Products.Where(x => x.id == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
        }
    }
}