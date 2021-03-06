﻿namespace SparesBase
{
    public class Account
    {
        public Account(
            int id, 
            string firstName, 
            string lastName, 
            string secondName, 
            string login,
            Organization organization,
            string city, 
            string phone, 
            string email, 
            bool admin)
        {
            Id = id;

            FirstName = firstName;
            LastName = lastName;
            SecondName = secondName;

            Login = login;

            Organization = organization;

            City = city;
            Phone = phone;
            Email = email;

            Admin = admin;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }

        public string Login { get; set; }

        public Organization Organization { get; set; }

        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public bool Admin { get; set; }
    }
}
