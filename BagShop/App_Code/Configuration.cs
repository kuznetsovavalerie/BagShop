using System.Configuration;

namespace BagShop.App_Code
{
    public static class Configuration
    {
        public static string ProductsImageFolder {
            get {
                return ConfigurationManager.AppSettings["ProductsImageFolder"].ToString();
            }
        }

        public static string ColoursImageFolder
        {
            get
            {
                return ConfigurationManager.AppSettings["ColoursImageFolder"].ToString();
            }
        }

        public static string TitleImageName
        {
            get
            {
                return ConfigurationManager.AppSettings["TitleImageName"].ToString();
            }
        }
    }
}