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

                cfg.CreateMap<Colour, ColourViewModel>().ForMember(
                    dest => dest.Images,
                    opt => opt.MapFrom(src => ImageHelper.GetProductImageUrls(src.ID))
                    );
                cfg.CreateMap<ShoppingItem, ProductViewModel>()
                .ForMember(
                    dest => dest.Colours,
                    opt => opt.MapFrom(si => si.Colours.Select(c => Mapper.Map<Colour, ColourViewModel>(c)))
                    );

            });

            _mapper = enterpriseConfig.CreateMapper();
        }
    }
}