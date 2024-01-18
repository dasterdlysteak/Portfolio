using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02
{
    public class Address
    {
        public string Number { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }

        public Address(string number, string street, string suburb, string postcode, string state)
        {
            this.Number = number;
            this.Street = street;
            this.Suburb = suburb;
            this.Postcode = postcode;
            this.State = state;
        }

    }
}
