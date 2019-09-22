using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneBook.Core.Entities.Dtos.GroupDtos.InputDtos
{
    public class GroupAddDto
    {
        [Required]
        public string GroupName { get; set; }
    }
}
