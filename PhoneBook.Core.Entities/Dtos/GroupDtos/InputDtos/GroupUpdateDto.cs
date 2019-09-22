using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneBook.Core.Entities.Dtos.GroupDtos.InputDtos
{
   public class GroupUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string GroupName { get; set; }
    }
}
