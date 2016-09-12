using System.Collections.Generic;
using System.Linq;

namespace BagShop.App_Code
{
    public static class ImageHelper
    {
        private static string productsImageDir = @"/Content/img/products";
        private static string coloursImageDir = @"/Content/img/colours";
        private static string titleImageName = @"title.jpg";

        public static IEnumerable<string> GetColourImageUrls(int productId, int colourId, IEnumerable<int> colourPhotos)
        {
            var urls = colourPhotos.Select(cp => string.Join(@"/", productsImageDir, productId.ToString(), colourId.ToString(), cp.ToString() + ".jpg"));

            return urls;
        }

        public static string GetProductTitleImageUrl(int id)
        {
            var url = string.Join(@"/", productsImageDir, id.ToString(), titleImageName);
            
            return url;
        }

        public static string GetColourPreviewImageUrl(int id)
        {
            var url = string.Concat(coloursImageDir, @"/", id.ToString(), ".jpg");
            
            return url;
        }
    }
}