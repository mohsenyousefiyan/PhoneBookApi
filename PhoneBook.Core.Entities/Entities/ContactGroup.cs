using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entities.Entities
{
    public class ContactGroup
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
