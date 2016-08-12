using BagShop.App_Code;
using BagShop.Common.Interfaces;
using BagShop.DAL;
using BagShop.Identity;
using BagShop.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BagShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser, Guid> _userManager;
        private IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public ActionResult Index()
        {
            var products = productService.GetAllItems()
                .Select(p => AutoMapperConfiguration.Mapper.Map<ProductPreviewModel>(p));

            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult View(int productId)
        {
            var model = AutoMapperConfiguration.Mapper.Map<ProductPreviewModel>(productService.GetItem(productId));

            return View(model);
        }

        public ActionResult Buy(int productId)
        {
            var model = new OrderViewModel() {
                Product = AutoMapperConfiguration.Mapper.Map<ProductPreviewModel>(productService.GetItem(productId))
            };

            return View(model);
        }

        public ActionResult Confirm(OrderViewModel model)
        {
            if (ModelState.IsValid) {
                //var model = AutoMapperConfiguration.Mapper.Map<ProductPreviewModel>(productService.GetItem(productId));
                var user = new IdentityUser() { UserName = model.PhoneNumber };
            }

            return View(model);
        }
    }
}