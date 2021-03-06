﻿using BagShop.Common.Entities;
using BagShop.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BagShop.BLL.Services
{
    public class BlogService : BaseService, IBlogService
    {
        public BlogService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public IEnumerable<BlogPost> GetAllPosts()
        {
            return unitOfWork.BlogPostRepository.GetAll();
        }

        public IEnumerable<BlogPost> GetLatestPosts()
        {
            return unitOfWork.BlogPostRepository.GetAll().Take(2);
        }

        public void CreatePost(BlogPost post)
        {
            unitOfWork.BlogPostRepository.Add(post);
            unitOfWork.SaveChanges();
        }
    }
}
