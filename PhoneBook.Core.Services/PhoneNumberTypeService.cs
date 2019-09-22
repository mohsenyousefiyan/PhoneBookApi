using PhoneBook.Core.Contracts.Repository;
using PhoneBook.Core.Contracts.Service;
using PhoneBook.Core.Entities.Dtos.BaseDtos;
using PhoneBook.Core.Entities.Dtos.PhoneNumberTypeDtos.InputDtos;
using PhoneBook.Core.Entities.Dtos.PhoneNumberTypeDtos.OutPutDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Services
{
    public class PhoneNumberTypeService : IPhoneNumberTypeService
    {
        private readonly IPhoneNumberTypeRepository phoneNumberTypeRepository;

        public PhoneNumberTypeService(IPhoneNumberTypeRepository phoneNumberTypeRepository)
        {
            this.phoneNumberTypeRepository = phoneNumberTypeRepository;
        }

        public async Task<BaseResultCRUDDto<OutPut_PhoneNumberTypeDto>> CreatePhoneNumberType(PhoneNumberTypeAddDto addedmodel)
        {
            if (await phoneNumberTypeRepository.GetByPhoneNumberTypeName(addedmodel.PhoneNumberTypeName) != null)
                return new BaseResultCRUDDto<OutPut_PhoneNumberTypeDto>() { ErrorMessage = "عنوان نوعتلفن از قبل به ثبت رسیده است " };

            return await phoneNumberTypeRepository.AddPhoneNumberType(addedmodel);
        }
       
        public async Task<BaseResultCRUDDto<OutPut_PhoneNumberTypeDto>> EditPhoneNumberType(PhoneNumberTypeUpdateDto editmodel)
        {
            var findobject = await phoneNumberTypeRepository.GetByPhoneNumberTypeName(editmodel.PhoneNumberTypeName);
            if (findobject != null && findobject.Id != editmodel.Id)
                return new BaseResultCRUDDto<OutPut_PhoneNumberTypeDto>() { ErrorMessage = "عنوان نوعتلفن از قبل به ثبت رسیده است " };

            return await phoneNumberTypeRepository.UpdatePhoneNumberType(editmodel);
        }

        public async Task<BaseOutPutDto> DeletePhoneNumberType(int id)
        {
            return await phoneNumberTypeRepository.DeletePhoneNumberType(id);
        }

        public async Task<OutPut_PhoneNumberTypeDto> GetById(int id)
        {
            return await phoneNumberTypeRepository.GetById(id);
        }

        public async Task<List<OutPut_PhoneNumberTypeDto>> SearchPhoneNumberTyp(PhoneNumberTypeSelectDto selectmodel)
        {
            return await phoneNumberTypeRepository.GetPhoneNumberTypList(selectmodel);
        }
       
    }
}
