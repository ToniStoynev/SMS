namespace SMS.App.Controllers
{
    using System;
    using System.Linq;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Result;
    using SMS.App.ViewModels.HomeModels;
    using SMS.Services;

    public class HomeController : BaseController
    {
        private readonly ICartService cartService;

        public HomeController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet(Url = "/")]
        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                var model = this.cartService.GetAllProducts()
                .Select(x => new ProductsViewAllModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                }).ToList();
                return this.View(model, "IndexLoggedIn");
            }
            else
            {
                return this.View();
            }
        }
    }
}