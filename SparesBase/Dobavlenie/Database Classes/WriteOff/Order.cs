namespace SparesBase
{
    public class Order
    {
        public Order(
            int id,
            int numberOfOrder,
            int quantity,
            string firmPrice,
            string total,
            int itemId)
        {
            Id = id;
            NumberOfOrder = numberOfOrder;
            Quantity = quantity;
            FirmPrice = firmPrice;
            Total = total;
            ItemId = itemId;
        }

        public int Id { get; set; }
        public int NumberOfOrder { get; set; }
        public int Quantity { get; set; }
        public string FirmPrice { get; set; }
        public string Total { get; set; }
        public int ItemId { get; set; }
    }
}
