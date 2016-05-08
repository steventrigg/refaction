using refactor_me.Models;

namespace refactor_me.DataModel
{
    internal static class ProductMapper
    {
        public static ProductEntity MapProductToEntity(Product model)
        {
            return new ProductEntity()
            {
                id = model.Id.Value,
                name = model.Name,
                description = model.Description,
                price = model.Price,
                deliveryprice = model.DeliveryPrice
            };
        }

        public static ProductOptionEntity MapProductOptionToEntity(ProductOption model)
        {
            return new ProductOptionEntity()
            {
                id = model.Id.Value,
                name = model.Name,
                description = model.Description,
                productid = model.ProductId
            };
        }

        public static Product MapProductToModel(ProductEntity entity)
        {
            return new Product()
            {
                Id = entity.id,
                Name = entity.name,
                Description = entity.description,
                Price = entity.price.HasValue ? entity.price.Value : 0,
                DeliveryPrice = entity.deliveryprice.HasValue ? entity.deliveryprice.Value : 0
            };
        }

        public static ProductOption MapProductOptionToModel(ProductOptionEntity entity)
        {
            return new ProductOption()
            {
                Id = entity.id,
                Name = entity.name,
                Description = entity.description,
                ProductId = entity.productid
            };
        }
    }
}