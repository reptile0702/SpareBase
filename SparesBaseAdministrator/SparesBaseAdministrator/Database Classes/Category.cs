namespace SparesBaseAdministrator
{
    public class Category
    {
        public Category(int id, string name, int previousCategoryId, int organizationId)
        {
            Id = id;
            Name = name;
            PreviousCategoryId = previousCategoryId;
            OrganizationId = organizationId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int PreviousCategoryId { get; set; }
        public int OrganizationId { get; set; }
    }
}
