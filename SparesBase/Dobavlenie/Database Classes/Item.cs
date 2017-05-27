namespace SparesBase
{
    class Item
    {
        public int MainCategoryID { get; set; }
        public int SubCategory1ID { get; set; }
        public int SubCategory2ID { get; set; }
        public int SubCategory3ID { get; set; }
        public int SubCategory4ID { get; set; }

        public string ItemName { get; set; }
        public int SellerID { get; set; }
        public float PurchasePrice { get; set; }
        public float RetailPrice { get; set; }
        public float WholesalePrice { get; set; }
        public float ServicePrice { get; set; }
        public string Storage { get; set; }
        public string Note { get; set; }
        public int Quantuty { get; set; }

        public Item(int main, int sub1, int sub2, int sub3, int sub4, string name, int seller, float purchase, float retail, float whole, float service, string storage, string note, int quantity)
        {
            this.MainCategoryID = main;
            this.SubCategory1ID = sub1;
            this.SubCategory2ID = sub2;
            this.SubCategory3ID = sub3;
            this.SubCategory4ID = sub4;

            this.ItemName = name;
            this.SellerID = seller;
            this.PurchasePrice = purchase;
            this.RetailPrice = retail;
            this.WholesalePrice = whole;
            this.ServicePrice = service;
            this.Storage = storage;
            this.Note = note;
            this.Quantuty = quantity;
        }
    }
}
