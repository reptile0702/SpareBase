namespace SparesBase
{
    public class Defect
    {
        public Defect(
            int id,
            int quantity,
            string whoIndetified,
            string note,
            int itemId)
        {
            Id = id;
            Quantity = quantity;
            WhoIndetified = whoIndetified;
            Note = note;
            ItemId = itemId;
        }

        public int Id { get; set; }
        public int Quantity { get; set; }
        public string WhoIndetified { get; set; }
        public string Note { get; set; }
        public int ItemId { get; set; }
    }
}
