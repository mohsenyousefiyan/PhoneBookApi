using PhoneBook.Core.Entities.Dtos.BaseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entities.Dtos.GroupDtos.InputDtos
{
    public class GroupSelectDto: BaseSelectPagingDto
    {
        public string GroupName { get; set; }
    }
}
