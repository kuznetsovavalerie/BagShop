using System.ComponentModel.DataAnnotations;

namespace BagShop.Models
{
    public class OrderViewModel
    {
        public ProductPreviewModel Product { get; set; }

        [Required]
        public int SelectedColourId { get; set; }
        
        [Required]
        [RegularExpression("^[a-zA-Z␣]{1,30}$")]
        public string FirstName { get; set; }
        
        [Required]
        [RegularExpression("^[a-zA-Z␣]{1,30}$")]
        public string LastName { get; set; }
        
        [Required]
        [RegularExpression("^[0-9]{9}$")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}