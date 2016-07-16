using BagShop.App_Code;
using BagShop.Common.Interfaces;
using BagShop.Models;
using System.Linq;
using System.Web.Mvc;

namespace BagShop.Controllers
{
    public class BlogController : Controller
    {
        private IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        // GET: Blog
        public ActionResult Index()
        {
            var posts = blogService.GetAllPosts().Select(bp => AutoMapperConfiguration.Mapper.Map<BlogPostPreviewModel>(bp));

            return View("Index", posts);
        }
    }
}