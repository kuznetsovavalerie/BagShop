using BagShop.App_Code;
using BagShop.Common.Interfaces;
using BagShop.DAL;
using BagShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BagShop.Controllers
{
    public class HomeController : Controller
    {
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
    }
}