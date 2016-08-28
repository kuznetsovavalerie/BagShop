using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BagShop.App_Code
{
    public static class ImageHelper
    {
        private static string productsImageDir = @"C:\Users\vkuznetsova\Documents\visual studio 2015\Projects\BagShop\BagShop\Content\img\products\";
        private static string coloursImageDir = @"C:\Users\vkuznetsova\Documents\visual studio 2015\Projects\BagShop\BagShop\Content\img\colours\";
        private static string titleImageName = @"title.jpg";

        public static IEnumerable<string> GetColourImageUrls(int productId, int colourId)
        {
            var dirInfo = new DirectoryInfo(productsImageDir);

            var files = dirInfo.GetDirectories(productId.ToString())
                .FirstOrDefault()?
                .GetDirectories(productId.ToString())
                .FirstOrDefault()?
                .GetFiles()
                .Select(f => f.Name);

            return new List<string>();
        }

        public static string GetProductTitleImageUrl(int id)
        {
            var url = string.Concat(productsImageDir, titleImageName);
            
            return url;
        }

        public static string GetColourPreviewImageUrl(int id)
        {
            var url = string.Concat(productsImageDir, id.ToString(), ".jpg");
            
            return url;
        }
    }
}