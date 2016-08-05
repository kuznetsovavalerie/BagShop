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
        private static string dir = @"C:\Users\vkuznetsova\Documents\visual studio 2015\Projects\BagShop\BagShop\Content\img";

        public static IEnumerable<string> GetProductImageUrls(int id)
        {
            var dirInfo = new DirectoryInfo(dir);

            //var files = dirInfo.GetDirectories("products")[0].GetDirectories(id.ToString()).FirstOrDefault()?.GetFiles().Select(f => f.;
            return new List<string>();
        }
    }
}