using PhoneBook.Core.Entities.Dtos.ContactPhoneNumbersDto.InputDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneBook.Core.Entities.Dtos.ContactDtos.InputDtos
{
    public class ContactUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string CompanyName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string WebSite { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<ContactPhoneNumbersAddDto> ContactPhoneNumbers { get; set; }
    }
}
