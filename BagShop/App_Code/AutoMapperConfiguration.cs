using AutoMapper;
using BagShop.Common.Entities;
using BagShop.Models;

namespace BagShop.App_Code
{
    public static class AutoMapperConfiguration
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }

        public static void Init()
        {
            var enterpriseConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BlogPost, BlogPostPreviewModel>();
            });

            _mapper = enterpriseConfig.CreateMapper();
        }
    }
}