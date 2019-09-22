using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneBook.Core.Entities.Dtos.PhoneNumberTypeDtos.InputDtos
{
    public class PhoneNumberTypeAddDto
    {        
        [Required]
        public string PhoneNumberTypeName { get; set; }
    }
}
