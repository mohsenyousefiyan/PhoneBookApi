using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entities.Dtos.ContactPhoneNumbersDto.OutPutDtos
{
    public class OutPut_ContactPhoneNumbersDto
    {
        public int Id { get; set; }
        public byte PhoneNumberTypeId { get; set; }
        public string PhoneNumberTypeName { get; set; }
        public string PhoneNumber { get; set; }      
    }
}
