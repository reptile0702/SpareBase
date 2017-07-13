namespace SparesBase
{
    public class Seller
    {
        public Seller(
            int id, 
            string name, 
            string site, 
            string telephone, 
            string contactFirstName, 
            string contactLastName, 
            string contactSecondName,
            int organizationId,
            bool hidden)
        {
            Id = id;
            Name = name;
            Site = site;
            Telephone = telephone;
            ContactFirstName = contactFirstName;
            ContactLastName = contactLastName;
            ContactSecondName = contactSecondName;
            OrganizationId = organizationId;
            Hidden = hidden;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Site { get; set; }
        public string Telephone { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactSecondName { get; set; }
        public int OrganizationId { get; set; }
        public bool Hidden { get; set; }
    }
}
