namespace SparesBase
{
    class Item
    {
        public int Id { get; set; }
        public int MainCategoryID { get; set; }
        public int SubCategory1ID { get; set; }
        public int SubCategory2ID { get; set; }
        public int SubCategory3ID { get; set; }
        public int SubCategory4ID { get; set; }

        public string ItemName { get; set; }
        public int SellerID { get; set; }
        public string PurchasePrice { get; set; }
        public string RetailPrice { get; set; }
        public string WholesalePrice { get; set; }
        public string ServicePrice { get; set; }
        public string Storage { get; set; }
        public string Note { get; set; }
        public int Quantuty { get; set; }
        public string FirmPrice { get; set; }
        public int Residue { get; set; }
        public int OrganizationId { get; set; }
        public bool SearchAllowed { get; set; }

        public Item(int id, int main, int sub1, int sub2, int sub3, int sub4, string name, int seller, string purchase, string retail, string whole, string service, string storage, string note, int quantity, string firmPrice, int residue, int organizationId, bool searchAllowed)
        {
            this.Id = id;
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
            this.FirmPrice = firmPrice;
            this.Residue = residue;
            this.OrganizationId = organizationId;
            this.SearchAllowed = searchAllowed;
        }

        public Item(object[] fields)
       {
            this.Id = int.Parse(fields[0].ToString());
            this.MainCategoryID = int.Parse(fields[1].ToString());
            this.SubCategory1ID = int.Parse(fields[2].ToString());
            this.SubCategory2ID = int.Parse(fields[3].ToString());
            this.SubCategory3ID = int.Parse(fields[4].ToString());
            this.SubCategory4ID = int.Parse(fields[5].ToString());

            this.ItemName = fields[6].ToString();
            this.SellerID = int.Parse(fields[7].ToString());
            this.PurchasePrice = fields[8].ToString();
            this.RetailPrice = fields[9].ToString();
            this.WholesalePrice = fields[10].ToString();
            this.ServicePrice = fields[11].ToString();
            this.Storage = fields[13].ToString();
            this.Note = fields[14].ToString();
            this.Quantuty = int.Parse(fields[15].ToString());
            this.FirmPrice = fields[12].ToString();
            this.Residue = int.Parse(fields[17].ToString());
            this.OrganizationId = int.Parse(fields[18].ToString());
            this.SearchAllowed = fields[19].ToString() == "1" ? true : false;

        }
    }
}
