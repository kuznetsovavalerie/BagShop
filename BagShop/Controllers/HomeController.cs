using BagShop.App_Code;
using BagShop.BLL.Services;
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
        private IUserService _userService;

        public HomeController(IProductService productService, 
            UserManager<IdentityUser, Guid> userManager, 
            IOrderService orderService,
            IUserService userService)
        {
            this._productService = productService;
            this._userManager = userManager;
            this._orderService = orderService;
            this._userService = userService;
        }

        public ActionResult Index()
        {
            var products = _productService.GetAllItems();
            var model = products
                .Select(p => AutoMapperConfiguration.Mapper.Map<ProductPreviewModel>(p));

            return View(model);
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
            var model = new OrderViewModel()
            {
                Product = AutoMapperConfiguration.Mapper.Map<ProductPreviewModel>(_productService.GetItem(productId)),
                SelectedColourId = colourId
            };

            return View(model);
        }

        public ActionResult DeliveryDetails()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Confirm(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Success = false });
            }

            var user = _userManager.Find(model.PhoneNumber, "Dummy!1");

            if (user == null)
            {
                user = new IdentityUser()
                {
                    UserName = model.PhoneNumber,
                };

                _userManager.Create(user, "Dummy!1");
            }


            var entityUser = _userService.Get(user.Id);

            entityUser.FirstName = model.FirstName;
            entityUser.LastName = model.LastName;
            entityUser.Address = model.Address;

            _userService.Update(entityUser);

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

            MailService.SendOrderInformation(order);

            return Json(new { Success = true });
        }
    }
}