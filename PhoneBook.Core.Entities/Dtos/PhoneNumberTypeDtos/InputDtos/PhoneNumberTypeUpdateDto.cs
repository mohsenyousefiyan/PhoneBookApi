using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Core.Entities.Dtos.PhoneNumberTypeDtos.InputDtos
{
    public class PhoneNumberTypeUpdateDto
    {
        [Required]
        public byte Id { get; set; }

        [Required]
        public string PhoneNumberTypeName { get; set; }
    }
}
