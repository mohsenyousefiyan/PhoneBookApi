using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entities.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string WebSite { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<ContactPhoneNumbers> ContactPhoneNumbers { get; private set; }
        public List<ContactGroup> ContactGroups { get;private set; }
    }
}
