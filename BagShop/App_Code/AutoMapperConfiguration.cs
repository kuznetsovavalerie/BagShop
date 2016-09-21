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
                    dest => dest.TitleImage,
                    opt => opt.MapFrom(src => string.Join(
                        @"/", 
                        Configuration.ProductsImageFolder, 
                        src.ID.ToString(), 
                        Configuration.TitleImageName)))
                .ForMember(
                    dest => dest.Colours, 
                    opt => opt.MapFrom(src => src.Colours.Select(c => 
                    new ColourPreviewModel()
                    {
                        ID = c.ID,
                        Name = c.Preview.Name,
                        PreviewImage = string.Concat(Configuration.ColoursImageFolder, @"/", c.Preview.ID.ToString(), ".jpg")
                    }))
                    );
                
                cfg.CreateMap<ShoppingItem, ProductViewModel>()
                .ForMember(
                    dest => dest.Colours,
                    opt => opt.MapFrom(si => si.Colours
                    .Select(c => new ColourViewModel()
                    {
                        ID = c.ID,
                        Name = c.Preview.Name,
                        Images = c.Photos.Select(p => 
                            string.Join(
                                @"/", 
                                Configuration.ProductsImageFolder, 
                                si.ID.ToString(), c.ID.ToString(), 
                                p.ID.ToString() + ".jpg"
                                )),
                        PreviewImage = string.Concat(Configuration.ColoursImageFolder, @"/", c.Preview.ID.ToString(), ".jpg")
                    }))
                    )
                .ForMember(
                    dest => dest.TitleImage,
                    opt => opt.MapFrom(src => string.Join(
                        @"/",
                        Configuration.ProductsImageFolder,
                        src.ID.ToString(),
                        Configuration.TitleImageName)));

                cfg.CreateMap<OrderViewModel, Order>()
                .ForMember(
                    dest => dest.DeliveryAddress,
                    opt => opt.MapFrom(src => src.Address));

            });

            _mapper = enterpriseConfig.CreateMapper();
        }
    }
}