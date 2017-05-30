namespace SparesBase
{
    public class Account
    {
        public Account(int id, string firstName, string lastName, string secondName, string login, string city, string phone, string email, bool admin, Organization organization)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            SecondName = secondName;
            Login = login;
            City = city;
            Phone = phone;
            Email = email;
            Admin = admin;
            Organization = organization;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }

        public string Login { get; set; }

        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public bool Admin { get; set; }

        public Organization Organization { get; set; }
    }
}
