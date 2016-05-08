using System;
using refactor_me.Models;
using System.Collections.Generic;

namespace refactor_me.DataModel
{
    public interface IProductOptionRepository
    {
        IList<ProductOption> GetProductOptions(Guid productId);
        ProductOption getProductOption(Guid productId, Guid id);
        void AddOption(ProductOption option);
        void UpdateOption(ProductOption option);
        void DeleteOption(Guid id);
    }
}