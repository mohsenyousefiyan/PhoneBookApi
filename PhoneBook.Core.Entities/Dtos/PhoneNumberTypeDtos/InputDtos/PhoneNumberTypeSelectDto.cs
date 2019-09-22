using PhoneBook.Core.Entities.Dtos.BaseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entities.Dtos.PhoneNumberTypeDtos.InputDtos
{
    public class PhoneNumberTypeSelectDto:BaseSelectPagingDto
    {
        public string  PhoneNumberTypeName { get; set; }
    }
}
