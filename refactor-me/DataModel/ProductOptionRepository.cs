using refactor_me.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace refactor_me.DataModel
{
    public class ProductOptionRepository : IProductOptionRepository
    {
        private readonly RefactorMeContext _dbContext;

        public ProductOptionRepository(RefactorMeContext refactorMeContext)
        {
            _dbContext = refactorMeContext;
        }

        public void AddOption(ProductOption option)
        {
            _dbContext.Entry(ProductMapper.MapProductOptionToEntity(option)).State = EntityState.Added;
            _dbContext.SaveChanges();
        }

        public void DeleteOption(Guid id)
        {
            ProductOptionEntity entity = _dbContext.ProductOptions.Where(x => x.id == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
        }

        public ProductOption getProductOption(Guid productId, Guid id)
        {
            List<ProductOptionEntity> result = _dbContext.ProductOptions
                .Where(x => x.productid == productId && x.id == id).ToList();
            return result.Select(x => ProductMapper.MapProductOptionToModel(x)).FirstOrDefault();
        }

        public IList<ProductOption> GetProductOptions(Guid productId)
        {
            List<ProductOptionEntity> result = _dbContext.ProductOptions.Where(x => x.productid == productId).ToList();
            return result.Select(x => ProductMapper.MapProductOptionToModel(x)).ToList();
        }

        public void UpdateOption(ProductOption option)
        {
            ProductOptionEntity entity = _dbContext.ProductOptions
                .Where(x => x.productid == option.ProductId && x.id == option.Id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Entry(entity).CurrentValues.SetValues(ProductMapper.MapProductOptionToEntity(option));
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }
    }
}