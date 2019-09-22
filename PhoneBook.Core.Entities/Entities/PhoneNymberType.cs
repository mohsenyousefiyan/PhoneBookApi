using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entities.Entities
{
   public class PhoneNymberType
    {
        public byte Id { get; set; }
        public string PhoneNymberTypeName { get; set; }

        public List<ContactPhoneNumbers> ContactPhoneNumbers { get; private set; }
    }
}
