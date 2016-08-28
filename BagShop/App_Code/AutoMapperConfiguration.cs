﻿using AutoMapper;
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
                    opt => opt.MapFrom(src => ImageHelper.GetProductTitleImageUrl(src.ID))
                    )
                .ForMember(
                    dest => dest.ColourUrls, 
                    opt => opt.MapFrom(src => src.Colours.Select(c => ImageHelper.GetColourPreviewImageUrl(c.ID)))
                    );
                
                cfg.CreateMap<ShoppingItem, ProductViewModel>()
                .ForMember(
                    dest => dest.Colours,
                    opt => opt.MapFrom(si => si.Colours.Select(c => new ColourViewModel()
                    {
                        ID = c.ID,
                        Name = c.Name,
                        Images = ImageHelper.GetColourImageUrls(si.ID, c.ID),
                        PreviewImage = ImageHelper.GetColourPreviewImageUrl(c.ID)
                    }))
                    );

            });

            _mapper = enterpriseConfig.CreateMapper();
        }
    }
}