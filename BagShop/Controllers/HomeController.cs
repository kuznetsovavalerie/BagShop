using BagShop.App_Code;
using BagShop.Common.Entities;
using BagShop.Common.Interfaces;
using BagShop.Common.Interfaces.Services;
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
        private IProductService _productService;
        private IOrderService _orderService;

        public HomeController(IProductService productService, UserManager<IdentityUser, Guid> userManager)
        {
            this._productService = productService;
            this._userManager = userManager;
        }

        public ActionResult Index()
        {
            var products = _productService.GetAllItems()
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
            var product = _productService.GetItem(productId);
            var model = AutoMapperConfiguration.Mapper.Map<ProductViewModel>(product);

            return View(model);
        }

        public ActionResult Buy(int productId, int colourId)
        {
            var model = new OrderViewModel() {
                Product = AutoMapperConfiguration.Mapper.Map<ProductPreviewModel>(_productService.GetItem(productId)),
                SelectedColourId = colourId
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Confirm(OrderViewModel model)
        {
            if (ModelState.IsValid) {
                var user = _userManager.Find(model.PhoneNumber, "Dummy!1");

                if(user == null)
                {
                    user = new IdentityUser()
                    {
                        UserName = model.PhoneNumber,
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    };

                    _userManager.Create(user, "Dummy!1");
                }

                var product = _productService.GetItem(model.Product.ID);
                var order = AutoMapperConfiguration.Mapper.Map<Order>(model);
                var orderItem = new OrderItem()
                {
                    Item = _productService.GetItem(model.Product.ID),
                    Quantity = model.Quantity,
                    SelectedColourID = model.SelectedColourId
                };

                order.Items.Add(orderItem);
                _orderService.AddItem(order, user.Id);
            }

            return View(model);
        }
    }
}