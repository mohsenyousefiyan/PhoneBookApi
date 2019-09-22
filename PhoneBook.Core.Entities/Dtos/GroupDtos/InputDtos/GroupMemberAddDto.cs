using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entities.Dtos.GroupDtos.InputDtos
{
   public class GroupMemberAddDto
    {
        public int GroupId { get; set; }
        public List<int> ContactIds { get; set; }
    }
}
