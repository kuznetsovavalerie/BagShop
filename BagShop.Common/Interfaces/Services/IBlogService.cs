using BagShop.Common.Entities;
using System.Collections.Generic;

namespace BagShop.Common.Interfaces
{
    public interface IBlogService
    {
        IEnumerable<BlogPost> GetAllPosts();

        IEnumerable<BlogPost> GetLatestPosts();

        void CreatePost(BlogPost post);
    }
}
