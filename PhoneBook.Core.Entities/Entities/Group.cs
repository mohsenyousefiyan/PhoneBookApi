using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entities.Entities
{
   public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }

        public List<ContactGroup> ContactGroups { get;private set; }
    }
}
