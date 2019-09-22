using PhoneBook.Core.Entities.Dtos.BaseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entities.Dtos.ContactPhoneNumbersDto.InputDtos
{
    public class ContactSelectDto: BaseSelectPagingDto
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }        
    }
}
