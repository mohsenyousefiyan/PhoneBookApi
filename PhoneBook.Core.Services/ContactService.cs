using PhoneBook.Core.Contracts.Repository;
using PhoneBook.Core.Contracts.Service;
using PhoneBook.Core.Entities.Dtos.BaseDtos;
using PhoneBook.Core.Entities.Dtos.ContactDtos.InputDtos;
using PhoneBook.Core.Entities.Dtos.ContactDtos.OutPutDtos;
using PhoneBook.Core.Entities.Dtos.ContactPhoneNumbersDto.InputDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository contactRepository;
        private readonly IGroupRepository groupRepository;

        public ContactService(IContactRepository contactRepository,IGroupRepository groupRepository)
        {
            this.contactRepository = contactRepository;
            this.groupRepository = groupRepository;
        }

        public async Task<BaseResultCRUDDto<OutPut_ContactDto>> CreateContact(ContactAddDto addedmodel)
        {
            if (await contactRepository.GetByContactFullName(addedmodel.FirstName+" "+addedmodel.LastName) != null)
                return new BaseResultCRUDDto<OutPut_ContactDto>() { ErrorMessage = "نام مخاطب از قبل به ثبت رسیده است " };

            return await contactRepository.Addcontact(addedmodel);                       
        }

        public async Task<BaseOutPutDto> DeleteContact(int id)
        {
            return await contactRepository.DeleteContact(id);
        }
        public async Task<BaseOutPutDto> DeletePhoneNumber(int id)
        {
            return await contactRepository.DeletePhoneNumber(id);
        }

        public async Task<BaseResultCRUDDto<OutPut_ContactDto>> EditContact(ContactUpdateDto editmodel)
        {
            var findobject = await contactRepository.GetByContactFullName(editmodel.FirstName+" "+editmodel.LastName);
            if (findobject != null && findobject.Id != editmodel.Id)
                return new BaseResultCRUDDto<OutPut_ContactDto>() { ErrorMessage = "نام مخاطب از قبل به ثبت رسیده است " };

            return await contactRepository.UpdateContact(editmodel);
        }

        public async Task<OutPut_ContactDto> GetById(int id)
        {
            return await contactRepository.GetById(id);
        }

        public async Task<List<OutPut_ContactDto>> SearchContact(ContactSelectDto selectmodel)
        {
            return await contactRepository.GetContactList(selectmodel);
        }
    }
}
