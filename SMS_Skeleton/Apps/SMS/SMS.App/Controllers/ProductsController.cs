using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SMS.App.ViewModels.ProductsModels;
using SMS.Services;

namespace SMS.App.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }


        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateProductBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Products/Create");
            }

            this.productService.CreateProduct(model.Name, model.Price);

            return this.Redirect("/");
        }
    }
}