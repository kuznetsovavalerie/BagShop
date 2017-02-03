using BagShop.App_Code;
using BagShop.Common.Interfaces;
using BagShop.Common.Interfaces.Services;
using BagShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BagShop.Controllers
{
    public class DashboardController : ApiController
    {
        private IProductService _productService;
        private IOrderService _orderService;
        private IUserService _userService;
        private IMailService _mailService;

        public DashboardController(IProductService productService,
            IOrderService orderService,
            IUserService userService,
            IMailService mailService)
        {
            this._productService = productService;
            this._orderService = orderService;
            this._userService = userService;
            this._mailService = mailService;
        }

        public IEnumerable<ProductPreviewModel> GetProducts()
        {
            var products = _productService.GetAllItems();
            var model = products
                .Select(p => AutoMapperConfiguration.Mapper.Map<ProductPreviewModel>(p));

            return model;
        }

        public ProductViewModel GetProductDetails(int id)
        {
            var product = _productService.GetItem(id);
            var model = AutoMapperConfiguration.Mapper.Map<ProductViewModel>(product);

            return model;
        }
    }
}
