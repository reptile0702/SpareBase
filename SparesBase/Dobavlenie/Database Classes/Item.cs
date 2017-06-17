namespace SparesBase
{
    public class Item
    {
        public Item(
            int id,
            Category mainCategory,
            Category subCategory1,
            Category subCategory2,
            Category subCategory3,
            Category subCategory4,
            string name,
            Seller seller,
            string purchasePrice,
            string retailPrice,
            string wholesalePrice,
            string servicePrice,
            string firmPrice,
            string storage,
            string note,
            int quantity,
            int residue,
            System.DateTime uploadDate,
            System.DateTime changeDate,
            Organization organization,
            bool searchAllowed,
            string status)
        {
            Id = id;

            MainCategory = mainCategory;
            SubCategory1 = subCategory1;
            SubCategory2 = subCategory2;
            SubCategory3 = subCategory3;
            SubCategory4 = subCategory4;

            Name = name;
            Seller = seller;

            PurchasePrice = purchasePrice;
            RetailPrice = retailPrice;
            WholesalePrice = wholesalePrice;
            ServicePrice = servicePrice;
            FirmPrice = firmPrice;

            Storage = storage;
            Note = note;

            Quantity = quantity;
            Residue = residue;

            UploadDate = uploadDate;
            ChangeDate = changeDate;

            Organization = organization;

            SearchAllowed = searchAllowed;

            Status = status;
        }

        public int Id { get; set; }

        public Category MainCategory { get; set; }
        public Category SubCategory1 { get; set; }
        public Category SubCategory2 { get; set; }
        public Category SubCategory3 { get; set; }
        public Category SubCategory4 { get; set; }

        public string Name { get; set; }
        public Seller Seller { get; set; }

        public string PurchasePrice { get; set; }
        public string RetailPrice { get; set; }
        public string WholesalePrice { get; set; }
        public string ServicePrice { get; set; }
        public string FirmPrice { get; set; }

        public string Storage { get; set; }
        public string Note { get; set; }

        public int Quantity { get; set; }
        public int Residue { get; set; }

        public System.DateTime UploadDate { get; set; }
        public System.DateTime ChangeDate { get; set; }

        public Organization Organization { get; set; }

        public bool SearchAllowed { get; set; }

        public string Status { get; set; }
    }
}
