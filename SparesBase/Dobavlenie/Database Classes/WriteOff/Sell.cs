namespace SparesBase
{
    public class Sell
    {
        public Sell(
            int id,
            int quantity,
            int price,
            int itemId)
        {
            Id = id;
            Quantity = quantity;
            Price = price;
            ItemId = itemId;
        }

        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int ItemId { get; set; }
    }
}
