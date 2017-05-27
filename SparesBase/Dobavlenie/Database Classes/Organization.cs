namespace SparesBase
{
    public class Organization
    {
        public Organization(int id, string name, string site, string telephone, string city, Account admin)
        {
            Id = id;
            Name = name;
            Site = site;
            Telephone = telephone;
            City = city;
            Admin = admin;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Site { get; set; }
        public string Telephone { get; set; }
        public string City { get; set; }
        public Account Admin { get; set; }
    }
}
