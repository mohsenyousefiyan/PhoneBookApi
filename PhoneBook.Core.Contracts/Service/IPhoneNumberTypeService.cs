using PhoneBook.Core.Entities.Dtos.BaseDtos;
using PhoneBook.Core.Entities.Dtos.PhoneNumberTypeDtos.InputDtos;
using PhoneBook.Core.Entities.Dtos.PhoneNumberTypeDtos.OutPutDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Contracts.Service
{
   public interface IPhoneNumberTypeService
    {
        Task<BaseResultCRUDDto<OutPut_PhoneNumberTypeDto>> CreatePhoneNumberType(PhoneNumberTypeAddDto addedmodel);
        Task<BaseResultCRUDDto<OutPut_PhoneNumberTypeDto>> EditPhoneNumberType(PhoneNumberTypeUpdateDto editmodel);
        Task<BaseOutPutDto> DeletePhoneNumberType(int id);

        Task<OutPut_PhoneNumberTypeDto> GetById(int id);
        Task<List<OutPut_PhoneNumberTypeDto>> SearchPhoneNumberTyp(PhoneNumberTypeSelectDto selectmodel);
    }
}
