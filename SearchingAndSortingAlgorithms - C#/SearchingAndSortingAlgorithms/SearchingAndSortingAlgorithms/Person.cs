using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string TelNum { get; set; }
        public Address Address { get; set; }

        public Person(string name, string email, string telnum, string number, 
            string street, string suburb, string postcode, string state)
        {
            Name = name;
            Email = email;
            TelNum = telnum;
            Address address = new Address(number, street, suburb, postcode, state);
        }

        public abstract void displayPerson();

    }
}
