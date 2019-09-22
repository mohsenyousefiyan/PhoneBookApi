using PhoneBook.Core.Entities.Dtos.BaseDtos;
using PhoneBook.Core.Entities.Dtos.ContactDtos.InputDtos;
using PhoneBook.Core.Entities.Dtos.ContactDtos.OutPutDtos;
using PhoneBook.Core.Entities.Dtos.ContactPhoneNumbersDto.InputDtos;
using PhoneBook.Core.Entities.Dtos.GroupDtos.InputDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Contracts.Service
{
    public interface IContactService
    {
        Task<BaseResultCRUDDto<OutPut_ContactDto>> CreateContact(ContactAddDto addedmodel);
        Task<BaseResultCRUDDto<OutPut_ContactDto>> EditContact(ContactUpdateDto editmodel);
        Task<BaseOutPutDto> DeleteContact(int id);
        Task<BaseOutPutDto> DeletePhoneNumber(int id);
        
        Task<OutPut_ContactDto> GetById(int id);
        Task<List<OutPut_ContactDto>> SearchContact(ContactSelectDto selectmodel);
    }
}
