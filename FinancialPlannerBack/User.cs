using System;

namespace FinancialPlannerBack
{
    public class User
    {
        public string Name { get; set; }
        public Credentials Credentials { get; private set; }

        public User(string name, string username, string password)
        {
            Name = name;
            Credentials = new Credentials
            {
                Username = username,
                Password = password
            };
        }

    }
}
