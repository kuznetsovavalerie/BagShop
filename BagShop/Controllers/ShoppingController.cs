using BagShop.App_Code;
using BagShop.Common.Interfaces;
using BagShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BagShop.Controllers
{
    public class ShoppingController : ApiController
    {
        private IProductService productService;

        public ShoppingController(IProductService productService)
        {
            this.productService = productService;
        }

        //// GET: api/Shopping
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Shopping/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        public IEnumerable<ProductViewModel> GetProducts()
        {
            var result = productService.GetAllItems();
            var products = result.Select(p => AutoMapperConfiguration.Mapper.Map<ProductViewModel>(p));

            return products;
        }

        // POST: api/Shopping
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Shopping/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Shopping/5
        public void Delete(int id)
        {
        }
    }
}
