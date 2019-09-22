using PhoneBook.Core.Entities.Dtos.BaseDtos;
using PhoneBook.Core.Entities.Dtos.ContactDtos.InputDtos;
using PhoneBook.Core.Entities.Dtos.ContactDtos.OutPutDtos;
using PhoneBook.Core.Entities.Dtos.ContactPhoneNumbersDto.InputDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Contracts.Repository
{
    public interface IContactRepository
    {
        Task<BaseResultCRUDDto<OutPut_ContactDto>> Addcontact(ContactAddDto addedmodel);
        Task<BaseResultCRUDDto<OutPut_ContactDto>> UpdateContact(ContactUpdateDto editmodel);
        Task<BaseOutPutDto> DeleteContact(int id);

        Task<BaseOutPutDto> DeletePhoneNumber(int id);

        Task<OutPut_ContactDto> GetById(int id);
        Task<List<OutPut_ContactDto>> GetContactList(ContactSelectDto selectmodel);
        Task<OutPut_ContactDto> GetByContactFullName(string contactfullname);
    }
}
