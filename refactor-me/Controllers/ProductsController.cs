using System;
using System.Net;
using System.Web.Http;
using refactor_me.Models;
using refactor_me.ViewModel;
using System.Net.Http;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private readonly IProductsViewModel _productsService;

        public ProductsController()
        {
            _productsService = WebApiApplication.getIocContainer().Resolve<ProductsViewModel>();
        }

        [Route]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK,
            new {
                Items = _productsService.GetProducts()
            });
        }

        [Route]
        [HttpGet]
        public HttpResponseMessage SearchByName(string name)
        {
            return Request.CreateResponse(HttpStatusCode.OK,
            new
            {
                Items = _productsService.GetProducts(name)
            });
        }

        [Route("{id}")]
        [HttpGet]
        public Product GetProduct(Guid id)
        {
            var product = _productsService.GetProduct(id);

            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return product;
            }
        }

        [Route]
        [HttpPost]
        public void Create(Product product)
        {
            _productsService.AddProduct(product);
        }

        [Route("{id}")]
        [HttpPut]
        public void Update(Guid id, Product product)
        {
            _productsService.UpdateProduct(id, product);
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            _productsService.DeleteProduct(id);
        }

        [Route("{productId}/options")]
        [HttpGet]
        public HttpResponseMessage GetOptions(Guid productId)
        {
            return Request.CreateResponse(HttpStatusCode.OK,
            new
            {
                Items = _productsService.GetProductOptions(productId)
            });
        }

        [Route("{productId}/options/{id}")]
        [HttpGet]
        public ProductOption GetOption(Guid productId, Guid id)
        {
            var productOption = _productsService.getProductOption(productId, id);

            if (productOption == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return productOption;
            }
        }

        [Route("{productId}/options")]
        [HttpPost]
        public void CreateOption(Guid productId, ProductOption option)
        {
            _productsService.AddOption(productId, option);
        }

        [Route("{productId}/options/{id}")]
        [HttpPut]
        public void UpdateOption(Guid productId, Guid id, ProductOption option)
        {
            _productsService.UpdateOption(id, productId, option);
        }

        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public void DeleteOption(Guid id)
        {
            _productsService.DeleteOption(id);
        }
    }
}
