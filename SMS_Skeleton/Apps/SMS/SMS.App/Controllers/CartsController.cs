using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SMS.App.ViewModels.HomeModels;
using SMS.Services;
using System.Linq;

namespace SMS.App.Controllers
{
    public class CartsController : BaseController
    {
        private readonly IProductService productService;
        private readonly ICartService cartService;

        public CartsController(IProductService productService, ICartService cartService)
        {
            this.productService = productService;
            this.cartService = cartService;
        }

        [Authorize]
        public IActionResult Details()
        {
            var product = this.productService.GetlAllProducts().ToList();
            var model = new HomeViewModel
            {
                ProductListingModel = product.Select(x => new ProductsViewAllModel
                {
                    Name = x.Name,
                    Price = x.Price
                }).ToList()

            };

            return this.View(model);
        }

        [Authorize]
        public IActionResult AddProduct(string productId)
        {
            var product = this.productService.GetProductById(productId);

            this.cartService.AddProduct(product);

            return this.Redirect("/Carts/Details");
        }

        [Authorize]
        public IActionResult Buy()
        {
            this.cartService.Buy();

            return this.Redirect("/");
        }
    }
}