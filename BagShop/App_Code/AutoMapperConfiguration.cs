using AutoMapper;
using BagShop.Common.Entities;
using BagShop.Models;
using System.Linq;

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
                cfg.CreateMap<ShoppingItem, ProductPreviewModel>()
                .ForMember(
                    dest => dest.UrlColours, 
                    opt => opt.MapFrom(src => src.Colours.Select(c => c.PreviewImage))
                    );


            });

            _mapper = enterpriseConfig.CreateMapper();
        }
    }
}