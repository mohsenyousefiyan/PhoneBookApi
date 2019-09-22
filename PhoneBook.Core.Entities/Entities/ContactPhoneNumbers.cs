using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entities.Entities
{
    public class ContactPhoneNumbers
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public byte PhoneNumberTypeId { get; set; }
        public PhoneNymberType PhoneNymberType { get; set; }
        public string PhoneNumber { get; set; }
    }
}
