using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneBook.Core.Entities.Dtos.ContactPhoneNumbersDto.InputDtos
{
    public class ContactPhoneNumbersAddDto
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public byte PhoneNumberTypeId { get; set; }
    }
}
