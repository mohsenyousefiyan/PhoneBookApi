using PhoneBook.Core.Entities.Dtos.ContactPhoneNumbersDto.OutPutDtos;
using PhoneBook.Core.Entities.Dtos.GroupDtos.OutPutDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entities.Dtos.ContactDtos.OutPutDtos
{
    public class OutPut_ContactDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string WebSite { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<OutPut_GroupDto> Groups { get; set; }
        public List<OutPut_ContactPhoneNumbersDto> ContactPhoneNumbers  { get; set; }
    }
}
