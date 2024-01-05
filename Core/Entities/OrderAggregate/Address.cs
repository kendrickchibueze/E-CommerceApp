using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregate
{
    public class Address
    {

        public Address()
        { 

        }



        //This allows us populate the field when we create a new instance of our order with the address
        public Address(string firstName, string lastName, string street,
            string city, string state, string zipcode)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            State = state;
            Zipcode = zipcode;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    }
    //its not going to have an Id because it is owned by our order and hence live 
    //on the same row in our table as our  order itself. Its not going to be related to our order anyway
    //other than the fact that our order owns it
}
