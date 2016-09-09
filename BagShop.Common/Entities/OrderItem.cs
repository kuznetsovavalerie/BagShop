namespace BagShop.Common.Entities
{
    public class OrderItem
    {
        public int ID { get; set; }

        public ShoppingItem Item { get; set; }

        public int Quantity { get; set; }

        public int SelectedColourID { get; set; }

        public Colour SelectedColour { get; set; }
    }
}
